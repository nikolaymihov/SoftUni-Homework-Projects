using System;
using System.Text;
using System.Linq;

using BookShop.Data;
using BookShop.Initializer;
using Microsoft.EntityFrameworkCore.Internal;
using System.Collections.Generic;

namespace BookShop
{
    public class StartUp
    {
        public static void Main()
        {
            using var dbContext = new BookShopContext();
            //DbInitializer.ResetDatabase(dbContext);

            var categoriesAsStr = Console.ReadLine();

            var books = GetBooksByCategory(categoriesAsStr, dbContext);

            Console.WriteLine(books);
        }

        public static string GetBooksByCategory(string categoriesAsStr, BookShopContext context)
        {
            StringBuilder output = new StringBuilder();

            var categories = categoriesAsStr.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                                            .Select(c => c.ToLower())
                                            .ToList();

            var bookTitles = new List<string>();

            foreach (var cat in categories)
            {
                var currentCatBookTitles = context.Books
                                               .Where(b => b.BookCategories.Any(bc => bc.Category.Name.ToLower() == cat))
                                               .Select(b => b.Title)
                                               .ToList();

                bookTitles.AddRange(currentCatBookTitles);
            }

            bookTitles = bookTitles.OrderBy(bt => bt).ToList();

            foreach (var bookTitle in bookTitles)
            {
                output.AppendLine(bookTitle);
            }

            return output.ToString().TrimEnd();
        }
    }
}
