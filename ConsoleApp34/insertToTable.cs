using MySql.Data.MySqlClient;
using System;

namespace ConsoleApp34
{
    internal class InsertToTable
    {
        Database db = new Database();

        public void InsertNewPerson(string name, string secretCode)
        {
            string insertQuery = @"
            INSERT INTO People (Name, SecretCode) 
            VALUES (@Name, @SecretCode)";

            try
            {
                MySqlConnection con = db.connection();
                MySqlCommand cmd = new MySqlCommand(insertQuery, con);

                cmd.Parameters.AddWithValue("@Name", name);
                cmd.Parameters.AddWithValue("@SecretCode", secretCode);

                cmd.ExecuteNonQuery();

                Console.WriteLine("Person added successfully...");
                db.close(con);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error inserting person: {ex.Message}");
            }
        }

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

        
        public int CheckTarget(string target)
        {
            MySqlConnection con = db.connection();
            string checkQuery = "SELECT Id FROM People WHERE Name = @input OR SecretCode = @input";

            MySqlCommand checkCmd = new MySqlCommand(checkQuery, con);
            checkCmd.Parameters.AddWithValue("@input", target);

            object result = checkCmd.ExecuteScalar();
            db.close(con);  

            if (result != null && int.TryParse(result.ToString(), out int id))
                return id;

            return 0;
        }

       
        public int CheckReporter(string reporter)
        {
            MySqlConnection con = db.connection();
            string checkQuery = "SELECT Id FROM People WHERE Name = @input OR SecretCode = @input";

            MySqlCommand checkCmd = new MySqlCommand(checkQuery, con);
            checkCmd.Parameters.AddWithValue("@input", reporter);

            object result = checkCmd.ExecuteScalar();
            db.close(con);  

            if (result != null && int.TryParse(result.ToString(), out int id))
                return id;

            return 0;
        }

        
        public void insert(string reporterInput, string targetInput, string reportText)
        {
            if (CheckReporter(reporterInput) == 0)
            {
                Console.Write("Enter name:");
                string name = Console.ReadLine();
                Console.Write("Enter secret code:");
                string code = Console.ReadLine();
                InsertNewPerson(name, code);
            }

            if (CheckTarget(targetInput) == 0)
            {
                Console.Write("Enter name:");
                string name = Console.ReadLine();
                Console.Write("Enter secret code:");
                string code = Console.ReadLine();
                InsertNewPerson(name, code);
            }

            int reporterId = CheckReporter(reporterInput);  
            int targetId = CheckTarget(targetInput);        

            InsertReport(reporterId, targetId, reportText);
        }
    }
}
