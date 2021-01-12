using AutoMapper;
using Infrastructure.Entities;
using Infrastructure.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class RoleService : IRoleService
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly RoleManager<ApplicationUser> _userManager;
        private readonly IMapper _mapper;

        public RoleService(RoleManager<IdentityRole> roleManager, IMapper mapper)
        {
            _roleManager = roleManager;
            _mapper = mapper;
        }

        public async Task<List<RoleClaim>> GetRoleClaimsByRoleId(string id)
        {
            var role = await _roleManager.FindByIdAsync(id);
            var existingRoleClaims = await _roleManager.GetClaimsAsync(role);
            List<RoleClaim> roleClaims = new List<RoleClaim>();
            foreach (Claim item in ClaimsStore.AllClaims)
            {
                RoleClaim roleClaim = new RoleClaim
                {
                    ClaimType = item.Type
                };

                if (existingRoleClaims.Any(c => c.Type == item.Type))
                {
                    roleClaim.IsSelected = true;
                }
                roleClaims.Add(roleClaim);
            }
            return roleClaims;
        }

        public async Task UpdateRoleClaimsAsync(string id, List<RoleClaim> roleClaims)
        {
            
            var role = await _roleManager.FindByIdAsync(id);
            if(role != null)
            {
                //Delete old role claims
                var claims = await _roleManager.GetClaimsAsync(role);
                foreach(var claim in claims)
                {
                    await _roleManager.RemoveClaimAsync(role, claim);
                }

                var newClaims = roleClaims.Where(claim => claim.IsSelected).ToList();

                //Add new role claims for role
                newClaims.ForEach(async item =>
                {
                    var newclaim = new Claim(item.ClaimType, item.ClaimType);
                    _ = await _roleManager.AddClaimAsync(role, newclaim);
                });

            }

        }

        public async Task<IEnumerable<RoleModel>> GetAllRoleAsync()
        {
            var roleList = await _roleManager.Roles.ToListAsync();
            var roles = _mapper.Map<IEnumerable<RoleModel>>(roleList);
            return roles;
        }

        public async Task AddRoleAsync(RoleModel model)
        {
            if (!string.IsNullOrWhiteSpace(model.Name))
            {
                IdentityRole role = new IdentityRole
                {
                    Name = model.Name
                };
                await _roleManager.CreateAsync(role);
            }
        }

        public async Task DeleteAsync(string id)
        {
            var role = await _roleManager.FindByIdAsync(id);
            if (role != null)
            {
                await _roleManager.DeleteAsync(role);
            }
        }

        public async Task<RoleModel> FindByIdAsync(string id)
        {
            var role = await _roleManager.FindByIdAsync(id);
            return _mapper.Map<RoleModel>(role);
        }

        public async Task<RoleModel> FindByNameAsync(string name)
        {
            var role = await _roleManager.FindByNameAsync(name);
            return _mapper.Map<RoleModel>(role);
        }

        

        public async Task UpdateAsync(string id, string Name)
        {
            var role = await _roleManager.FindByIdAsync(id);
            if(role != null)
            {
                role.Name = Name;
                await _roleManager.UpdateAsync(role);
            }
        }
    }
}
