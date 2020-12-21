using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SHOP.Infrastructure.Entities
{
    public class OrderDetail
    {
        public string OrderId { get; set; }
        public string ProductId { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
        [ForeignKey("OrderId")]
        [Column(TypeName = "decimal(18, 2)")]
        public virtual Order Order { get; set; }
        [ForeignKey("ProductId")]
        public virtual Product Product { get; set; }
    }
}
