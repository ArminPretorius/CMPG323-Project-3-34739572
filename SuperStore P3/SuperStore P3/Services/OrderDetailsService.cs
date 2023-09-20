using Models;
using EcoPower_Logistics.Repository;

namespace EcoPower_Logistics.Services
{
    //OrderDetails service that will be used by the OrderDetails controller
    public class OrderDetailsService : IOrderDetailsService
    {
        private readonly IOrderDetailsRepository _orderDetailsRepository;

        public OrderDetailsService(IOrderDetailsRepository orderDetailsRepository)
        {
            _orderDetailsRepository = orderDetailsRepository;
        }

        public IEnumerable<OrderDetail> GetAllOrderDetails()
        {
            return _orderDetailsRepository.GetAll().ToList();
        }

        public OrderDetail GetOrderDetailsById(int id)
        {
            return _orderDetailsRepository.GetAll().FirstOrDefault(x => x.OrderDetailsId == id);
        }

        public void AddOrderDetails(OrderDetail entity)
        {
            _orderDetailsRepository.Add(entity);
        }

        public void UpdateOrderDetails(OrderDetail entity)
        {
            _orderDetailsRepository.Update(entity);
        }

        public void DeleteOrderDetails(OrderDetail entity)
        {
            _orderDetailsRepository.Delete(entity);
        }
    }
}
