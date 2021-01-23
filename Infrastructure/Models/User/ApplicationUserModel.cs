using Infrastructure.Enums;

namespace Infrastructure.Models
{
    public class ApplicationUserModel
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public UserType UserType { get; set; }
        public string PhoneNumber { get; set; }
        public string PasswordHash { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
    }
}
