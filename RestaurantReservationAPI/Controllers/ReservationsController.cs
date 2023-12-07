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
    [Route("api/reservations")]
    public class ReservationsController : ControllerBase
    {
        private readonly IReservationRepository _reservationRepository;
        private readonly IMapper _mapper;

        public ReservationsController(IReservationRepository reservationRepository, IMapper mapper)
        {
            _reservationRepository = reservationRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ReservationDTO>>> GetReservations()
        {
            try
            {
                var reservations = await _reservationRepository.RetrieveAllAsync();
                var reservationsDTO = _mapper.Map<IEnumerable<ReservationDTO>>(reservations);

                return Ok(reservationsDTO);
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ReservationDTO>> GetReservation(int id)
        {
            try
            {
                var reservation = await _reservationRepository.GetByIdAsync(id);

                if (reservation == null)
                {
                    return NotFound();
                }

                var reservationDTO = _mapper.Map<ReservationDTO>(reservation);

                return Ok(reservationDTO);
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpPost]
        public async Task<ActionResult<ReservationDTO>> CreateReservation(ReservationDTO reservationDTO)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var reservation = _mapper.Map<Reservation>(reservationDTO);

                await _reservationRepository.CreateAsync(reservation);

                var createdReservationDTO = _mapper.Map<ReservationDTO>(reservation);

                return CreatedAtAction(nameof(GetReservation), new { id = createdReservationDTO.ReservationId }, createdReservationDTO);
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateReservation(int id, ReservationDTO reservationDTO)
        {
            try
            {
                if (id != reservationDTO.ReservationId)
                {
                    return BadRequest("Invalid reservation ID");
                }

                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var reservation = _mapper.Map<Reservation>(reservationDTO);

                await _reservationRepository.UpdateAsync(reservation);

                return NoContent();
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReservation(int id)
        {
            try
            {
                await _reservationRepository.DeleteAsync(id);

                return NoContent();
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpGet("customer/{customerId}")]
        public async Task<ActionResult<IEnumerable<ReservationDTO>>> GetReservationsByCustomer(int customerId)
        {
            try
            {
                var reservations = await _reservationRepository.GetReservationsByCustomerAsync(customerId);
                var reservationsDTO = _mapper.Map<IEnumerable<ReservationDTO>>(reservations);

                return Ok(reservationsDTO);
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpGet("{reservationId}/orders")]
        public async Task<ActionResult<IEnumerable<OrderDTO>>> GetOrdersForReservation(int reservationId)
        {
            try
            {
                var orders = await _reservationRepository.GetOrdersForReservationAsync(reservationId);
                var ordersDTO = _mapper.Map<IEnumerable<OrderDTO>>(orders);

                return Ok(ordersDTO);
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpGet("{reservationId}/menu-items")]
        public async Task<ActionResult<IEnumerable<MenuItemDTO>>> GetMenuItemsForReservation(int reservationId)
        {
            try
            {
                var menuItems = await _reservationRepository.GetMenuItemsForReservationAsync(reservationId);
                var menuItemsDTO = _mapper.Map<IEnumerable<MenuItemDTO>>(menuItems);

                return Ok(menuItemsDTO);
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal Server Error");
            }
        }
    }
}