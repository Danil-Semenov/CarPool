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
            builder.ToTable("trip", "dbo");
            builder.Property(p => p.Id)
                .HasColumnName("id")
                .HasColumnType("int");
            builder.Property(p => p.Driver)
                .HasColumnName("driver_id")
                .HasColumnType("int");
            builder.Property(p => p.Passengers1)
               .HasColumnName("passenger1_id")
               .HasColumnType("int");
            builder.Property(p => p.Passengers2)
               .HasColumnName("passenger2_id")
               .HasColumnType("int");
            builder.Property(p => p.Passengers3)
               .HasColumnName("passenger3_id")
               .HasColumnType("int");
            builder.Property(p => p.Passengers4)
               .HasColumnName("passenger4_id")
               .HasColumnType("int");
            builder.Property(p => p.TripDate)
               .HasColumnName("trip_date")
               .HasColumnType("DateTime");
            builder.Property(p => p.Status)
               .HasColumnName("status_id")
               .HasColumnType("int");
            builder.Property(p => p.Destination)
               .HasColumnName("destination_id")
               .HasColumnType("int");
            builder.Property(p => p.Metro)
              .HasColumnName("metro_id")
              .HasColumnType("int");
            builder.Property(p => p.Days)
              .HasColumnName("days_id")
              .HasColumnType("int");


            builder.HasKey(k => k.Id);
        }
    }
}
