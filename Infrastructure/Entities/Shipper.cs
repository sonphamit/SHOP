using Shared.Entities;
using SHOP.Infrastructure.Enums;
using System.Collections.Generic;

namespace SHOP.Infrastructure.Entities
{
    public class Shipper : GuidEntity
    {
        public string ShipperName { get; set; }
        public string ShipperPhone { get; set; }
        public Company Company { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
