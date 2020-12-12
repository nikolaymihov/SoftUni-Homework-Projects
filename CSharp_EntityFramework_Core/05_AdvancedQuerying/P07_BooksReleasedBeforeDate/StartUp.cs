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

            var releaseDateAsStr = Console.ReadLine();

            var booksInfo = GetBooksReleasedBefore(releaseDateAsStr, dbContext);

            Console.WriteLine(booksInfo);
        }

        public static string GetBooksReleasedBefore(string dateAsStr, BookShopContext context)
        {
            var releaseDate = Convert.ToDateTime(dateAsStr);

            StringBuilder output = new StringBuilder();

            var books = context.Books
                               .Where(b => b.ReleaseDate < releaseDate)
                               .OrderByDescending(b => b.ReleaseDate)
                               .Select(b => new
                               {
                                   b.Title,
                                   EditionType = b.EditionType.ToString(),
                                   b.Price
                               })
                               .ToList();

            foreach (var book in books)
            {
                output.AppendLine($"{book.Title} - {book.EditionType} - ${book.Price}");
            }

            return output.ToString().TrimEnd();
        }
    }
}
