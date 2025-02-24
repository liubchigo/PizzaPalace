using PizzaPalaceApi.Models;

namespace PizzaPalaceApi.Services
{
    public interface IOrderService
    {
        Order PlaceOrder(Order order);
        Order GetOrderDetails(int orderId);
        IEnumerable<Order> GetAllOrders();
    }
}
