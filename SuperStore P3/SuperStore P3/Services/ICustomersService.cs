using Models;

namespace EcoPower_Logistics.Services
{
    //Customers interface that will be used by the customers repository
    public interface ICustomersService
    {
        IEnumerable<Customer> GetAllCustomers();
        Customer GetCustomerById(int id);
        void AddCustomer(Customer entity);
        void UpdateCustomer(Customer entity);
        void DeleteCustomer(Customer entity);
    }
}
