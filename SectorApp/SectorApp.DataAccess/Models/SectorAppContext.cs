using Microsoft.EntityFrameworkCore;

namespace SectorApp.DataAccess.Models
{
    public class SectorAppContext : DbContext
    {
        public SectorAppContext()
        {
        }

        public SectorAppContext(DbContextOptions<SectorAppContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AppUser> AppUsers { get; set; }
        public virtual DbSet<Sector> Sectors { get; set; }
        public virtual DbSet<UsersSector> UsersSectors { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=MAMMADOVE10;Database=SectorApp;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<AppUser>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Sector>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.Parent);
            });

            modelBuilder.Entity<UsersSector>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.HasOne(d => d.IdNavigation)
                    .WithOne(p => p.UsersSectors)
                    .HasForeignKey<UsersSector>(d => d.Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UsersSectors_Sectors");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UsersSectors)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UsersSectors_AppUsers");
            });
        }
    }
}
