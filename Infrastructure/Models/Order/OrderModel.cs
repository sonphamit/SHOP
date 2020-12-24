using Infrastructure.Entities;
using Infrastructure.Enums;
using Infrastructure.Mappings;
using System;
using System.Collections.Generic;

namespace Infrastructure.Models
{
    public class OrderModel : IMapFrom<Order>
    {
        public string CustomerId { get; set; }
        public string EmployeeId { get; set; }
        public OrderStatus Status { get; set; }
        public DateTime OrderDate { get; set; }
        public string ShipAddress { get; set; }
        public string ShipperId { get; set; }

        public virtual ICollection<OrderDetailModel> OrderDetails { get; set; }
        public virtual CustomerModel Customer { get; set; }
        public virtual EmployeeModel Employee { get; set; }
        public virtual ShipperModel Shipper { get; set; }
    }
}
