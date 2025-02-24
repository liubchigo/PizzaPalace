using PizzaPalaceApi.Models;
using PizzaPalaceApi.Repositories;

namespace PizzaPalaceApi.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;

        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public Order PlaceOrder(Order order)
        {
            // Validate the order details
            if (string.IsNullOrWhiteSpace(order.CustomerName) || order.Quantity <= 0)
            {
                throw new ArgumentException("Invalid order details.");
            }

            // Add the order to the repository
            _orderRepository.AddOrder(order);
            return order;
        }

        public Order GetOrderDetails(Guid orderId)
        {
            // Retrieve the order from the repository
            var order = _orderRepository.GetOrderById(orderId);
            if (order == null)
            {
                throw new KeyNotFoundException("Order not found.");
            }

            return order;
        }

        public IEnumerable<Order> GetAllOrders()
        {
            // Retrieve all orders from the repository
            return _orderRepository.GetAllOrders();
        }
    }
}