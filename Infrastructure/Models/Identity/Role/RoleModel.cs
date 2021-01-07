using System.ComponentModel.DataAnnotations;

namespace Infrastructure.Models
{
    public class RoleModel
    {
        [Required]
        public string Name { get; set; }
        public string Id { get; set; }
    }
}
