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
    public class CustomerService : ICustomerService
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public CustomerService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task AddAsync(CustomerModel model)
        {
            var entity = _mapper.Map<Customer>(model);
            await _unitOfWork.CustomerRepository.AddAsync(entity);
        }

        public Task AddRangeAsync(IEnumerable<CustomerModel> models)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteAsync(string id)
        {
            var entity = await _unitOfWork.CustomerRepository.FindByCondition(e => e.Id == id).FirstOrDefaultAsync();
            _unitOfWork.CustomerRepository.Delete(entity);
        }

        public async Task<IEnumerable<CustomerModel>> GetAllAsync()
        {
            var entities = _unitOfWork.CustomerRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<CustomerModel>>(entities);
        }

        public async Task<CustomerModel> GetByIdAsync(string id)
        {
            var entity = await _unitOfWork.CustomerRepository.FindByCondition(e => e.Id == id).FirstOrDefaultAsync();
            return _mapper.Map<CustomerModel>(entity);
        }

        public Task<IEnumerable<CustomerModel>> Pagination(string categoryId, string keyword, string orderCol, string orderType, int? page = null, int? size = null)
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
