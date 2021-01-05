using System;
using System.IO;
using System.Linq;
using ProductShop.Data;
using ProductShop.Models;
using ProductShop.XMLHelper;
using ProductShop.Dtos.Import;
using ProductShop.Dtos.Export;

namespace ProductShop
{
    public class StartUp
    {
        private static string InputDirectoryPath = "../../../Datasets/";
        private static string ResultsDirectoryPath = "../../../Datasets/Results/";

        public static void Main()
        {
            ProductShopContext db = new ProductShopContext();

            ResetDatabase(db);

            //Problem 01
            var usersXml = File.ReadAllText(InputDirectoryPath + "users.xml");
            var usersResult = ImportUsers(db, usersXml);
            Console.WriteLine(usersResult);

            //Problem 02
            var productsXml = File.ReadAllText(InputDirectoryPath + "products.xml");
            var productsResult = ImportProducts(db, productsXml);
            Console.WriteLine(productsResult);

            //Problem 03
            var categoriesXml = File.ReadAllText(InputDirectoryPath + "categories.xml");
            var categoriesResult = ImportCategories(db, categoriesXml);
            Console.WriteLine(categoriesResult);

            //Problem 04
            var categoryProductsXml = File.ReadAllText(InputDirectoryPath + "categories-products.xml");
            var categoryProductsResult = ImportCategoryProducts(db, categoryProductsXml);
            Console.WriteLine(categoryProductsResult);

            EnsureDirectoryExists(ResultsDirectoryPath);

            //Problem 05
            var productsInRangeXml = GetProductsInRange(db);
            File.WriteAllText(ResultsDirectoryPath + "products-in-range.xml", productsInRangeXml);

            //Problem 06
            var usersWithSoldProductsXml = GetSoldProducts(db);
            File.WriteAllText(ResultsDirectoryPath + "users-with-sold-products.xml", usersWithSoldProductsXml);

            //Problem 07
            var categoriesByProductsCountXml = GetCategoriesByProductsCount(db);
            File.WriteAllText(ResultsDirectoryPath + "categories-by-products-count.xml", categoriesByProductsCountXml);

            //Problem 08
            var usersWithProductsXml = GetUsersWithProducts(db);
            File.WriteAllText(ResultsDirectoryPath + "users-with-products.xml", usersWithProductsXml);
        }

        public static void ResetDatabase(ProductShopContext db)
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

        public static string ImportUsers(ProductShopContext context, string inputXml)
        {
            const string rootElement = "Users";

            var usersResult = XmlConverter.Deserializer<ImportUserDto>(inputXml, rootElement);

            var usersToImport = usersResult.Select(u => new User
                                            {
                                                FirstName = u.FirstName,
                                                LastName = u.LastName,
                                                Age = u.Age
                                            })
                                            .ToArray();

            context.Users.AddRange(usersToImport);
            context.SaveChanges();

            return $"Successfully imported {usersToImport.Length}";
            
        }

        public static string ImportProducts(ProductShopContext context, string inputXml)
        {
            const string rootElement = "Products";

            var productsResult = XmlConverter.Deserializer<ImportProductDto>(inputXml, rootElement);

            var productsToImport = productsResult.Select(p => new Product
                                                {
                                                    Name = p.Name,
                                                    Price = p.Price,
                                                    SellerId = p.SellerId,
                                                    BuyerId = p.BuyerId
                                                })
                                                .ToArray();

            context.Products.AddRange(productsToImport);
            context.SaveChanges();

            return $"Successfully imported {productsToImport.Length}";
        }

        public static string ImportCategories(ProductShopContext context, string inputXml)
        {
            const string rootElement = "Categories";

            var categoriesResult = XmlConverter.Deserializer<ImportCategoryDto>(inputXml, rootElement);

            var categoriesToImport = categoriesResult.Where(c => c.Name != null)
                                                     .Select(c => new Category
                                                     {
                                                         Name = c.Name
                                                     })
                                                     .ToArray();

            context.Categories.AddRange(categoriesToImport);
            context.SaveChanges();

            return $"Successfully imported {categoriesToImport.Length}";
        }

