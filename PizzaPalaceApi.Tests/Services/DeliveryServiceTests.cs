using Xunit;
using Moq;
using PizzaPalaceApi.Services;
using PizzaPalaceApi.Models;
using PizzaPalaceApi.Repositories;

namespace PizzaPalaceApi.Tests.Services
{
    public class DeliveryServiceTests
    {
        private readonly Mock<IDeliveryRepository> _mockDeliveryRepository;
        private readonly DeliveryService _deliveryService;

        public DeliveryServiceTests()
        {
            _mockDeliveryRepository = new Mock<IDeliveryRepository>();
            _deliveryService = new DeliveryService(_mockDeliveryRepository.Object);
        }

        [Fact]
        public void ScheduleDelivery_ShouldAddDelivery_WhenCalled()
        {
            // Arrange
            var delivery = new Delivery
            {
                DeliveryId = 1,
                OrderId = 1,
                DeliveryAddress = "123 Pizza St",
                DeliveryStatus = "Scheduled"
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
        public void GetDeliveryStatus_ShouldReturnDeliveryStatus_WhenDeliveryExists()
        {
            // Arrange
            var deliveryId = 1;
            var delivery = new Delivery
            {
                DeliveryId = deliveryId,
                OrderId = 1,
                DeliveryAddress = "123 Pizza St",
                DeliveryStatus = "In Transit"
            };

            _mockDeliveryRepository.Setup(repo => repo.GetDeliveryById(deliveryId)).Returns(delivery);

            // Act
            var result = _deliveryService.GetDeliveryStatus(deliveryId);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(delivery.DeliveryStatus, result.DeliveryStatus);
            _mockDeliveryRepository.Verify(repo => repo.GetDeliveryById(deliveryId), Times.Once);
        }

        [Fact]
        public void GetDeliveryStatus_ShouldReturnNull_WhenDeliveryDoesNotExist()
        {
            // Arrange
            var deliveryId = 999; // Non-existing delivery ID
            _mockDeliveryRepository.Setup(repo => repo.GetDeliveryById(deliveryId)).Returns((Delivery)null);

            // Act
            var result = _deliveryService.GetDeliveryStatus(deliveryId);

            // Assert
            Assert.Null(result);
            _mockDeliveryRepository.Verify(repo => repo.GetDeliveryById(deliveryId), Times.Once);
        }
    }
}