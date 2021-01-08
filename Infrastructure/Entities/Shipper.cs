using Shared.Entities;
using Infrastructure.Enums;
using System.Collections.Generic;

namespace Infrastructure.Entities
{
    public class Shipper : BaseEntity
    {
        public string ShipperName { get; set; }
        public string ShipperPhone { get; set; }
        public DeliveryCompany Company { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
