using AutoMapper;
using Infrastructure.Database;
using Infrastructure.Entities;
using Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
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

        public async Task AddRangeAsync(IEnumerable<OrderModel> models)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteAsync(OrderModel model)
        {
            var entity = await _unitOfWork.OrderRepository.GetByIdAsync(model.Id);
            _unitOfWork.OrderRepository.Delete(entity);
        }

        public async Task<IEnumerable<OrderModel>> GetAllAsync()
        {
            var entities = _unitOfWork.OrderRepository.GetAll();
            return _mapper.Map<IEnumerable<OrderModel>>(entities);
        }

        public async Task<OrderModel> GetByIdAsync(string id)
        {
            var entity = await _unitOfWork.OrderRepository.GetByIdAsync(id);
            return _mapper.Map<OrderModel>(entity);
        }

        public Task<IEnumerable<OrderModel>> Pagination(Expression<Func<OrderModel, bool>> predicate)
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
