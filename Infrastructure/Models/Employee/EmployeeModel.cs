using System.Collections.Generic;

namespace Infrastructure.Models
{
    public class EmployeeModel
    {
        public virtual ICollection<OrderModel> Orders { get; set; }
    }
}
