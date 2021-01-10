using SharedCore.Entities;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infrastructure.Entities
{
    public class Product : BaseEntity
    {
        public string SupplierId { get; set; }
        public string CategoryId { get; set; }
        public string Name { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal UnitPrice { get; set; }
        public bool Discontinued { get; set; }
        public float Discount { get; set; }
        public int UnitsInStock { get; set; }
        public int UnitsOnOrder { get; set; }
        [ForeignKey("CategoryId")]
        public virtual Category Category { get; set; }
        [ForeignKey("SupplierId")]
        public virtual Supplier Supplier { get; set; }
        public virtual ICollection<Resource> Images { get; set; }
    }
}
