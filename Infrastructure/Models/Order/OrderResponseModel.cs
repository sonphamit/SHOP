﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Models
{
    public class OrderResponseModel : OrderModel
    {
        public OrderResponseModel() : base()
        {
            //Supplier = new SupplierModel();
        }
        public string SubTotal { get; set; }
    }
}
