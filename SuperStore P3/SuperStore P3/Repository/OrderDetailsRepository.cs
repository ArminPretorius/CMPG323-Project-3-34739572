using Models;

namespace EcoPower_Logistics.Repository
{
    //OrderDetails repository that will be used to interact with the database
    public class OrderDetailsRepository : GenericRepository<OrderDetail>, IOrderDetailsRepository
    {
        public IEnumerable<OrderDetail> GetAllOrderDetails()
        {
            return GetAll().ToList();
        }

        public OrderDetail GetOrderDetailById(int id)
        {
            return GetAll().FirstOrDefault(x => x.OrderDetailsId == id);
        }

        public void AddOrderDetail(OrderDetail entity)
        {
            Add(entity);
        }

        public void UpdateOrderDetail(OrderDetail entity)
        {
            Update(entity);
        }

        public void DeleteOrderDetail(OrderDetail entity)
        {
            Delete(entity);
        }
    }
}
