using System;
using System.Linq;

using P01_StudentSystem.Data;

namespace P01_StudentSystem
{
    public class StartUp
    {
        public static void Main()
        {

            StudentSystemContext dbContext = new StudentSystemContext();

            var courses = dbContext.Courses
                                   .Select(c => new
                                   {
                                       c.Name,
                                       c.Description,
                                       c.StartDate,
                                       c.EndDate,
                                       c.Price
                                   })
                                    .OrderBy(c => c.Price)
                                    .ToList();

            foreach (var course in courses)
            {
                Console.WriteLine($"{course.Name} - {course.Description} - {course.StartDate} - {course.EndDate} - {course.Price}");
            }
        }
    }
}
