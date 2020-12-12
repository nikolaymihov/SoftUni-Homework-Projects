using System;
using System.Text;
using System.Linq;

using BookShop.Data;
using BookShop.Models;
using BookShop.Initializer;

namespace BookShop
{
    public class StartUp
    {
        public static void Main()
        {
            using var dbContext = new BookShopContext();
            //DbInitializer.ResetDatabase(dbContext);

            var categoriesInfo = GetTotalProfitByCategory(dbContext);

            Console.WriteLine(categoriesInfo);
        }

        public static string GetTotalProfitByCategory(BookShopContext context)
        {
            var output = new StringBuilder();

            var categoriesInfo = context.Categories
                                        .Select(c => new
                                        {
                                            c.Name,
                                            CategoryProfit = c.CategoryBooks.Select(cb => new
                                                                         {
                                                                             BookProfit = cb.Book.Copies * cb.Book.Price
                                                                         })
                                                                        .Sum(cb => cb.BookProfit)
                                        })
                                        .OrderByDescending(c => c.CategoryProfit)
                                        .ThenBy(c => c.Name)
                                        .ToList();


            foreach (var categoryInfo in categoriesInfo)
            {
                output.AppendLine($"{categoryInfo.Name} ${categoryInfo.CategoryProfit:F2}");
            }

            return output.ToString().TrimEnd();
        }
    }
}
