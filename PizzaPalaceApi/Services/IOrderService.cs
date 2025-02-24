using PizzaPalaceApi.Models;

namespace PizzaPalaceApi.Services
{
    public interface IOrderService
    {
        Order PlaceOrder(Order order);
        Order GetOrderDetails(Guid orderId);
        IEnumerable<Order> GetAllOrders();
    }
}
