
using FirstWork.API.Models;
using Microsoft.EntityFrameworkCore;

namespace FirstWork.API.DataAccess
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {}
        public virtual DbSet<User> Users { get; set; }

    }
}
