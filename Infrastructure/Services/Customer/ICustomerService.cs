using System.Collections.Generic;
using System.Threading.Tasks;

namespace SHOP.Infrastructure.Services
{
    public interface ICustomerService
    {
        Task AddAsync();
        Task UpdateAsync();
        void Delete();
        Task<IEnumerable<CustomerService>> GetAllAsync();
        Task GetByIdAsync(string id);
        //Task Pagination();
    }
}
