using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace ConsoleApp34
{
    internal class ImportToCSV
    {   
        Database db = new Database();
        InsertToTable insertToTable = new InsertToTable();
        pupleDAL pupleDAL = new pupleDAL();
        reportDAL reportDAL = new reportDAL();

        Random random = new Random();
        public void addCSV(string link)
        {

            MySqlConnection con = db.connection();



            var reader = new StreamReader(link);

            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                var parts = line.Split(',');

                string reporter = parts[0].Trim();
                string target = parts[1].Trim();
                string reportText = parts[2].Trim();
                string timestamp = parts[3].Trim();


                if (pupleDAL.CheckInPuple(reporter) == 0)
                {

                    string name = reporter;
                    string code = GenerateRandomDigits(5);
                    pupleDAL.InsertNewPerson(name, code);

                }

                if (pupleDAL.CheckInPuple(target) == 0)
                {
                   
                    string name = target;
                    string code = GenerateRandomDigits(5);
                    pupleDAL.InsertNewPerson(name, code);
                }

                int reporterId = pupleDAL.CheckInPuple(reporter);
                int targetId = pupleDAL.CheckInPuple(target);

                string insert = @"INSERT INTO reports (ReporterId, TargetId, ReportText, SubmissionTime)
                                         VALUES (@reporter, @target, @text, @time)";



                MySqlCommand cmd = new MySqlCommand(insert, con);

                cmd.Parameters.AddWithValue("@reporter", reporterId);
                cmd.Parameters.AddWithValue("@target", targetId);
                cmd.Parameters.AddWithValue("@text", reportText);
                cmd.Parameters.AddWithValue("@time", timestamp);


                cmd.ExecuteNonQuery();

            }
            db.close(con);
        }
        public string GenerateRandomDigits(int length)
            {
                Random rand = new Random();
                string digits = "";

                for (int i = 0; i < length; i++)
                {
                    digits += rand.Next(0, 10).ToString(); 
                }

                return digits;
        }



        
    }
}
