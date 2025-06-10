using ConsoleApp34;
using MySql.Data.MySqlClient;
using System;


    internal class CreateTable
    {
      Database db = new Database();

      public void CreateNewTable()
      {
        string newTable1 = @"
               CREATE TABLE IF NOT EXISTS People (
                        Id INT PRIMARY KEY AUTO_INCREMENT,
                        Name VARCHAR(100) NOT NULL,
                        SecretCode VARCHAR(50) NOT NULL,
                       
                        CreatedDate DATETIME DEFAULT CURRENT_TIMESTAMP
               )";

        string newTable2 = @"      CREATE TABLE IF NOT EXISTS Reports (
                     Id INT PRIMARY KEY AUTO_INCREMENT,
                     ReporterId INT NOT NULL,
                     TargetId INT NOT NULL,
                     ReportText TEXT NOT NULL,
                     SubmissionTime DATETIME DEFAULT CURRENT_TIMESTAMP,

                     FOREIGN KEY (ReporterId) REFERENCES People(Id),
                     FOREIGN KEY (TargetId) REFERENCES People(Id)
               )";

        string newTable3 = @"       CREATE TABLE Alerts (
                     AlertId INT AUTO_INCREMENT PRIMARY KEY,
                     TargetId INT NOT NULL,
                     AlertType ENUM('THRESHOLD', 'BURST') NOT NULL,
                   
    
                     FOREIGN KEY (TargetId) REFERENCES People(Id)
                );
                ";


        try
        {
            MySqlConnection con = db.connection();
            MySqlCommand cmd1 = new MySqlCommand(newTable1, con);
            MySqlCommand cmd2 = new MySqlCommand(newTable2, con);
            MySqlCommand cmd3 = new MySqlCommand(newTable3, con);

            cmd1.ExecuteNonQuery();
            cmd2.ExecuteNonQuery();
            cmd3.ExecuteNonQuery();

            Console.WriteLine("Tables created successfully...");
            db.close(con);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error creating tables: {ex.Message}");
        }
    }

}