using System;
using GymApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace GymApp.Infrastructure.Data;

public class AuthDataDbContext: DbContext
{
    public AuthDataDbContext(DbContextOptions<AuthDataDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }

}
