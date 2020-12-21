using Shared.Entities;
using System.Collections.Generic;

namespace SHOP.Infrastructure.Entities
{
    public class Category : GuidEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}
