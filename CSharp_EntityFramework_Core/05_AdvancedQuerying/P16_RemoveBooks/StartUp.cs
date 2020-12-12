using System;
using System.Linq;

using BookShop.Data;
using BookShop.Initializer;

namespace BookShop
{
    public class StartUp
    {
        public static void Main()
        {
            using var dbContext = new BookShopContext();
            //DbInitializer.ResetDatabase(dbContext);

            var affectedBooks = RemoveBooks(dbContext);

            Console.WriteLine(affectedBooks);
        }

        public static int RemoveBooks(BookShopContext context)
        {
            var booksToDelete = context.Books.Where(b => b.Copies < 4200);
            
            var countOfBooksToDelete = booksToDelete.Count();

            context.Books.RemoveRange(booksToDelete);

            context.SaveChanges();

            return countOfBooksToDelete;
        }
    }
}
