using Models;

namespace EcoPower_Logistics.Repository
{
    public interface ICustomersRepository : IGenericRepository<Customer>
    {
        IEnumerable<Customer> GetAllCustomers();
        Customer GetCustomerById(int id);
        void AddCustomer(Customer entity);
        void UpdateCustomer(Customer entity);
        void DeleteCustomer(Customer entity);
    }
}
