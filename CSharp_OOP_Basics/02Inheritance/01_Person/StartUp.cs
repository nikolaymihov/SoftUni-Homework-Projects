namespace Person
{
    using System;
    public class StartUp
    {
        public static void Main()
        {
            string childName = Console.ReadLine();
            int childAge = int.Parse(Console.ReadLine());

            Child child = new Child(childName, childAge);
            Console.WriteLine(child);
        }
    }
}
