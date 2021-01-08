using Infrastructure.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public interface ISupplierService
    {
        Task AddAsync(SupplierModel model);
        void Update(string id, SupplierModel model);

        Task<IEnumerable<SupplierModel>> GetAllAsync();
        IEnumerable<SupplierModel> GetAll();
        Task<SupplierModel> GetByIdAsync(string id);
        Task DeleteAsync(SupplierModel model);
        Task<int> SaveChangesAsync();
        int SaveChanges();
    }
}
