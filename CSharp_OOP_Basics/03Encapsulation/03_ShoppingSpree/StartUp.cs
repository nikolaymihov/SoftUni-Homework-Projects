using System;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingSpree
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            string[] peopleArgs = Console.ReadLine().Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
            string[] productsArgs = Console.ReadLine().Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
            
            HashSet<Person> people = new HashSet<Person>();
            HashSet<Product> products = new HashSet<Product>();

            AddAllPeople(peopleArgs, people);
            AddAllProducts(productsArgs, products);

            string command = Console.ReadLine();

            while (command.ToLower() != "end")
            {
                string[] commandArgs = command.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
                string personName = commandArgs[0];
                string productName = commandArgs[1];

                Person currentPerson = people.Where(person => person.Name == personName).FirstOrDefault();
                Product currentProduct = products.Where(prod => prod.Name == productName).FirstOrDefault();

                if (currentPerson.CanAffordProduct(currentProduct.Cost))
                {
                    currentPerson.AddProduct(currentProduct);
                    Console.WriteLine($"{personName} bought {productName}");
                }
                else
                {
                    Console.WriteLine($"{personName} can't afford {productName}");
                }

                command = Console.ReadLine();
            }

            foreach (Person person in people)
            {
                Console.WriteLine(person);
            }

        }

        public static void AddAllPeople(string[] peopleArgs, ICollection<Person> peopleCollection)
        {
            for (int i = 0; i < peopleArgs.Length; i++)
            {
                Person person = CreatePerson(peopleArgs, i);
                peopleCollection.Add(person);
            }
        }

        public static Person CreatePerson(string[] peopleArgs, int index)
        {
            Person person = null;

            string[] currentPersonArgs = peopleArgs[index].Split(new char[] { '=' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
            string name = currentPersonArgs[0];
            decimal money = decimal.Parse(currentPersonArgs[1]);

            try
            {
                person = new Person(name, money);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                System.Environment.Exit(0);
            }

            return person;
        }

        public static void AddAllProducts(string[] productsArgs, ICollection<Product> productsCollection)
        {
            for (int i = 0; i < productsArgs.Length; i++)
            {
                Product product = CreateProduct(productsArgs, i);
                productsCollection.Add(product);
            }
        }

        public static Product CreateProduct(string[] productsArgs, int index)
        {
            Product product = null;

            string[] currentProductArgs = productsArgs[index].Split(new char[] { '=' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
            string name = currentProductArgs[0];
            decimal cost = decimal.Parse(currentProductArgs[1]);

            try
            {
                product = new Product(name, cost);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                System.Environment.Exit(0);
            }

            return product;
        }
    }
}
