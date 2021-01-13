using Infrastructure.Database;
using Infrastructure.Entities;
using Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Store.Configuration
{
    public static class ServicesDependency
    {
        public static void AddServicesDependency(this IServiceCollection services)
        {
            //services.Scan(scan => scan
            //    .FromCallingAssembly()
            //    .AddClasses(classes => classes.AssignableTo(typeof(IService)))
            //    .AsSelf()
            //    .WithTransientLifetime()
            //);

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IRepository<Category>, Repository<Category>>();
            services.AddScoped<IRepository<Customer>, Repository<Customer>>();
            services.AddScoped<IRepository<Employee>, Repository<Employee>>();
            services.AddScoped<IRepository<Shipper>, Repository<Shipper>>();
            services.AddScoped<IRepository<Supplier>, Repository<Supplier>>();
            services.AddScoped<IRepository<Product>, Repository<Product>>();
            services.AddScoped<IRepository<Order>, Repository<Order>>();
            services.AddScoped<IRepository<OrderDetail>, Repository<OrderDetail>>();
            services.AddScoped<IRepository<Resource>, Repository<Resource>>();

            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<IEmployeeService, EmployeeService>();
            services.AddScoped<IIdentityService, IdentityService>();
            services.AddScoped<IShipperService, ShipperService>();
            services.AddScoped<ISupplierService, SupplierService>();
            services.AddScoped<IProductService, ProductService>();

            services.AddScoped<IOrderService, OrderService>();

            services.AddScoped<IRoleService, RoleService>();
        }
    }
}
