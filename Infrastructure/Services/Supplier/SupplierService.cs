using AutoMapper;
using Infrastructure.Database;
using Infrastructure.Entities;
using Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class SupplierService : ISupplierService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public SupplierService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task AddAsync(SupplierModel model)
        {
            var entity = _mapper.Map<Supplier>(model);
            await _unitOfWork.SupplierRepository.AddAsync(entity);
            SaveChanges();
            _unitOfWork.SupplierRepository.Detach(entity);
        }

        public async Task DeleteAsync(string id)
        {
            var entity = await _unitOfWork.SupplierRepository.FindByCondition(e => e.Id.Equals(id)).FirstOrDefaultAsync();
            _unitOfWork.SupplierRepository.Delete(entity);
        }

        public async Task<IEnumerable<SupplierModel>> GetAllAsync()
        {
            var entities = await _unitOfWork.SupplierRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<SupplierModel>>(entities).OrderBy(e => e.CompanyName);
        }

        public IEnumerable<SupplierModel> GetAll()
        {
            var entities = _unitOfWork.SupplierRepository.GetAll();
            return _mapper.Map<IEnumerable<SupplierModel>>(entities).OrderBy(e => e.CompanyName);
        }

        public async Task<SupplierModel> GetByIdAsync(string id)
        {
            var entity = await _unitOfWork.SupplierRepository.FindByCondition(e => e.Id.Equals(id)).FirstOrDefaultAsync();
            return _mapper.Map<SupplierModel>(entity);
        }

        public SupplierModel GetById(string id)
        {
            var entity = _unitOfWork.SupplierRepository.FindByCondition(e => e.Id.Equals(id)).FirstOrDefault();
            return _mapper.Map<SupplierModel>(entity);
        }

        public Task<IEnumerable<SupplierModel>> Pagination(Expression<Func<SupplierModel, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public int SaveChanges()
        {
            return _unitOfWork.SaveChanges();
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _unitOfWork.SaveChangesAsync();
        }

        public void Update(string id, SupplierModel model)
        {
            if (!string.IsNullOrWhiteSpace(id))
            {
                var originEntity = _unitOfWork.SupplierRepository.FindByCondition(cat => cat.Id.Equals(model.Id)).FirstOrDefault();
                var entityUpdate = _mapper.Map(model, originEntity);
                entityUpdate.Id = model.Id;
                _unitOfWork.SupplierRepository.Update(entityUpdate);
                SaveChanges();
                _unitOfWork.SupplierRepository.Detach(entityUpdate);
            }

        }
        public async Task<bool> UpdateAsync(string id, SupplierModel model)
        {
            if (!string.IsNullOrWhiteSpace(id))
            {
                var originEntity = _unitOfWork.SupplierRepository.FindByCondition(cat => cat.Id.Equals(model.Id)).FirstOrDefault();
                var entityUpdate = _mapper.Map(model, originEntity);
                entityUpdate.Id = model.Id;
                _unitOfWork.SupplierRepository.Update(entityUpdate);
                await SaveChangesAsync();
                _unitOfWork.SupplierRepository.Detach(entityUpdate);
                return true;
            }
            return false;
        }
    }
}
