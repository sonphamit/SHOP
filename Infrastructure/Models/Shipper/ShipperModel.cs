using Infrastructure.Entities;
using Infrastructure.Enums;
using Infrastructure.Mappings;
using System.Collections.Generic;

namespace Infrastructure.Models
{
    public class ShipperModel : IMapFrom<Shipper>
    {
        public string ShipperName { get; set; }
        public string ShipperPhone { get; set; }
        public Company Company { get; set; }
        public virtual ICollection<OrderModel> Orders { get; set; }
    }
}
