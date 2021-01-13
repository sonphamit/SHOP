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
        Task<IEnumerable<ProductModel>> GetAllAsync();
        IEnumerable<ProductModel> GetAll();
        ProductModel FindByCondition(string id);
        Task<IEnumerable<ProductModel>> Pagination(string categoryId, string keyword, string orderCol, string orderType, int? page = null, int? size = null);
        Task DeleteAsync(string id);
        Task<int> SaveChangesAsync();
        int SaveChanges();

    }
}
