using AM.ApplicationCore.Domain;
using AM.Infrastructure.Configurations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.Infrastructure
{
    public class AMContext : DbContext
    {   
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies()
                 .UseSqlServer(@"Data Source=(localdb)\mssqllocaldb;Initial Catalog=MarwenFekiDB;Integrated Security=true");
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PlaneConfiguration());
            modelBuilder.ApplyConfiguration(new FlightConfiguration());
            modelBuilder.ApplyConfiguration(new PassengerConfiguration());
            modelBuilder.ApplyConfiguration(new TicketConfiguration());
            modelBuilder.Entity<Traveller>().ToTable("Travellers");
            modelBuilder.Entity<Staff>().ToTable("Staffs");
        }

        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            base.ConfigureConventions(configurationBuilder);

            // Set DateTime properties to 'date' in SQL Server
            configurationBuilder.Properties<DateTime>()
                .HaveColumnType("date");
        }


        public DbSet<Flight> Flights { get; set; }

        public DbSet<Passenger> Passengers { get; set; }

        public DbSet<Plane> Planes { get; set; }

        public DbSet<Staff> Staffs { get; set; }

        public DbSet<Traveller> Travellers { get; set; }
    }
}
