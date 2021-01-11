
using SharedCore.Entities;
using System.ComponentModel.DataAnnotations;

namespace Infrastructure.Entities
{
    public class Supplier : BaseEntity
    {
        [Required]
        public string CompanyName { get; set; }
    }
}
