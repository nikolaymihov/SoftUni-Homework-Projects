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

            IncreasePrices(dbContext);
        }

        public static void IncreasePrices(BookShopContext context)
        {
            var booksToIncrease = context.Books.Where(b => b.ReleaseDate.Value.Year < 2010);

            foreach (var book in booksToIncrease)
            {
                book.Price += 5;
            }

            context.SaveChanges();
        }
    }
}
