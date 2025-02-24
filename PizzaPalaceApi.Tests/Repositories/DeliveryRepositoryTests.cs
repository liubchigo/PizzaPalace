using Xunit;
using Moq;
using PizzaPalaceApi.Models;
using PizzaPalaceApi.Repositories;
using PizzaPalaceApi.Services;

namespace PizzaPalaceApi.Tests.Repositories
{
    public class DeliveryRepositoryTests
    {
        private readonly Mock<IDeliveryRepository> _mockDeliveryRepository;
        private readonly DeliveryService _deliveryService;

        public DeliveryRepositoryTests()
        {
            _mockDeliveryRepository = new Mock<IDeliveryRepository>();
            _deliveryService = new DeliveryService(_mockDeliveryRepository.Object);
        }

        [Fact]
        public void AddDelivery_ShouldAddDelivery()
        {
            // Arrange
            var delivery = new Delivery
            {
                DeliveryId = 1,
                OrderId = 1,
                DeliveryAddress = "123 Pizza St",
                DeliveryStatus = "Pending"
            };

            _mockDeliveryRepository.Setup(repo => repo.AddDelivery(delivery)).Returns(delivery);

            // Act
            var result = _deliveryService.ScheduleDelivery(delivery);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(delivery.DeliveryId, result.DeliveryId);
            _mockDeliveryRepository.Verify(repo => repo.AddDelivery(delivery), Times.Once);
        }

        [Fact]
        public void GetDeliveryById_ShouldReturnDelivery()
        {
            // Arrange
            var deliveryId = 1;
            var delivery = new Delivery
            {
                DeliveryId = deliveryId,
                OrderId = 1,
                DeliveryAddress = "123 Pizza St",
                DeliveryStatus = "Pending"
            };

            _mockDeliveryRepository.Setup(repo => repo.GetDeliveryById(deliveryId)).Returns(delivery);

            // Act
            var result = _deliveryService.GetDeliveryStatus(deliveryId);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(deliveryId, result.DeliveryId);
            _mockDeliveryRepository.Verify(repo => repo.GetDeliveryById(deliveryId), Times.Once);
        }

        [Fact]
        public void GetAllDeliveries_ShouldReturnAllDeliveries()
        {
            // Arrange
            var deliveries = new List<Delivery>
            {
                new Delivery { DeliveryId = 1, OrderId = 1, DeliveryAddress = "123 Pizza St", DeliveryStatus = "Pending" },
                new Delivery { DeliveryId = 2, OrderId = 2, DeliveryAddress = "456 Pasta Ave", DeliveryStatus = "Delivered" }
            };

            _mockDeliveryRepository.Setup(repo => repo.GetAllDeliveries()).Returns(deliveries);

            // Act
            var result = _deliveryService.GetAllDeliveries();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(2, result.Count());
            _mockDeliveryRepository.Verify(repo => repo.GetAllDeliveries(), Times.Once);
        }
    }
}