using Xunit;
using Moq;
using PizzaPalaceApi.Models;
using PizzaPalaceApi.Repositories;
using System.Collections.Generic;

namespace PizzaPalaceApi.Tests.Repositories
{
    public class OrderRepositoryTests
    {
        private readonly Mock<IOrderRepository> _mockOrderRepository;

        public OrderRepositoryTests()
        {
            _mockOrderRepository = new Mock<IOrderRepository>();
        }

        [Fact]
        public void AddOrder_ShouldAddOrder()
        {
            // Arrange
            var order = new Order { OrderId = 1, CustomerName = "John Doe", PizzaType = "Margherita", Quantity = 2 };
            _mockOrderRepository.Setup(repo => repo.AddOrder(order)).Returns(order);

            // Act
            var result = _mockOrderRepository.Object.AddOrder(order);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(order.OrderId, result.OrderId);
        }

        [Fact]
        public void GetOrderById_ShouldReturnOrder()
        {
            // Arrange
            var order = new Order { OrderId = 1, CustomerName = "John Doe", PizzaType = "Margherita", Quantity = 2 };
            _mockOrderRepository.Setup(repo => repo.GetOrderById(1)).Returns(order);

            // Act
            var result = _mockOrderRepository.Object.GetOrderById(1);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(order.OrderId, result.OrderId);
        }

        [Fact]
        public void GetAllOrders_ShouldReturnListOfOrders()
        {
            // Arrange
            var orders = new List<Order>
            {
                new Order { OrderId = 1, CustomerName = "John Doe", PizzaType = "Margherita", Quantity = 2 },
                new Order { OrderId = 2, CustomerName = "Jane Smith", PizzaType = "Pepperoni", Quantity = 1 }
            };
            _mockOrderRepository.Setup(repo => repo.GetAllOrders()).Returns(orders);

            // Act
            var result = _mockOrderRepository.Object.GetAllOrders();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(2, result.Count);
        }
    }
}