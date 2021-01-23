using Infrastructure.Enums;
using Microsoft.AspNetCore.Identity;

namespace Infrastructure.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public UserType UserType { get; set; }
    }
}

