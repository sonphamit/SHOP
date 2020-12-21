using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace SHOP.Infrastructure.Entities
{
    public class Employee : IdentityUser
    {
        public virtual ICollection<Order> Orders { get; set; }
    }
}
