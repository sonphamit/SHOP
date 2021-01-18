using System.ComponentModel.DataAnnotations;

namespace Infrastructure.Models
{
    public class SupplierModel
    {
        public string Id { get; set; }
        [Required(ErrorMessage = "Company Name is required")]
        public string CompanyName { get; set; }
    }
}
