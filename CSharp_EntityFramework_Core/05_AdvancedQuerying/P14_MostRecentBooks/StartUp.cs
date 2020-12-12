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

            var booksPerCategory = GetMostRecentBooks(dbContext);

            Console.WriteLine(booksPerCategory);
        }

        public static string GetMostRecentBooks(BookShopContext context)
        {
            var output = new StringBuilder();

            var mostRecentBooksPerCategory = context.Categories
                                                    .OrderBy(c => c.Name)
                                                    .Select(c => new
                                                    {
                                                        c.Name,
                                                        MostRecentBooks = c.CategoryBooks
                                                                           .Select(cb => new
                                                                           {
                                                                               cb.Book.Title,
                                                                               cb.Book.ReleaseDate
                                                                           })
                                                                           .OrderByDescending(cb => cb.ReleaseDate)
                                                                           .Take(3)
                                                                           .ToList()
                                                    }).ToList();


            foreach (var categoryBooks in mostRecentBooksPerCategory)
            {
                output.AppendLine($"--{categoryBooks.Name}");

                foreach (var book in categoryBooks.MostRecentBooks)
                {
                    output.AppendLine($"{book.Title} ({book.ReleaseDate.Value.Year})");
                }
            }

            return output.ToString().TrimEnd();
        }
    }
}
