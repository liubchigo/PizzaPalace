using Xunit;
using Moq;
using PizzaPalaceApi.Models;
using PizzaPalaceApi.Repositories;
using PizzaPalaceApi.Services;
using System.Collections.Generic;

namespace PizzaPalaceApi.Tests.Services
{
    public class OrderServiceTests
    {
        private readonly Mock<IOrderRepository> _orderRepositoryMock;
        private readonly OrderService _orderService;

        public OrderServiceTests()
        {
            _orderRepositoryMock = new Mock<IOrderRepository>();
            _orderService = new OrderService(_orderRepositoryMock.Object);
        }

        [Fact]
        public void PlaceOrder_ShouldAddOrder_WhenOrderIsValid()
        {
            // Arrange
            var order = new Order { OrderId = 1, CustomerName = "John Doe", PizzaType = "Margherita", Quantity = 2 };
            _orderRepositoryMock.Setup(repo => repo.AddOrder(order)).Returns(order);

            // Act
            var result = _orderService.PlaceOrder(order);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(order.OrderId, result.OrderId);
            _orderRepositoryMock.Verify(repo => repo.AddOrder(order), Times.Once);
        }

        [Fact]
        public void GetOrderDetails_ShouldReturnOrder_WhenOrderExists()
        {
            // Arrange
            var orderId = 1;
            var order = new Order { OrderId = orderId, CustomerName = "John Doe", PizzaType = "Margherita", Quantity = 2 };
            _orderRepositoryMock.Setup(repo => repo.GetOrderById(orderId)).Returns(order);

            // Act
            var result = _orderService.GetOrderDetails(orderId);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(orderId, result.OrderId);
            _orderRepositoryMock.Verify(repo => repo.GetOrderById(orderId), Times.Once);
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
            _orderRepositoryMock.Setup(repo => repo.GetAllOrders()).Returns(orders);

            // Act
            var result = _orderService.GetAllOrders();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(2, result.Count);
            _orderRepositoryMock.Verify(repo => repo.GetAllOrders(), Times.Once);
        }
    }
}