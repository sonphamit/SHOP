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
            var entity = await _unitOfWork.CustomerRepository.GetByIdAsync(id);
            _unitOfWork.CustomerRepository.Delete(entity);
        }

        public async Task<IEnumerable<CustomerModel>> GetAllAsync()
        {
            var entities = _unitOfWork.CustomerRepository.GetAll();
            return _mapper.Map<IEnumerable<CustomerModel>>(entities);
        }

        public async Task<CustomerModel> GetByIdAsync(string id)
        {
            var entity = await _unitOfWork.CustomerRepository.GetByIdAsync(id);
            return _mapper.Map<CustomerModel>(entity);
        }

        public Task<IEnumerable<CustomerModel>> Pagination(Expression<Func<CustomerModel, bool>> predicate)
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
