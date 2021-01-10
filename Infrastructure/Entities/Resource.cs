using System.ComponentModel.DataAnnotations.Schema;

namespace Infrastructure.Entities
{
    public class Resource
    {
        public string Id { get; set; }
        public bool IsDeleted { get; set; }
        public string PathName { get; set; }
        [ForeignKey("ProductId")]
        public virtual Product Product { get; set; }
    }
}
