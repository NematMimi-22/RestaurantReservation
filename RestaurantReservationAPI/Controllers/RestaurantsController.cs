using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RestaurantReservation.Db.Entities;
using RestaurantReservation.Db.IRepositories;
using RestaurantReservationAPI.DTO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

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
            try
            {
                var restaurants = await _restaurantRepository.RetrieveAllAsync();
                var restaurantsDTO = _mapper.Map<IEnumerable<RestaurantDTO>>(restaurants);

                return Ok(restaurantsDTO);
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<RestaurantDTO>> GetRestaurant(int id)
        {
            try
            {
                var restaurant = await _restaurantRepository.GetByIdAsync(id);

                if (restaurant == null)
                {
                    return NotFound();
                }

                var restaurantDTO = _mapper.Map<RestaurantDTO>(restaurant);

                return Ok(restaurantDTO);
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpPost]
        public async Task<ActionResult<RestaurantDTO>> CreateRestaurant(RestaurantDTO restaurantDTO)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var restaurant = _mapper.Map<Restaurant>(restaurantDTO);

                await _restaurantRepository.CreateAsync(restaurant);

                var createdRestaurantDTO = _mapper.Map<RestaurantDTO>(restaurant);

                return CreatedAtAction(nameof(GetRestaurant), new { id = createdRestaurantDTO.RestaurantId }, createdRestaurantDTO);
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateRestaurant(int id, RestaurantDTO restaurantDTO)
        {
            try
            {
                if (id != restaurantDTO.RestaurantId)
                {
                    return BadRequest("Invalid restaurant ID");
                }

                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var restaurant = _mapper.Map<Restaurant>(restaurantDTO);

                await _restaurantRepository.UpdateAsync(restaurant);

                return NoContent();
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRestaurant(int id)
        {
            try
            {
                await _restaurantRepository.DeleteAsync(id);

                return NoContent();
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal Server Error");
            }
        }
    }
}