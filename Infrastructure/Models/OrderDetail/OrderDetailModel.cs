﻿namespace Infrastructure.Models
{
    public class OrderDetailModel
    {
        public string OrderId { get; set; }
        public string ProductId { get; set; }
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
        public virtual OrderModel Order { get; set; }
        public virtual ProductResponseModel Product { get; set; }
    }
}
