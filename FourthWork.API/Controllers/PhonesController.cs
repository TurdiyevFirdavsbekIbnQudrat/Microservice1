using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FourthWork.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PhonesController : ControllerBase
    {
        ApplicationDbContext context;
        public PhonesController(ApplicationDbContext dbContext)
        {
            context = dbContext;
        }
        [HttpGet]
        public async ValueTask<IActionResult> GetAllAsync()
        {
            return Ok(await context.Phones.ToListAsync());
        }
        [HttpGet]
        public async ValueTask<IActionResult> GetByIdAsync(int id)
        {
            return Ok(await context.Phones.FirstOrDefaultAsync(x => x.id == id));
        }
        [HttpPut]
        public async ValueTask<IActionResult> DeleteAsync(int id)
        {
            var d = await context.Phones.Where(x => x.id == id).ExecuteDeleteAsync();
            await context.SaveChangesAsync();
            if (d > 0)
            {
                return Ok(true);
            }
            return Ok(false);
        }
    }
}
