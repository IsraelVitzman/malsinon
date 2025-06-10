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
                string reportText = parts[2].Trim().Trim('"');
                string timestamp = parts[3].Trim();

               

                if (insertToTable.CheckReporter(reporter) == 0)
                {
                    Console.Write("Enter name:");
                    string name = Console.ReadLine();
                    Console.Write("Enter secret code:");
                    string code = Console.ReadLine();
                    insertToTable.InsertNewPerson(name, code);
                }

                if (insertToTable.CheckTarget(target) == 0)
                {
                    Console.Write("Enter name:");
                    string name = Console.ReadLine();
                    Console.Write("Enter secret code:");
                    string code = Console.ReadLine();
                    insertToTable.InsertNewPerson(name, code);
                }

                int reporter1 = insertToTable.CheckReporter(reporter);
                int target1 = insertToTable.CheckTarget(target);

                string insert= @"INSERT INTO reports (ReporterId, TargetId, report_text, report_time)
                                         VALUES (@reporter, @target, @text, @time)";



                MySqlCommand cmd = new MySqlCommand(insert ,con);

                cmd.Parameters.AddWithValue("@reporter", reporter1);
                cmd.Parameters.AddWithValue("@target", target1);
                cmd.Parameters.AddWithValue("@text", reportText);
                cmd.Parameters.AddWithValue("@time", DateTime.Parse(timestamp));


                cmd.ExecuteNonQuery();
                
            }
            db.close(con);





        }
    }
}
