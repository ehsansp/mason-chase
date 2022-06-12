using System;
using Mc2.CrudTest.Domain;
using Mc2.CrudTest.Domain.Generators;
using Mc2.CrudTest.Presentation.Server.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Mc2.CrudTest.Presentation.Server.Models;

namespace Mc2.CrudTest.Presentation.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerController : ControllerBase
    {
        private ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet]
        [Route("GetCustomerById")]
        public async Task<IActionResult> GetById( int customerId)
        {
            if (await _customerService.CustomerExists(customerId))
            {
                var customer = await _customerService.GetCustomerById(customerId);
                return Ok(customer);
            }
            else
            {
                return NotFound();
            }
        }

        [Route("AddCustomer")]
        [HttpPost]
        public async Task<IActionResult> AddCustomer([FromForm]Customer customer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (_customerService.IsExistUserName(customer.FirstName,customer.LastName,customer.DateOfBirth))
            {
                return BadRequest( "The User Is Exist");
            }

            await _customerService.AddCustomer(customer);
            return CreatedAtAction("GetById", new { id = customer.Id }, customer);
        }

        [Route("GetAllCustomer")]
        [HttpGet]
        public IActionResult GetCustomer()
        {

            var result = new ObjectResult(_customerService.GetAll())
            {
                StatusCode = (int)HttpStatusCode.OK
            };
            Request.HttpContext.Response.Headers.Add("X-Count", _customerService.CountCustomer().ToString());

            return result;
        }


        [Route("EditCustomer")]
        [HttpPut]
        public async Task<IActionResult> EditCustomer([FromBody] Customer customer)
        {
            await _customerService.Update(customer);
            return Ok(customer);
        }

        [Route("DeleteCustomer/{id}")]
        [HttpDelete]
        public async Task<IActionResult> DeleteCustomer([FromRoute] int id)
        {
            await _customerService.Remove(id);
            return Ok();
        }
    }
}
