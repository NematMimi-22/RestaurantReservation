using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RestaurantReservation.Db.Entities;
using RestaurantReservationAPI.DTO;
using RestaurantReservation.Db.IRepositories;

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
            var reservations = await _reservationRepository.RetrieveAllAsync();
            var reservationsDTO = _mapper.Map<IEnumerable<ReservationDTO>>(reservations);

            return Ok(reservationsDTO);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ReservationDTO>> GetReservation(int id)
        {
            var reservation = await _reservationRepository.GetByIdAsync(id);

            if (reservation == null)
            {
                return NotFound();
            }

            var reservationDTO = _mapper.Map<ReservationDTO>(reservation);

            return Ok(reservationDTO);
        }

        [HttpPost]
        public async Task<ActionResult<ReservationDTO>> CreateReservation(ReservationDTO reservationDTO)
        {
            var reservation = _mapper.Map<Reservation>(reservationDTO);

            await _reservationRepository.CreateAsync(reservation);

            var createdReservationDTO = _mapper.Map<ReservationDTO>(reservation);

            return CreatedAtAction(nameof(GetReservation), new { id = createdReservationDTO.ReservationId }, createdReservationDTO);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateReservation(int id, ReservationDTO reservationDTO)
        {
            if (id != reservationDTO.ReservationId)
            {
                return BadRequest();
            }

            var reservation = _mapper.Map<Reservation>(reservationDTO);

            await _reservationRepository.UpdateAsync(reservation);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReservation(int id)
        {
            await _reservationRepository.DeleteAsync(id);

            return NoContent();
        }
    }
}