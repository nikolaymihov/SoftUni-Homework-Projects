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

            string books = GetGoldenBooks(dbContext);

            Console.WriteLine(books);
        }

        public static string GetGoldenBooks(BookShopContext context)
        {
            StringBuilder output = new StringBuilder();

            var bookTitles = context.Books
                                    .AsEnumerable()
                                    .Where(b => b.EditionType.ToString().ToLower() == "gold")
                                    .Where(b => b.Copies < 5000)
                                    .Select(b => new 
                                    { 
                                        b.BookId,
                                        b.Title
                                    })
                                    .OrderBy(b => b.BookId)
                                    .ToList();

            foreach (var book in bookTitles)
            {
                output.AppendLine(book.Title);
            }

            return output.ToString().TrimEnd();
        }
    }
}
