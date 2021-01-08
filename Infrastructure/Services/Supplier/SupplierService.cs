using AutoMapper;
using Infrastructure.Database;
using Infrastructure.Entities;
using Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
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

        public async Task DeleteAsync(SupplierModel model)
        {
            var entity = await _unitOfWork.SupplierRepository.FindByCondition(cat => cat.Id.Equals(model.Id)).FirstOrDefaultAsync();
            _unitOfWork.SupplierRepository.Delete(entity);
        }

        public IEnumerable<SupplierModel> GetAll()
        {
            var entities = _unitOfWork.SupplierRepository.GetAll();
            return _mapper.Map<IEnumerable<SupplierModel>>(entities);
        }

        public async Task<IEnumerable<SupplierModel>> GetAllAsync()
        {
            var entities = await _unitOfWork.SupplierRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<SupplierModel>>(entities);
        }

        public async Task<SupplierModel> GetByIdAsync(string id)
        {
            var entity = await _unitOfWork.SupplierRepository.GetByIdAsync(id);
            return _mapper.Map<SupplierModel>(entity);
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
                //_unitOfWork.SupplierRepository.Detach(entityUpdate);
                _unitOfWork.SupplierRepository.Update(entityUpdate);
                SaveChanges();
                _unitOfWork.SupplierRepository.Detach(entityUpdate);
            }
        }

        public async Task UpdateAsync(string id, SupplierModel model)
        {
            if (!string.IsNullOrWhiteSpace(id))
            {
                var originEntity = _unitOfWork.SupplierRepository.FindByCondition(cat => cat.Id.Equals(model.Id)).FirstOrDefault();
                var entityUpdate = _mapper.Map(model, originEntity);
                entityUpdate.Id = model.Id;
                //_unitOfWork.SupplierRepository.Detach(entityUpdate);
                _unitOfWork.SupplierRepository.Update(entityUpdate);
                await SaveChangesAsync();
                _unitOfWork.SupplierRepository.Detach(entityUpdate);
            }
        }

    }
}
