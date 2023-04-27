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
    public class ScoreEntitySchemaDefinition : IEntityTypeConfiguration<Score>
    {
        public void Configure(EntityTypeBuilder<Score> builder)
        {
            builder.ToTable("scores", "public");
            builder.Property(p => p.Id)
                .HasColumnName("id")
                .HasColumnType("SERIAL");
            builder.Property(p => p.Name)
                .HasColumnName("description")
                .HasMaxLength(50)
                .IsUnicode(false);
            builder.Property(p => p.RoleId)
                .HasColumnName("role_id")
                .HasColumnType("bigint");

            builder.HasKey(k => k.Id);
        }
    }
}
