using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RestaurantReservation.Db.Entities;
using RestaurantReservationAPI.DTO;
using RestaurantReservation.Db.IRepositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

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
            try
            {
                var orderItems = await _orderItemRepository.RetrieveAllAsync();
                var orderItemsDTO = _mapper.Map<IEnumerable<OrderItemDTO>>(orderItems);

                return Ok(orderItemsDTO);
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<OrderItemDTO>> GetOrderItem(int id)
        {
            try
            {
                var orderItem = await _orderItemRepository.GetByIdAsync(id);

                if (orderItem == null)
                {
                    return NotFound();
                }

                var orderItemDTO = _mapper.Map<OrderItemDTO>(orderItem);

                return Ok(orderItemDTO);
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpPost]
        public async Task<ActionResult<OrderItemDTO>> CreateOrderItem(OrderItemDTO orderItemDTO)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var orderItem = _mapper.Map<OrderItem>(orderItemDTO);

                await _orderItemRepository.CreateAsync(orderItem);

                var createdOrderItemDTO = _mapper.Map<OrderItemDTO>(orderItem);

                return CreatedAtAction(nameof(GetOrderItem), new { id = createdOrderItemDTO.OrderItemId }, createdOrderItemDTO);
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateOrderItem(int id, OrderItemDTO orderItemDTO)
        {
            try
            {
                if (id != orderItemDTO.OrderItemId)
                {
                    return BadRequest("Invalid order item ID");
                }

                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var orderItem = _mapper.Map<OrderItem>(orderItemDTO);

                await _orderItemRepository.UpdateAsync(orderItem);

                return NoContent();
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrderItem(int id)
        {
            try
            {
                await _orderItemRepository.DeleteAsync(id);

                return NoContent();
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal Server Error");
            }
        }
    }
}