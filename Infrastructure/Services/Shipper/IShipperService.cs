using Infrastructure.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public interface IShipperService
    {
        Task AddAsync(ShipperModel model);
        void Update(string id, ShipperModel model);

        Task<IEnumerable<ShipperModel>> GetAllAsync();
        IEnumerable<ShipperModel> GetAll();
        Task<ShipperModel> GetByIdAsync(string id);
        Task DeleteAsync(ShipperModel model);
        Task<int> SaveChangesAsync();
        int SaveChanges();
    }
}
