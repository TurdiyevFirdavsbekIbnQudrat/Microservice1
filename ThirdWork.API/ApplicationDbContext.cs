
using Microsoft.EntityFrameworkCore;
using ThirdWork.API.Models;

namespace ThirdWork.API
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public virtual DbSet<Home> Homes { get; set; }

    }
}
