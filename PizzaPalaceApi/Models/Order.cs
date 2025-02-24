using System;

namespace PizzaPalaceApi.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public string CustomerName { get; set; }
        public string PizzaType { get; set; }
        public int Quantity { get; set; }
        public DateTime OrderDate { get; set; }
        public string Status { get; set; }

        public Order()
        {
            OrderId = new Random().Next(1, int.MaxValue);
            OrderDate = DateTime.UtcNow;
            Status = "Pending";
        }
    }
}