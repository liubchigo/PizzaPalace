using PizzaPalaceApi.Models;

namespace PizzaPalaceApi.Repositories
{
    public interface IOrderRepository
    {
        void AddOrder(Order order);
        Order GetOrderById(Guid orderId);
        IEnumerable<Order> GetAllOrders();
    }
}