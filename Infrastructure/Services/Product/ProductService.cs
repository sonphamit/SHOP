using AutoMapper;
using Infrastructure.Database;
using Infrastructure.Entities;
using Infrastructure.Models;
using System;
using System.Collections.Generic;
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
            var entity = _mapper.Map<Product>(model);
            await _unitOfWork.ProductRepository.AddAsync(entity);
        }

        public Task AddRangeAsync(IEnumerable<ProductModel> models)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteAsync(ProductModel model)
        {
            var entity = await _unitOfWork.ProductRepository.GetByIdAsync(model.Id);
            _unitOfWork.ProductRepository.Delete(entity);
        }

        public async Task<IEnumerable<ProductModel>> GetAllAsync()
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
    }
}
