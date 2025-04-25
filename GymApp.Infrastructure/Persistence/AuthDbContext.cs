using GymApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace GymApp.Infrastructure.Persistence;

public class AuthPersistenceDbContext : DbContext
{
    public AuthPersistenceDbContext(DbContextOptions<AuthPersistenceDbContext> options)
        : base(options) { }

    public DbSet<User> Users => Set<User>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<User>().HasIndex(u => u.Email).IsUnique();
        modelBuilder.Entity<User>().HasIndex(u => u.Username).IsUnique();
    }
}