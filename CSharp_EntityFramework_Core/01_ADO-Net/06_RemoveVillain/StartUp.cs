using System;
using System.Text;

using Microsoft.Data.SqlClient;

namespace _06_RemoveVillain
{
    public class StartUp
    {
        private const string CONNECTION_STRING = @"Server=.;Database=Minions;Integrated Security=true;";

        public static void Main()
        {
            int villainId = int.Parse(Console.ReadLine());

            using SqlConnection dbConnection = new SqlConnection(CONNECTION_STRING);

            dbConnection.Open();

            string result = RemoveVillainById(villainId, dbConnection);

            Console.WriteLine(result);
        }

        static string RemoveVillainById(int villainId, SqlConnection dbConnection)
        {
            StringBuilder output = new StringBuilder();

            using SqlTransaction sqlTransaction = dbConnection.BeginTransaction();

            string getVillainNameQuery = @"Select [Name] From Villains 
                                           Where Id = @villainId";

            using SqlCommand getVillainNameCommand = new SqlCommand(getVillainNameQuery, dbConnection);
            getVillainNameCommand.Parameters.AddWithValue("@villainId", villainId);
            getVillainNameCommand.Transaction = sqlTransaction;

            string villainName = getVillainNameCommand.ExecuteScalar()?.ToString();

            if (villainName == null)
            {
                output.AppendLine("No such villain was found.");
            }
            else
            {
                try
                {
                    string releaseMinionsQuery = @"Delete From MinionsVillains
                                                   Where VillainId = @villainId";

                    using SqlCommand releaseMinionsCommand = new SqlCommand(releaseMinionsQuery, dbConnection);
                    releaseMinionsCommand.Parameters.AddWithValue("@villainId", villainId);
                    releaseMinionsCommand.Transaction = sqlTransaction;

                    int releasedMinionsCount = releaseMinionsCommand.ExecuteNonQuery();

                    string deleteVillainQuery = @"Delete From Villains
                                                  Where Id = @villainId";

                    using SqlCommand deleteVillainCommand = new SqlCommand(deleteVillainQuery, dbConnection);
                    deleteVillainCommand.Parameters.AddWithValue("@villainId", villainId);
                    deleteVillainCommand.Transaction = sqlTransaction;

                    deleteVillainCommand.ExecuteNonQuery();

                    sqlTransaction.Commit();

                    output.AppendLine($"{villainName} was deleted.");
                    output.AppendLine($"{releasedMinionsCount} minions were released.");
                }
                catch (Exception ex)
                {
                    output.AppendLine(ex.Message);

                    try
                    {
                        sqlTransaction.Rollback();
                    }
                    catch (Exception rollBackEx)
                    {
                        output.AppendLine(rollBackEx.Message);
                    }
                }
            }

            return output.ToString().TrimEnd();
        }
    }
}
