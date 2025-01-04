using Laboratory.Services.OrderAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace Laboratory.Services.OrderAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<OrderHeader> OrderHeaders { get; set; }
        public DbSet<OrderDetalis> OrderDetails { get; set; }

    }
}
