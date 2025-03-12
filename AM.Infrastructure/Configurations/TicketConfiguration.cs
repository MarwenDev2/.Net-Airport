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
    public class TicketConfiguration : IEntityTypeConfiguration<Ticket>
    {
        public void Configure(EntityTypeBuilder<Ticket> builder)
        {
            builder.HasKey(t => new { t.PasseportNumber,t.FlightId});

            builder.Property(t => t.Seat)
                   .HasMaxLength(5)
                   .IsRequired();

            builder.HasOne(t => t.MyPassenger)
                   .WithMany(p => p.Tickets)
                   .HasForeignKey(t => t.PasseportNumber)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(t => t.MyFlight)
                   .WithMany(f => f.Tickets)
                   .HasForeignKey(t => t.FlightId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
