using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Applications.DB.Entities;

namespace Applications.DB.Shema
{
    public class UserEntitySchemaDefinition : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("users", "dbo");

            builder.Property(p => p.Id)
                .HasColumnName("id")
                .HasColumnType("int");
            builder.Property(p => p.RoleId)
                .HasColumnName("role_id")
                .HasColumnType("int");
            builder.Property(p => p.FirstName)
                .HasColumnName("first_name")
                .HasMaxLength(50)
                .IsUnicode(false);
            builder.Property(p => p.Phone)
                .HasColumnName("phone")
                .HasMaxLength(30)
                .IsUnicode(false);
            builder.Property(p => p.TgLink)
                .HasColumnName("tg_link")
                .HasMaxLength(30)
                .IsUnicode(false);
            builder.Property(p => p.Benefits)
                .HasColumnName("benefits")
                .HasMaxLength(30)
                .IsUnicode(false);
            builder.Property(p => p.Capacity)
                .HasColumnName("capacity")
                .HasColumnType("int");
            builder.Property(p => p.RegistrationDate)
                .HasColumnName("registration_date")
                .HasColumnType("DateTime");

            builder.HasKey(k => k.Id);
        }
    }
}
