using Infrastructure.Entities;

namespace Infrastructure.Models
{
    public class EmployeeModel
    {
        public string Id { get; set; }
        public virtual ApplicationUserModel User { get; set; }
    }
}
