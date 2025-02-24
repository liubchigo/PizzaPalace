using Microsoft.AspNetCore.Mvc;
using PizzaPalaceApi.Models;
using System.Collections.Generic;
using System.Linq;

namespace PizzaPalaceApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DeliveriesController : ControllerBase
    {
        private static List<Delivery> deliveries = new List<Delivery>();

        [HttpGet]
        public ActionResult<IEnumerable<Delivery>> GetDeliveries()
        {
            return Ok(deliveries);
        }

        [HttpGet("{id}")]
        public ActionResult<Delivery> GetDelivery(int id)
        {
            var delivery = deliveries.FirstOrDefault(d => d.DeliveryId == id);
            if (delivery == null)
            {
                return NotFound();
            }
            return Ok(delivery);
        }

        [HttpPost]
        public ActionResult<Delivery> CreateDelivery(Delivery delivery)
        {
            delivery.DeliveryId = deliveries.Count > 0 ? deliveries.Max(d => d.DeliveryId) + 1 : 1;
            deliveries.Add(delivery);
            return CreatedAtAction(nameof(GetDelivery), new { id = delivery.DeliveryId }, delivery);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateDelivery(int id, Delivery updatedDelivery)
        {
            var delivery = deliveries.FirstOrDefault(d => d.DeliveryId == id);
            if (delivery == null)
            {
                return NotFound();
            }
            delivery.DeliveryAddress = updatedDelivery.DeliveryAddress;
            delivery.DeliveryStatus = updatedDelivery.DeliveryStatus;
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteDelivery(int id)
        {
            var delivery = deliveries.FirstOrDefault(d => d.DeliveryId == id);
            if (delivery == null)
            {
                return NotFound();
            }
            deliveries.Remove(delivery);
            return NoContent();
        }
    }
}