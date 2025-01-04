
using Laboratory.Services.TestParameterAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace Laboratory.Services.TestParameterAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Parameter> parameters { get; set; }

      

        
    }
}
