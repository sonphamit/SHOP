using AutoMapper;
using Infrastructure.Database;
using Infrastructure.Entities;
using Infrastructure.Extentions;
using Infrastructure.Models;
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

        public EmployeeService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task AddAsync(EmployeeRequestModel model)
        {
            var entity = _mapper.Map<Employee>(model);
            await _unitOfWork.EmployeeRepository.AddAsync(entity);
            SaveChanges();
        }

        public async Task DeleteAsync(string id)
        {
            var entity = await _unitOfWork.EmployeeRepository.FindByCondition(e => e.Id.Equals(id)).FirstOrDefaultAsync();
            _unitOfWork.EmployeeRepository.Delete(entity);
        }

        public async Task<IEnumerable<EmployeeResponseModel>> GetAllAsync()
        {
            var entities = await _unitOfWork.EmployeeRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<EmployeeResponseModel>>(entities).OrderBy(e => e.User.UserName);
        }

        public async Task<EmployeeResponseModel> GetByIdAsync(string id)
        {
            var entity = await _unitOfWork.EmployeeRepository.FindByCondition(e => e.Id.Equals(id)).FirstOrDefaultAsync();
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
            string keyword, string orderCol, string orderType, 
            int? userType, int? page = null, int? size = null)
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
                                || x.ApplicationUser.FirstName.ToLower().Contains(wordLower)
                                || x.ApplicationUser.MiddleName.ToLower().Contains(wordLower)
                                || x.ApplicationUser.LastName.ToLower().Contains(wordLower)
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

            if (userType.HasValue)
            {
                listPredicates.Add(x => (int)x.ApplicationUser.UserType == userType);
            }

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

        public async Task UpdateAsync(string id, EmployeeRequestModel  model)
        {
            if (!string.IsNullOrWhiteSpace(id))
            {
                var originEntity = await _unitOfWork.EmployeeRepository.FindByCondition(e => e.Id.Equals(model.Id)).FirstOrDefaultAsync();
                var entityUpdate = _mapper.Map(model, originEntity);
                entityUpdate.Id = model.Id;
                _unitOfWork.EmployeeRepository.Update(entityUpdate);
                SaveChanges();
                _unitOfWork.EmployeeRepository.Detach(entityUpdate);
            }
        }

    }
}
