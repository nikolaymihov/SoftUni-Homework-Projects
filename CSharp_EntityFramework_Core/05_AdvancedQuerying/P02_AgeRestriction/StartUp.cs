using System;
using System.Text;
using System.Linq;

using BookShop.Data;
using BookShop.Initializer;

namespace BookShop
{
    public class StartUp
    {
        public static void Main()
        {
            var dbContext = new BookShopContext();
            //DbInitializer.ResetDatabase(dbContext);

            string ageRestriction = Console.ReadLine();

            string books = GetBooksByAgeRestriction(ageRestriction, dbContext);

            Console.WriteLine(books);
        }

        public static string GetBooksByAgeRestriction(string command, BookShopContext context)
        {
            StringBuilder output = new StringBuilder();

            var bookTitles = context.Books
                                    .AsEnumerable()
                                    .Where(b => b.AgeRestriction.ToString().ToLower() == command.ToLower())
                                    .Select(b => b.Title)
                                    .OrderBy(b => b)
                                    .ToList();

            foreach (var book in bookTitles)
            {
                output.AppendLine(book);
            }

            return output.ToString().TrimEnd();
        }
    }
}
