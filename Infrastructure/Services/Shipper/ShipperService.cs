using Infrastructure.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class ShipperService : IShipperService
    {
        public Task AddAsync(ShipperModel model)
        {
            throw new System.NotImplementedException();
        }

        public Task DeleteAsync(ShipperModel model)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<ShipperModel> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<ShipperModel>> GetAllAsync()
        {
            throw new System.NotImplementedException();
        }

        public Task<ShipperModel> GetByIdAsync(string id)
        {
            throw new System.NotImplementedException();
        }

        public int SaveChanges()
        {
            throw new System.NotImplementedException();
        }

        public Task<int> SaveChangesAsync()
        {
            throw new System.NotImplementedException();
        }

        public void Update(string id, ShipperModel model)
        {
            throw new System.NotImplementedException();
        }
    }
}
