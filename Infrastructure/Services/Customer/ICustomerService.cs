using Infrastructure.Extentions;
using Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
namespace Infrastructure.Services
{
    public interface ICustomerService 
    {
        Task<bool> IsExsistAsync(string userName);
        Task AddAsync(CustomerRequestModel model);
        Task UpdateAsync(string id, CustomerRequestModel model);
        Task<IEnumerable<CustomerResponseModel>> GetAllAsync();
        Task<CustomerResponseModel> GetByIdAsync(string id);
        Task<Pagination<CustomerResponseModel>>
            Search(
            string keyword,
            string orderCol,
            string orderType,
            int? page = null,
            int? size = null
            );
        Task DeleteAsync(string id);
        Task<int> SaveChangesAsync();
        int SaveChanges();

    }
}
