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
        public void recruit(string input)
        {
            string qeerry = "";
            if (input == "1")
            {
                qeerry = "SELECT ReporterId, COUNT(*) AS ReportCount, AVG(CHAR_LENGTH(ReportText)) AS AvgLength" +
                "            FROM Reports" +
                "            GROUP BY ReporterId" +
                "            HAVING ReportCount >= 10 AND AvgLength >= 100";

            }
            else if (input == "2")
            {
                qeerry = "SELECT r1.TargetId, r1.Timestamp" +
                    "            FROM Reports r1" +
                    "            JOIN Reports r2 ON r1.TargetId = r2.TargetId " +
                    "            AND r2.Timestamp BETWEEN r1.Timestamp AND DATE_ADD(r1.Timestamp, INTERVAL 15 MINUTE)" +
                    "            GROUP BY r1.TargetId, r1.Timestamp" +
                    "            HAVING COUNT(r2.ReportId) >= 3;";

            }
            else
            {
                Console.WriteLine("invalid error");
                return;
            }
           
            try
            {
                
                MySqlConnection connection = db.connection();
                connection.Open();
                MySqlCommand command = new MySqlCommand(qeerry,connection);

                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read()) 
                { 
                    Console.WriteLine(reader);
                }


            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error inserting person: {ex.Message}");
            }




        }
    }
}
