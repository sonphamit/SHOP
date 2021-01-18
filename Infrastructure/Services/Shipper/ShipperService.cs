using AutoMapper;
using Infrastructure.Database;
using Infrastructure.Entities;
using Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class ShipperService : IShipperService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ShipperService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task AddAsync(ShipperModel model)
        {
            var entity = _mapper.Map<Shipper>(model);
            await _unitOfWork.ShipperRepository.AddAsync(entity);
            SaveChanges();
            _unitOfWork.ShipperRepository.Detach(entity);
        }

        public async Task DeleteAsync(string id)
        {
            var entity = await _unitOfWork.ShipperRepository.FindByCondition(cat => cat.Id.Equals(id)).FirstOrDefaultAsync();
            _unitOfWork.ShipperRepository.Delete(entity);
        }

        public IEnumerable<ShipperModel> GetAll()
        {
            var entities = _unitOfWork.ShipperRepository.GetAll();
            return _mapper.Map<IEnumerable<ShipperModel>>(entities).OrderBy(e => e.ShipperName);
        }

        public async Task<IEnumerable<ShipperModel>> GetAllAsync()
        {
            var entities = await _unitOfWork.ShipperRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<ShipperModel>>(entities).OrderBy(e => e.ShipperName);
        }

        public async Task<ShipperModel> GetByIdAsync(string id)
        {
            var entity = await _unitOfWork.ShipperRepository.FindByCondition(e => e.Id.Equals(id)).FirstOrDefaultAsync();
            return _mapper.Map<ShipperModel>(entity);
        }

        public ShipperModel GetById(string id)
        {
            var entity = _unitOfWork.ShipperRepository.FindByCondition(e => e.Id.Equals(id)).FirstOrDefault();
            return _mapper.Map<ShipperModel>(entity);
        }

        public int SaveChanges()
        {
            return _unitOfWork.SaveChanges();
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _unitOfWork.SaveChangesAsync();
        }

        public void Update(string id, ShipperModel model)
        {
            if (!string.IsNullOrWhiteSpace(id))
            {
                var originEntity = _unitOfWork.ShipperRepository.FindByCondition(e => e.Id.Equals(model.Id)).FirstOrDefault();
                var entityUpdate = _mapper.Map(model, originEntity);
                entityUpdate.Id = model.Id;
                _unitOfWork.ShipperRepository.Update(entityUpdate);
                SaveChanges();
                _unitOfWork.ShipperRepository.Detach(entityUpdate);
            }
        }
    }
}
