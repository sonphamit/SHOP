using AutoMapper;
using Infrastructure.Database;
using Infrastructure.Entities;
using Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public async Task AddAsync(ProductRequestModel model)
        {
            //model.CategoryId = model.Category.Id;
            var entity = _mapper.Map<Product>(model);
            await _unitOfWork.ProductRepository.AddAsync(entity);
            entity.Images.ToList().ForEach( item => item.ProductId = entity.Id);
            await _unitOfWork.ResourceRepository.AddRangeAsync(entity.Images);
            SaveChanges();
            _unitOfWork.ProductRepository.Detach(entity);
        }

        public async Task DeleteAsync(string id)
        {
            var resources = await _unitOfWork.ResourceRepository.FindByCondition(rs => rs.ProductId.Equals(id)).ToListAsync();
            if (resources.Any())
            {
                resources.ForEach(item =>
                {
                    item.IsDeleted = true;
                });
            }

            var entityDelete = await _unitOfWork.ProductRepository.FindByCondition(e => e.Id.Equals(id)).FirstOrDefaultAsync();

            resources.ForEach(item =>
            {
                _unitOfWork.ResourceRepository.Update(item);
            });

            _unitOfWork.ProductRepository.Delete(entityDelete);
        }

        public async Task<IEnumerable<ProductResponseModel>> GetAllAsync()
        {
            var entities = await _unitOfWork.ProductRepository.DbSet
                .Include(item => item.Category).Include(item => item.Supplier)
                .Include(item => item.Images).AsNoTracking().ToListAsync();
            return _mapper.Map<IEnumerable<ProductResponseModel>>(entities).OrderBy(e => e.Name);
        }

        public IEnumerable<ProductResponseModel> GetAll()
        {
            var entities = _unitOfWork.ProductRepository.GetAll();
            return _mapper.Map<IEnumerable<ProductResponseModel>>(entities).OrderBy(e => e.Name);
        }

        
        public ProductResponseModel GetById(string id)
        {
            var entity = _unitOfWork.ProductRepository.FindByCondition(e => e.Id == id)
                .Include(i => i.Images).FirstOrDefault();
            var Images = entity.Images.Where(img => !img.IsDeleted);
            entity.Images = Images.ToList();
            var model = _mapper.Map<ProductResponseModel>(entity);
            _unitOfWork.ProductRepository.Detach(entity);
            return model;
        }

        public async Task<ProductResponseModel> GetByIdAsync(string id)
        {
            var entity = await _unitOfWork.ProductRepository.FindByCondition(e => e.Id == id).FirstOrDefaultAsync();
            var model = _mapper.Map<ProductResponseModel>(entity);
            return model;
        }

        public Task<IEnumerable<ProductResponseModel>> Pagination(string categoryId, string keyword, string orderCol, string orderType, int? page = null, int? size = null)
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

        public void Update(string id, ProductRequestModel model)
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
        public async Task<bool> UpdateAsync(string id, ProductRequestModel model)
        {
            if (!string.IsNullOrWhiteSpace(id))
            {
                var resources = await _unitOfWork.ResourceRepository.FindByCondition(rs => rs.ProductId.Equals(id)&&!rs.IsDeleted).ToListAsync();

                resources.ForEach(item =>
                {
                    item.IsDeleted = true;
                });

                resources.ForEach(item =>
                {
                    _unitOfWork.ResourceRepository.Update(item);
                });

                var originEntity = _unitOfWork.ProductRepository.FindByCondition(cat => cat.Id.Equals(model.Id)).FirstOrDefault();


                var entityUpdate = _mapper.Map(model, originEntity);
                entityUpdate.Id = model.Id;

                await _unitOfWork.ResourceRepository.AddRangeAsync(entityUpdate.Images);

                _unitOfWork.ProductRepository.Update(entityUpdate);

                await SaveChangesAsync();
                _unitOfWork.ProductRepository.Detach(entityUpdate);
                entityUpdate.Images.ToList().ForEach(item => _unitOfWork.ResourceRepository.Detach(item));
                return true;
            }
            return false;
        }

    }
}
