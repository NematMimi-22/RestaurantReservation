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
            try
            {
                var menuItems = await _menuItemRepository.RetrieveAllAsync();
                var menuItemsDTO = _mapper.Map<IEnumerable<MenuItemDTO>>(menuItems);

                return Ok(menuItemsDTO);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<MenuItemDTO>> GetMenuItem(int id)
        {
            try
            {
                var menuItem = await _menuItemRepository.GetByIdAsync(id);

                if (menuItem == null)
                {
                    return NotFound("Menu item not found");
                }

                var menuItemDTO = _mapper.Map<MenuItemDTO>(menuItem);

                return Ok(menuItemDTO);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpPost]
        public async Task<ActionResult<MenuItemDTO>> CreateMenuItem(MenuItemDTO menuItemDTO)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var menuItem = _mapper.Map<MenuItem>(menuItemDTO);

                await _menuItemRepository.CreateAsync(menuItem);

                var createdMenuItemDTO = _mapper.Map<MenuItemDTO>(menuItem);

                return CreatedAtAction(nameof(GetMenuItem), new { id = createdMenuItemDTO.MenuItemId }, createdMenuItemDTO);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMenuItem(int id, MenuItemDTO menuItemDTO)
        {
            try
            {
                if (id != menuItemDTO.MenuItemId)
                {
                    return BadRequest("Invalid menu item ID");
                }

                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var menuItem = _mapper.Map<MenuItem>(menuItemDTO);

                await _menuItemRepository.UpdateAsync(menuItem);

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMenuItem(int id)
        {
            try
            {
                await _menuItemRepository.DeleteAsync(id);

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal Server Error");
            }
        }
    }
}