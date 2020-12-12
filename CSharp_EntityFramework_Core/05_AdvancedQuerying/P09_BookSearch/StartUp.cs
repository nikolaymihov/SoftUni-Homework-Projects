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

            var letterCombination = Console.ReadLine();

            var titles = GetBookTitlesContaining(letterCombination, dbContext);

            Console.WriteLine(titles);
        }

        public static string GetBookTitlesContaining(string letterCombination, BookShopContext context)
        {
            StringBuilder output = new StringBuilder();

            var bookTitles = context.Books
                                     .Where(b => b.Title.Contains(letterCombination))
                                     .Select(b => b.Title)
                                     .OrderBy(bt => bt)
                                     .ToList();

            foreach (var title in bookTitles)
            {
                output.AppendLine(title);
            }

            return output.ToString().TrimEnd();
        }
    }
}
