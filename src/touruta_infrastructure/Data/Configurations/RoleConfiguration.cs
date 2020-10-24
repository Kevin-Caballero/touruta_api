using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using Touruta.Core.Data;

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
