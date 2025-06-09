using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace ConsoleApp34
{
    internal class ToRecruit
    {   
        Database db =new Database();
        public void recruit()
        {
            string qeerry = "FROM * SELECT  Reports WHERE ReporterId > 10 ";

            MySqlConnection connection = db.connection();

            MySqlCommand command = new MySqlCommand(qeerry,connection);

            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read()) 
            { 
                Console.WriteLine(reader);
            }

        }
    }
}
