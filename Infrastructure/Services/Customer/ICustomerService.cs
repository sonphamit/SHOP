﻿using Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
namespace Infrastructure.Services
{
    public interface ICustomerService 
    {
        Task AddAsync(CustomerModel model);
        Task AddRangeAsync(IEnumerable<CustomerModel> models);
        Task<IEnumerable<CustomerModel>> GetAllAsync();
        Task<CustomerModel> GetByIdAsync(string id);
        Task<IEnumerable<CustomerModel>> Pagination(string categoryId, string keyword, string orderCol, string orderType, int? page = null, int? size = null);
        Task DeleteAsync(string id);
        Task<int> SaveChangesAsync();
        int SaveChanges();

    }
}
