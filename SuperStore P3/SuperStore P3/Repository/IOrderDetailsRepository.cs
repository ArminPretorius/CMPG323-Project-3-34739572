using Models;

namespace EcoPower_Logistics.Repository
{
    //OrderDetails interface that will be used by the order details repository
    public interface IOrderDetailsRepository : IGenericRepository<OrderDetail>
    {
        IEnumerable<OrderDetail> GetAllOrderDetails();
        OrderDetail GetOrderDetailById(int id);
        void AddOrderDetail(OrderDetail entity);
        void UpdateOrderDetail(OrderDetail entity);
        void DeleteOrderDetail(OrderDetail entity);
    }
}
