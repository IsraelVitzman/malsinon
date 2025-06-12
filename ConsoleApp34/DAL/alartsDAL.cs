using System;
using System.Data.SqlClient;
using ConsoleApp34;
using MySql.Data.MySqlClient;

public class AlertsDAL
{
    Database db = new Database();
    public MySqlDataReader newAlert(int code)
    {
        string qeerry = "SELECT  TargetId,   " +
            "                    MIN(SubmissionTime) AS FirstTime, " +
            "                    MAX(SubmissionTime) AS LastTime," +
            "                    TIMESTAMPDIFF(MINUTE, MIN(SubmissionTime), " +
            "                    MAX(SubmissionTime)) AS MinutesDiff," +
            "                    COUNT(*) AS ReportsCount" +
            "                    FROM ( " +
            "                         SELECT SubmissionTime, TargetId" +
            "                         FROM Reports" +
            "                         WHERE TargetId = @input" +
            "                         ORDER BY SubmissionTime DESC" +
            "                         LIMIT 3) AS LastThree" +
            "                         GROUP BY TargetId" +
            "                         HAVING ReportsCount = 3 AND MinutesDiff <= 15;";


        MySqlConnection connection = db.connection();
        

        MySqlCommand command = new MySqlCommand(qeerry, connection);
        command.Parameters.AddWithValue("@input", code);

        MySqlDataReader reader = command.ExecuteReader();

        return reader;

    }
    public  void InsertAlert(int targetId, string alertType, string reason)
    {      
            

            MySqlConnection conn = db.connection();
          

            string sql = "INSERT INTO Alerts (TargetId, AlertType ,Reason) VALUES (@TargetId, @AlertType ,@Reason)";

            MySqlCommand cmd = new MySqlCommand(sql, conn);

            cmd.Parameters.AddWithValue("@TargetId", targetId);
            cmd.Parameters.AddWithValue("@AlertType", alertType);
            cmd.Parameters.AddWithValue("@Reason", reason);
            

            cmd.ExecuteNonQuery();
        
    }

    public void RunAlertAnalysis(int code)
    {
        using (MySqlDataReader reader = newAlert(code))
        {
            if (reader.Read())
            {

                int targetId = reader.GetInt32("TargetId");
                DateTime time = reader.GetDateTime("FirstTime");

                string alertType = "Burst";
                string reason = $"3 דיווחים על מטרה תוך פחות מ־15 דקות. זמן התחלה: {time}";


                InsertAlert(targetId, alertType, reason);

                Console.WriteLine($"התראה נוספה: מטרה {targetId} נחשבת למסוכנת (Burst)");


            }
            else
            {
                Console.WriteLine("---------------");
            }

            

                reader.Close();
        }
    }

}

