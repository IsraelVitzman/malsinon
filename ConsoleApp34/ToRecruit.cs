using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace ConsoleApp34
{
    internal class ToRecruit
    {   
        Database db =new Database();
        public void recruit()
        {
            
            
              string  qeerry = "SELECT ReporterId, COUNT(*) AS ReportCount, AVG(CHAR_LENGTH(ReportText)) AS AvgLength" +
                "            FROM Reports" +
                "            GROUP BY ReporterId" +
                "            HAVING ReportCount >= 10 AND AvgLength >= 100";

            
           
            try
            {
                
                MySqlConnection connection = db.connection();
                connection.Open();
                MySqlCommand command = new MySqlCommand(qeerry,connection);

                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read()) 
                {
                    Console.WriteLine($"ReporterId: {reader["ReporterId"]}, Reports: {reader["ReportCount"]}, AvgLen: {reader["AvgLength"]}");

                }


            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error inserting person: {ex.Message}");
            }




        }
    }
}
