using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace ConsoleApp34
{
    internal class creetTeble
    {   
        Database db = new Database();
        public void creetNewTeble()
        {   
            string newTeble= @"
               CREATE TABLE People (
                        Id INT PRIMARY KEY IDENTITY(1,1),
                        Name NVARCHAR(100) NOT NULL,
                        SecretCode NVARCHAR(50) UNIQUE NOT NULL,
                        CreatedDate DATETIME DEFAULT GETDATE()
             ) ;

               CREATE TABLE Reports (
                     Id INT PRIMARY KEY IDENTITY(1,1),
                     ReporterId INT NOT NULL,
                     TargetId INT NOT NULL,
                     ReportText NVARCHAR(MAX) NOT NULL,
                     SubmissionTime DATETIME DEFAULT GETDATE(),
    
     
             )";


            // try  לעשות בהמשך 

            MySqlConnection con= db.connection();

            MySqlCommand cmd = new MySqlCommand(newTeble,con);
            cmd.ExecuteNonQuery();

            Console.WriteLine("exuted ... ");

            

        }
    }
}
