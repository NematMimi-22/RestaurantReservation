﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RestaurantReservation.Db.Entities;
using RestaurantReservationAPI.DTO;
using RestaurantReservation.Db.IRepositories;
using Microsoft.AspNetCore.Authorization;

namespace RestaurantReservationAPI.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/customers")]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;

        public CustomersController(ICustomerRepository customerRepository, IMapper mapper)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
        }

        [Authorize]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CustomerDTO>>> GetCustomers()
        {
            var customers = await _customerRepository.RetrieveAllAsync();
            var customersDTO = _mapper.Map<IEnumerable<CustomerDTO>>(customers);

            return Ok(customersDTO);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CustomerDTO>> GetCustomer(int id)
        {
            var customer = await _customerRepository.GetByIdAsync(id);

            if (customer == null)
            {
                return NotFound();
            }

            var customerDTO = _mapper.Map<CustomerDTO>(customer);

            return Ok(customerDTO);
        }

        [HttpPost]
        public async Task<ActionResult<CustomerDTO>> CreateCustomer(CustomerDTO customerDTO)
        {
            var customer = _mapper.Map<Customer>(customerDTO);

            await _customerRepository.CreateAsync(customer);

            var createdCustomerDTO = _mapper.Map<CustomerDTO>(customer);

            return CreatedAtAction(nameof(GetCustomer), new { id = createdCustomerDTO.CustomerId }, createdCustomerDTO);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCustomer(int id, CustomerDTO customerDTO)
        {
            if (id != customerDTO.CustomerId)
            {
                return BadRequest();
            }

            var customer = _mapper.Map<Customer>(customerDTO);

            await _customerRepository.UpdateAsync(customer);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomer(int id)
        { 
            await _customerRepository.DeleteAsync(id);

            return NoContent();
        }
    }
}