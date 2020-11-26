using System;

using Microsoft.Data.SqlClient;

namespace _02_VillainNames
{
    public class Startup
    {
        public static void Main()
        {
            using SqlConnection dbConnection = new SqlConnection(@"Server=.;Database=Minions;Integrated Security=true;");
            
            dbConnection.Open();

            SqlCommand command = new SqlCommand(
                                              @"Select Name, Count(MV.MinionId) As Count from Villains AS V
                                                Join MinionsVillains AS MV ON V.Id = MV.VillainId
                                                Group By V.Id, V.Name
                                                Having Count(MV.MinionId) > 3", dbConnection);

            using SqlDataReader reader = command.ExecuteReader();

            while(reader.Read())
            {
                string name = reader["Name"].ToString();
                int count = int.Parse(reader["Count"].ToString());

                Console.WriteLine("{0} - {1}", name, count);
            }
        }
    }
}
