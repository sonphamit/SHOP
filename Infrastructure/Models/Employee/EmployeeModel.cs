using System;

namespace Infrastructure.Models
{
    public class EmployeeModel
    {
        public EmployeeModel()
        {
            User = new ApplicationUserModel();
        }
        public string Id { get; set; }
        public virtual ApplicationUserModel User { get; set; }
    }
}
