using PizzaPalaceApi.Models;
using PizzaPalaceApi.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace PizzaPalaceApi.Services
{
    public class DeliveryService : IDeliveryService
    {
        private static List<Delivery> deliveries = new List<Delivery>();

        public Delivery ScheduleDelivery(int orderId, string deliveryAddress)
        {
            var delivery = new Delivery
            {
                DeliveryId = deliveries.Count > 0 ? deliveries.Max(d => d.Id) + 1 : 1,
                OrderId = orderId,
                DeliveryAddress = deliveryAddress,
                DeliveryStatus = "Scheduled"
            };

            deliveries.Add(delivery);
            return delivery;
        }

        public Delivery GetDeliveryStatus(int deliveryId)
        {
            return deliveries.FirstOrDefault(d => d.DeliveryId == deliveryId);
        }

        public IEnumerable<Delivery> GetAllDeliveries()
        {
            return deliveries;
        }
    }
}