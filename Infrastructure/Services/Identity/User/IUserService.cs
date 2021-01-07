using Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public interface IUserService
    {
        Task AddAsync(UserModel model);
        Task AddRangeAsync(IEnumerable<UserModel> models);
        Task<IEnumerable<UserModel>> GetAllAsync();
        Task<UserModel> GetByIdAsync(string id);

        Task<UserModel> LoginAsync(string email, string password);
        Task<IEnumerable<UserModel>> Pagination(Expression<Func<UserModel, bool>> predicate);
        Task DeleteAsync(UserModel model);
        Task<int> SaveChangesAsync();
        int SaveChanges();
    }

}
