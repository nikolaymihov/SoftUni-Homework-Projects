using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using PetStore.Common;
using PetStore.Models.Enums;

namespace PetStore.Models
{
    public class Pet
    {
        public Pet()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        [Key]
        [Required]
        public string Id { get; set; }

        [Required]
        [MinLength(GlobalConstants.PetNameMingLength)]
        public string Name { get; set; }

        public Gender Gender { get; set; }

        [Range(GlobalConstants.PetMinAge, GlobalConstants.PetMaxAge)]
        public byte Age { get; set; }

        public bool IsSold { get; set; }

        [Range(GlobalConstants.SellableMinPrice, Double.MaxValue)]
        public decimal Price { get; set; }

        [Required]
        [ForeignKey(nameof(Breed))]
        public string BreedId { get; set; }

        public virtual Breed Breed { get; set; }

        [Required]
        [ForeignKey(nameof(Client))]
        public string ClientId { get; set; }

        public virtual Client Client { get; set; }
    }
}
