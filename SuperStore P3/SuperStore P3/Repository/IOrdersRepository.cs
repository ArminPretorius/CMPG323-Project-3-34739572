using Models;

namespace EcoPower_Logistics.Repository
{
    //Orders interface that will be used by the orders repository
    public interface IOrdersRepository : IGenericRepository<Order>
    {
        IEnumerable<Order> GetAllOrders();
        Order GetOrderById(int id);
        void AddOrder(Order entity);
        void UpdateOrder(Order entity);
        void DeleteOrder(Order entity);
    }
}
