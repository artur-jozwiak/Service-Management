using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Configuration;
using Warsztat.BLL.Models;

namespace Warsztat_v2.Data
{
    public class ServiceContext : IdentityDbContext
    {
        public ServiceContext()
        {

        }
        public ServiceContext(DbContextOptions<ServiceContext> options) : base(options)
        {

        }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Part> Parts { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            var order = modelBuilder.Entity<Order>();
            var car = modelBuilder.Entity<Car>();


            order.HasOne(o => o.Mechanic).WithMany().HasForeignKey("MechanicId");
            order.Property(o => o.Fault).HasMaxLength(200);
            order.Property(o=>o.RegistrationNumber).HasMaxLength(10);
       
        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder
                .UseSqlServer("Server=localhost;Database=Service;Trusted_Connection=True;MultipleActiveResultSets=true");
        }
    }
}
