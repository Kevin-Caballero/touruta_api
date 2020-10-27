using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Touruta.Core.Entities;

namespace Touruta.Infrastructure.Data.Configurations
{
    public class TourConfiguration : IEntityTypeConfiguration<Tour>
    {
        public void Configure(EntityTypeBuilder<Tour> builder)
        {
            builder.HasKey(e => e.IdTour)
                    .HasName("PK_Publicacion");

            builder.Property(e => e.Audio)
                .HasMaxLength(500)
                .IsUnicode(false);

            builder.Property(e => e.Date).HasColumnType("datetime");

            builder.Property(e => e.Description)
                .IsRequired()
                .HasMaxLength(1000)
                .IsUnicode(false);

            builder.Property(e => e.Image)
                .HasMaxLength(500)
                .IsUnicode(false);

            builder.HasOne(d => d.IdUserNavigation)
                .WithMany(p => p.Tours)
                .HasForeignKey(d => d.IdUser)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Tours_Users");
        }
    }
}
