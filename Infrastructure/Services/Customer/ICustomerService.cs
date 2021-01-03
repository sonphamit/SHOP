using Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
namespace Infrastructure.Services
{
    public interface ICustomerService 
    {
        Task AddAsync(CustomerModel model);
        Task AddRangeAsync(IEnumerable<CustomerModel> models);
        Task<IEnumerable<CustomerModel>> GetAllAsync();
        Task<CustomerModel> GetByIdAsync(string id);
        Task<IEnumerable<CustomerModel>> Pagination(Expression<Func<CustomerModel, bool>> predicate);
        Task DeleteAsync(CustomerModel model);
        Task<int> SaveChangesAsync();
        int SaveChanges();

    }
}
