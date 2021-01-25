using SharedCore.Helpers;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infrastructure.Models
{
    public class EmployeeRequestModel : EmployeeModel
    {
        public EmployeeRequestModel()
        {
            
        }
        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required(ErrorMessage = "Confirm Password is required")]
        [DataType(DataType.Password)]
        [Compare("Password")]
        [NotMapped]
        public string ConfirmPassword { get; set; }
    }
}
