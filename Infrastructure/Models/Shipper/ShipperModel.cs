using Infrastructure.Enums;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Infrastructure.Models
{
    public class ShipperModel
    {
        public string Id { get; set; }
        [Required(ErrorMessage = "Shipper Name is required")]
        public string ShipperName { get; set; }
        [Required(ErrorMessage = "Shipper Phone is required")]
        public string ShipperPhone { get; set; }
        [Required(ErrorMessage = "Delivery Company is required")]
        public DeliveryCompany Company { get; set; }
        public virtual ICollection<OrderModel> Orders { get; set; }
    }
}
