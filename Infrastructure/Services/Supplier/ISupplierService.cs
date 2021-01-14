using Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public interface ISupplierService
    {
        Task AddAsync(SupplierModel model);
        void Update(string id, SupplierModel model);
        Task<bool> UpdateAsync(string id, SupplierModel model);
        Task<IEnumerable<SupplierModel>> GetAllAsync();
        IEnumerable<SupplierModel> GetAll();
        Task<SupplierModel> GetByIdAsync(string id);
        Task<IEnumerable<SupplierModel>> Pagination(Expression<Func<SupplierModel, bool>> predicate);
        Task DeleteAsync(string id);
        Task<int> SaveChangesAsync();
        int SaveChanges();

    }
}
