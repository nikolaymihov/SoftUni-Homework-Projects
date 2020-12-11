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

            string books = GetBooksByPrice(dbContext);

            Console.WriteLine(books);
        }

        public static string GetBooksByPrice(BookShopContext context)
        {
            StringBuilder output = new StringBuilder();

            var books = context.Books
                                    .AsEnumerable()
                                    .Where(b => b.Price > 40 )
                                    .Select(b => new 
                                    { 
                                        b.Title,
                                        b.Price
                                    })
                                    .OrderByDescending(b => b.Price)
                                    .ToList();

            foreach (var book in books)
            {
                output.AppendLine($"{book.Title} - ${book.Price}");
            }

            return output.ToString().TrimEnd();
        }
    }
}
