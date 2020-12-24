using Shared.Entities;
using System.Threading.Tasks;

namespace Infrastructure.Database
{
    public interface IUnitOfWork
    {
        Task<int> SaveChangesAsync();
        int SaveChanges();
    }
}
