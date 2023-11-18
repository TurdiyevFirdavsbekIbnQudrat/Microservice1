using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ThirdWork.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        ApplicationDbContext context;
        public HomeController(ApplicationDbContext dbContext)
        {
            context = dbContext;
        }
        [HttpGet]
        public async ValueTask<IActionResult> GetAllAsync()
        {
            return Ok(await context.Homes.ToListAsync());
        }
        [HttpGet]
        public async ValueTask<IActionResult> GetByIdAsync(int id)
        {
            return Ok(await context.Homes.FirstOrDefaultAsync(x => x.Id == id));
        }
        [HttpPut]
        public async ValueTask<IActionResult> DeleteAsync(int id)
        {
            var d=await context.Homes.Where(x=>x.Id==id).ExecuteDeleteAsync();
            await context.SaveChangesAsync();
            if (d > 0)
            {
                return Ok(true);
            }
            return Ok(false);
        }
    }
}
