using Microsoft.AspNetCore.Mvc;
using PizzaPalaceApi.Models;
using PizzaPalaceApi.Services;

namespace PizzaPalaceApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeliveriesController : ControllerBase
    {
        private readonly IDeliveryService _deliveryService;

        public DeliveriesController(IDeliveryService deliveryService)
        {
            _deliveryService = deliveryService;
        }

        [HttpPost]
        public ActionResult<Delivery> CreateDelivery([FromBody] Delivery delivery)
        {
            var createdDelivery = _deliveryService.ScheduleDelivery(delivery.OrderId, delivery.DeliveryAddress);
            return CreatedAtAction(nameof(GetDelivery), new { id = createdDelivery.DeliveryId }, createdDelivery);
        }

        [HttpGet("{id}")]
        public ActionResult<Delivery> GetDelivery(int id)
        {
            var delivery = _deliveryService.GetDeliveryStatus(id);
            if (delivery == null)
            {
                return NotFound();
            }
            return Ok(delivery);
        }

        [HttpGet]
        public ActionResult<IEnumerable<Delivery>> GetAllDeliveries()
        {
            var deliveries = _deliveryService.GetAllDeliveries();
            return Ok(deliveries);
        }
    }
}