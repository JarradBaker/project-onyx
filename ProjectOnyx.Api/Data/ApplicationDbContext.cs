using Microsoft.EntityFrameworkCore;
using ProjectOnyx.Api.Models;

namespace ProjectOnyx.Api.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        // This links your C# model to the actual database table
        public DbSet<Player> Players { get; set; }
    }
}