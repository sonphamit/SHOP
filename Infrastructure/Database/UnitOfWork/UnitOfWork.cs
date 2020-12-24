using Infrastructure.Entities;
using System;
using System.Threading.Tasks;

namespace Infrastructure.Database
{
    public class UnitOfWork : IDisposable, IUnitOfWork
    {

        public readonly ApplicationDbContext dbContext;

        
        public IRepository<Customer> CustomerRepository { get; }
        public IRepository<Category> CategoryRepository { get; }
        public IRepository<Employee> EmployeeRepository { get; }
        public IRepository<Order> OrderRepository { get; }
        public IRepository<OrderDetail> OrderDetailRepository { get; }
        public IRepository<Product> ProductRepository { get; }
        public IRepository<Shipper> ShipperRepository { get; }
        public IRepository<Supplier> SupplierRepository { get; }

        

        public int SaveChanges()
        {
            return dbContext.SaveChanges();
        }

        public async Task<int> SaveChangesAsync()
        {
            return await dbContext.SaveChangesAsync();
        }

        private bool disposed = false;

        public UnitOfWork(ApplicationDbContext dbContext,
            IRepository<Customer> customerRepository,
            IRepository<Category> categoryRepository,
            IRepository<Employee> employeeRepository,
            IRepository<Order> orderRepository,
            IRepository<OrderDetail> orderDetailRepository,
            IRepository<Product> productRepository,
            IRepository<Shipper> shipperRepository,
            IRepository<Supplier> supplierRepository)
        {
            this.dbContext = dbContext;

            CustomerRepository = customerRepository;
            CustomerRepository.DbContext = dbContext;

            CategoryRepository = categoryRepository;
            CategoryRepository.DbContext = dbContext;

            EmployeeRepository = employeeRepository;
            EmployeeRepository.DbContext = dbContext;

            OrderRepository = orderRepository;
            OrderRepository.DbContext = dbContext;

            OrderDetailRepository = orderDetailRepository;
            OrderDetailRepository.DbContext = dbContext;

            ProductRepository = productRepository;
            ProductRepository.DbContext = dbContext;

            ShipperRepository = shipperRepository;
            ShipperRepository.DbContext = dbContext;

            SupplierRepository = supplierRepository;
            SupplierRepository.DbContext = dbContext;
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects)
                    dbContext.Dispose();
                }

                // TODO: free unmanaged resources (unmanaged objects) and override finalizer
                // TODO: set large fields to null
                disposed = true;
            }
        }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
        
    }
}
