using Infrastructure.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public interface ICategoryService
    {
        Task AddAsync(CategoryModel model);
        void Update(string id,CategoryModel model);
        Task<IEnumerable<CategoryModel>> GetAllAsync();
        IEnumerable<CategoryModel> GetAll();
        Task<CategoryModel> GetByIdAsync(string id);
        Task DeleteAsync(CategoryModel model);
        Task<int> SaveChangesAsync();
        int SaveChanges();
    }
}
