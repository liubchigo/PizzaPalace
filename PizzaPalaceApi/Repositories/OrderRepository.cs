using PizzaPalaceApi.Models;
using System.Collections.Generic;
using System.Linq;

namespace PizzaPalaceApi.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly List<Order> _orders = new List<Order>();

        public void AddOrder(Order order)
        {
            _orders.Add(order);
        }

        public Order GetOrderById(Guid orderId)
        {
            return _orders.FirstOrDefault(o => o.OrderId == orderId);
        }

        public IEnumerable<Order> GetAllOrders()
        {
            return _orders;
        }
    }
}