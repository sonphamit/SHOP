using Infrastructure.Entities;
using Infrastructure.Mappings;

namespace Infrastructure.Models
{
    public class ProductModel : IMapFrom<Product>
    {
        public string Id { get; set; }
        public string SupplierId { get; set; }
        public string CategoryId { get; set; }
        public string Name { get; set; }
        public decimal UnitPrice { get; set; }
        public int UnitsInStock { get; set; }
        public int UnitsOnOrder { get; set; }
        public virtual CategoryModel Category { get; set; }
        public virtual SupplierModel Supplier { get; set; }
    }
}
