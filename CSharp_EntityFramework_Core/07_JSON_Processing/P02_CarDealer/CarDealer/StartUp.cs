using System;
using System.IO;
using System.Linq;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using CarDealer.DTO;
using CarDealer.Data;
using CarDealer.Models;
using Newtonsoft.Json;

namespace CarDealer
{
    public class StartUp
    {
        private static string InputDirectoryPath = "../../../Datasets/";
        private static string ResultsDirectoryPath = "../../../Datasets/Results/";

        public static void Main()
        {
            CarDealerContext db = new CarDealerContext();

            InitializeMapper();

            ResetDatabase(db);

            //Problem 01
            string suppliersJson = File.ReadAllText(InputDirectoryPath + "suppliers.json");
            string suppliersResult = ImportSuppliers(db, suppliersJson);
            Console.WriteLine(suppliersResult);

            //Problem 02
            string partsJson = File.ReadAllText(InputDirectoryPath + "parts.json");
            string partsResult = ImportParts(db, partsJson);
            Console.WriteLine(partsResult);

            //Problem 03
            string carsJson = File.ReadAllText(InputDirectoryPath + "cars.json");
            string carsResult = ImportCars(db, carsJson);
            Console.WriteLine(carsResult);

            //Problem 04
            string customersJson = File.ReadAllText(InputDirectoryPath + "customers.json");
            string customersResult = ImportCustomers(db, customersJson);
            Console.WriteLine(customersResult);

            //Problem 05
            string salesJson = File.ReadAllText(InputDirectoryPath + "sales.json");
            string salesResult = ImportSales(db, salesJson);
            Console.WriteLine(salesResult);

            EnsureDirectoryExists(ResultsDirectoryPath);

            //Problem 06
            string orderedCustomersJson = GetOrderedCustomers(db);
            File.WriteAllText(ResultsDirectoryPath + "ordered-customers.json", orderedCustomersJson);

            //Problem 07
            string toyotaCarsJson = GetCarsFromMakeToyota(db);
            File.WriteAllText(ResultsDirectoryPath + "cars-from-make-toyota.json", toyotaCarsJson);

            //Problem 08
            string localSuppliersJson = GetLocalSuppliers(db);
            File.WriteAllText(ResultsDirectoryPath + "local-suppliers.json", localSuppliersJson);

            //Problem 09
            string carsWithPartsJson = GetCarsWithTheirListOfParts(db);
            File.WriteAllText(ResultsDirectoryPath + "cars-with-parts.json", carsWithPartsJson);

            //Problem 10
            string customerSalesJson = GetTotalSalesByCustomer(db);
            File.WriteAllText(ResultsDirectoryPath + "customer-sales.json", customerSalesJson);

        }

        public static void ResetDatabase(CarDealerContext context)
        {
            context.Database.EnsureDeleted();
            Console.WriteLine("Database was successfully deleted!");

            context.Database.EnsureCreated();
            Console.WriteLine("Database was successfully created!");
        }

        public static void EnsureDirectoryExists(string path)
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
        }

        public static void InitializeMapper()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.AddProfile<CarDealerProfile>();
            });
        }

        public static string ImportSuppliers(CarDealerContext context, string inputJson)
        {
            Supplier[] suppliers = JsonConvert.DeserializeObject<Supplier[]>(inputJson).ToArray();

            context.Suppliers.AddRange(suppliers);
            context.SaveChanges();

            return $"Successfully imported {suppliers.Length}";
        }

        public static string ImportParts(CarDealerContext context, string inputJson)
        {
            Part[] parts = JsonConvert.DeserializeObject<Part[]>(inputJson).Where(p => p.SupplierId <= 31).ToArray();

            context.Parts.AddRange(parts);
            context.SaveChanges();

            return $"Successfully imported {parts.Length}";
        }

        public static string ImportCars(CarDealerContext context, string inputJson)
        {
            Car[] cars = JsonConvert.DeserializeObject<Car[]>(inputJson).ToArray();

            context.Cars.AddRange(cars);
            context.SaveChanges();

            return $"Successfully imported {cars.Length}";
        }

        public static string ImportCustomers(CarDealerContext context, string inputJson)
        {
            Customer[] customers = JsonConvert.DeserializeObject<Customer[]>(inputJson).ToArray();

            context.Customers.AddRange(customers);
            context.SaveChanges();

            return $"Successfully imported {customers.Length}";
        }

        public static string ImportSales(CarDealerContext context, string inputJson)
        {
            Sale[] sales = JsonConvert.DeserializeObject<Sale[]>(inputJson).ToArray();

            context.Sales.AddRange(sales);
            context.SaveChanges();

            return $"Successfully imported {sales.Length}";
        }

        public static string GetOrderedCustomers(CarDealerContext context)
        {
            CustomersDTO[] customers = context.Customers
                                   .OrderBy(c => c.BirthDate)
                                   .ThenBy(c => c.IsYoungDriver == false)
                                   .ProjectTo<CustomersDTO>()
                                   .ToArray();

            string customersJson = JsonConvert.SerializeObject(customers, Formatting.Indented);

            return customersJson;
        }

        public static string GetCarsFromMakeToyota(CarDealerContext context)
        {
            CarsFromMakeDTO[] cars = context.Cars
                                            .Where(c => c.Make == "Toyota")
                                            .OrderBy(c => c.Model)
                                            .ThenByDescending(c => c.TravelledDistance)
                                            .ProjectTo<CarsFromMakeDTO>()
                                            .ToArray();

            string carsJson = JsonConvert.SerializeObject(cars, Formatting.Indented);

            return carsJson;
        }

        public static string GetLocalSuppliers(CarDealerContext context)
        {
            var suppliers = context.Suppliers
                                   .Where(s => s.IsImporter == false)
                                   .Select(s => new
                                   {
                                       s.Id,
                                       s.Name,
                                       PartsCount = s.Parts.Count
                                   })
                                   .ToArray();

            string suppliersJson = JsonConvert.SerializeObject(suppliers, Formatting.Indented);

            return suppliersJson;
        }

        public static string GetCarsWithTheirListOfParts(CarDealerContext context)
        {
            var cars = context.Cars
                                   .Select(c => new
                                   {
                                       car = new
                                       {
                                           c.Make,
                                           c.Model,
                                           c.TravelledDistance
                                       },
                                       parts = c.PartCars
                                                .Where(cp => cp.CarId == c.Id)
                                                .Select(cp => new
                                                {
                                                    cp.Part.Name,
                                                    Price = cp.Part.Price.ToString("F2")
                                                }).ToArray()
                                   }).ToArray();

            string carsJson = JsonConvert.SerializeObject(cars, Formatting.Indented);

            return carsJson;
        }

        public static string GetTotalSalesByCustomer(CarDealerContext context)
        {
            var customers = context.Customers
                                   .Where(c => c.Sales.Any(s => s.Car != null))
                                   .Select(c => new
                                   {
                                       fullName = c.Name,
                                       boughtCars = c.Sales.Count
                                   })
                                   .OrderByDescending(c => c.boughtCars)
                                   .ToArray();

            string customersJson = JsonConvert.SerializeObject(customers, Formatting.Indented);

            return customersJson;
        }
    }
}