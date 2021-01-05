using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using CarDealer.Data;
using CarDealer.Models;
using CarDealer.XMLHelper;
using CarDealer.DataTransferObjects.Import;
using CarDealer.DataTransferObjects.Export;

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

            EnsureDirectoryExists(ResultsDirectoryPath);

            //Problem 06
            var carsWithDistanceXml = GetCarsWithDistance(db);
            File.WriteAllText(ResultsDirectoryPath + "cars-with-distance.xml", carsWithDistanceXml);

            //Problem 07
            var carsFromMakeBmwXml = GetCarsFromMakeBmw(db);
            File.WriteAllText(ResultsDirectoryPath + "cars-from-make-bmw.xml", carsFromMakeBmwXml);

            //Problem 08
            var localSuppliersXml = GetLocalSuppliers(db);
            File.WriteAllText(ResultsDirectoryPath + "local-suppliers.xml", localSuppliersXml);

            //Problem 09
            var carsWithTheirPartsXml = GetCarsWithTheirListOfParts(db);
            File.WriteAllText(ResultsDirectoryPath + "cars-with-their-parts.xml", carsWithTheirPartsXml);

            //Problem 10
            var totalSalesByCustomerXml = GetTotalSalesByCustomer(db);
            File.WriteAllText(ResultsDirectoryPath + "total-sales-by-customer.xml", totalSalesByCustomerXml);

            //Problem 11
            var salesWithDiscountXml = GetSalesWithAppliedDiscount(db);
            File.WriteAllText(ResultsDirectoryPath + "sales-with-applied-discount.xml", salesWithDiscountXml);
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

        public static string GetCarsWithDistance(CarDealerContext context)
        {
            const string rootElement = "cars";

            var carsToExport = context.Cars.Where(c => c.TravelledDistance > 2000000)
                                           .Select(c => new ExportCarDto
                                           {
                                               Make = c.Make,
                                               Model = c.Model,
                                               TravelledDistance = c.TravelledDistance
                                           })
                                           .OrderBy(c => c.Make)
                                           .ThenBy(c => c.Model)
                                           .Take(10)
                                           .ToArray();

            var result = XmlConverter.Serialize(carsToExport, rootElement);

            return result;
        }

        public static string GetCarsFromMakeBmw(CarDealerContext context)
        {
            const string rootElement = "cars";

            var carsToExport = context.Cars.Where(c => c.Make.ToLower() == "bmw")
                                           .Select(c => new ExportCarsFromMakeBmwDto
                                           {
                                               Id = c.Id,
                                               Model = c.Model,
                                               TravelledDistance = c.TravelledDistance
                                           })
                                           .OrderBy(c => c.Model)
                                           .ThenByDescending(c => c.TravelledDistance)
                                           .ToArray();

            var result = XmlConverter.Serialize(carsToExport, rootElement);

            return result;
        }

        public static string GetLocalSuppliers(CarDealerContext context)
        {
            const string rootElement = "suppliers";

            var suppliersToExport = context.Suppliers.Where(s => s.IsImporter == false)
                                           .Select(c => new ExportLocalSuppliersDto
                                           {
                                               Id = c.Id,
                                               Name = c.Name,
                                               PartsCount = c.Parts.Count
                                           })
                                           .ToArray();

            var result = XmlConverter.Serialize(suppliersToExport, rootElement);

            return result;
        }

        public static string GetCarsWithTheirListOfParts(CarDealerContext context)
        {
            const string rootElement = "cars";

            var carsToExport = context.Cars.Select(c => new ExportCarsWithPartsDto
                                             {
                                                Make = c.Make,
                                                Model = c.Model,
                                                TravelledDistance = c.TravelledDistance,
                                                Parts = c.PartCars.Select(p => new PartsNameAndPriceDto
                                                                   {
                                                                        Name = p.Part.Name,
                                                                        Price = p.Part.Price
                                                                   })
                                                                   .OrderByDescending(p => p.Price) 
                                                                   .ToArray()
                                             })
                                             .OrderByDescending(c => c.TravelledDistance)
                                             .ThenBy(c => c.Model)
                                             .Take(5)
                                             .ToArray();

            var result = XmlConverter.Serialize(carsToExport, rootElement);

            return result;
        }

        public static string GetTotalSalesByCustomer(CarDealerContext context)
        {
            const string rootElement = "customers";

            var salesToExport = context.Sales.Where(s => s.Customer.Sales.Any(cs => cs.Car != null))
                                                 .Select(s => new ExportTotalSalesByCustomerDto
                                                 {
                                                     FullName = s.Customer.Name,
                                                     BoughtCars = s.Customer.Sales.Count,
                                                     SpentMoney = s.Car.PartCars.Sum(pc => pc.Part.Price)
                                                 })
                                                 .OrderByDescending(s => s.SpentMoney)
                                                 .ToArray();

            var result = XmlConverter.Serialize(salesToExport, rootElement);

            return result;
        }

        public static string GetSalesWithAppliedDiscount(CarDealerContext context)
        {
            const string rootElement = "sales";

            var salesToExport = context.Sales
                                             .Select(s => new ExportSalesWithDiscountDto
                                             {
                                                 Car = new CarDetailsDto
                                                 { 
                                                     Make = s.Car.Make,
                                                     Model = s.Car.Model,
                                                     TravelledDistance = s.Car.TravelledDistance
                                                 },
                                                 Discount = s.Discount,
                                                 CustomerName = s.Customer.Name,
                                                 Price = s.Car.PartCars.Sum(pc => pc.Part.Price),
                                                 PriceWithDiscount = s.Car.PartCars.Sum(pc => pc.Part.Price) - (s.Car.PartCars.Sum(pc => pc.Part.Price) * s.Discount / 100)
                                             })
                                             .ToArray();

            var result = XmlConverter.Serialize(salesToExport, rootElement);

            return result;
        }
    }
}