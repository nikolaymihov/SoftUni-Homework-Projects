using System;

namespace Restaurant
{
    public class StartUp
    {
        public static void Main()
        {
            Cake cake = new Cake("Garage cake");
            Console.WriteLine($"Name: {cake.Name}, price: {cake.Price}, grams: {cake.Grams}, calories: {cake.Calories}");

            Fish fish = new Fish("Skumria", 7.50m);
            Console.WriteLine($"Name: {fish.Name}, price: {fish.Price}, grams {fish.Grams}");

            Coffee coffee = new Coffee("Cappuccino", 10.50);
            Console.WriteLine($"Name: {coffee.Name}, price: {coffee.Price}, milliliters: {coffee.Milliliters}, caffeine: {coffee.Caffeine}");
        }
    }
}
