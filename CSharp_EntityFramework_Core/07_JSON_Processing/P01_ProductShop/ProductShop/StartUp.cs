using System;
using System.IO;
using System.Linq;
using System.Globalization;
using ProductShop.Data;
using ProductShop.Models;
using ProductShop.DTO.User;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Newtonsoft.Json;

namespace ProductShop
{
    public class StartUp
    {
        private static string InputDirectoryPath = "../../../Datasets/";
        private static string ResultsDirectoryPath = "../../../Datasets/Results/";

        public static void Main()
        {
            ProductShopContext db = new ProductShopContext();

            InitializeMapper();

            ResetDatabase(db);

            //Problem 01
            string usersJson = File.ReadAllText(InputDirectoryPath + "users.json");
            string usersResult = ImportUsers(db, usersJson);
            Console.WriteLine(usersResult);

            //Problem 02
            string productsJson = File.ReadAllText(InputDirectoryPath + "products.json");
            string productsResult = ImportProducts(db, productsJson);
            Console.WriteLine(productsResult);

            //Problem 03 
            string categoriesJson = File.ReadAllText(InputDirectoryPath + "categories.json");
            string categoriesResult = ImportCategories(db, categoriesJson);
            Console.WriteLine(categoriesResult);

            //Problem 04
            string categoryProductsJson = File.ReadAllText(InputDirectoryPath + "categories-products.json");
            string categoryProductsResult = ImportCategoryProducts(db, categoryProductsJson);
            Console.WriteLine(categoryProductsResult);

            EnsureDirectoryExists(ResultsDirectoryPath);

            //Problem 05
            string productsInRangeJson = GetProductsInRange(db);
            File.WriteAllText(ResultsDirectoryPath + "products-in-range.json", productsInRangeJson);

            //Problem 06
            string soldProductsJson = GetSoldProducts(db);
            //File.WriteAllText(ResultsDirectoryPath + "sold-products.json", soldProductsJson);

            //Problem 07
            string categoriesByProductJson = GetCategoriesByProductsCount(db);
            File.WriteAllText(ResultsDirectoryPath + "categories-by-product.json", categoriesByProductJson);

            //problem 08
            string usersWithProductsJson = GetUsersWithProducts(db);
            File.WriteAllText(ResultsDirectoryPath + "users-with-products.json", usersWithProductsJson);

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

        public static void InitializeMapper()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.AddProfile<ProductShopProfile>();
            });
        }

        public static string ImportUsers(ProductShopContext context, string inputJson)
        {
            User[] users = JsonConvert.DeserializeObject<User[]>(inputJson).ToArray();

            context.AddRange(users);
            context.SaveChanges();

            return $"Successfully imported {users.Length}";
        }

        public static string ImportProducts(ProductShopContext context, string inputJson)
        {
            Product[] products = JsonConvert.DeserializeObject<Product[]>(inputJson).ToArray();

            context.AddRange(products);
            context.SaveChanges();

            return $"Successfully imported {products.Length}";
        }

        public static string ImportCategories(ProductShopContext context, string inputJson)
        {
            Category[] categories = JsonConvert.DeserializeObject<Category[]>(inputJson)
                                                .Where(c => c.Name != null)
                                                .ToArray();

            context.AddRange(categories);
            context.SaveChanges();

            return $"Successfully imported {categories.Length}";
        }

        public static string ImportCategoryProducts(ProductShopContext context, string inputJson)
        {
            CategoryProduct[] categoryProducts = JsonConvert.DeserializeObject<CategoryProduct[]>(inputJson).ToArray();

            context.AddRange(categoryProducts);
            context.SaveChanges();

            return $"Successfully imported {categoryProducts.Length}";
        }

        public static string GetProductsInRange(ProductShopContext context)
        {
            var products = context.Products
                                  .Where(p => p.Price >= 500 && p.Price <= 1000)
                                  .OrderBy(p => p.Price)
                                  .Select(p => new
                                  {
                                      name = p.Name,
                                      price = p.Price,
                                      seller = p.Seller.FirstName + " " + p.Seller.LastName
                                  }).ToArray();

            string jsonResult = JsonConvert.SerializeObject(products, Formatting.Indented);

            return jsonResult;
        }

        public static string GetSoldProducts(ProductShopContext context)
        {
            UserWithSoldProductsDTO[] users = context.Users
                                  .OrderBy(u => u.LastName)
                                  .ThenBy(u => u.FirstName)
                                  .ProjectTo<UserWithSoldProductsDTO>()
                                  .ToArray();

            string jsonResult = JsonConvert.SerializeObject(users, Formatting.Indented);

            return jsonResult;
        }

        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
            var categories = context.Categories
                                    .Select(c => new
                                    {
                                        category = c.Name,
                                        productsCount = c.CategoryProducts.Count(),
                                        averagePrice = c.CategoryProducts.Average(cp => cp.Product.Price).ToString("F2"),
                                        totalRevenue = c.CategoryProducts.Sum(cp => cp.Product.Price).ToString("F2")
                                    })
                                    .OrderByDescending(c => c.productsCount)
                                    .ToArray();

            string jsonResult = JsonConvert.SerializeObject(categories, Formatting.Indented);

            return jsonResult;
        }

        public static string GetUsersWithProducts(ProductShopContext context)
        {
            var users = context.Users
                               .Where(u => u.ProductsSold.Any(p => p.Buyer != null))
                               .Select(u => new
                               {
                                   lastName = u.LastName,
                                   age = u.Age,
                                   soldProducts = new
                                   {
                                       count = u.ProductsSold.Count(p => p.Buyer != null),
                                       products = u.ProductsSold
                                                   .Where(p => p.Buyer != null)
                                                   .Select(p => new
                                                   {
                                                       name = p.Name,
                                                       price = p.Price
                                                   }).ToArray()        
                                   }
                               })
                               .OrderByDescending(u => u.soldProducts.count)
                               .ToArray();

            var resultObj = new
            {
                usersCount = users.Length,
                users = users
            };

            var jsonSettings = new JsonSerializerSettings()
            {
                Culture = CultureInfo.InvariantCulture,
                NullValueHandling = NullValueHandling.Ignore,
                Formatting = Formatting.Indented
            };

            string jsonResult = JsonConvert.SerializeObject(resultObj, jsonSettings);

            return jsonResult;
        }
    }
}