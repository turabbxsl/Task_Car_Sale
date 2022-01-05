using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Task_Car_Sale_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {

        ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }


        /// <summary>
        /// Get All Customers
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetCustomerList()
        {
            try
            {
                var customers = await _customerService.GetList();

                if (customers != null)
                {
                    return Ok(customers);
                }
                else
                {
                    return BadRequest("Customer list is empty");
                }

            }
            catch (Exception ex)
            {
                throw new Exception(
            $"Error State {ex}.");
            }

        }//getCustomerList




        /// <summary>
        /// Get Customer By ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("[action]/{id}")]
        public IActionResult GetCustomerByID(int id)
        {
            try
            {
                var customer = _customerService.TGetByID(id);
                if (customer != null)
                {
                    return Ok(customer);
                }
                else
                {
                    return BadRequest("Customer not found for this ID");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(
            $"Error State {ex}.");
            }

        }//getCustomerByID




        /// <summary>
        /// Insert Customer
        /// </summary>
        /// <param name="customer"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("[action]")]
        public IActionResult CreateCustomer([FromBody] Customer customer)
        {
            try
            {
                if (customer != null)
                {
                    var createdCustomer = _customerService.TAdd(customer);
                    return CreatedAtAction("Get", new { id = createdCustomer.CustomerId }, createdCustomer);
                }
                else
                {
                    return BadRequest("Failed to create Customer");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(
            $"Error State {ex}.");
            }

        }//create




        /// <summary>
        /// Update Customer
        /// </summary>
        /// <param name="customer"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("[action]")]
        public IActionResult UpdateCustomer([FromBody] Customer customer)
        {
            try
            {
                var updatedCar = _customerService.TGetByID(customer.CustomerId);

                if (updatedCar != null)
                {
                    return Ok(_customerService.TUpdate(customer));
                }
                else
                {
                    return BadRequest("Customer not found");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(
            $"Error State {ex}.");
            }

        }//update




        /// <summary>
        /// Delete Customer 
        /// </summary>
        /// <param name="id"></param>
        [HttpDelete]
        [Route("[action]")]
        public IActionResult DeleteCustomer(int id)
        {
            try
            {
                var deletedCustomer = _customerService.TGetByID(id);

                if (deletedCustomer != null)
                {
                    _customerService.TDelete(deletedCustomer);
                    return Ok();
                }
                else
                {
                    return BadRequest("Customer not found for this ID");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(
            $"Error State {ex}.");
            }

        }//delete


    }
}
