using BusinessLayer.Abstract;
using DataAccessLayer.Concrete;
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
    public class SaleController : ControllerBase
    {
        ICustomerService _customerService;
        ICarService _carService;

        public SaleController(ICustomerService customerService, ICarService carService = null)
        {
            _customerService = customerService;
            _carService = carService;
        }


        /// <summary>
        /// Car Sale
        /// </summary>
        /// <param name="carid"></param>
        /// <param name="customerid"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("[action]/{carid}/{customerid}")]
        public IActionResult CarSale(int carid, int customerid)
        {
            try
            {
                var checkCar = _carService.TGetByID(carid);
                var checkCustomer = _customerService.TGetByID(customerid);

                if (checkCar == null)
                    return BadRequest("Not Found Car");

                if (checkCustomer == null)
                    return BadRequest("Not Found Customer");

                var sale = new Sale { 
                CarId = carid,
                CustomerId = customerid
                };

                checkCar.IsAvailable = false;
                checkCar.SaleDate = DateTime.Now.ToShortDateString();

                using var c = new Context();
                c.Update(checkCar);
                c.Update(sale);
                c.SaveChanges();

                return Ok(sale);

            }
            catch (Exception ex)
            {
                throw new Exception(
            $"Error State {ex}.");
            }

        }//create

    }
}
