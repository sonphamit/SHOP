using Infrastructure.Enums;
using Microsoft.AspNetCore.Identity;

namespace Infrastructure.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public string FullName { get; set; }
        public string Address { get; set; }
        public UserType UserType { get; set; }
    }
}

