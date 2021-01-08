using System.Collections.Generic;

namespace Infrastructure.Models
{
    public class CategoryModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual ICollection<ProductModel> Products { get; set; }
    }

}
