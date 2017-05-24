using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace GLBankATM
{
    class Database
    {
        private string server;
        private string uid;
        private string password;
        private string database;
        private MySqlConnection connection;
        
        public Database()
        {
            server = "localhost";
            uid = "root";
            password = "";
            database = "glbank";
            connection = openConnection();
        }

        private MySqlConnection openConnection()
        {
            string connectionString = "SERVER=" + server + ";";
            connectionString += "DATABASE=" + database + ";";
            connectionString += "UID=" + uid + ";";
            connectionString += "PASSWORD=" + password + ";";
            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();
            return connection;
        }

        void closeConnection()
        {
            if (connection != null)
            {
                connection.Close();
            }
        }

        public bool existCard(long idcard)
        {
            String query = "SELECT idCard FROM cards WHERE cardNumber LIKE " + idcard;
            if (connection != null)
            {
                try
                {
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    MySqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        return true;
                    }
                }catch (Exception ex)
                {
                    Console.WriteLine("MySQL error:" + ex.ToString());
                }
            }
            return false;
        }

        public bool isCardBlocked(long idcard)
        {
            String query = "SELECT blocked FROM cards WHERE cardNumber LIKE " + idcard;
            if (connection != null)
            {
                try
                {
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    MySqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        return reader.GetChar("blocked") == 'T' ? true : false;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("MySQL error:" + ex.ToString());
                }
            }
            return true;
        }
    }
}
