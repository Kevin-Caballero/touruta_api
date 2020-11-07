using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using Touruta.Core.Data;

namespace Touruta.Infrastructure.Data.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(e => e.IdUser)
                    .HasName("PK_Usuario");

            builder.Property(e => e.BirthDate).HasColumnType("date");

            builder.Property(e => e.Email)
                .IsRequired()
                .HasMaxLength(30)
                .IsUnicode(false);

            builder.Property(e => e.LastName)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.Property(e => e.Phone)
                .HasMaxLength(10)
                .IsUnicode(false);

            builder.Property(e => e.UserName)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.HasOne(d => d.IdRolNavigation)
                .WithMany(p => p.Users)
                .HasForeignKey(d => d.IdRol)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Users_Roles");
        }
    }
}
