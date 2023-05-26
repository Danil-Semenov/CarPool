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
    public class ReviewEntitySchemaDefinition : IEntityTypeConfiguration<Review>
    {
        public void Configure(EntityTypeBuilder<Review> builder)
        {
            builder.ToTable("review", "dbo");
            builder.Property(p => p.Id)
                .HasColumnName("id")
                .HasColumnType("int");
            builder.Property(p => p.Trip)
                .HasColumnName("trip_id")
                .HasColumnType("int");
            builder.Property(p => p.User)
               .HasColumnName("user_id")
               .HasColumnType("bigint");
            builder.Property(p => p.Score)
               .HasColumnName("scores_id")
               .HasColumnType("int");

            builder.HasKey(k => k.Id);
        }
    }
}
