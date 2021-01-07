using Infrastructure.Entities;
using Infrastructure.Mappings;


namespace Infrastructure.Models
{
    public class ProductModel : IMapFrom<Product>
    {
        public ProductModel()
        {
            Category = new CategoryModel();
            //Supplier = new SupplierModel();
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
    
    }
    public class ProductAddModel : IMapFrom<Product>
    {
        public string Name { get; set; }
        public string SupplierId { get; set; }
        public string CategoryId { get; set; }
        public decimal UnitPrice { get; set; }
        public int UnitsInStock { get; set; }
        public int UnitsOnOrder { get; set; }
        public virtual CategoryModel Category { get; set; }
        public virtual SupplierModel Supplier { get; set; }

    }
}
