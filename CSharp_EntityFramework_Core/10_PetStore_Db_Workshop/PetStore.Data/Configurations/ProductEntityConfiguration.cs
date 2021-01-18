using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using PetStore.Models;
using PetStore.Common;

namespace PetStore.Data.Configurations
{
    public class ProductEntityConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            //Making property Name to be unique
            builder.HasAlternateKey(p => p.Name);

            builder.Property(p => p.Name)
                   .HasMaxLength(GlobalConstants.ProductNameMaxLength)
                   .IsUnicode(true);
        }
    }
}
