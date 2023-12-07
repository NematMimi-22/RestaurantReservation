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
    [Route("api/employees")]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMapper _mapper;

        public EmployeesController(IEmployeeRepository employeeRepository, IMapper mapper)
        {
            _employeeRepository = employeeRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmployeeDTO>>> GetEmployees()
        {
            try
            {
                var employees = await _employeeRepository.RetrieveAllAsync();
                var employeesDTO = _mapper.Map<IEnumerable<EmployeeDTO>>(employees);

                return Ok(employeesDTO);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<EmployeeDTO>> GetEmployee(int id)
        {
            try
            {
                var employee = await _employeeRepository.GetByIdAsync(id);

                if (employee == null)
                {
                    return NotFound("Employee not found");
                }

                var employeeDTO = _mapper.Map<EmployeeDTO>(employee);

                return Ok(employeeDTO);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpPost]
        public async Task<ActionResult<EmployeeDTO>> CreateEmployee(EmployeeDTO employeeDTO)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var employee = _mapper.Map<Employee>(employeeDTO);

                await _employeeRepository.CreateAsync(employee);

                var createdEmployeeDTO = _mapper.Map<EmployeeDTO>(employee);

                return CreatedAtAction(nameof(GetEmployee), new { id = createdEmployeeDTO.EmployeeId }, createdEmployeeDTO);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEmployee(int id, EmployeeDTO employeeDTO)
        {
            try
            {
                if (id != employeeDTO.EmployeeId)
                {
                    return BadRequest("Invalid employee ID");
                }

                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var employee = _mapper.Map<Employee>(employeeDTO);

                await _employeeRepository.UpdateAsync(employee);

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            try
            {
                await _employeeRepository.DeleteAsync(id);

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpGet("managers")]
        public async Task<ActionResult<IEnumerable<EmployeeDTO>>> GetManagers()
        {
            try
            {
                var managers = await _employeeRepository.GetManagersAsync();
                var managersDTO = _mapper.Map<IEnumerable<EmployeeDTO>>(managers);

                return Ok(managersDTO);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpGet("{employeeId}/average-order-amount")]
        public async Task<ActionResult<double>> GetAverageOrderAmount(int employeeId)
        {
            try
            {
                var averageOrderAmount = await _employeeRepository.GetAverageOrderAmountAsync(employeeId);

                return Ok(averageOrderAmount);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal Server Error");
            }
        }
    }
}