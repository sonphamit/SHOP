﻿namespace Infrastructure.Models
{
    public class ProductResponseModel : ProductModel
    {
        public ProductResponseModel() : base()
        {
            Category = new CategoryModel();
            Supplier = new SupplierModel();
        }
        public string DiscountPriceString
        {
            get
            {
                return string.Format("{0:0,0 VND}", UnitPrice * (1 - Discount / 100));
            }
        }

        public string UnitPriceString
        {
            get
            {
                return string.Format("{0:0,0 VND}",UnitPrice);
            }
        }

        public string DiscountString
        {
            get
            {
                return string.Format("{0:0,0 VND}", Discount);
            }
        }

        public CategoryModel Category { get; set; }
        public SupplierModel Supplier { get; set; }

    }

}
