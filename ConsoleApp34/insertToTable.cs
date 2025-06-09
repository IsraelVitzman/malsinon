using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using MySql.Data.MySqlClient;

namespace ConsoleApp34
{
    internal class insertToTable
    {
        Database db = new Database();
        public void insert(string Name ,string CodName ,string Text)
        {
            string insertQuery = @"
            INSERT INTO Users ( Name , CodName , Text) 
            VALUES (@Name ,@CodName , Text)";

            // לעשות טרי בהמשך..
            MySqlConnection con = db.connection();

            MySqlCommand cmd = new MySqlCommand(insertQuery, con);

            cmd.Parameters.AddWithValue("@Name", Name);
            cmd.Parameters.AddWithValue("@CodName", CodName);
            cmd.Parameters.AddWithValue("@Text", Text);

            cmd.ExecuteNonQuery();
            Console.WriteLine("add to seccsfoly...");
        }
             
       
    }
}
