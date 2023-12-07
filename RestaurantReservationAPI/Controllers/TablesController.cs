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
    [Route("api/tables")]
    public class TablesController : ControllerBase
    {
        private readonly ITableRepository _tableRepository;
        private readonly IMapper _mapper;

        public TablesController(ITableRepository tableRepository, IMapper mapper)
        {
            _tableRepository = tableRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TableDTO>>> GetTables()
        {
            try
            {
                var tables = await _tableRepository.RetrieveAllAsync();
                var tablesDTO = _mapper.Map<IEnumerable<TableDTO>>(tables);

                return Ok(tablesDTO);
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TableDTO>> GetTable(int id)
        {
            try
            {
                var table = await _tableRepository.GetByIdAsync(id);

                if (table == null)
                {
                    return NotFound();
                }

                var tableDTO = _mapper.Map<TableDTO>(table);

                return Ok(tableDTO);
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpPost]
        public async Task<ActionResult<TableDTO>> CreateTable(TableDTO tableDTO)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var table = _mapper.Map<Table>(tableDTO);

                await _tableRepository.CreateAsync(table);

                var createdTableDTO = _mapper.Map<TableDTO>(table);

                return CreatedAtAction(nameof(GetTable), new { id = createdTableDTO.TableId }, createdTableDTO);
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTable(int id, TableDTO tableDTO)
        {
            try
            {
                if (id != tableDTO.TableId)
                {
                    return BadRequest("Invalid table ID");
                }

                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var table = _mapper.Map<Table>(tableDTO);

                await _tableRepository.UpdateAsync(table);

                return NoContent();
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTable(int id)
        {
            try
            {
                await _tableRepository.DeleteAsync(id);

                return NoContent();
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal Server Error");
            }
        }
    }
}