using Data;
using Models;

namespace EcoPower_Logistics.Repository
{
    public class OrdersRepository
    {
        protected readonly SuperStoreContext _context = new SuperStoreContext();

        public IEnumerable<Order> GetAll()
        {
            return _context.Orders.ToList();
        }

        public Order GetById(int id)
        {
            return _context.Orders.FirstOrDefault(x => x.OrderId == id);
        }

        public void Add(Order order)
        {
            _context.Add(order);
            _context.SaveChanges();
        }
    }
}
