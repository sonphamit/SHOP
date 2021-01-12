using Infrastructure.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public interface IRoleService
    {
        Task<IEnumerable<RoleModel>> GetAllRoleAsync();
        Task AddRoleAsync(RoleModel model);
        Task DeleteAsync(string id);
        Task UpdateAsync(string id, string name);
        Task<RoleModel> FindByIdAsync(string id);
        Task<RoleModel> FindByNameAsync(string name);
        Task<List<RoleClaim>> GetRoleClaimsByRoleId(string id);
        Task UpdateRoleClaimsAsync(string id, List<RoleClaim> roleClaims);
    }
}