        public static string ImportCategoryProducts(ProductShopContext context, string inputXml)
        {
            const string rootElement = "CategoryProducts";

            var categoryProductsResult = XmlConverter.Deserializer<ImportCategoryProductDto>(inputXml, rootElement);

            var categoryProductsToImport = categoryProductsResult
                                                     .Where(cp => context.Categories.Any(c => c.Id == cp.CategoryId) &&
                                                                  context.Products.Any(p => p.Id == cp.ProductId))
                                                     .Select(cp => new CategoryProduct
                                                     {
                                                         CategoryId = cp.CategoryId,
                                                         ProductId = cp.ProductId
                                                     })
                                                     .ToArray();

            context.CategoryProducts.AddRange(categoryProductsToImport);
            context.SaveChanges();

            return $"Successfully imported {categoryProductsToImport.Length}";
        }

        public static string GetProductsInRange(ProductShopContext context)
        {
            const string rootElement = "Products";

            var productsToExport = context.Products
                                          .Where(p => p.Price >= 500 && p.Price <= 1000)
                                          .Select(p => new ExportProductsInRangeDto
                                          {
                                              Name = p.Name,
                                              Price = p.Price,
                                              Buyer = p.Buyer.FirstName + ' ' + p.Buyer.LastName
                                          })
                                          .OrderBy(p => p.Price)
                                          .Take(10)
                                          .ToArray();

            var result = XmlConverter.Serialize(productsToExport, rootElement);

            return result;
        }

        public static string GetSoldProducts(ProductShopContext context)
        {
            const string rootElement = "Users";

            var usersWithSoldProductsToExport = context.Users
                                                       .Where(u => u.ProductsSold.Any(p => p.Buyer != null))
                                                       .Select(u => new ExportUserWithSoldProductsDto
                                                       {
                                                           FirstName = u.FirstName,
                                                           LastName = u.LastName,
                                                           SoldProducts = u.ProductsSold
                                                                           .Select(ps => new UserSoldProductDto
                                                                           {
                                                                               Name = ps.Name,
                                                                               Price = ps.Price
                                                                           }).ToArray()
                                                       })
                                                       .OrderBy(u => u.LastName)
                                                       .ThenBy(u => u.FirstName)
                                                       .Take(5)
                                                       .ToArray();

            var result = XmlConverter.Serialize(usersWithSoldProductsToExport, rootElement);

            return result;
        }

        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
            const string rootElement = "Categories";

            var categoriesByProductsToExport = context.Categories
                                                      .Select(c => new ExportCategoriesByProductsDto
                                                      {
                                                          Name = c.Name,
                                                          Count = c.CategoryProducts.Count,
                                                          AveragePrice = c.CategoryProducts.Average(cp => cp.Product.Price),
                                                          TotalRevenue = c.CategoryProducts.Sum(cp => cp.Product.Price)
                                                      })
                                                      .OrderByDescending(c => c.Count)
                                                      .ThenBy(c => c.TotalRevenue)
                                                      .ToArray();
            
            var result = XmlConverter.Serialize(categoriesByProductsToExport, rootElement);

            return result;
        }

        public static string GetUsersWithProducts(ProductShopContext context)
        {
            const string rootElement = "Users";

            var usersWithSoldProducts = context.Users
                                                   .Where(u => u.ProductsSold.Any(p => p.Buyer != null))
                                                   .Select(u => new UsersWithSoldProductsDto
                                                   {
                                                       FirstName = u.FirstName,
                                                       LastName = u.LastName,
                                                       Age = u.Age,
                                                       SoldProducts = new SoldProductsDto
                                                       {
                                                           Count = u.ProductsSold.Count,
                                                           Products = u.ProductsSold
                                                                       .Select(ps => new ProductWithPriceDto 
                                                                       { 
                                                                            Name = ps.Name,
                                                                            Price = ps.Price
                                                                       }).ToArray()
                                                       }
                                                   })
                                                   .OrderByDescending(u => u.SoldProducts.Count)
                                                   .ToArray();

            var usersWithProductsToExport = new ExportUsersWithCountOfSoldProductsDto
                                            {
                                                Count = usersWithSoldProducts.Length,
                                                Users = usersWithSoldProducts.Take(10).ToArray()
                                            };

            var result = XmlConverter.Serialize(usersWithProductsToExport, rootElement);

            return result;
        }
    }
}