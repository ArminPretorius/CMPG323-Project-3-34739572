using Data;
using Models;

namespace EcoPower_Logistics.Repository
{
    public class OrdersRepository : GenericRepository<Order>, IOrdersRepository
    {
        public IEnumerable<Order> GetAllOrders()
        {
            return GetAll().ToList();
        }

        public Order GetOrderById(int id)
        {
            return GetAll().FirstOrDefault(x => x.OrderId == id);
        }

        public void AddOrder(Order entity)
        {
            Add(entity);
        }

        public void UpdateOrder(Order entity)
        {
            Update(entity);
        }

        public void DeleteOrder(Order entity)
        {
            Delete(entity);
        }
    }
}
