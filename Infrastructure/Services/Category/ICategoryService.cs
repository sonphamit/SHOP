using Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public interface ICategoryService
    {
        Task AddAsync(CategoryModel model);
        Task AddRangeAsync(IEnumerable<CategoryModel> models);
        Task<IEnumerable<CategoryModel>> GetAllAsync();
        Task<CategoryModel> GetByIdAsync(string id);
        Task<IEnumerable<CategoryModel>> Pagination(Expression<Func<CategoryModel, bool>> predicate);
        Task DeleteAsync(CategoryModel model);
        Task<int> SaveChangesAsync();
        int SaveChanges();
    }
}
