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
    public class CategoryService : ICategoryService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public CategoryService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task AddAsync(CategoryModel model)
        {
            var entity = _mapper.Map<Category>(model);
            await _unitOfWork.CategoryRepository.AddAsync(entity);
        }

        public Task AddRangeAsync(IEnumerable<CategoryModel> entities)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteAsync(CategoryModel model)
        {
            var entity = await _unitOfWork.CategoryRepository.GetByIdAsync(model.Id);
            _unitOfWork.CategoryRepository.Delete(entity);
        }

        public async Task<IEnumerable<CategoryModel>> GetAllAsync()
        {
            var entities =  _unitOfWork.CategoryRepository.GetAll();
            return _mapper.Map<IEnumerable<CategoryModel>>(entities);
        }

        public async Task<CategoryModel> GetByIdAsync(string id)
        {
            var entity = await _unitOfWork.CategoryRepository.GetByIdAsync(id);
            return _mapper.Map<CategoryModel>(entity);
        }

        public Task<IEnumerable<CategoryModel>> Pagination(Expression<Func<CategoryModel, bool>> predicate)
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
