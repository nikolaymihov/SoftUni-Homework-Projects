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

            var titleLength = int.Parse(Console.ReadLine());

            var booksCount = CountBooks(titleLength, dbContext);

            Console.WriteLine($"There are {booksCount} books with longer title than {titleLength} symbols");
        }

        public static int CountBooks(int lengthCheck, BookShopContext context)
        {
            return context.Books.Count(b => b.Title.Length > lengthCheck);
        }
    }
}
