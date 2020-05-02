namespace NeedForSpeed
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            FamilyCar myFamilyCar = new FamilyCar(250, 50);
            myFamilyCar.Drive(3);
            Console.WriteLine(myFamilyCar);

            RaceMotorcycle myRaceMotorcycle = new RaceMotorcycle(20, 10);
            myRaceMotorcycle.Drive(0.5);
            Console.WriteLine(myRaceMotorcycle);

            CrossMotorcycle myCrossMotorCycle = new CrossMotorcycle(15, 20);
            myCrossMotorCycle.Drive(10);
            Console.WriteLine(myCrossMotorCycle);
        }
    }
}
