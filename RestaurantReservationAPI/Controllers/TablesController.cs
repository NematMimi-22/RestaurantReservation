using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RestaurantReservation.Db.Entities;
using RestaurantReservation.Db.IRepositories;
using RestaurantReservationAPI.DTO;

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
            var tables = await _tableRepository.RetrieveAllAsync();
            var tablesDTO = _mapper.Map<IEnumerable<TableDTO>>(tables);

            return Ok(tablesDTO);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TableDTO>> GetTable(int id)
        {
            var table = await _tableRepository.GetByIdAsync(id);

            if (table == null)
            {
                return NotFound();
            }

            var tableDTO = _mapper.Map<TableDTO>(table);

            return Ok(tableDTO);
        }

        [HttpPost]
        public async Task<ActionResult<TableDTO>> CreateTable(TableDTO tableDTO)
        {
            var table = _mapper.Map<Table>(tableDTO);

            await _tableRepository.CreateAsync(table);

            var createdTableDTO = _mapper.Map<TableDTO>(table);

            return CreatedAtAction(nameof(GetTable), new { id = createdTableDTO.TableId }, createdTableDTO);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTable(int id, TableDTO tableDTO)
        {
            if (id != tableDTO.TableId)
            {
                return BadRequest();
            }

            var table = _mapper.Map<Table>(tableDTO);

            await _tableRepository.UpdateAsync(table);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTable(int id)
        {
            await _tableRepository.DeleteAsync(id);

            return NoContent();
        }
    }
}