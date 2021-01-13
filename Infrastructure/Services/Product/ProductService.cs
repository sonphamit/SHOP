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

        public async Task AddAsync(ProductModel model)
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
            var resources = await _unitOfWork.ResourceRepository.FindByCondition(rs => rs.ProductId.Equals(id) && rs.IsDeleted).ToListAsync();
            resources.ForEach(item =>
            {
                item.IsDeleted = true;
            });

            var entityDelete = await _unitOfWork.ProductRepository.FindByCondition(e => e.Id.Equals(id)).FirstOrDefaultAsync();
            resources.AddRange(entityDelete.Images);


            resources.ForEach(item =>
            {
                _unitOfWork.ResourceRepository.Update(item);
            });

            _unitOfWork.ProductRepository.Delete(entityDelete);
        }

        public async Task<IEnumerable<ProductModel>> GetAllAsync()
        {
            var entities = await _unitOfWork.ProductRepository.DbSet
                .Include(item => item.Category).Include(item => item.Supplier)
                .Include(item => item.Images).AsNoTracking().ToListAsync();
            return _mapper.Map<IEnumerable<ProductModel>>(entities).OrderBy(e => e.Name);
        }

        public IEnumerable<ProductModel> GetAll()
        {
            var entities = _unitOfWork.ProductRepository.GetAll();
            return _mapper.Map<IEnumerable<ProductModel>>(entities).OrderBy(e => e.Name);
        }

        public ProductModel FindByCondition(string id)
        {
            var entity = _unitOfWork.ProductRepository.FindByCondition(e => e.Id == id).FirstOrDefault();
            var model = _mapper.Map<ProductModel>(entity);
            return model;
        }

        public Task<IEnumerable<ProductModel>> Pagination(string categoryId, string keyword, string orderCol, string orderType, int? page = null, int? size = null)
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
                var resources = await _unitOfWork.ResourceRepository.FindByCondition(rs => rs.ProductId.Equals(id)&&!rs.IsDeleted).ToListAsync();

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
