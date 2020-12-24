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
        private IUnitOfWork _unitOfWork;
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

        public Task<IEnumerable<CategoryModel>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<CategoryModel> GetByIdAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<CategoryModel>> Pagination(Expression<Func<CategoryModel, bool>> predicate)
        {
            throw new NotImplementedException();
        }
    }
}
