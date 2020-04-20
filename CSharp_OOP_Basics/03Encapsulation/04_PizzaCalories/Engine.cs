using System;
using System.Linq;

namespace PizzaCalories
{
    public class Engine
    {
        public void Run()
        {
            string pizzaName = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray()[1];
            Pizza pizza = new Pizza(pizzaName);

            string command = Console.ReadLine();
            command = ParseCommands(pizza, command);

            Console.WriteLine(pizza);
        }

        private string ParseCommands(Pizza pizza, string command)
        {
            while (command.ToLower() != "end")
            {
                string[] commandArgs = command.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
                string typeOfInput = commandArgs[0];

                if (typeOfInput.ToLower() == "dough")
                {
                    Dough dough = CreateDough(commandArgs);
                    pizza.Dough = dough;
                }
                else if (typeOfInput.ToLower() == "topping")
                {

                    Topping topping = CreateTopping(commandArgs);
                    pizza.AddTopping(topping);
                }

                command = Console.ReadLine();
            }

            return command;
        }

        private Dough CreateDough(string[] doughArgs)
        {
            string flourType = doughArgs[1];
            string bakingTechnique = doughArgs[2];
            double weightInGrams = double.Parse(doughArgs[3]);

            Dough dough = new Dough(flourType, bakingTechnique, weightInGrams);

            return dough;
        }

        private Topping CreateTopping(string[] toppingArgs)
        {
            string toppingType = toppingArgs[1];
            double weightInGrams = double.Parse(toppingArgs[2]);

            Topping topping = new Topping(toppingType, weightInGrams);

            return topping;
        }
    }
}
