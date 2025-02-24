using PizzaPalaceApi.Models;

namespace PizzaPalaceApi.Services
{
    public interface IDeliveryService
    {
        Delivery ScheduleDelivery(int orderId, string deliveryAddress);
        Delivery GetDeliveryStatus(int deliveryId);
        IEnumerable<Delivery> GetAllDeliveries();
    }
}
