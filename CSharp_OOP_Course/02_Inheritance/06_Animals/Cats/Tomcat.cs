namespace Animals
{
    public class Tomcat : Animal
    {
        private const Gender TOMCATS_GENDER = Gender.Male;
        
        public Tomcat(string name, int age)
            : this(name, age, TOMCATS_GENDER)
        {
        }

        private Tomcat(string name, int age, Gender gender) 
            : base(name, age, gender)
        {
        }

        public override string ProduceSound()
        {
            return "MEOW";
        }
    }
}
