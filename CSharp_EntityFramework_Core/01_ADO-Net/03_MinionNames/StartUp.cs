using System;
using System.Text;

using Microsoft.Data.SqlClient;

namespace _03_MinionNames
{
    public class StartUp
    {
        public static void Main()
        {
            int villainId = int.Parse(Console.ReadLine());
            StringBuilder result = new StringBuilder();

            using SqlConnection dbConnection = new SqlConnection(@"Server=.;Database=Minions;Integrated Security=true;");
            
            dbConnection.Open();

            string getVillainNameQuery = @"Select [Name] From Villains Where Id = @villainId";

            using SqlCommand getVillainNameCommand = new SqlCommand(getVillainNameQuery, dbConnection);
            getVillainNameCommand.Parameters.AddWithValue("@villainId", villainId);

            string villainName = getVillainNameCommand.ExecuteScalar()?.ToString();

            if (villainName == null)
            {
                result.AppendLine($"No villain with ID {villainId} exists in the database.");
            }
            else
            {
                result.AppendLine($"Villain: {villainName}");

                string getMinionsInfoQuery = @"Select m.[Name], m.Age FROM Villains AS V
                                               LEFT JOIN MinionsVillains AS MV
                                               ON V.Id = MV.VillainId
                                               LEFT JOIN Minions AS M
                                               ON mv.MinionId = M.Id
                                               WHERE V.Id = @villainId
                                               Order By M.[Name]";

                using SqlCommand getMinionsInfoCommand = new SqlCommand(getMinionsInfoQuery, dbConnection);
                getMinionsInfoCommand.Parameters.AddWithValue("@villainId", villainId);

                using SqlDataReader reader = getMinionsInfoCommand.ExecuteReader();

                if (reader.HasRows)
                {
                    int rowNumber = 1;

                    while (reader.Read())
                    {
                        string minionName = reader["Name"]?.ToString();
                        string minionAge = reader["Age"]?.ToString();

                        result.AppendLine($"{rowNumber}. {minionName} {minionAge}");

                        rowNumber++;
                    }
                }
                else
                {
                    result.AppendLine("(no minions)");
                }
            }

            Console.WriteLine(result.ToString().TrimEnd());
        }
    }
}
