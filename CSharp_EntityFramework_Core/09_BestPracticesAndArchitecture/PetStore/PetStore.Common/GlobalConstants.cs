namespace PetStore.Common
{
    public class GlobalConstants
    {
        //Breed
        public const int BreedNameMinLength = 5;
        public const int BreedNameMaxLength = 30;

        //Client
        public const int UsernameMinLength = 6;
        public const int UsernameMaxLength = 30;
        public const int EmailMinLength = 6;
        public const int EmailMaxLength = 50;
        public const int ClientNameMinLength = 3;
        public const int ClientNameMaxLength = 50;

        //ClientProduct
        public const int ClientProductMinQuantity = 1;
        public const int ClientProductMaxQuantity = 1000;

        //Order
        public const int TownNameMinLength = 3;
        public const int TownNameMaxLength = 50;
        public const int AddressTextMinLength = 10;
        public const int AddressTextMaxLength = 100;

        //Pet
        public const int PetNameMingLength = 3;
        public const int PetnNameMaxLength = 50;
        public const int PetMinAge = 0;
        public const int PetMaxAge = 200;

        //Product
        public const int ProductNameMinLength = 3;
        public const int ProductNameMaxLength = 50;

        //Shared
        public const int SellableMinPrice = 0;
    }
}
