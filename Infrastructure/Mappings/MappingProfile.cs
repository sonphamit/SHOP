using AutoMapper;

namespace Infrastructure.Mappings
{
    public class CustomerProfile : Profile
    {
        public CustomerProfile()
        {
            //CreateMap<CustomerPayment, CustomerPaymentFullModel>()
             //   .ForMember(x => x.CardTypeName, opt => opt.MapFrom(y => EnumHelper.GetDescription(y.CardType)));
        }

        
    }
}
