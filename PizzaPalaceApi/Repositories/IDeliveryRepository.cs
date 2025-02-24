using PizzaPalaceApi.Models;

namespace PizzaPalaceApi.Repositories
{
    public interface IDeliveryRepository
    {
        public void AddDelivery(Delivery delivery);
        public Delivery GetDeliveryById(int deliveryId);
        public IEnumerable<Delivery> GetAllDeliveries();
    }
}