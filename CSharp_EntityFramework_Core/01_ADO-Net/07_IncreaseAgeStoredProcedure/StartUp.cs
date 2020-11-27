using System;
using System.Data;
using System.Text;

using Microsoft.Data.SqlClient;

namespace _07_IncreaseAgeStoredProcedure
{
    public class StartUp
    {
        private const string CONNECTION_STRING = @"Server=.;Database=Minions;Integrated Security=true;";

        public static void Main()
        {
            int minionId = int.Parse(Console.ReadLine());

            using SqlConnection dbConnection = new SqlConnection(CONNECTION_STRING);

            dbConnection.Open();

            string outputMsg = IncreaseMinionAgeById(minionId, dbConnection);

            Console.WriteLine(outputMsg);
        }

        private static string IncreaseMinionAgeById(int minionId, SqlConnection dbConnection)
        {
            StringBuilder output = new StringBuilder();

            string procedureName = "usp_GetOlder";

            using SqlCommand increaseAgeCommand = new SqlCommand(procedureName, dbConnection);
            increaseAgeCommand.CommandType = CommandType.StoredProcedure;
            increaseAgeCommand.Parameters.AddWithValue("@minionId", minionId);

            increaseAgeCommand.ExecuteNonQuery();

            string getMinionArgsQuery = @"Select [Name], Age From Minions
                                          Where Id = @minionId";

            using SqlCommand getMinionArgsCommand = new SqlCommand(getMinionArgsQuery, dbConnection);
            getMinionArgsCommand.Parameters.AddWithValue("@minionId", minionId);

            using SqlDataReader reader = getMinionArgsCommand.ExecuteReader();

            reader.Read();

            string minionName = reader["Name"]?.ToString();
            string minionAge = reader["Age"]?.ToString();

            output.AppendLine($"{minionName} – {minionAge} years old");

            return output.ToString().TrimEnd();
        }
    }
}
