using Microsoft.AspNetCore.Mvc;
using PizzaPalaceApi.Models;
using System.Collections.Generic;
using System.Linq;

namespace PizzaPalaceApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrdersController : ControllerBase
    {
        private static List<Order> orders = new List<Order>();

        [HttpGet]
        public ActionResult<IEnumerable<Order>> GetOrders()
        {
            return Ok(orders);
        }

        [HttpGet("{id}")]
        public ActionResult<Order> GetOrder(int id)
        {
            var order = orders.FirstOrDefault(o => o.OrderId == id);
            if (order == null)
            {
                return NotFound();
            }
            return Ok(order);
        }

        [HttpPost]
        public ActionResult<Order> CreateOrder(Order order)
        {
            order.OrderId = orders.Count > 0 ? orders.Max(o => o.OrderId) + 1 : 1;
            orders.Add(order);
            return CreatedAtAction(nameof(GetOrder), new { id = order.OrderId }, order);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateOrder(int id, Order updatedOrder)
        {
            var order = orders.FirstOrDefault(o => o.OrderId == id);
            if (order == null)
            {
                return NotFound();
            }
            order.CustomerName = updatedOrder.CustomerName;
            order.PizzaType = updatedOrder.PizzaType;
            order.Quantity = updatedOrder.Quantity;
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteOrder(int id)
        {
            var order = orders.FirstOrDefault(o => o.OrderId == id);
            if (order == null)
            {
                return NotFound();
            }
            orders.Remove(order);
            return NoContent();
        }
    }
}