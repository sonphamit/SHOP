using Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Models
{
    public class ResourceModel
    {
        public string Id { get; set; }
         public bool IsDeleted { get; set; }
        public string PathName { get; set; }
        public virtual ProductModel Product { get; set; }
    }
}
