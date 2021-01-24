using Infrastructure.Enums;
using System;
using System.Collections.Generic;

namespace Infrastructure.Models
{
    public class OrderModel
    {
        public OrderModel()
        {
            OrderDetails = new List<OrderDetailModel>();
        }
        public string Id { get; set; }
        public string CustomerId { get; set; }
        public string EmployeeId { get; set; }
        public OrderStatus Status { get; set; }
        public DateTime OrderDate { get; set; }
        public string ShipAddress { get; set; }
        public string ShipperId { get; set; }

        public virtual List<OrderDetailModel> OrderDetails { get; set; }
        public virtual CustomerModel Customer { get; set; }
        public virtual EmployeeModel Employee { get; set; }
        public virtual ShipperModel Shipper { get; set; }
    }
}
