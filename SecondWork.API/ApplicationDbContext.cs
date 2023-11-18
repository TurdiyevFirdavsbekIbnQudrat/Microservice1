
using Microsoft.EntityFrameworkCore;
using SecondWork.API.Models;

namespace SecondWork.API
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        
        public virtual DbSet<Cars> Car { get; set; }
    }
}
