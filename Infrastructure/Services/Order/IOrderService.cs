using Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public interface IOrderService
    {
        Task AddAsync(OrderModel model);
        Task AddRangeAsync(IEnumerable<OrderModel> models);
        Task<IEnumerable<OrderModel>> GetAllAsync();
        Task<OrderModel> GetByIdAsync(string id);
        Task<IEnumerable<OrderModel>> Pagination(Expression<Func<OrderModel, bool>> predicate);
        Task DeleteAsync(OrderModel model);
        Task<int> SaveChangesAsync();
        int SaveChanges();
    }
}
