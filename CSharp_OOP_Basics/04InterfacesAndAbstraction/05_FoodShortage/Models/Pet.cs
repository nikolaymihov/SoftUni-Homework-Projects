namespace FoodShortage
{
    public class Pet : ICreature
    {
        public Pet(string name, string birthdate)
        {
            this.Name = name;
            this.BirthDate = birthdate;
        }

        public string Name { get; }

        public string BirthDate { get; }
    }
}
