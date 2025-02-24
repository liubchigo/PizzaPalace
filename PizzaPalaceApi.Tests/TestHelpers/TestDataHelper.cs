using System.Collections.Generic;
using PizzaPalaceApi.Models;

namespace PizzaPalaceApi.Tests.TestHelpers
{
    public static class TestDataHelper
    {
        public static Order GetSampleOrder()
        {
            return new Order
            {
                OrderId = 1,
                CustomerName = "John Doe",
                PizzaType = "Margherita",
                Quantity = 2
            };
        }

        public static List<Order> GetSampleOrders()
        {
            return new List<Order>
            {
                new Order { OrderId = 1, CustomerName = "John Doe", PizzaType = "Margherita", Quantity = 2 },
                new Order { OrderId = 2, CustomerName = "Jane Smith", PizzaType = "Pepperoni", Quantity = 1 },
                new Order { OrderId = 3, CustomerName = "Alice Johnson", PizzaType = "Veggie", Quantity = 3 }
            };
        }

        public static Delivery GetSampleDelivery()
        {
            return new Delivery
            {
                DeliveryId = 1,
                OrderId = 1,
                DeliveryAddress = "123 Pizza Lane",
                DeliveryStatus = "In Progress"
            };
        }

        public static List<Delivery> GetSampleDeliveries()
        {
            return new List<Delivery>
            {
                new Delivery { DeliveryId = 1, OrderId = 1, DeliveryAddress = "123 Pizza Lane", DeliveryStatus = "In Progress" },
                new Delivery { DeliveryId = 2, OrderId = 2, DeliveryAddress = "456 Pasta Ave", DeliveryStatus = "Delivered" }
            };
        }
    }
}