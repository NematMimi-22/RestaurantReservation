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
    [Route("api/orders")]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;

        public OrdersController(IOrderRepository orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderDTO>>> GetOrders()
        {
            try
            {
                var orders = await _orderRepository.RetrieveAllAsync();
                var orderDTOs = _mapper.Map<IEnumerable<OrderDTO>>(orders);

                return Ok(orderDTOs);
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<OrderDTO>> GetOrder(int id)
        {
            try
            {
                var order = await _orderRepository.GetByIdAsync(id);

                if (order == null)
                {
                    return NotFound();
                }

                var orderDTO = _mapper.Map<OrderDTO>(order);

                return Ok(orderDTO);
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpPost]
        public async Task<ActionResult<OrderDTO>> CreateOrder(OrderDTO orderDTO)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var order = _mapper.Map<Order>(orderDTO);
                order.OrderDate = DateTime.Now;

                await _orderRepository.CreateAsync(order);

                var createdOrderDTO = _mapper.Map<OrderDTO>(order);

                return CreatedAtAction(nameof(GetOrder), new { id = createdOrderDTO.OrderId }, createdOrderDTO);
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateOrder(int id, OrderDTO orderDTO)
        {
            try
            {
                if (id != orderDTO.OrderId)
                {
                    return BadRequest("Invalid order ID");
                }

                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var order = _mapper.Map<Order>(orderDTO);

                await _orderRepository.UpdateAsync(order);

                return NoContent();
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrder(int id)
        {
            try
            {
                await _orderRepository.DeleteAsync(id);

                return NoContent();
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal Server Error");
            }
        }
    }
}