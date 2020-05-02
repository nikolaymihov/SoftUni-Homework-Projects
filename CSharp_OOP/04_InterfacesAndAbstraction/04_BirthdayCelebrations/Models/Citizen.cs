namespace BirthdayCelebrations
{
    public class Citizen : IIdentifiable, ICreature
    {
        public Citizen(string name, int age, string id, string birthdate)
        {
            this.Name = name;
            this.Age = age;
            this.Id = id;
            this.BirthDate = birthdate;
        }

        public string Name { get; }

        public int Age { get; }

        public string Id { get; }

        public string BirthDate { get; }
    }
}
