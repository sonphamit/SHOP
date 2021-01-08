using System.Collections.Generic;

namespace Infrastructure.Models
{
    public class CustomerModel
    {
        public string Id { get; set; }
        public virtual ICollection<OrderModel> Orders { get; set; }
    }
}
