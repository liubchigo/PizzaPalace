using System;

namespace PizzaPalaceApi.Models
{
    public class Order
    {
        public Guid OrderId { get; set; }
        public string CustomerName { get; set; }
        public string PizzaType { get; set; }
        public int Quantity { get; set; }
        public DateTime OrderDate { get; set; }
        public string Status { get; set; }

        public Order()
        {
            OrderId = Guid.NewGuid();
            OrderDate = DateTime.UtcNow;
            Status = "Pending";
        }
    }
}