using Infrastructure.Database;
using Infrastructure.Entities;
using Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Dashboard.Configuration
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

            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient<IRepository<Category>, Repository<Category>>();
            services.AddTransient<IRepository<Customer>, Repository<Customer>>();
            services.AddTransient<IRepository<Employee>, Repository<Employee>>();
            services.AddTransient<IRepository<Shipper>, Repository<Shipper>>();
            services.AddTransient<IRepository<Supplier>, Repository<Supplier>>();
            services.AddTransient<IRepository<Product>, Repository<Product>>();
            services.AddTransient<IRepository<Order>, Repository<Order>>();
            services.AddTransient<IRepository<OrderDetail>, Repository<OrderDetail>>();

            services.AddTransient<ICategoryService, CategoryService>();
            services.AddTransient<ICustomerService, CustomerService>();
            services.AddTransient<IEmployeeService, EmployeeService>();
            services.AddTransient<IIdentityService, IdentityService>();
            services.AddTransient<IShipperService, ShipperService>();
            services.AddTransient<ISupplierService, SupplierService>();
            services.AddTransient<IProductService, ProductService>();

            services.AddTransient<IOrderService, OrderService>();

            services.AddTransient<IRoleService, RoleService>();
        }
    }
}
