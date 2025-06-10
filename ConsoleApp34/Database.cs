using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace ConsoleApp34
{
    internal class Database
    {
        public MySqlConnection connection()
        {
            string strConnection = "Server=localhost;Database=yourdb;Uid=username;Pwd=password;";
            MySqlConnection con = new MySqlConnection(strConnection);
            con.Open();
            return con;
        }

        public void close(MySqlConnection connection)
        {
            connection.Close();
        }
    }
}