using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using PizzaPalaceApi.Controllers;
using PizzaPalaceApi.Models;
using PizzaPalaceApi.Services;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace PizzaPalaceApi.Tests.Controllers
{
    public class DeliveriesControllerTests
    {
        private readonly DeliveriesController _controller;
        private readonly Mock<IDeliveryService> _mockService;
        private readonly Mock<ILogger<DeliveriesController>> _mockLogger;

        public DeliveriesControllerTests()
        {
            _mockService = new Mock<IDeliveryService>();
            _mockLogger = new Mock<ILogger<DeliveriesController>>();
            _controller = new DeliveriesController(_mockService.Object, _mockLogger.Object);
        }

        [Fact]
        public async Task CreateDelivery_ReturnsCreatedDelivery()
        {
            // Arrange
            var delivery = new Delivery { DeliveryId = 1, OrderId = 1, DeliveryAddress = "123 Pizza St", DeliveryStatus = "Pending" };
            _mockService.Setup(service => service.ScheduleDelivery(It.IsAny<Delivery>())).ReturnsAsync(delivery);

            // Act
            var result = await _controller.CreateDelivery(delivery);

            // Assert
            var actionResult = Assert.IsType<ActionResult<Delivery>>(result);
            var createdResult = Assert.IsType<CreatedAtActionResult>(actionResult.Result);
            Assert.Equal(delivery, createdResult.Value);
        }

        [Fact]
        public async Task GetDelivery_ReturnsDelivery()
        {
            // Arrange
            var deliveryId = 1;
            var delivery = new Delivery { DeliveryId = deliveryId, OrderId = 1, DeliveryAddress = "123 Pizza St", DeliveryStatus = "Pending" };
            _mockService.Setup(service => service.GetDeliveryById(deliveryId)).ReturnsAsync(delivery);

            // Act
            var result = await _controller.GetDelivery(deliveryId);

            // Assert
            var actionResult = Assert.IsType<ActionResult<Delivery>>(result);
            Assert.Equal(delivery, actionResult.Value);
        }

        [Fact]
        public async Task GetAllDeliveries_ReturnsListOfDeliveries()
        {
            // Arrange
            var deliveries = new List<Delivery>
            {
                new Delivery { DeliveryId = 1, OrderId = 1, DeliveryAddress = "123 Pizza St", DeliveryStatus = "Pending" },
                new Delivery { DeliveryId = 2, OrderId = 2, DeliveryAddress = "456 Pasta Ave", DeliveryStatus = "Delivered" }
            };
            _mockService.Setup(service => service.GetAllDeliveries()).ReturnsAsync(deliveries);

            // Act
            var result = await _controller.GetAllDeliveries();

            // Assert
            var actionResult = Assert.IsType<ActionResult<IEnumerable<Delivery>>>(result);
            Assert.Equal(deliveries, actionResult.Value);
        }
    }
}