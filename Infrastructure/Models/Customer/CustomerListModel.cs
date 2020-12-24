using AutoMapper;
using Infrastructure.Entities;
using Infrastructure.Mappings;

namespace Infrastructure.Models
{
    public class CustomerListModel: IMapFrom<Customer>
    {
        public string PhoneNumber { get; set; }
        public string Password { get; set; }

        public void Mapping(Profile profile)
        {
            //rofile.CreateMap<District, DistrictModel>();
        }
    }
}
