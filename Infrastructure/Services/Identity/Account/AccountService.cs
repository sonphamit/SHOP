using AutoMapper;
using Infrastructure.Entities;
using Infrastructure.Models;
using Microsoft.AspNetCore.Identity;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class AccountService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly UserManager<IdentityRole> _roleManager;
        private readonly IMapper _mapper;

        public AccountService(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        

        public async Task GetRoleClaimsByUser(ApplicationUser user)
        {

            var existingUserClaims = await _userManager.GetClaimsAsync(user);

            foreach (Claim claim in ClaimsStore.AllClaims)
            {
                RoleClaim userClaim = new RoleClaim
                {
                    ClaimType = claim.Type
                };

                if (existingUserClaims.Any(c => c.Type == claim.Type))
                {
                    userClaim.IsSelected = true;
                }
            }

        }
    }
}
