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

            CreateMap<ApplicationUser, UserModel>();
            CreateMap<UserModel, ApplicationUser>();

            CreateMap<Product, ProductModel>();
            CreateMap<ProductModel, Product>().ForMember(x => x.Id, opt => opt.Ignore())
                                                .ForMember(x => x.Category, opt => opt.Ignore());

            CreateMap<Shipper, ShipperModel>();
            CreateMap<ShipperModel, Shipper>().ForMember(x => x.Id, opt => opt.Ignore());

            CreateMap<Supplier, SupplierModel>();
            CreateMap<SupplierModel, Supplier>().ForMember(x => x.Id, opt => opt.Ignore());

        }


    }
}
