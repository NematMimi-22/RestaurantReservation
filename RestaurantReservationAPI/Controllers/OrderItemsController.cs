using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RestaurantReservation.Db.Entities;
using RestaurantReservation.Db.IRepositories;

namespace RestaurantReservationAPI.Controllers
{
    [ApiController]
    [Route("api/orderitems")]
    public class OrderItemsController : ControllerBase
    {
        private readonly IOrderItemRepository _orderItemRepository;
        private readonly IMapper _mapper;

        public OrderItemsController(IOrderItemRepository orderItemRepository, IMapper mapper)
        {
            _orderItemRepository = orderItemRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderItemDTO>>> GetOrderItems()
        {
            var orderItems = await _orderItemRepository.RetrieveAllAsync();
            var orderItemsDTO = _mapper.Map<IEnumerable<OrderItemDTO>>(orderItems);

            return Ok(orderItemsDTO);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<OrderItemDTO>> GetOrderItem(int id)
        {
            var orderItem = await _orderItemRepository.GetByIdAsync(id);

            if (orderItem == null)
            {
                return NotFound();
            }

            var orderItemDTO = _mapper.Map<OrderItemDTO>(orderItem);

            return Ok(orderItemDTO);
        }

        [HttpPost]
        public async Task<ActionResult<OrderItemDTO>> CreateOrderItem(OrderItemDTO orderItemDTO)
        {
            var orderItem = _mapper.Map<OrderItem>(orderItemDTO);

            await _orderItemRepository.CreateAsync(orderItem);

            var createdOrderItemDTO = _mapper.Map<OrderItemDTO>(orderItem);

            return CreatedAtAction(nameof(GetOrderItem), new { id = createdOrderItemDTO.OrderItemId }, createdOrderItemDTO);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateOrderItem(int id, OrderItemDTO orderItemDTO)
        {
            if (id != orderItemDTO.OrderItemId)
            {
                return BadRequest();
            }

            var orderItem = _mapper.Map<OrderItem>(orderItemDTO);

            await _orderItemRepository.UpdateAsync(orderItem);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrderItem(int id)
        {
            await _orderItemRepository.DeleteAsync(id);

            return NoContent();
        }
    }
}