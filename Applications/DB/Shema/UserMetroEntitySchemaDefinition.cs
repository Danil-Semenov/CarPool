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
    public class UserMetroEntitySchemaDefinition : IEntityTypeConfiguration<UserMetro>
    {
        public void Configure(EntityTypeBuilder<UserMetro> builder)
        {
            builder.ToTable("user_metro", "dbo");

            builder.Property(p => p.UserId)
              .HasColumnName("user_id")
              .HasColumnType("bigint");

            builder.Property(p => p.MetroId)
              .HasColumnName("metro_id")
              .HasColumnType("int");

            builder.HasNoKey();
        }
    }
}
