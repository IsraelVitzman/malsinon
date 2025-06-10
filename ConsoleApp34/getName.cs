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

                string qerry = "SELECT Name, SecretCode FROM People WHERE Name = @input";

                

                MySqlCommand cmd = new MySqlCommand(qerry, con);
                cmd.Parameters.AddWithValue("input", name);

                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Console.WriteLine( reader["Name"] );
                    Console.WriteLine( reader["SecretCode"] );
                }



            }
            catch (Exception ex) { 
                Console.WriteLine(ex.Message);
            }
            
            

        }
    }
}
