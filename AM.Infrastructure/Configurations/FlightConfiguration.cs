using AM.ApplicationCore.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.Infrastructure.Configurations
{
    public class FlightConfiguration : IEntityTypeConfiguration<Flight>
    {
        public void Configure(EntityTypeBuilder<Flight> builder)
        {
            builder.HasKey(f => f.FlightId);

            // One-to-Many with Plane
            builder.HasOne(f => f.Plane)
                   .WithMany(p => p.Flights)
                   .HasForeignKey(f => f.PlaneId)
                   .OnDelete(DeleteBehavior.Cascade);

            // Many-to-Many with Passenger
            //builder.HasMany(f => f.Passengers)
            //       .WithMany(p => p.Flights)
            //       .UsingEntity(j => j.ToTable("PassengerFlights"));

            builder.ToTable("Flights");
        }
    }
}
