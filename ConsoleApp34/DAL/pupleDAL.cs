using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace ConsoleApp34
{
    internal class pupleDAL
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

        


        public int CheckInPuple(string nameOrCode)
        {
            try
            {
                MySqlConnection con = db.connection();
                string checkQuery = "SELECT Id FROM People WHERE Name = @input OR SecretCode = @input";

                MySqlCommand checkCmd = new MySqlCommand(checkQuery, con);
                checkCmd.Parameters.AddWithValue("@input", nameOrCode);

                object result = checkCmd.ExecuteScalar();
                db.close(con);

                if (result != null && int.TryParse(result.ToString(), out int id))
                    return id;


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return 0;

        }

        public void getCodeName(string name)
        {
            try
            {
                MySqlConnection con = db.connection();

                string qerry = "SELECT Name, SecretCode FROM People WHERE Name = @input";



                MySqlCommand cmd = new MySqlCommand(qerry, con);
                cmd.Parameters.AddWithValue("input", name);

                MySqlDataReader reader = cmd.ExecuteReader();

                if (reader == null)
                {
                    Console.WriteLine("not found...");
                }
                while (reader.Read())
                {
                    Console.WriteLine(reader["Name"]);
                    Console.WriteLine(reader["SecretCode"]);
                }



            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }



        }
    }
}
