using System;

namespace PizzaPalaceApi.Models
{
    public class Delivery
    {
        public int DeliveryId { get; set; }
        public int OrderId { get; set; }
        public string DeliveryAddress { get; set; }
        public string DeliveryStatus { get; set; }
        public DateTime DeliveryTime { get; set; }
    }
}