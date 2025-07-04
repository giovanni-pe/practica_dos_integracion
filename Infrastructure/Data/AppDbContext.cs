using Microsoft.EntityFrameworkCore;
using Practica.Domain.Entities;
using System.Collections.Generic;

namespace Practica.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<User> Users => Set<User>();
        public DbSet<Course> Courses => Set<Course>();
        public DbSet<Teacher> Teachers => Set<Teacher>();
    }
}
