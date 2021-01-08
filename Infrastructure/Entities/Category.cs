using SharedCore.Entities;
using System.Collections.Generic;

namespace Infrastructure.Entities
{
    public class Category : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}
