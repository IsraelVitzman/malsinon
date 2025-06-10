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
        public void addCSV(string link)
        {
            MySqlConnection con= db.connection();
            con.Open();


            var reader = new StreamReader(link);




            MySqlCommand command = new MySqlCommand();
         
        }
    }
}
