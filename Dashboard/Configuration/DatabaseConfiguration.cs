﻿using Microsoft.Extensions.DependencyInjection;
using SHOP.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace Dashboard.Configuration
{
    public static class DatabaseConfiguration
    {
        public static void AddAppDatabase(this IServiceCollection services, string connectionString) =>
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString));
    }
}
