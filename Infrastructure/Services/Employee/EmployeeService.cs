﻿using AutoMapper;
using Infrastructure.Database;
using Infrastructure.Entities;
using Infrastructure.Extentions;
using Infrastructure.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SharedCore.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly UserManager<ApplicationUser> _userManager;

        public EmployeeService(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            UserManager<ApplicationUser> userManager
            )
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _userManager = userManager;
        }

        public async Task AddAsync(EmployeeRequestModel model)
        {
            var entity = _mapper.Map<Employee>(model);
            entity.Id = CommonHelper.NewGuid();
            entity.CreatedAt = DateTime.Now;
            entity.UpdatedAt = DateTime.Now;

            entity.ApplicationUser.UserType = Enums.UserType.EMPLOYEE_TYPE;
            entity.ApplicationUser.Id = entity.Id;
            entity.ApplicationUser.EmailConfirmed = true;
            entity.ApplicationUser.PhoneNumberConfirmed = true;

            if (!string.IsNullOrWhiteSpace(model.Password))
            {
                var passwordHash = new PasswordHasher<ApplicationUser>();
                entity.ApplicationUser.PasswordHash = passwordHash.HashPassword(entity.ApplicationUser, model.Password);
            }


            entity.ApplicationUser.NormalizedEmail = entity.ApplicationUser.Email.ToUpperInvariant().Normalize();
            entity.ApplicationUser.NormalizedUserName = entity.ApplicationUser.UserName.ToUpperInvariant().Normalize();

            await _unitOfWork.EmployeeRepository.AddAsync(entity);
            SaveChanges();
            _unitOfWork.EmployeeRepository.Detach(entity);
            _unitOfWork.ApplicationUserRepository.Detach(entity.ApplicationUser);
        }

        public async Task<bool> IsExsistAsync(string userName)
        {
            bool isExist = true;
            var user = await _userManager.FindByNameAsync(userName);
            if (user is null)
            {
                isExist = false;
            }

            return isExist;
        }

        public async Task DeleteAsync(string id)
        {
            var entity = await _unitOfWork.EmployeeRepository.FindByCondition(e => e.Id.Equals(id)).FirstOrDefaultAsync();
            if (entity is not null)
            {
                var user = await _userManager.FindByIdAsync(entity.Id);
                if (user is not null)
                {
                    await _userManager.DeleteAsync(user);
                }
                _unitOfWork.EmployeeRepository.Delete(entity);
            }
            //await SaveChangesAsync();
        }

        public async Task<IEnumerable<EmployeeResponseModel>> GetAllAsync()
        {
            var entities = await _unitOfWork.EmployeeRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<EmployeeResponseModel>>(entities).OrderBy(e => e.ApplicationUser.UserName);
        }

        public async Task<EmployeeResponseModel> GetByIdAsync(string id)
        {
            var entity = await _unitOfWork.EmployeeRepository.FindByCondition(e => e.Id.Equals(id))
                .Include(x => x.ApplicationUser).FirstOrDefaultAsync();
            return _mapper.Map<EmployeeResponseModel>(entity);
        }

        public int SaveChanges()
        {
            return _unitOfWork.SaveChanges();
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _unitOfWork.SaveChangesAsync();
        }

        public async Task<Pagination<EmployeeResponseModel>> Search(
            string keyword, string orderCol, string orderType, int? page = null, int? size = null)
        {
            var listPredicates = new List<Expression<Func<Employee, bool>>>();
            Func<IQueryable<Employee>, IOrderedQueryable<Employee>> orderBy = null;
            if (!string.IsNullOrEmpty(keyword))
            {
                var keywords = keyword.Trim().Split(" ").ToList().Where(x => !string.IsNullOrEmpty(x));
                if (keywords.Any())
                {
                    foreach (var word in keywords)
                    {
                        var wordLower = word.ToLower();
                        listPredicates.Add(x => x.ApplicationUser.UserName.ToLower().Contains(wordLower)
                            || x.ApplicationUser.FullName.ToLower().Contains(wordLower)
                            || x.ApplicationUser.Email.ToLower().Contains(wordLower)
                            || x.ApplicationUser.PhoneNumber.ToLower().Contains(wordLower)
                        );
                    }
                }
            }
            else
            {
                listPredicates.Add(x => true);
            }

            listPredicates.Add(x => x.ApplicationUser.UserType == Enums.UserType.EMPLOYEE_TYPE);

            if (!string.IsNullOrEmpty(orderCol) && !string.IsNullOrEmpty(orderType))
            {
                orderBy = OrderByHelper.GetOrderBy<Employee>(orderCol, orderType.ToString());
            }
            else
            {
                orderBy = OrderByHelper.GetOrderBy<Employee>(nameof(Employee.ApplicationUser.UserName), "asc");
            }

            var query = _unitOfWork.EmployeeRepository.Query(listPredicates.Aggregate((a, b) => a.And(b)), orderBy);

            return await query.ToPagingAsync<Employee, EmployeeResponseModel>(_mapper, page, size, 0);
        }

        public async Task UpdateAsync(string id, EmployeeRequestModel model)
        {
            if (!string.IsNullOrWhiteSpace(id))
            {
                var originEntity = await _unitOfWork.EmployeeRepository.FindByCondition(e => e.Id.Equals(model.Id))
                    .Include(x => x.ApplicationUser).FirstOrDefaultAsync();
                var entityUpdate = _mapper.Map(model, originEntity);
                //entityUpdate.Id = model.Id;

                if (!string.IsNullOrWhiteSpace(model.Password))
                {
                    var passwordHash = new PasswordHasher<ApplicationUser>();
                    entityUpdate.ApplicationUser.PasswordHash = passwordHash.HashPassword(entityUpdate.ApplicationUser, model.Password);
                }

                entityUpdate.ApplicationUser.NormalizedEmail = entityUpdate.ApplicationUser.Email.ToUpperInvariant().Normalize();
                entityUpdate.ApplicationUser.NormalizedUserName = entityUpdate.ApplicationUser.UserName.ToUpperInvariant().Normalize();

                entityUpdate.UpdatedAt = DateTime.Now;

                _unitOfWork.EmployeeRepository.Update(entityUpdate);
                _unitOfWork.ApplicationUserRepository.Update(entityUpdate.ApplicationUser);
                //await _userManager.UpdateAsync(entityUpdate.ApplicationUser);
                SaveChanges();
                _unitOfWork.EmployeeRepository.Detach(entityUpdate);
                _unitOfWork.ApplicationUserRepository.Detach(entityUpdate.ApplicationUser);
                //_unitOfWork.Detach(entityUpdate.ApplicationUser);
                
                
            }
        }

    }
}
