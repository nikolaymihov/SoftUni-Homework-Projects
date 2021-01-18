﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using PetStore.Models;
using PetStore.Common;

namespace PetStore.Data.Configurations
{
    public class PetEntityConfiguration : IEntityTypeConfiguration<Pet>
    {
        public void Configure(EntityTypeBuilder<Pet> builder)
        {
            builder.Property(p => p.Name)
                   .HasMaxLength(GlobalConstants.PetnNameMaxLength)
                   .IsUnicode(true);
        }
    }
}
