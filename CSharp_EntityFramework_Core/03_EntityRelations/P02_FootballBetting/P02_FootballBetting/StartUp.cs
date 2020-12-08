using System;
using System.Linq;

using P02_FootballBetting.Data;

namespace _02_FootballBetting
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var dbContext = new FootballBettingContext();

            var users = dbContext.Users
                                 .Select(u => new
                                 {
                                     u.Username,
                                     u.Password,
                                     u.Email,
                                     u.Balance
                                 })
                                 .OrderByDescending(u => u.Balance)
                                 .ToList();

            foreach (var user in users)
            {
                Console.WriteLine($"{user.Username} - {user.Password} - {user.Email} - {user.Balance}");
            }
        }
    }
}
