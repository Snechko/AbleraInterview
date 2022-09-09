using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using AbleraAPI.Data;
using AbleraAPI.Models;
using Microsoft.AspNetCore.Authorization;

namespace AbleraAPI.Controllers
{
    [ApiController]
    [AllowAnonymous]
    [Route("api/[controller]")]
    public class CarsController : Controller
    {
        private readonly CarsAPIDbContext dbContext;

        public CarsController(CarsAPIDbContext dbContext)
        {
            this.dbContext = dbContext;
        }


        [HttpGet]
        public async Task<IActionResult> GetCars()
        {
            return Ok(await dbContext.Cars.ToListAsync());
        }


        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetOneCar([FromRoute] int id)
        {
            var car = await dbContext.Cars.FindAsync(id);
            if (car == null)
            {
                return NotFound();
            }
            return Ok(car);
        }


        [HttpPost]
        public async Task<IActionResult> AddCar(AddCarsRequest addCarsRequest)
        {
            Car car = new Car()
            {
                Name = addCarsRequest.Name,
                Properties = addCarsRequest.Properties
            };

            dbContext.Cars.Add(car);
            await dbContext.SaveChangesAsync();

            return Ok(car);
        }


        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> UpdateCar([FromRoute] int id, UpdateCarRequest updateCarRequest)
        {
            var car = dbContext.Cars.Find(id);
            if (car != null)
            {
                car.Name = updateCarRequest.Name;
                car.Properties = updateCarRequest.Properties;

                await dbContext.SaveChangesAsync();

                return Ok(car);
            }

            return NotFound();
        }


        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> DeleteCar([FromRoute] int id)
        {
            var car = await dbContext.Cars.FindAsync(id);
            if (car != null)
            {
                dbContext.Remove(car);
                await dbContext.SaveChangesAsync();
                return Ok(car + " was deleted");
            }
            return NotFound();
        }
    }
}
