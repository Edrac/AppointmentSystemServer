using AppointmentSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace AppointmentSystem.Data
{
    public class AppSystemDbContext : DbContext
    {
        public AppSystemDbContext(DbContextOptions<AppSystemDbContext> options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Appointment> Appointments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasMany<Appointment>(u => u.Appointments).WithOne(u => u.User);

        }
    }
}