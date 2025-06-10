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
        public void addCSV(string link)
        {

            MySqlConnection con= db.connection();
            con.Open();

         
            var reader = new StreamReader(link);

            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                var parts = line.Split(',');

                string reporter = parts[0].Trim();
                string target = parts[1].Trim();
                string reportText = parts[2].Trim();
                string timestamp = parts[3].Trim();

                // יש כאן אולי מבנה מסורבל כי עדיף
                // אולי שהוא יכניס שירות לתוך אנשים כי הרי אתה מביא כנראה קובץ חדש שהוא ודאי לא מעודכן שאנשים

                if (pupleDAL.CheckReporter(reporter) == 0)
                {
                    Console.Write("Enter name reporter:");
                    string name = Console.ReadLine();
                    Console.Write("Enter secret code reporter:");
                    string code = Console.ReadLine();
                    pupleDAL.InsertNewPerson(name, code);
                }

                if (pupleDAL.CheckTarget(target) == 0)
                {
                    Console.Write("Enter name terget:");
                    string name = Console.ReadLine();
                    Console.Write("Enter secret code terget:");
                    string code = Console.ReadLine();
                    pupleDAL.InsertNewPerson(name, code);
                }

                int reporterId = pupleDAL.CheckReporter(reporter);
                int targetId = pupleDAL.CheckTarget(target);

                string insert= @"INSERT INTO reports (ReporterId, TargetId, report_text, report_time)
                                         VALUES (@reporter, @target, @text, @time)";



                MySqlCommand cmd = new MySqlCommand(insert ,con);

                cmd.Parameters.AddWithValue("@reporter", reporterId);
                cmd.Parameters.AddWithValue("@target", targetId);
                cmd.Parameters.AddWithValue("@text", reportText);
                cmd.Parameters.AddWithValue("@time", DateTime.Parse(timestamp));


                cmd.ExecuteNonQuery();
                
            }
            db.close(con);





        }
    }
}
