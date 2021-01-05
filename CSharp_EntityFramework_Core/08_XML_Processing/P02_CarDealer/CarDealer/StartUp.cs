using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using CarDealer.Data;
using CarDealer.Models;
using CarDealer.XMLHelper;
using CarDealer.DataTransferObjects.Import;

namespace CarDealer
{
    public class StartUp
    {
        private static string InputDirectoryPath = "../../../Datasets/";
        private static string ResultsDirectoryPath = "../../../Datasets/Results/";

        public static void Main()
        {
            CarDealerContext db = new CarDealerContext();

            ResetDatabase(db);

            //Problem 01
            var suppliersXml = File.ReadAllText(InputDirectoryPath + "suppliers.xml");
            var suppliersResult = ImportSuppliers(db, suppliersXml);
            Console.WriteLine(suppliersResult);

            //Problem 02
            var partsXml = File.ReadAllText(InputDirectoryPath + "parts.xml");
            var partsResult = ImportParts(db, partsXml);
            Console.WriteLine(partsResult);

            //Problem 03
            var carsXml = File.ReadAllText(InputDirectoryPath + "cars.xml");
            var carsResult = ImportCars(db, carsXml);
            Console.WriteLine(carsResult);

            //Problem 04
            var customersXml = File.ReadAllText(InputDirectoryPath + "customers.xml");
            var customersResult = ImportCustomers(db, customersXml);
            Console.WriteLine(customersResult);

            //Problem 05
            var salesXml = File.ReadAllText(InputDirectoryPath + "sales.xml");
            var salesResult = ImportSales(db, salesXml);
            Console.WriteLine(salesResult);
        }

        public static void ResetDatabase(CarDealerContext db)
        {
            db.Database.EnsureDeleted();
            Console.WriteLine("Database was successfully deleted!");

            db.Database.EnsureCreated();
            Console.WriteLine("Database was successfully created!");
        }

        public static void EnsureDirectoryExists(string path)
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
        }

        public static string ImportSuppliers(CarDealerContext context, string inputXml)
        {
            const string rootElement = "Suppliers";

            var suppliersResult = XmlConverter.Deserializer<ImportSupplierDto>(inputXml, rootElement);

            var suppliersToImport = suppliersResult.Select(s => new Supplier
                                    {
                                        Name = s.Name,
                                        IsImporter = s.IsImporter
                                    })
                                    .ToArray();

            context.Suppliers.AddRange(suppliersToImport);
            context.SaveChanges();

            return $"Successfully imported {suppliersToImport.Length}";
        }

        public static string ImportParts(CarDealerContext context, string inputXml)
        {
            const string rootElement = "Parts";

            var partsResult = XmlConverter.Deserializer<ImportPartDto>(inputXml, rootElement);

            var partsToImport = partsResult.Where(p => context.Suppliers.Any(s => s.Id == p.SupplierId))
                                           .Select(p => new Part
                                           {
                                               Name = p.Name,
                                               Price = p.Price,
                                               Quantity = p.Quantity,
                                               SupplierId = p.SupplierId
                                           })
                                           .ToArray();

            context.Parts.AddRange(partsToImport);
            context.SaveChanges();

            return $"Successfully imported {partsToImport.Length}";
        }

        public static string ImportCars(CarDealerContext context, string inputXml)
        {
            const string rootElement = "Cars";

            var carsResult = XmlConverter.Deserializer<ImportCarDto>(inputXml, rootElement);

            var carsToImport = new List<Car>();

            foreach (var carDto in carsResult)
            {
                var uniqueParts = carDto.Parts.Select(p => p.Id).Distinct().ToArray();
                var realParts = uniqueParts.Where(id => context.Parts.Any(p => p.Id == id));

                var car = new Car
                {
                    Make = carDto.Make,
                    Model = carDto.Model,
                    TravelledDistance = carDto.TraveledDistance,
                    PartCars = realParts.Select(id => new PartCar
                    {
                        PartId = id
                    }).ToArray()
                };

                carsToImport.Add(car);
            }

            context.Cars.AddRange(carsToImport);
            context.SaveChanges();

            return $"Successfully imported {carsToImport.Count}";
        }

        public static string ImportCustomers(CarDealerContext context, string inputXml)
        {
            const string rootElement = "Customers";

            var customersResult = XmlConverter.Deserializer<ImportCustomerDto>(inputXml, rootElement);

            var customersToImport = customersResult
                                            .Select(c => new Customer
                                            {
                                                Name = c.Name,
                                                BirthDate = DateTime.Parse(c.Birthdate),
                                                IsYoungDriver = c.IsYoungDriver
                                            })
                                            .ToArray();

            context.Customers.AddRange(customersToImport);
            context.SaveChanges();

            return $"Successfully imported {customersToImport.Length}";
        }

        public static string ImportSales(CarDealerContext context, string inputXml)
        {
            const string rootElement = "Sales";

            var salesResult = XmlConverter.Deserializer<ImportSaleDto>(inputXml, rootElement);

            var salesToImport = salesResult
                                           .Where(s => context.Cars.Any(c => c.Id == s.CarId))
                                           .Select(s => new Sale
                                           {
                                               CarId = s.CarId,
                                               CustomerId = s.CustomerId,
                                               Discount = s.Discount
                                           })
                                           .ToArray();

            context.Sales.AddRange(salesToImport);
            context.SaveChanges();

            return $"Successfully imported {salesToImport.Length}";
        }
    }
}