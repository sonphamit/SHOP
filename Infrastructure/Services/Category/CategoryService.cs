using AutoMapper;
using Infrastructure.Database;
using Infrastructure.Entities;
using Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
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
            SaveChanges();
        }

        public async Task DeleteAsync(CategoryModel model)
        {
            var entity = await _unitOfWork.CategoryRepository.FindByCondition(cat => cat.Id.Equals(model.Id)).FirstOrDefaultAsync();
            _unitOfWork.CategoryRepository.Delete(entity);
        }

        public async Task<IEnumerable<CategoryModel>> GetAllAsync()
        {
            var entities = await _unitOfWork.CategoryRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<CategoryModel>>(entities);
        }

        public IEnumerable<CategoryModel> GetAll()
        {
            var entities = _unitOfWork.CategoryRepository.GetAll();
            return _mapper.Map<IEnumerable<CategoryModel>>(entities);
        }

        public async Task<CategoryModel> GetByIdAsync(string id)
        {
            var entity = await _unitOfWork.CategoryRepository.GetByIdAsync(id);
            return _mapper.Map<CategoryModel>(entity);
        }

        public int SaveChanges()
        {
            return _unitOfWork.SaveChanges();
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _unitOfWork.SaveChangesAsync();
        }

        public void Update(string id, CategoryModel model)
        {
            if (!string.IsNullOrWhiteSpace(id))
            {
                var originEntity =  _unitOfWork.CategoryRepository.FindByCondition(cat => cat.Id.Equals(model.Id)).FirstOrDefault();
                var entityUpdate = _mapper.Map(model, originEntity);
                entityUpdate.Id = model.Id;
                _unitOfWork.CategoryRepository.Update(entityUpdate);
                SaveChanges();
                _unitOfWork.CategoryRepository.Detach(entityUpdate);
            }
            
        }
    }
}
