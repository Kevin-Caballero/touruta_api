using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Touruta.Core.Entities;

namespace Touruta.Infrastructure.Data.Configurations
{
    public class CommentConfiguration : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.HasKey(e => e.Id)
                    .HasName("PK_Comentario");

            builder.Property(e => e.Id).ValueGeneratedNever();

            builder.Property(e => e.Date).HasColumnType("datetime");

            builder.Property(e => e.Description)
                .IsRequired()
                .HasMaxLength(500)
                .IsUnicode(false);

            builder.HasOne(d => d.IdTourNavigation)
                .WithMany(p => p.Comments)
                .HasForeignKey(d => d.IdTour)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Comments_Tours");

            builder.HasOne(d => d.IdUserNavigation)
                .WithMany(p => p.Comments)
                .HasForeignKey(d => d.IdUser)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Comments_Users");
        }
    }
}
