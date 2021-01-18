using Infrastructure.Enums;
using Infrastructure.Extentions;
using Infrastructure.Models;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace Infrastructure.Services
{
    public interface IProductService
    {
        Task AddAsync(ProductRequestModel model);
        void Update(string id, ProductRequestModel model);
        Task<bool> UpdateAsync(string id, ProductRequestModel model);
        Task<IEnumerable<ProductResponseModel>> GetAllAsync();
        IEnumerable<ProductResponseModel> GetAll();
        ProductResponseModel GetById(string id);
        Task<ProductResponseModel> GetByIdAsync(string id);
        Task<Pagination<ProductResponseModel>>
            Search(
            string categoryId,
            string supplierId,
            Gender Gender,
            string keyword,
            string orderCol,
            string orderType,
            int? page = null,
            int? size = null
            );
        Task DeleteAsync(string id);
        Task<int> SaveChangesAsync();
        int SaveChanges();

        Task<List<ProductResponseModel>> GetProductsCategoryAsync(string categoryId, string? productId);

    }
}
