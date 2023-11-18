using FirstWork.API.DataAccess;
using FirstWork.API.DTOs;
using FirstWork.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FirstWork.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public UserController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async ValueTask<IActionResult> GetAllFromUserAsync()
        {
                var d = await _context.Users.ToListAsync();
                return Ok(d);
        }
        [HttpGet("{Id}")]
        public async ValueTask<IActionResult> GetByIdAsync(int id)
        {
            var d = await _context.Users.FirstOrDefaultAsync(x=>x.Id==id);
            return Ok(d);
        }
        [HttpPost("{User}")]
        public async ValueTask<IActionResult> CreateAsync(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            return Ok("Yaratilindi!!!");
        }
    }
}
