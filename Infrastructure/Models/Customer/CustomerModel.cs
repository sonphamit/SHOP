using Infrastructure.Entities;
using Infrastructure.Mappings;
using System.Collections.Generic;

namespace Infrastructure.Models
{
    public class CustomerModel : IMapFrom<Customer>
    {
        public virtual ICollection<OrderModel> Orders { get; set; }
    }
}
