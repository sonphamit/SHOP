using Infrastructure.Enums;
using System.Collections.Generic;

namespace Infrastructure.Models
{
    public class ShipperModel
    {
        public string ShipperName { get; set; }
        public string ShipperPhone { get; set; }
        public DeliveryCompany Company { get; set; }
        public virtual ICollection<OrderModel> Orders { get; set; }
    }
}
