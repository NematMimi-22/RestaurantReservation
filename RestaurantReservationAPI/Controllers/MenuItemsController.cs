using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RestaurantReservation.Db.Entities;
using RestaurantReservationAPI.DTO;
using RestaurantReservation.Db.IRepositories;

namespace RestaurantReservationAPI.Controllers
{
    [ApiController]
    [Route("api/menuitems")]
    public class MenuItemsController : ControllerBase
    {
        private readonly IMenuItemRepository _menuItemRepository;
        private readonly IMapper _mapper;

        public MenuItemsController(IMenuItemRepository menuItemRepository, IMapper mapper)
        {
            _menuItemRepository = menuItemRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MenuItemDTO>>> GetMenuItems()
        {
            var menuItems = await _menuItemRepository.RetrieveAllAsync();
            var menuItemsDTO = _mapper.Map<IEnumerable<MenuItemDTO>>(menuItems);

            return Ok(menuItemsDTO);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<MenuItemDTO>> GetMenuItem(int id)
        {
            var menuItem = await _menuItemRepository.GetByIdAsync(id);

            if (menuItem == null)
            {
                return NotFound();
            }

            var menuItemDTO = _mapper.Map<MenuItemDTO>(menuItem);

            return Ok(menuItemDTO);
        }

        [HttpPost]
        public async Task<ActionResult<MenuItemDTO>> CreateMenuItem(MenuItemDTO menuItemDTO)
        {
            var menuItem = _mapper.Map<MenuItem>(menuItemDTO);

            await _menuItemRepository.CreateAsync(menuItem);

            var createdMenuItemDTO = _mapper.Map<MenuItemDTO>(menuItem);

            return CreatedAtAction(nameof(GetMenuItem), new { id = createdMenuItemDTO.MenuItemId }, createdMenuItemDTO);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMenuItem(int id, MenuItemDTO menuItemDTO)
        {
            if (id != menuItemDTO.MenuItemId)
            {
                return BadRequest();
            }

            var menuItem = _mapper.Map<MenuItem>(menuItemDTO);

            await _menuItemRepository.UpdateAsync(menuItem);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMenuItem(int id)
        {
            await _menuItemRepository.DeleteAsync(id);

            return NoContent();
        }
    }
}