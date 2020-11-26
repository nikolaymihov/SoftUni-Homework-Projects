using System;
using System.Linq;
using System.Text;

using Microsoft.Data.SqlClient;

namespace _04_AddMinion
{
    public class StartUp
    {
        private const string CONNECTION_STRING = @"Server=.;Database=Minions;Integrated Security=true;";

        public static void Main()
        {
            string[] minionInput = Console.ReadLine().Split(": ", StringSplitOptions.RemoveEmptyEntries).ToArray();
            string[] villainInput = Console.ReadLine().Split(": ", StringSplitOptions.RemoveEmptyEntries).ToArray();

            string[] minionArgs = minionInput[1].Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
            string minionName = minionArgs[0];
            string minionAge = minionArgs[1];
            string townName = minionArgs[2];

            string villainName = villainInput[1];

            StringBuilder output = new StringBuilder();

            using SqlConnection dbConnection = new SqlConnection(CONNECTION_STRING);

            dbConnection.Open();

            EnsureTownExists(townName, dbConnection, output);

            string townId = GetTownId(townName, dbConnection);

            InsertMinionToDB(minionName, minionAge, townId, dbConnection);

            string minionId = GetMinionId(minionName, dbConnection);

            EnsureVillainExists(villainName, dbConnection, output);

            string villainId = GetVillainId(villainName, dbConnection);

            AddMinionAndVillainToMappingTable(minionId, villainId, dbConnection);

            output.AppendLine($"Successfully added {minionName} to be minion of {villainName}.");

            Console.WriteLine(output.ToString().TrimEnd());
        }

        static void EnsureTownExists(string townName, SqlConnection dbConnection, StringBuilder result)
        {
            string townId = GetTownId(townName, dbConnection);

            if (townId == null)
            {
                string addTownToDBQuery = @"Insert Into Towns([Name], CountryCode)
                                            Values (@townName, 1);";

                using SqlCommand addTownToDBCommand = new SqlCommand(addTownToDBQuery, dbConnection);

                addTownToDBCommand.Parameters.AddWithValue("@townName", townName);

                addTownToDBCommand.ExecuteNonQuery();

                result.AppendLine($"Town {townName} was added to the database.");
            }
        }

        static string GetTownId (string townName, SqlConnection dbConnection)
        {
            string getTownIdQuery = @"Select Id From Towns Where [Name] = @townName";

            using SqlCommand getTownIdCommand = new SqlCommand(getTownIdQuery, dbConnection);

            getTownIdCommand.Parameters.AddWithValue("@townName", townName);

            return getTownIdCommand.ExecuteScalar()?.ToString();
        }

        static void InsertMinionToDB(string minionName, string minionAge, string townId, SqlConnection dbConnection)
        {
            string insertMinionQuery= @"Insert Into Minions([Name], Age, TownId)
                                         Values (@minionName, @minionAge, @townId)";

            using SqlCommand insertMinionCommand = new SqlCommand(insertMinionQuery, dbConnection);
            insertMinionCommand.Parameters.AddRange(new []
            {
                new SqlParameter("@minionName", minionName),
                new SqlParameter("@minionAge", minionAge),
                new SqlParameter("@townId", townId)
            });

            insertMinionCommand.ExecuteNonQuery();
        }

        static string GetMinionId(string minionName, SqlConnection dbConnection)
        {
            string getMinionIdQuery = @"Select Id From Minions Where [Name] = @minionName";

            using SqlCommand getMinionIdCommand = new SqlCommand(getMinionIdQuery, dbConnection);

            getMinionIdCommand.Parameters.AddWithValue("@minionName", minionName);

            return getMinionIdCommand.ExecuteScalar()?.ToString();
        }

        static void EnsureVillainExists(string villainName, SqlConnection dbConnection, StringBuilder result)
        {
            string villainId = GetVillainId(villainName, dbConnection);

            if (villainId == null)
            {
                string evilFactorId = "4";
                string addVillainToDBQuery = @"Insert Into Villains(Name, EvilnessFactorId)
                                               Values (@villainName, @evliFactorId);";

                using SqlCommand addVillainToDBCommand = new SqlCommand(addVillainToDBQuery, dbConnection);

                addVillainToDBCommand.Parameters.AddRange(new[]
                {
                    new SqlParameter("@villainName", villainName),
                    new SqlParameter("@evliFactorId", evilFactorId)
                });

                addVillainToDBCommand.ExecuteNonQuery();

                result.AppendLine($"Villain {villainName} was added to the database.");
            }
        }

        static string GetVillainId(string villainName, SqlConnection dbConnection)
        {
            string getVillainIdQuery = @"Select Id From Villains Where [Name] = @villainName";

            using SqlCommand getVillainIdCommand = new SqlCommand(getVillainIdQuery, dbConnection);

            getVillainIdCommand.Parameters.AddWithValue("@villainName", villainName);

            return getVillainIdCommand.ExecuteScalar()?.ToString();
        }

        static void AddMinionAndVillainToMappingTable(string minionId, string villainId, SqlConnection dbConnection)
        {
            string insertMinionAndVillainToMappingTableQuery = @"Insert Into MinionsVillains(MinionId, VillainId)
                                                                 Values (@minionId, @villainId);";

            using SqlCommand insertMinionAndVillainToMappingTableCommand = new SqlCommand(insertMinionAndVillainToMappingTableQuery, dbConnection);

            insertMinionAndVillainToMappingTableCommand.Parameters.AddRange(new[]
            {
                    new SqlParameter("@minionId", minionId),
                    new SqlParameter("@villainId", villainId)
            });

            insertMinionAndVillainToMappingTableCommand.ExecuteNonQuery();
        }
    }
}
