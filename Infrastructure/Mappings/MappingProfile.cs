using AutoMapper;
using Infrastructure.Entities;
using Infrastructure.Models;
using Microsoft.AspNetCore.Identity;

namespace Infrastructure.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {

            CreateMap<IdentityRole, RoleModel>();
            CreateMap<RoleModel, IdentityRole>().ForMember(x => x.Id, opt => opt.Ignore());


            CreateMap<Category, CategoryModel>();
            CreateMap<CategoryModel, Category>().ForMember(x => x.Id, opt => opt.Ignore());

            CreateMap<User, UserModel>();
            CreateMap<UserModel, User>();

            CreateMap<Product, ProductModel>();
            CreateMap<ProductModel, Product>().ForMember(x => x.Id, opt => opt.Ignore())
                                                .ForMember(x => x.Category, opt => opt.Ignore());

            CreateMap<Shipper, CategoryModel>();
            CreateMap<CategoryModel, Shipper>().ForMember(x => x.Id, opt => opt.Ignore());

        }


    }
}
