using Models;

namespace EcoPower_Logistics.Services
{
    //OrderDetails interface that will be used by the order details repository
    public interface IOrderDetailsService
    {
        IEnumerable<OrderDetail> GetAllOrderDetails();
        OrderDetail GetOrderDetailsById(int id);
        void AddOrderDetails(OrderDetail entity);
        void UpdateOrderDetails(OrderDetail entity);
        void DeleteOrderDetails(OrderDetail entity);
    }
}
