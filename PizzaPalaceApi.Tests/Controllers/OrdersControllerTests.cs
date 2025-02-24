using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using PizzaPalaceApi.Controllers;
using PizzaPalaceApi.Models;
using PizzaPalaceApi.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace PizzaPalaceApi.Tests.Controllers
{
    public class OrdersControllerTests
    {
        private readonly OrdersController _controller;
        private readonly Mock<IOrderRepository> _mockRepo;
        private readonly Mock<ILogger<OrdersController>> _mockLogger;

        public OrdersControllerTests()
        {
            _mockRepo = new Mock<IOrderRepository>();
            _mockLogger = new Mock<ILogger<OrdersController>>();
            _controller = new OrdersController(_mockRepo.Object, _mockLogger.Object);
        }

        [Fact]
        public async Task CreateOrder_ReturnsCreatedResult_WhenOrderIsValid()
        {
            var order = new Order { OrderId = 1, CustomerName = "John Doe", PizzaType = "Margherita", Quantity = 2 };
            _mockRepo.Setup(repo => repo.AddOrder(order)).ReturnsAsync(order);

            var result = await _controller.CreateOrder(order);

            var createdResult = Assert.IsType<CreatedAtActionResult>(result);
            Assert.Equal(order, createdResult.Value);
        }

        [Fact]
        public async Task GetOrder_ReturnsOkResult_WhenOrderExists()
        {
            var orderId = 1;
            var order = new Order { OrderId = orderId, CustomerName = "John Doe", PizzaType = "Margherita", Quantity = 2 };
            _mockRepo.Setup(repo => repo.GetOrderById(orderId)).ReturnsAsync(order);

            var result = await _controller.GetOrder(orderId);

            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(order, okResult.Value);
        }

        [Fact]
        public async Task GetAllOrders_ReturnsOkResult_WithListOfOrders()
        {
            var orders = new List<Order>
            {
                new Order { OrderId = 1, CustomerName = "John Doe", PizzaType = "Margherita", Quantity = 2 },
                new Order { OrderId = 2, CustomerName = "Jane Smith", PizzaType = "Pepperoni", Quantity = 1 }
            };
            _mockRepo.Setup(repo => repo.GetAllOrders()).ReturnsAsync(orders);

            var result = await _controller.GetAllOrders();

            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnedOrders = Assert.IsAssignableFrom<List<Order>>(okResult.Value);
            Assert.Equal(2, returnedOrders.Count);
        }
    }
}