using Infrastructure.Entities;
using System.Threading.Tasks;

namespace Infrastructure.Database
{
    public interface IUnitOfWork
    {
        public IRepository<Customer> CustomerRepository { get; }
        public IRepository<Category> CategoryRepository { get; }
        public IRepository<Employee> EmployeeRepository { get; }
        public IRepository<Order> OrderRepository { get; }
        public IRepository<OrderDetail> OrderDetailRepository { get; }
        public IRepository<Product> ProductRepository { get; }
        public IRepository<Shipper> ShipperRepository { get; }
        public IRepository<Supplier> SupplierRepository { get; }

        Task<int> SaveChangesAsync();
        int SaveChanges();
    }
}
