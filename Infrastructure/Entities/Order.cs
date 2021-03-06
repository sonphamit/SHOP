﻿using Infrastructure.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using SharedCore.Entities;

namespace Infrastructure.Entities
{
    public class Order : BaseEntity
    {
        public string CustomerId { get; set; }
        public string EmployeeId { get; set; }
        public OrderStatus Status { get; set; }
        public DateTime OrderDate { get; set; }
        public string ShipAddress { get; set; }
        public string ShipperId { get; set; }

        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
        [ForeignKey("CustomerId")]
        public virtual Customer Customer { get; set; }

        [ForeignKey("EmployeeId")]
        public virtual Employee Employee { get; set; }
        [ForeignKey("ShipperId")]
        public virtual Shipper Shipper { get; set; }

    }
}
