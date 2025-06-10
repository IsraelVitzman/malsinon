using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace ConsoleApp34
{
    
    internal class getName
    {
        Database db = new Database();
        public void name(string name)
        {
            try
            {
                MySqlConnection con = db.connection();

                string qerry = "SELECT Id FROM People WHERE Name = @input";

                con.Open();

                MySqlCommand cmd = new MySqlCommand(qerry, con);

                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    int reporterId = reader.GetInt32("ReporterId");
                    int reportCount = reader.GetInt32("ReportCount");
                    double avgLength = reader.GetDouble("AvgTextLength");

                    Console.WriteLine($"Reporter ID: {reporterId}, Reports: {reportCount}, Avg. Length: {avgLength:F1} chars");
                }



            }
            catch (Exception ex) { 
                Console.WriteLine(ex.Message);
            }
            
            

        }
    }
}
