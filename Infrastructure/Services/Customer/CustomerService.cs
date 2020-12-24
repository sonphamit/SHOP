using System.Collections.Generic;
using System.Threading.Tasks;

namespace SHOP.Infrastructure.Services
{
    public class CustomerService : ICustomerService
    {
        Task ICustomerService.AddAsync()
        {
            throw new System.NotImplementedException();
        }

        void ICustomerService.Delete()
        {
            throw new System.NotImplementedException();
        }

        Task<IEnumerable<CustomerService>> ICustomerService.GetAllAsync()
        {
            throw new System.NotImplementedException();
        }

        Task ICustomerService.GetByIdAsync(string id)
        {
            throw new System.NotImplementedException();
        }

        Task ICustomerService.UpdateAsync()
        {
            throw new System.NotImplementedException();
        }
    }
}
