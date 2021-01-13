using AutoMapper;
using Infrastructure.Database;
using Infrastructure.Entities;
using Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class OrderService : IOrderService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public OrderService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task AddAsync(OrderModel model)
        {
            var entity = _mapper.Map<Order>(model);
            await _unitOfWork.OrderRepository.AddAsync(entity);
        }

        public async Task DeleteAsync(string id)
        {
            var entity =  await _unitOfWork.OrderRepository.FindByCondition(e => e.Id.Equals(id)).FirstOrDefaultAsync();
            _unitOfWork.OrderRepository.Delete(entity);
        }

        public async Task<IEnumerable<OrderModel>> GetAllAsync()
        {
            var entities = await _unitOfWork.OrderRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<OrderModel>>(entities);
        }

        public async Task<OrderModel> GetByIdAsync(string id)
        {
            var entity = await _unitOfWork.OrderRepository.FindByCondition(e => e.Id.Equals(id)).FirstOrDefaultAsync();
            return _mapper.Map<OrderModel>(entity);
        }

        public Task<IEnumerable<OrderModel>> Pagination(string categoryId, string keyword, string orderCol, string orderType, int? page = null, int? size = null)
        {
            throw new NotImplementedException();
        }

        public int SaveChanges()
        {
            return _unitOfWork.SaveChanges();
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _unitOfWork.SaveChangesAsync();
        }
    }
}
