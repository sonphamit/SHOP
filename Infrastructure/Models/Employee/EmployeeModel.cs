using System;

namespace Infrastructure.Models
{
    public class EmployeeModel
    {
        public EmployeeModel()
        {
            ApplicationUser = new ApplicationUserModel();
        }
        public string Id { get; set; }
        public virtual ApplicationUserModel ApplicationUser { get; set; }
    }
}
