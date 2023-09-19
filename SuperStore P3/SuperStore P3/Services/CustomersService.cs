using Models;
using EcoPower_Logistics.Repository;

namespace EcoPower_Logistics.Services
{
    public class CustomersService : ICustomersService
    {
        private readonly ICustomersRepository _customersRepository;

        public CustomersService(ICustomersRepository customersRepository)
        {
            _customersRepository = customersRepository;
        }

        public IEnumerable<Customer> GetAllCustomers()
        {
            return _customersRepository.GetAll().ToList();
        }

        public Customer GetCustomerById(int id)
        {
            return _customersRepository.GetAll().FirstOrDefault(x => x.CustomerId == id);
        }

        public void AddCustomer(Customer entity)
        {
            _customersRepository.Add(entity);
        }

        public void UpdateCustomer(Customer entity)
        {
            _customersRepository.Update(entity);
        }

        public void DeleteCustomer(Customer entity)
        {
            _customersRepository.Delete(entity);
        }
    }
}
