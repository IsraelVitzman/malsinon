using System;
using System.Data.SqlClient;
using ConsoleApp34;
using MySql.Data.MySqlClient;

public class AlertHandler
{
    Database db = new Database();
    public MySqlDataReader newAlert()
    {
        string qeerry = "SELECT r1.TargetId, r1.SubmissionTime" +
                    "    FROM Reports r1" +
                    "    JOIN Reports r2 ON r1.TargetId = r2.TargetId" +
                    "    AND r2.SubmissionTime BETWEEN r1.SubmissionTime AND DATE_ADD(r1.SubmissionTime, INTERVAL 15 MINUTE)" +
                    "    GROUP BY r1.TargetId, r1.SubmissionTime" +
                    "    HAVING COUNT(r2.Id) >= 3;";

        MySqlConnection connection = db.connection();
        

        MySqlCommand command = new MySqlCommand(qeerry, connection);

        MySqlDataReader reader = command.ExecuteReader();

        return reader;

    }
    public  void InsertAlert(int targetId, string alertType, string reason)
    {      
            

            MySqlConnection conn = db.connection();
        
           


            string sql = "INSERT INTO Alerts (TargetId, AlertType) VALUES (@TargetId, @AlertType)";

            MySqlCommand cmd = new MySqlCommand(sql, conn);

            cmd.Parameters.AddWithValue("@TargetId", targetId);
            cmd.Parameters.AddWithValue("@AlertType", alertType);
            

            cmd.ExecuteNonQuery();
        
    }
    public void RunAlertAnalysis()
    {
        using (MySqlDataReader reader = newAlert())
        {
            while (reader.Read())
            {
                int targetId = reader.GetInt32("TargetId");
                DateTime time = reader.GetDateTime("SubmissionTime");

                string alertType = "Burst";
                string reason = $"3 דיווחים על מטרה תוך פחות מ־15 דקות. זמן התחלה: {time}";

                
                InsertAlert(targetId, alertType, reason);

                Console.WriteLine($"התראה נוספה: מטרה {targetId} נחשבת למסוכנת (Burst)");
            }

            reader.Close();
        }
    }

}

