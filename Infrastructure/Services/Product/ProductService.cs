using AutoMapper;
using Infrastructure.Database;
using Infrastructure.Entities;
using Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class ProductService : IProductService
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ProductService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task AddAsync(ProductModel model)
        {
            //model.CategoryId = model.Category.Id;
            var entity = _mapper.Map<Product>(model);
            await _unitOfWork.ProductRepository.AddAsync(entity);
            await _unitOfWork.ResourceRepository.AddRangeAsync(entity.Images);
            SaveChanges();
            _unitOfWork.ProductRepository.Detach(entity);
        }

        public Task AddRangeAsync(IEnumerable<ProductModel> models)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteAsync(ProductModel model)
        {
            var entity = await _unitOfWork.ProductRepository.FindByCondition(cat => cat.Id.Equals(model.Id)).FirstOrDefaultAsync();
            _unitOfWork.ProductRepository.Delete(entity);
        }

        public async Task<IEnumerable<ProductModel>> GetAllAsync()
        {
            var entities = await _unitOfWork.ProductRepository.DbSet.Include(item => item.Category).Include(item => item.Supplier).AsNoTracking().ToListAsync();
            return _mapper.Map<IEnumerable<ProductModel>>(entities);
        }

        public IEnumerable<ProductModel> GetAll()
        {
            var entities = _unitOfWork.ProductRepository.GetAll();
            return _mapper.Map<IEnumerable<ProductModel>>(entities);
        }

        public async Task<ProductModel> GetByIdAsync(string id)
        {
            var entity = await _unitOfWork.ProductRepository.GetByIdAsync(id);
            return _mapper.Map<ProductModel>(entity);
        }

        public Task<IEnumerable<ProductModel>> Pagination(Expression<Func<ProductModel, bool>> predicate)
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

        public void Update(string id, ProductModel model)
        {
            if (!string.IsNullOrWhiteSpace(id))
            {
                var originEntity = _unitOfWork.ProductRepository.FindByCondition(cat => cat.Id.Equals(model.Id)).FirstOrDefault();
                var entityUpdate = _mapper.Map(model, originEntity);
                entityUpdate.Id = model.Id;
                _unitOfWork.ProductRepository.Update(entityUpdate);
                SaveChanges();
                _unitOfWork.ProductRepository.Detach(entityUpdate);
            }

        }
        public async Task<bool> UpdateAsync(string id, ProductModel model)
        {
            if (!string.IsNullOrWhiteSpace(id))
            {
                var resources = await _unitOfWork.ResourceRepository.FindByCondition(rs => rs.ProductId.Equals(id)&&rs.IsDeleted).ToListAsync();

                resources.ForEach(item =>
                {
                    item.IsDeleted = true;
                });


                var originEntity = _unitOfWork.ProductRepository.FindByCondition(cat => cat.Id.Equals(model.Id)).FirstOrDefault();
                var entityUpdate = _mapper.Map(model, originEntity);
                entityUpdate.Id = model.Id;

                resources.AddRange(entityUpdate.Images);


                resources.ForEach(item =>
                {
                    _unitOfWork.ResourceRepository.Update(item);
                });

                _unitOfWork.ProductRepository.Update(entityUpdate);

                await SaveChangesAsync();
                _unitOfWork.ProductRepository.Detach(entityUpdate);
               
                return true;
            }
            return false;
        }

    }
}
