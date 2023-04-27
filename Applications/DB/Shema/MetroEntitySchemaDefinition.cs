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
    public class MetroEntitySchemaDefinition : IEntityTypeConfiguration<Metro>
    {
        public void Configure(EntityTypeBuilder<Metro> builder)
        {
            builder.ToTable("metro", "public");
            builder.Property(p => p.Id)
                .HasColumnName("id")
                .HasColumnType("SERIAL");
            builder.Property(p => p.Name)
                .HasColumnName("station")
                .HasMaxLength(50)
                .IsUnicode(false);
            builder.Property(p => p.UserId)
                .HasColumnName("user_id")
                .HasColumnType("bigint");

            builder.HasKey(k => k.Id);
        }
    }
}
