﻿using Applications.DB.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Applications.DB.Shema
{
    public class DestinationEntitySchemaDefinition : IEntityTypeConfiguration<Destination>
    {
        public void Configure(EntityTypeBuilder<Destination> builder)
        {
            builder.ToTable("destinations", "dbo");
            builder.Property(p => p.Id)
                .HasColumnName("id")
                .HasColumnType("int");
            builder.Property(p => p.Name)
                .HasColumnName("destination")
                .HasMaxLength(50)
                .IsUnicode(true);

            builder.HasKey(k => k.Id);
        }
    }
}
