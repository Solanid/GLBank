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

        public Card existCard(long idcard)
        {
            String query = "SELECT * FROM cards WHERE cardNumber LIKE " + idcard;
            if (connection != null)
            {
                try
                {
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    MySqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        bool blocked = reader.GetChar("blocked") == 'T' ? true : false;
                        return new Card(
                                reader.GetInt32("idCard"),
                                reader.GetInt64("cardNumber"),
                                reader.GetInt64("idAcc"),
                                blocked
                            );
                    }
                }catch (Exception ex)
                {
                    Console.WriteLine("MySQL error:" + ex.ToString());
                }
            }
            return null;
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

        public bool isPinCorrect(int pin, long idcard)
        {
            String query = "SELECT idCard FROM cards WHERE pin LIKE " + pin + " AND cardNumber LIKE "+ idcard;
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
                }
                catch (Exception ex)
                {
                    Console.WriteLine("MySQL isPinCorrect error:" + ex.ToString());
                }
            }
            return false;
        }

        public void incorrectPin(int idCard)
        {
            String query = "INSERT INTO unsuccessful_atm_logins (idCard) VALUES(" + idCard + ")";
            if (connection != null)
            {
                try
                {
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("MySQL incorrectPin error:" + ex.ToString());
                }
            }
        }

        public int getNumOfUnsuccessfullLoginAttemnts(int idCard)
        {
            String query = "SELECT count(*) AS attemnts FROM unsuccessful_atm_logins WHERE idCard LIKE " + idCard;
            if (connection != null)
            {
                try
                {
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    MySqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        return reader.GetInt32("attemnts");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("MySQL getNumOfUnsuccessfullLoginAttemnts error:" + ex.ToString());
                }
            }
            return 0;
        }

        public void resetLoginAttemnts(int idCard)
        {
            String query = "DELETE FROM unsuccessful_atm_logins WHERE idCard LIKE " + idCard;
            if (connection != null)
            {
                try
                {
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("MySQL resetLoginAttemnts error:" + ex.ToString());
                }
            }
        }

        public float getBalance(int idCard)
        {
            String query = "SELECT accounts.balance FROM cards INNER JOIN accounts ON cards.idAcc = accounts.idacc WHERE idCard LIKE " + idCard;
            if (connection != null)
            {
                try
                {
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    MySqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        return reader.GetFloat("balance");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("MySQL getBalance error:" + ex.ToString());
                }
            }
            return 0;
        }

        public bool changePin(int oldPin, int newPin, int idCard)
        {
            String query = "UPDATE cards SET pin = "+newPin+" WHERE pin like "+oldPin+" AND idCard like "+idCard;
            if (connection != null)
            {
                try
                {
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    int state = cmd.ExecuteNonQuery();
                    return state!= 0?true:false;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("MySQL changePin error:" + ex.ToString());
                }
            }
            return false;
        }

        //TODO idAccountu vytahovat, spravit si objekt card.

        public bool saveWithdrawalHistory(Card card, float amount, int idATM)
        {
            String query = "INSERT INTO atmwithdrawals (idAcc, amount, idATM, idCard) VALUES("+card.getCardNumber()+","+amount+","+idATM+","+card.getIdCard()+")";
            if (connection != null)
            {
                try
                {
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    cmd.ExecuteNonQuery();
                    return true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("MySQL incorrectPin error:" + ex.ToString());
                }
            }
            return false;
        }

        public bool withdrawMoney(Card card, float amount, float balance)
        {
            if (balance < amount)
                return false;
            String query = "UPDATE accounts SET balance=balance-"+amount+" WHERE idacc like "+card.getIdAcc();
            if (connection != null)
            {
                try
                {
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    int state = cmd.ExecuteNonQuery();
                    return state != 0 ? true : false;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("MySQL changePin error:" + ex.ToString());
                }
            }
            return false;
        }


    }

    
}
