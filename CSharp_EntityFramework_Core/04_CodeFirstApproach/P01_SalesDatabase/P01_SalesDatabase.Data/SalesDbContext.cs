using P01_SalesDatabase.Data.Models;

using Microsoft.EntityFrameworkCore;

namespace P01_SalesDatabase.Data
{
    public partial class SalesDbContext : DbContext
    {
        public SalesDbContext()
        {

        }

        public SalesDbContext(DbContextOptions dbContextOptions)
            : base(dbContextOptions)
        {

        }

        public virtual DbSet<Product> Products { get; set; }

        public virtual DbSet<Customer> Customers { get; set; }

        public virtual DbSet<Store> Stores { get; set; }

        public virtual DbSet<Sale> Sales { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Configuration.ConnectionString);
            }

            base.OnConfiguring(optionsBuilder); 
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>(entity => 
            {
                entity.Property(c => c.Email)
                      .IsUnicode(false);

                entity.Property(c => c.CreditCardNumber)
                      .IsUnicode(false);
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.Property(p => p.Description)
                      .HasDefaultValue("No description.");
            });

            modelBuilder.Entity<Sale>(entity => 
            {
                entity.Property(s => s.Date)
                      .HasDefaultValueSql("GETDATE()");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
