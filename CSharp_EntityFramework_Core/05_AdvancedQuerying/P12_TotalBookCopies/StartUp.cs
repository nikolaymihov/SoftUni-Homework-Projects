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

            var authorCopiesInfo = CountCopiesByAuthor(dbContext);

            Console.WriteLine(authorCopiesInfo);
        }

        public static string CountCopiesByAuthor(BookShopContext context)
        {
            var output = new StringBuilder();

            var authorCopies = context.Authors
                                      .Select(a => new
                                      {
                                          FullName = a.FirstName + " " + a.LastName,
                                          BookCopies = a.Books.Sum(b => b.Copies)
                                      })
                                      .OrderByDescending(a => a.BookCopies)
                                      .ToList();

            foreach (var authorCopiesInfo in authorCopies)
            {
                output.AppendLine($"{authorCopiesInfo.FullName} - {authorCopiesInfo.BookCopies}");
            }

            return output.ToString().TrimEnd();
        }
    }
}
