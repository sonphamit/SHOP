using System.Collections.Generic;

namespace Infrastructure.Models
{
    public class ProductModel
    {
        public ProductModel()
        {
            Category = new CategoryModel();
            Images = new List<ResourceModel>();
            Supplier = new SupplierModel();
        }
        public string Id { get; set; }
        public string SupplierId { get; set; }
        public string CategoryId { get; set; }
        public string Name { get; set; }
        public decimal UnitPrice { get; set; }
        public int UnitsInStock { get; set; }
        public int UnitsOnOrder { get; set; }
        public CategoryModel Category { get; set; }
        public SupplierModel Supplier { get; set; }
        public virtual ICollection<ResourceModel> Images { get; set; }

    }
    public class ProductAddModel
    {
        public string Name { get; set; }
        public string SupplierId { get; set; }
        public string CategoryId { get; set; }
        public decimal UnitPrice { get; set; }
        public int UnitsInStock { get; set; }
        public int UnitsOnOrder { get; set; }
        public virtual CategoryModel Category { get; set; }
        public virtual SupplierModel Supplier { get; set; }
        public virtual ICollection<ResourceModel> Images { get; set; }

    }
}
