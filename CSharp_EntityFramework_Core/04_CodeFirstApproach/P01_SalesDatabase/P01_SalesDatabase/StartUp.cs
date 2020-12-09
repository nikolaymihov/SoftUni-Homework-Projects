using System;
using System.Linq;

using P01_SalesDatabase.Data;

namespace P01_SalesDatabase
{
    public class StartUp
    {
        public static void Main()
        {
            var dbContext = new SalesDbContext();

            var products = dbContext.Products
                                    .Select(p => new
                                    {
                                        p.Name,
                                        p.Quantity,
                                        p.Price,
                                        p.Description
                                    })
                                    .Take(10)
                                    .ToList();

            foreach (var product in products)
            {
                Console.WriteLine($"{product.Name} - {product.Quantity} - {product.Price} - {product.Description}");
            }

            var sales = dbContext.Sales
                                    .Select(s => new
                                    {
                                        s.Date,
                                        ProductName = s.Product.Name,
                                        CustomerEmail = s.Customer.Email,
                                        StoreName = s.Store.Name
                                    })
                                    .Take(10)
                                    .ToList();

            foreach (var sale in sales)
            {
                Console.WriteLine($"{sale.Date} - {sale.ProductName} - {sale.CustomerEmail} - {sale.StoreName}");
            }
        }
    }
}
