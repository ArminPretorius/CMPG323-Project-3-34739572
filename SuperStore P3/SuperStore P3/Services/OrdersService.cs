using EcoPower_Logistics.Repository;
using Models;

namespace EcoPower_Logistics.Services
{
    public class OrdersService : IOrdersService
    {
        private readonly IOrdersRepository _ordersRepository;

        public OrdersService(IOrdersRepository ordersRepository)
        {
            _ordersRepository = ordersRepository;
        }

        public IEnumerable<Order> GetAllOrders()
        {
            return _ordersRepository.GetAll().ToList();
        }

        public Order GetOrderById(int id)
        {
            return _ordersRepository.GetAll().FirstOrDefault(x => x.OrderId == id);
        }

        public void AddOrder(Order entity)
        {
            _ordersRepository.Add(entity);
        }

        public void UpdateOrder(Order entity)
        {
            _ordersRepository.Update(entity);
        }

        public void DeleteOrder(Order entity)
        {
            _ordersRepository.Delete(entity);
        }
    }
}
