using Infrastructure.Entities;
using Infrastructure.Mappings;
using System.Collections.Generic;

namespace Infrastructure.Models
{
    public class EmployeeModel : IMapFrom<Employee>
    {
        public virtual ICollection<OrderModel> Orders { get; set; }
    }
}
