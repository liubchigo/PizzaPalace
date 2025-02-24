using PizzaPalaceApi.Models;
using System.Collections.Generic;
using System.Linq;

namespace PizzaPalaceApi.Repositories
{
    public class DeliveryRepository : IDeliveryRepository
    {
        private readonly List<Delivery> _deliveries = new List<Delivery>();

        public void AddDelivery(Delivery delivery)
        {
            _deliveries.Add(delivery);
        }

        public Delivery GetDeliveryById(int deliveryId)
        {
            return _deliveries.FirstOrDefault(d => d.DeliveryId == deliveryId);
        }

        public IEnumerable<Delivery> GetAllDeliveries()
        {
            return _deliveries;
        }
    }
}