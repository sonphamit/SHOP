﻿using Infrastructure.Database;
using Infrastructure.Entities;
using Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Store.Configuration
{
    public static class ServicesDependency
    {
        public static void AddServicesDependency(this IServiceCollection services)
        {

            services.AddTransient<IUnitOfWork, UnitOfWork>();

            services.AddTransient<IRepository<Category>, Repository<Category>>();
            services.AddTransient<IRepository<Customer>, Repository<Customer>>();
            services.AddTransient<IRepository<Employee>, Repository<Employee>>();
            services.AddTransient<IRepository<ApplicationUser>, Repository<ApplicationUser>>();
            services.AddTransient<IRepository<Shipper>, Repository<Shipper>>();
            services.AddTransient<IRepository<Supplier>, Repository<Supplier>>();
            services.AddTransient<IRepository<Product>, Repository<Product>>();
            services.AddTransient<IRepository<Order>, Repository<Order>>();
            services.AddTransient<IRepository<OrderDetail>, Repository<OrderDetail>>();
            services.AddTransient<IRepository<Resource>, Repository<Resource>>();

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
