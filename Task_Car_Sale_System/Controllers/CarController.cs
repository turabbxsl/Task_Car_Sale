using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Task_Car_Sale_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {

        ICarService _carService;

        public CarController(ICarService carService)
        {
            _carService = carService;
        }


        /// <summary>
        /// Get All Cars
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetCarList()
        {
            try
            {
                var cars = await _carService.GetList();

                if (cars != null)
                {
                    return Ok(cars);
                }
                else
                {
                    return BadRequest("Car list is empty");
                }

            }
            catch (Exception ex)
            {
                throw new Exception(
            $"Error State {ex}.");
            }

        }//getCarList




        /// <summary>
        /// Get Car By ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("[action]/{id}")]
        public IActionResult GetCarByID(int id)
        {
            try
            {
                var car = _carService.TGetByID(id);
                if (car != null)
                {
                    return Ok(car);
                }
                else
                {
                    return BadRequest("No car found for this ID");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(
            $"Error State {ex}.");
            }

        }//getCarByID




        /// <summary>
        /// Get Car By Model
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("[action]/{model}")]
        public IActionResult GetCarByModel(string model)
        {
            try
            {
                var car = _carService.GetCarByModel(model);
                if (car != null)
                {
                    return Ok(car);
                }
                else
                {
                    return BadRequest("No car found for this model");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(
            $"Error State {ex}.");
            }

        }//getCarByModel




        /// <summary>
        /// Insert Car
        /// </summary>
        /// <param name="car"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("[action]")]
        public IActionResult CreateCar([FromBody] Car car)
        {
            try
            {
                var checkCar = _carService.GetCarByModel(car.Model);
                if (checkCar == null)
                {
                    if (car.Description == null || car.Description == "string")
                        car.Description = "No Info";

                    car.SaleDate = "-";
                    var createdcar = _carService.TAdd(car);
                    return Ok(createdcar);
                }
                else
                {
                    return BadRequest("Cannot be entered twice from the same Car Model");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(
            $"Error State {ex}.");
            }

        }//create




        /// <summary>
        /// Update Car
        /// </summary>
        /// <param name="car"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("[action]")]
        public IActionResult UpdateCar([FromBody] Car car)
        {
            try
            {
                var updatedCar = _carService.TGetByID(car.CarID);

                if (updatedCar != null)
                {
                    return Ok(_carService.TUpdate(car));
                }
                else
                {
                    return BadRequest("Car not found");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(
            $"Error State {ex}.");
            }

        }//update




        /// <summary>
        /// Delete Car 
        /// </summary>
        /// <param name="id"></param>
        [HttpDelete]
        [Route("[action]")]
        public IActionResult DeleteCar(int id)
        {
            try
            {
                var deletedCar = _carService.TGetByID(id);

                if (deletedCar != null)
                {
                    _carService.TDelete(deletedCar);
                    return Ok();
                }
                else
                {
                    return BadRequest("Can not found for this ID");
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
