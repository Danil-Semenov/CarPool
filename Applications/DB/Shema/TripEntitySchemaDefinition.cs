using Applications.DB.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Applications.DB.Shema
{
    public class TripEntitySchemaDefinition : IEntityTypeConfiguration<Trip>
    {
        public void Configure(EntityTypeBuilder<Trip> builder)
        {
            builder.ToTable("trip", "public");
            builder.Property(p => p.Id)
                .HasColumnName("id")
                .HasColumnType("SERIAL");
            builder.Property(p => p.Driver)
                .HasColumnName("driver_id")
                .HasColumnType("bigint");
            builder.Property(p => p.Passengers)
               .HasColumnName("passenger_id")
               .HasColumnType("bigint");
            builder.Property(p => p.TripDate)
               .HasColumnName("trip_date")
               .HasColumnType("timestamp");
            builder.Property(p => p.Status)
               .HasColumnName("status_id")
               .HasColumnType("bigint");
            builder.Property(p => p.Destination)
               .HasColumnName("destination_id")
               .HasColumnType("bigint");

            builder.HasKey(k => k.Id);
        }
    }
}
