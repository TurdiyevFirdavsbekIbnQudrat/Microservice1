using FourthWork.API.Models;
using Microsoft.EntityFrameworkCore;

namespace FourthWork.API
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public virtual DbSet<Phone> Phones { get; set; }
    }
}
