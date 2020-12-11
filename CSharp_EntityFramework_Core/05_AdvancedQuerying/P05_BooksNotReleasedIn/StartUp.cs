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

            int releasedYear = int.Parse(Console.ReadLine());

            string books = GetBooksNotReleasedIn(releasedYear, dbContext);

            Console.WriteLine(books);
        }

        public static string GetBooksNotReleasedIn(int year, BookShopContext context)
        {
            StringBuilder output = new StringBuilder();

            var books = context.Books
                                    .AsEnumerable()
                                    .Where(b => b.ReleaseDate.Value.Year != year)
                                    .Select(b => new 
                                    { 
                                        b.BookId,
                                        b.Title
                                    })
                                    .OrderBy(b => b.BookId)
                                    .ToList();

            foreach (var book in books)
            {
                output.AppendLine(book.Title);
            }

            return output.ToString().TrimEnd();
        }
    }
}
