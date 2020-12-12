using System;
using System.Text;
using System.Linq;

using BookShop.Data;
using BookShop.Initializer;
using BookShop.Models;

namespace BookShop
{
    public class StartUp
    {
        public static void Main()
        {
            using var dbContext = new BookShopContext();
            //DbInitializer.ResetDatabase(dbContext);

            var startingString = Console.ReadLine();

            var books = GetBooksByAuthor(startingString, dbContext);

            Console.WriteLine(books);
        }

        public static string GetBooksByAuthor(string startingString, BookShopContext context)
        {
            StringBuilder output = new StringBuilder();

            var booksInfo = context.Books
                                     .Where(b => b.Author.LastName.StartsWith(startingString))
                                     .OrderBy(b => b.BookId)
                                     .Select(b => new
                                     {
                                         b.Title,
                                         AuthorName = b.Author.FirstName + " " + b.Author.LastName
                                     })
                                     .ToList();

            foreach (var bookInfo in booksInfo)
            {
                output.AppendLine($"{bookInfo.Title} ({bookInfo.AuthorName})");
            }

            return output.ToString().TrimEnd();
        }
    }
}
