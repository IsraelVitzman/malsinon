using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace ConsoleApp34
{
    internal class reportDAL
    {
        Database db = new Database();
        public void InsertReport(int reporterId, int targetId, string reportText)
        {
            string insertQuery = @"
            INSERT INTO Reports (ReporterId, TargetId, ReportText) 
            VALUES (@ReporterId, @TargetId, @ReportText)";

            try
            {
                MySqlConnection con = db.connection();
                MySqlCommand cmd = new MySqlCommand(insertQuery, con);

                cmd.Parameters.AddWithValue("@ReporterId", reporterId);
                cmd.Parameters.AddWithValue("@TargetId", targetId);
                cmd.Parameters.AddWithValue("@ReportText", reportText);

                cmd.ExecuteNonQuery();

                Console.WriteLine("Report added successfully...");
                db.close(con);

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error inserting report: {ex.Message}");
            }
        }

        public void recruit()
        {

            string qeerry = "SELECT ReporterId, COUNT(*) AS ReportCount, AVG(CHAR_LENGTH(ReportText)) AS AvgLength" +
              "            FROM Reports" +
              "            GROUP BY ReporterId" +
              "            HAVING ReportCount >= 10 AND AvgLength >= 100";


            try
            {

                MySqlConnection connection = db.connection();
                
                MySqlCommand command = new MySqlCommand(qeerry, connection);

                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Console.WriteLine($"ReporterId: {reader["ReporterId"]}, Reports: {reader["ReportCount"]}, AvgLen: {reader["AvgLength"]}");

                }

                db.close(connection);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error inserting person: {ex.Message}");
            }




        }
    }
}
