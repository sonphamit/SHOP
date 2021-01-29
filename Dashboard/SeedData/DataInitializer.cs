using Infrastructure.Entities;
using Infrastructure.Models;
using Microsoft.AspNetCore.Identity;

namespace Dashboard.SeedData
{
    public static class DataInitializer
    {
        public static void SeedData(
            UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            SeedRoles(roleManager);
            SeedUsers(userManager);
        }
        private static void SeedRoles(RoleManager<IdentityRole> roleManager)
        {
            var adminRole = roleManager.FindByNameAsync("Admin").Result;
            if (adminRole == null)
            {
                IdentityRole role = new IdentityRole
                {
                    Name = "Admin"
                };
                _ = roleManager.CreateAsync(role).Result;
            }
            else
            {
                if (roleManager.GetClaimsAsync(adminRole).Result.Count < 1)
                {
                    ClaimsStore.AllClaims.ForEach(claim =>
                    {
                    _ = roleManager.AddClaimAsync(adminRole, claim).Result;
                    });
                }
            }

            if (!roleManager.RoleExistsAsync("Customer").Result)
            {
                IdentityRole role = new IdentityRole
                {
                    Name = "Customer"
                };
                _ = roleManager.CreateAsync(role).Result;
            }

        }

        private static void SeedUsers(UserManager<ApplicationUser> userManager)
        {
            if (userManager.FindByNameAsync("admin").Result == null)
            {
                ApplicationUser userAdmin = new ApplicationUser
                {
                    UserName = "admin",
                    Email = "admin@shop.com",
                    FullName = "Just Admin",
                    EmailConfirmed = true,
                };

                IdentityResult result = userManager.CreateAsync(userAdmin, "123456@bC").Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(userAdmin, "Admin").Wait();
                }
            }
        }

    }
}
