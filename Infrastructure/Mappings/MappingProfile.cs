﻿using AutoMapper;
using Infrastructure.Entities;
using Infrastructure.Models;

namespace Infrastructure.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //CreateMap<CustomerPayment, CustomerPaymentFullModel>()
            //   .ForMember(x => x.CardTypeName, opt => opt.MapFrom(y => EnumHelper.GetDescription(y.CardType)));
            CreateMap<Category, CategoryModel>();
            CreateMap<CategoryModel, Category > ();
        }

        
    }
}
