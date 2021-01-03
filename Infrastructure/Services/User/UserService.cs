using Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class UserService : IUserService
    {
        public Task AddAsync(UserModel model)
        {
            throw new NotImplementedException();
        }

        public Task AddRangeAsync(IEnumerable<UserModel> models)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(UserModel model)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<UserModel>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<UserModel> GetByIdAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<UserModel> LoginAsync(string email, string password)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<UserModel>> Pagination(Expression<Func<UserModel, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public int SaveChanges()
        {
            throw new NotImplementedException();
        }

        public Task<int> SaveChangesAsync()
        {
            throw new NotImplementedException();
        }
    }
}
