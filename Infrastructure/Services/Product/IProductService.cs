using Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;


namespace Infrastructure.Services
{
    public interface IProductService
    {
        Task AddAsync(ProductModel model);
        void Update(string id, ProductModel model);
        Task<bool> UpdateAsync(string id, ProductModel model);
        Task AddRangeAsync(IEnumerable<ProductModel> models);
        Task<IEnumerable<ProductModel>> GetAllAsync();
        IEnumerable<ProductModel> GetAll();
        Task<ProductModel> GetByIdAsync(string id);
        Task<IEnumerable<ProductModel>> Pagination(Expression<Func<ProductModel, bool>> predicate);
        Task DeleteAsync(ProductModel model);
        Task<int> SaveChangesAsync();
        int SaveChanges();

    }
}
