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
        Task<IEnumerable<OrderModel>> GetAllAsync();
        Task<OrderModel> GetByIdAsync(string id);
        Task<IEnumerable<OrderModel>> Pagination(string categoryId, string keyword, string orderCol, string orderType, int? page = null, int? size = null);
        Task DeleteAsync(string id);
        Task<int> SaveChangesAsync();
        int SaveChanges();
    }
}
