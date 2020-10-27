﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Touruta.Core.Entities;

namespace Touruta.Infrastructure.Data.Configurations
{
    public class RoleConfiguration :IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.HasKey(e => e.IdRol);

            builder.Property(e => e.IdRol).ValueGeneratedNever();

            builder.Property(e => e.Rol)
                        .HasMaxLength(50)
                        .IsUnicode(false);
        }
    }
}
