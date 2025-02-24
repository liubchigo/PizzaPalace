using PizzaPalaceApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PizzaPalaceApi.Services
{
    public class OrderService : IOrderService
    {
        private static List<Order> orders = new List<Order>();

        public Order PlaceOrder(Order order)
        {
            // Validate the order details
            if (string.IsNullOrWhiteSpace(order.CustomerName) || order.Quantity <= 0)
            {
                throw new ArgumentException("Invalid order details.");
            }

            // Add the order to the list
            order.OrderId = orders.Count > 0 ? orders.Max(o => o.OrderId) + 1 : 1;
            orders.Add(order);
            return order;
        }

        public Order GetOrderDetails(int orderId)
        {
            // Retrieve the order from the list
            var order = orders.FirstOrDefault(o => o.OrderId == orderId);
            if (order == null)
            {
                throw new KeyNotFoundException("Order not found.");
            }

            return order;
        }

        public IEnumerable<Order> GetAllOrders()
        {
            // Retrieve all orders from the list
            return orders;
        }
    }
}