using Models;

namespace EcoPower_Logistics.Services
{
    //Orders interface that will be used by the orders repository
    public interface IOrdersService
    {
        IEnumerable<Order> GetAllOrders();
        Order GetOrderById(int id);
        void AddOrder(Order entity);
        void UpdateOrder(Order entity);
        void DeleteOrder(Order entity);
    }
}
