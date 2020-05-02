namespace Animals
{
    public class Kitten : Cat
    {
        private const Gender KITTENS_GENDER = Gender.Female;
        public Kitten(string name, int age) 
            : this(name, age, KITTENS_GENDER)
        {
        }

        private Kitten(string name, int age, Gender gender)
            : base(name, age, gender)
        { 
        }

        public override string ProduceSound()
        {
            return "Meow";
        }
    }
}
