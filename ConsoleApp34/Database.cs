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
            string strConecction = "";
            MySqlConnection con = new MySqlConnection(strConecction);
            con.Open();
            return con;
            
        }


        public MySqlCommand command(string Qery)
        { 
            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = Qery;
            return cmd;

        }

        public MySqlDataReader toSend(MySqlConnection connection, MySqlCommand command)
        {
            command.Connection = connection;
            MySqlDataReader reader = command.ExecuteReader();
            return reader;

        }
       
        public void close(MySqlConnection connection) 
        { 
               connection.Close();
          
        }



        
    }
}
