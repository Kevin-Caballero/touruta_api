using Microsoft.EntityFrameworkCore;
using Touruta.Core.Entities;
using Touruta.Infrastructure.Data.Configurations;

namespace Touruta.Infrastructure.Data
{
    public partial class TourutaContext : DbContext
    {
        public TourutaContext() {}

        public TourutaContext(DbContextOptions<TourutaContext> options)
            : base(options) {}

        public virtual DbSet<Comment> Comments { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Tour> Tours { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CommentConfiguration());
            modelBuilder.ApplyConfiguration(new RoleConfiguration());
            modelBuilder.ApplyConfiguration(new TourConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
        }
    }
}
