using Infrastructure.Entities;
using Infrastructure.Mappings;
using System.Collections.Generic;

namespace Infrastructure.Models
{
    public class CategoryModel : IMapFrom<Category>
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual ICollection<ProductModel> Products { get; set; }
    }

    public class CategoryAddModel : IMapFrom<Category>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual ICollection<ProductModel> Products { get; set; }
    }
}
