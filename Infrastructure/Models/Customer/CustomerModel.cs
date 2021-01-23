using Infrastructure.Entities;

namespace Infrastructure.Models
{
    public class CustomerModel
    {
        public string Id { get; set; }
        public virtual ApplicationUserModel User { get; set; }
    }
}
