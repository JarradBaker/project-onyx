using Microsoft.EntityFrameworkCore;
using server.Models;

namespace server.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<User> Users => Set<User>();
    public DbSet<UserSkill> UserSkills => Set<UserSkill>();
    public DbSet<UserTask> UserTasks => Set<UserTask>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // One User has One ActiveTask
        modelBuilder.Entity<User>()
            .HasOne(u => u.ActiveTask)
            .WithOne()
            .HasForeignKey<UserTask>(t => t.UserId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}