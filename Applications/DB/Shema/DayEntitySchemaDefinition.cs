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
    public class DayEntitySchemaDefinition : IEntityTypeConfiguration<Day>
    {
        public void Configure(EntityTypeBuilder<Day> builder)
        {
            builder.ToTable("days", "public");
            builder.Property(p => p.Id)
                .HasColumnName("id")
                .HasColumnType("SERIAL");
            builder.Property(p => p.Days)
                .HasColumnName("days")
                .HasColumnType("timestamp");
            builder.Property(p => p.UserId)
                .HasColumnName("user_id")
                .HasColumnType("bigint");
            builder.Property(p => p.DestinationId)
                .HasColumnName("destination_id")
                .HasColumnType("bigint");
            builder.Property(p => p.Seats)
                .HasColumnName("seats")
                .HasColumnType("bigint");

            builder.HasKey(k => k.Id);
        }
    }
}
