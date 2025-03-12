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
    public class PassengerConfiguration : IEntityTypeConfiguration<Passenger>
    {
        public void Configure(EntityTypeBuilder<Passenger> builder)
        {
            builder.HasKey(p => p.PasseportNumber);

            // Configure the owned type (FullName)
            builder.OwnsOne(p => p.FullName, fullNameBuilder =>
            {
                fullNameBuilder.Property(fn => fn.FirstName)
                               .HasColumnName("PassFirstName")
                               .HasMaxLength(30)
                               .IsRequired();

                fullNameBuilder.Property(fn => fn.LastName)
                               .HasColumnName("PassLastName")
                               .IsRequired();
            });
        }
    }
}
