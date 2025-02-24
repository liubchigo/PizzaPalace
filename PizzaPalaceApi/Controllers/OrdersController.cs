using Microsoft.AspNetCore.Mvc;
using PizzaPalaceApi.Models;
using PizzaPalaceApi.Repositories;

namespace PizzaPalaceApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderRepository _orderRepository;

        public OrdersController(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        [HttpPost]
        public ActionResult<Order> CreateOrder(Order order)
        {
            _orderRepository.AddOrder(order);
            return CreatedAtAction(nameof(GetOrder), new { id = order.OrderId }, order);
        }

        [HttpGet("{id}")]
        public ActionResult<Order> GetOrder(Guid id)
        {
            var order = _orderRepository.GetOrderById(id);
            if (order == null)
            {
                return NotFound();
            }
            return order;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Order>> GetAllOrders()
        {
            var orders = _orderRepository.GetAllOrders();
            return Ok(orders);
        }
    }
}