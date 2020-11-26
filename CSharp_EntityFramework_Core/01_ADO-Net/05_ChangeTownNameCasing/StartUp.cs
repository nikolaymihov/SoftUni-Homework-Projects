using System;
using System.Linq;
using System.Collections.Generic;

using Microsoft.Data.SqlClient;

namespace _05_ChangeTownNameCasing
{
    public class StartUp
    {
        private const string CONNECTION_STRING = @"Server=.;Database=Minions;Integrated Security=true;";
        private const string NO_TOWN_NAMES_MSG = "No town names were affected.";

        public static void Main()
        {
            string countryName = Console.ReadLine();

            using SqlConnection dbConnection = new SqlConnection(CONNECTION_STRING);

            dbConnection.Open();

            if (CountryExists(countryName, dbConnection))
            {
                List<string> townNames = GetTownNames(countryName, dbConnection);

                if (townNames.Count() > 0)
                {
                    string countryCode = GetCountryCode(countryName, dbConnection);

                    string updateTownNamesQuery = @"Update Towns
                                                    Set Name = UPPER(Name)
                                                    Where CountryCode = @countryCode";

                    using SqlCommand updateTownNamesCommand = new SqlCommand(updateTownNamesQuery, dbConnection);

                    updateTownNamesCommand.Parameters.AddWithValue("@countryCode", countryCode);

                    Console.WriteLine(updateTownNamesCommand.ExecuteNonQuery().ToString());

                    townNames = GetTownNames(countryName, dbConnection);

                    Console.WriteLine($"[{String.Join(", ", townNames)}]");
                }
                else
                {
                    Console.WriteLine(NO_TOWN_NAMES_MSG);
                }
            }
            else
            {
                Console.WriteLine(NO_TOWN_NAMES_MSG);
            }
        }

        static bool CountryExists(string countryName, SqlConnection dbConnection)
        {
            string getCountryIdQuery = @"Select Id From Countries Where [Name] = @countryName";

            using SqlCommand getCountryIdCommand = new SqlCommand(getCountryIdQuery, dbConnection);

            getCountryIdCommand.Parameters.AddWithValue("@countryName", countryName);

            string countryId =  getCountryIdCommand.ExecuteScalar()?.ToString();

            return countryId != null;
        }

        static List<string> GetTownNames(string countryName, SqlConnection dbConnection)
        {
            List<string> townNames = new List<string>();

            string getTownNamesQuery = @"Select T.Name from Countries as C
                                         Join Towns as T On C.Id = T.CountryCode
                                         Where C.Name = @countryName";

            using SqlCommand getTownNamesCommand = new SqlCommand(getTownNamesQuery, dbConnection);

            getTownNamesCommand.Parameters.AddWithValue("@countryName", countryName);

            using SqlDataReader reader = getTownNamesCommand.ExecuteReader();

            while (reader.Read())
            {
                string townName = reader["Name"].ToString();

                townNames.Add(townName);
            }

            return townNames;
        }

        static string GetCountryCode(string countryName, SqlConnection dbConnection)
        {
            string getCountryCodeQuery = @"Select Id from Countries
                                      Where [Name] = @countryName";

            using SqlCommand getCountryCodeCommand = new SqlCommand(getCountryCodeQuery, dbConnection);

            getCountryCodeCommand.Parameters.AddWithValue("@countryName", countryName);

            return getCountryCodeCommand.ExecuteScalar()?.ToString();
        }
    }
}
