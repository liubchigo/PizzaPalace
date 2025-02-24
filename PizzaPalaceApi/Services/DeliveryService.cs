using PizzaPalaceApi.Models;
using PizzaPalaceApi.Repositories;

namespace PizzaPalaceApi.Services
{
    public class DeliveryService : IDeliveryService
    {
        private readonly IDeliveryRepository _deliveryRepository;

        public DeliveryService(IDeliveryRepository deliveryRepository)
        {
            _deliveryRepository = deliveryRepository;
        }

        public Delivery ScheduleDelivery(int orderId, string deliveryAddress)
        {
            var delivery = new Delivery
            {
                OrderId = orderId,
                DeliveryAddress = deliveryAddress,
                DeliveryStatus = "Scheduled"
            };

            _deliveryRepository.AddDelivery(delivery);
            return delivery;
        }

        public Delivery GetDeliveryStatus(int deliveryId)
        {
            return _deliveryRepository.GetDeliveryById(deliveryId);
        }

        public IEnumerable<Delivery> GetAllDeliveries()
        {
            return _deliveryRepository.GetAllDeliveries();
        }
    }
}