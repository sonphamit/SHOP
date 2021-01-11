using Infrastructure.Entities;
using Microsoft.AspNetCore.Identity;

namespace Dashboard.SeedData
{
    public static class DataInitializer
    {
        public static void SeedData(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            SeedRoles(roleManager);
            SeedUsers(userManager);
        }
        private static void SeedRoles(RoleManager<IdentityRole> roleManager)
        {
            if (!roleManager.RoleExistsAsync("Admin").Result)
            {
                IdentityRole role = new IdentityRole
                {
                    Name = "Admin"
                };
                _ = roleManager.CreateAsync(role).Result;
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
                //var passwordHash = new PasswordHasher<ApplicationUser>();
                
                ApplicationUser userAdmin = new ApplicationUser
                {
                    UserName = "admin",
                    Email = "admin@shop.com",
                    FirstName = "Admin",
                    LastName = "Admin",
                    EmailConfirmed = true,
                };
                //passwordHash.HashPassword(userAdmin, "1234");

                IdentityResult result = userManager.CreateAsync(userAdmin, "123456@bC").Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(userAdmin, "Admin").Wait();
                }
            }
        }

    }
}
