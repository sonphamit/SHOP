using Infrastructure.Entities;
using Infrastructure.Mappings;

namespace Infrastructure.Models
{
    public class SupplierModel : IMapFrom<Supplier>
    {
        public string CompanyName { get; set; }
    }
}
