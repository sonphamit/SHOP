using AutoMapper;
using Infrastructure.Database;
using Infrastructure.Entities;
using Infrastructure.Enums;
using Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class OrderService : IOrderService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IProductService _productService;

        public OrderService(IUnitOfWork unitOfWork, IMapper mapper, IProductService productService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _productService = productService;
        }

        public async Task<string> AddAsync(OrderRequestModel model)
        {
            var entity = _mapper.Map<Order>(model);
            entity.OrderDetails.ToList().ForEach(item => item.OrderId = entity.Id);

            await _unitOfWork.OrderRepository.AddAsync(entity);
            //await _unitOfWork.OrderDetailRepository.AddRangeAsync(entity.OrderDetails);
            SaveChanges();
            _unitOfWork.OrderRepository.Detach(entity);
            return entity.Id;
        }



        public async Task DeleteAsync(string id)
        {

            var entityDelete = await _unitOfWork.OrderRepository.FindByCondition(e => e.Id.Equals(id)).FirstOrDefaultAsync();

            _unitOfWork.OrderRepository.Delete(entityDelete);
        }

        public IEnumerable<OrderResponseModel> GetAll()
        {
            var entities = _unitOfWork.OrderRepository.GetAll();
            return _mapper.Map<IEnumerable<OrderResponseModel>>(entities).OrderBy(e => e.OrderDate);
        }

        public Task<IEnumerable<OrderResponseModel>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public OrderResponseModel GetById(string id)
        {
            var entity = _unitOfWork.OrderRepository.FindByCondition(e => e.Id == id)
                .Include(i => i.OrderDetails).FirstOrDefault();

            var model = _mapper.Map<OrderResponseModel>(entity);
            _unitOfWork.OrderRepository.Detach(entity);
            return model;
        }

        public async Task<OrderResponseModel> GetByIdAsync(string id)
        {
            var entity = await _unitOfWork.OrderRepository.FindByCondition(e => e.Id == id)
                .Include(x => x.OrderDetails).ThenInclude(x => x.Product).ThenInclude(x => x.Images).FirstOrDefaultAsync();
            var model = _mapper.Map<OrderResponseModel>(entity);
            return model;
        }

        public async Task<OrderResponseModel> GetByCustomerIdOrderingAsync(string id)
        {
            var entity = await _unitOfWork.OrderRepository.FindByCondition(e => e.CustomerId == id && e.Status == OrderStatus.ORDERING)
                .Include(x => x.OrderDetails).ThenInclude(x => x.Product).ThenInclude(x => x.Images).FirstOrDefaultAsync();
            var model = _mapper.Map<OrderResponseModel>(entity);
            return model;
        }

        public async Task<OrderResponseModel> GetByIdOrderingAsync(string id)
        {
            var entity = await _unitOfWork.OrderRepository.FindByCondition(e => e.Id == id && e.Status == OrderStatus.ORDERING)
                .Include(x => x.OrderDetails).ThenInclude(x => x.Product).ThenInclude(x => x.Images).FirstOrDefaultAsync();
            var model = _mapper.Map<OrderResponseModel>(entity);
            return model;
        }

        public int SaveChanges()
        {
            return _unitOfWork.SaveChanges();
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _unitOfWork.SaveChangesAsync();
        }

        public void Update(string id, OrderRequestModel model)
        {
            if (!string.IsNullOrWhiteSpace(id))
            {
                var originEntity = _unitOfWork.OrderRepository.FindByCondition(cat => cat.Id.Equals(model.Id)).FirstOrDefault();
                var entityUpdate = _mapper.Map(model, originEntity);
                entityUpdate.Id = model.Id;
                _unitOfWork.OrderRepository.Update(entityUpdate);
                SaveChanges();
                _unitOfWork.OrderRepository.Detach(entityUpdate);
            }
        }

        public async Task<bool> UpdateAsync(string id, OrderRequestModel model)
        {
            if (!string.IsNullOrWhiteSpace(id))
            {

                var originEntity = _unitOfWork.OrderRepository.FindByCondition(cat => cat.Id.Equals(model.Id)).FirstOrDefault();

                var entityUpdate = _mapper.Map(model, originEntity);
                entityUpdate.Id = model.Id;

                _unitOfWork.OrderRepository.Update(entityUpdate);

                await SaveChangesAsync();
                _unitOfWork.OrderRepository.Detach(entityUpdate);
                entityUpdate.OrderDetails.ToList().ForEach(item => _unitOfWork.OrderDetailRepository.Detach(item));
                return true;
            }
            return false;
        }

        public async Task<OrderResponseModel> UpdateExistingOrder(string productId, int quantity, string? orderId = null, string? id = null)
        {
            //var order = await GetByIdAsync(orderId);
            var order = _unitOfWork.OrderRepository.FindByCondition(cat => cat.Id.Equals(orderId)).Include(x => x.OrderDetails).FirstOrDefault();
            if (order != null)
            {
                var cartItem = order.OrderDetails.Where(p => p.ProductId == productId).FirstOrDefault();
                order.CustomerId = id;
                if (cartItem != null)
                {
                    order.OrderDetails.Where(p => p.ProductId == productId).FirstOrDefault().Quantity = quantity;
                }
                else
                {

                    var product = await _productService.GetByIdAsync(productId);
                    if (product != null)
                    {
                        var orderDetail = new OrderDetail()
                        {
                            OrderId = orderId,
                            Quantity = quantity,
                            ProductId = productId,
                            UnitPrice = product.UnitPrice
                        };
                        //order.OrderDetails.Add(orderDetail);
                        await _unitOfWork.OrderDetailRepository.AddAsync(orderDetail);
                    }
                }

                await SaveChangesAsync();
            }

            var newOrder = _unitOfWork.OrderRepository.FindByCondition(cat => cat.Id.Equals(orderId)).Include(x => x.OrderDetails).FirstOrDefault();
            return _mapper.Map<OrderResponseModel>(newOrder);
        }

        public async Task<OrderResponseModel> AddNewOrder(string productId, int quantity, string? id = null)
        {
            var product = await _productService.GetByIdAsync(productId);
            string orderId = "";
            if (product != null)
            {
                var order = new OrderRequestModel()
                {
                    Status = OrderStatus.ORDERING,
                    CustomerId = id,
                };

                var orderDetailItem = new OrderDetailModel() { Quantity = quantity, ProductId = productId, UnitPrice = product.UnitPrice };

                order.OrderDetails.Add(orderDetailItem);

                orderId = await AddAsync(order);
            }

            if (!string.IsNullOrWhiteSpace(orderId))
            {
                var entity = await GetByIdAsync(orderId);
                return entity;
            }
            return null;
        }
    }
}
