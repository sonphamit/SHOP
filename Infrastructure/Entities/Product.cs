using Infrastructure.Enums;
using SharedCore.Entities;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infrastructure.Entities
{
    public class Product : BaseEntity
    {
        public string SupplierId { get; set; }
        public string CategoryId { get; set; }
        public string ProductionCode { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public uint UnitPrice { get; set; }
        public bool Discontinued { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Discount { get; set; }
        public uint UnitsInStock { get; set; }
        public uint UnitsOnOrder { get; set; }
        public Gender Gender { get; set; }
        [ForeignKey("CategoryId")]
        public virtual Category Category { get; set; }
        [ForeignKey("SupplierId")]
        public virtual Supplier Supplier { get; set; }
        public virtual ICollection<Resource> Images { get; set; }
    }
}
