using Models;

namespace EcoPower_Logistics.Services
{
    public interface IOrdersService
    {
        IEnumerable<Order> GetAllOrders();
        Order GetOrderById(int id);
        void AddOrder(Order entity);
        void UpdateOrder(Order entity);
        void DeleteOrder(Order entity);
    }
}
