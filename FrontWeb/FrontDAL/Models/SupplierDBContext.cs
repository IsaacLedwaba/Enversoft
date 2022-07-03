using Microsoft.EntityFrameworkCore;

#nullable disable

namespace FrontDAL.Models
{
    internal partial class SupplierDBContext : DbContext
    {
        public SupplierDBContext()
        {
        }

        public SupplierDBContext(DbContextOptions<SupplierDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Supplier> Suppliers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=SupplierDB;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Supplier>(entity =>
            {
                entity.HasKey(e => e.Code)
                    .HasName("PK__Supplier__A25C5AA6230B082F");

                entity.ToTable("Supplier");

                entity.Property(e => e.Code).ValueGeneratedNever();

                entity.Property(e => e.Name).HasColumnName(" Name");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
