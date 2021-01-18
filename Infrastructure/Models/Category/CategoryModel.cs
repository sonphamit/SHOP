using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Infrastructure.Models
{
    public class CategoryModel
    {
        public string Id { get; set; }
        [Required(ErrorMessage = "Name is required")]
        [StringLength(255, MinimumLength = 3, ErrorMessage = "Name is at least 3 chars.")]
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual ICollection<ProductModel> Products { get; set; }
    }

}
