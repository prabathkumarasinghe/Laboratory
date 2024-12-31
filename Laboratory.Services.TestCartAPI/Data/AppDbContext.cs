using Laboratory.Services.TestCartAPI.Models;
using Microsoft.EntityFrameworkCore;


namespace Laboratory.Services.TestCartAPI.Data
{
    public class AppDbContext : DbContext
    {
		public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
		{
		}

		public DbSet<CartHeader> CartHeaders { get; set; }
		public DbSet<CartDetails> CartDetails { get; set; }
	}
}
