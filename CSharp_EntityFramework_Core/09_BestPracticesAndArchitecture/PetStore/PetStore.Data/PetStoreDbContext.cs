using Microsoft.EntityFrameworkCore;

using PetStore.Models;
using PetStore.Common;

namespace PetStore.Data
{
    public class PetStoreDbContext : DbContext
    {
        public PetStoreDbContext()
        {

        }

        public PetStoreDbContext(DbContextOptions options)
            : base(options)
        {

        }

        public virtual DbSet<Breed> Breeds { get; set; }

        public virtual DbSet<Client> Clients { get; set; }

        public virtual DbSet<ClientProduct> ClientProducts { get; set; }

        public virtual DbSet<Order> Orders { get; set; }

        public virtual DbSet<Pet> Pets { get; set; }

        public virtual DbSet<Product> Products { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(DbConfiguration.DefConnectionString);
            }

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(PetStoreDbContext).Assembly);
        }
    }
}
