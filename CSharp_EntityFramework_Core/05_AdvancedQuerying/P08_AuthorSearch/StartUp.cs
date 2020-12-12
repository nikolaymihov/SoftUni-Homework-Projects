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

            var endingString = Console.ReadLine();

            var authorNames = GetAuthorNamesEndingIn(endingString, dbContext);

            Console.WriteLine(authorNames);
        }

        public static string GetAuthorNamesEndingIn(string endingString, BookShopContext context)
        {
            StringBuilder output = new StringBuilder();

            var authorNames = context.Authors
                                     .Where(a => a.FirstName.EndsWith(endingString))
                                     .Select(a => new
                                     {
                                         FullName = a.FirstName + " " + a.LastName
                                     })
                                     .OrderBy(a => a.FullName)
                                     .ToList();

            foreach (var authorName in authorNames)
            {
                output.AppendLine(authorName.FullName);
            }

            return output.ToString().TrimEnd();
        }
    }
}
