using Data;
using Models;

namespace EcoPower_Logistics.Repository
{
    //Customers repository that will be used to interact with the database
    public class CustomersRepository : GenericRepository<Customer>, ICustomersRepository
    {
        public IEnumerable<Customer> GetAllCustomers()
        {
            return GetAll().ToList();
        }

        public Customer GetCustomerById(int id)
        {
            return GetAll().FirstOrDefault(x => x.CustomerId == id);
        }

        public void AddCustomer(Customer entity)
        {
            Add(entity);
        }

        public void UpdateCustomer(Customer entity)
        {
            Update(entity);
        }

        public void DeleteCustomer(Customer entity)
        {
            Delete(entity);
        }
    }
}
