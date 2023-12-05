using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RestaurantReservation.Db.Entities;
using RestaurantReservation.Db.IRepositories;
using RestaurantReservationAPI.DTO;

namespace RestaurantReservationAPI.Controllers
{
    [ApiController]
    [Route("api/restaurants")]
    public class RestaurantsController : ControllerBase
    {
        private readonly IRestaurantRepository _restaurantRepository;
        private readonly IMapper _mapper;

        public RestaurantsController(IRestaurantRepository restaurantRepository, IMapper mapper)
        {
            _restaurantRepository = restaurantRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<RestaurantDTO>>> GetRestaurants()
        {
            var restaurants = await _restaurantRepository.RetrieveAllAsync();
            var restaurantsDTO = _mapper.Map<IEnumerable<RestaurantDTO>>(restaurants);

            return Ok(restaurantsDTO);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<RestaurantDTO>> GetRestaurant(int id)
        {
            var restaurant = await _restaurantRepository.GetByIdAsync(id);

            if (restaurant == null)
            {
                return NotFound();
            }

            var restaurantDTO = _mapper.Map<RestaurantDTO>(restaurant);

            return Ok(restaurantDTO);
        }

        [HttpPost]
        public async Task<ActionResult<RestaurantDTO>> CreateRestaurant(RestaurantDTO restaurantDTO)
        {
            var restaurant = _mapper.Map<Restaurant>(restaurantDTO);

            await _restaurantRepository.CreateAsync(restaurant);

            var createdRestaurantDTO = _mapper.Map<RestaurantDTO>(restaurant);

            return CreatedAtAction(nameof(GetRestaurant), new { id = createdRestaurantDTO.RestaurantId }, createdRestaurantDTO);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateRestaurant(int id, RestaurantDTO restaurantDTO)
        {
            if (id != restaurantDTO.RestaurantId)
            {
                return BadRequest();
            }

            var restaurant = _mapper.Map<Restaurant>(restaurantDTO);

            await _restaurantRepository.UpdateAsync(restaurant);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRestaurant(int id)
        {
            await _restaurantRepository.DeleteAsync(id);

            return NoContent();
        }
    }
}