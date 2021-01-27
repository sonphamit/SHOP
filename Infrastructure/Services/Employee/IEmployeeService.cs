using Infrastructure.Extentions;
using Infrastructure.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public interface IEmployeeService
    {
        Task<bool> IsExsistAsync(string userName);
        Task AddAsync(EmployeeRequestModel model);
        Task UpdateAsync(string id, EmployeeRequestModel model);
        Task<IEnumerable<EmployeeResponseModel>> GetAllAsync();
        Task<EmployeeResponseModel> GetByIdAsync(string id);
        Task<Pagination<EmployeeResponseModel>>
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
