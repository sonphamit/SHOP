using Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public interface IOrderService
    {
        Task<string> AddAsync(OrderRequestModel model);
        void Update(string id, OrderRequestModel model);
        Task<bool> UpdateAsync(string id, OrderRequestModel model);
        Task<IEnumerable<OrderResponseModel>> GetAllAsync();
        IEnumerable<OrderResponseModel> GetAll();
        OrderResponseModel GetById(string id);
        Task<OrderResponseModel> GetByCustomerIdOrderingAsync(string id);
        Task<OrderResponseModel> GetByIdOrderingAsync(string id);
        Task<OrderResponseModel> GetByIdAsync(string id);

        Task<OrderResponseModel> UpdateExistingOrder(string productId, int quantity , string? orderId = null, string? userName = null);

        Task<OrderResponseModel> AddNewOrder(string productId, int quantity, string? id = null);

        Task DeleteAsync(string id);
        Task<int> SaveChangesAsync();
        int SaveChanges();

    }
}
