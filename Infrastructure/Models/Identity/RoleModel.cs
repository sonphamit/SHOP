using System.ComponentModel.DataAnnotations;

namespace Infrastructure.Models
{
    public class RoleModel
    {
        [Required(ErrorMessage = "* Required")]
        [StringLength(255, MinimumLength = 3, ErrorMessage = "Name is too short.")]
        public string Name { get; set; }
        public string Id { get; set; }
        //public List<RoleClaim> Claims { get; set; }
    }
}
