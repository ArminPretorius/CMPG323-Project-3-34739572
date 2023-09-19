using Data;
using Models;

namespace EcoPower_Logistics.Repository
{
    public class CustomersRepository
    {
        protected readonly SuperStoreContext _context = new SuperStoreContext();

        public IEnumerable<Customer> GetAll()
        {
            return _context.Customers.ToList();
        }

        public Customer GetById(int id)
        {
            return _context.Customers.FirstOrDefault(x => x.CustomerId == id);
        }

        public void Add(Customer customer)
        {
            _context.Add(customer);
            _context.SaveChanges();
        }

        public void Update(Customer customer)
        {
            _context.Update(customer);
            _context.SaveChanges();
        }

        public void Delete(Customer customer)
        {
            _context.Remove(customer);
            _context.SaveChanges();
        }
    }
}
