using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SecondWork.API.DTOs;
using SecondWork.API.Models;

namespace SecondWork.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        ApplicationDbContext context;
        public CarController(ApplicationDbContext dbContext)
        {
            context = dbContext;
        }
        [HttpGet]
        public async ValueTask<IActionResult> GetAllAsync()
        {
            return Ok(await context.Car.ToListAsync());
        }
        [HttpGet("{id")]
        public async ValueTask<IActionResult> GetByIdAsync(int id)
        {
            return Ok(await context.Car.FirstOrDefaultAsync(x=>x.Id==id));
        }
        [HttpPut("{id")]
        public async ValueTask<IActionResult> UpdateAsync(int id,CarDto carDto)
        {
            Cars car = new Cars();
            car.Id = id;
            car.Name = carDto.Name;
            car.Description = carDto.Description;
           var d= await context.Car.Where(x=>x.Id==id).ExecuteUpdateAsync(s=>s
            .SetProperty(x=>x.Name,x=>car.Name)
            .SetProperty(x=>x.Description,x=> car.Description));
            await context.SaveChangesAsync();
            if (d > 0)
            {
                return Ok(true);
            }
            return Ok(false);
        }

    }
}
