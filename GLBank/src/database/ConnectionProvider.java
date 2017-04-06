/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package database;

import glbank.Account;
import glbank.Card;
import glbank.Client;
import glbank.Employee;
import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.sql.Statement;
import java.text.SimpleDateFormat;
import java.util.ArrayList;
import java.util.Date;
import java.util.List;

/**
 *
 * @author Solanid
 */
public class ConnectionProvider {
    private static final String USERNAME ="root";
    private static final String PASSWORD ="";
    private static final String DBNAME ="GLBank";
    private static final String URL = "jdbc:mysql://localhost/";
    private static final String DRIVER = "com.mysql.jdbc.Driver";

    private Connection getConnection() {
        Connection conn=null;
        try{
            conn = DriverManager.getConnection(URL+DBNAME, USERNAME, PASSWORD);
        } catch (SQLException ex) {
            System.out.println("Error: "+ex.toString());
        }    
        return conn;
    }
    
    public boolean isEmployeePasswordValid(String username, String password) {
        String query="Select idemp From LoginEmployee WHERE login LIKE BINARY ? AND password LIKE BINARY ?";
        Connection conn = getConnection();
        if (conn!=null) {
            try {
                PreparedStatement ps = conn.prepareStatement(query);
                ps.setString(1, username);
                ps.setString(2, password);
                ResultSet rs = ps.executeQuery();
                boolean ret = rs.next();
                conn.close();
                return ret;
            } catch (SQLException ex) {
                System.out.println("Error: "+ex.toString());
            }
        }
        return false;
    }
    
    public boolean isEmployeePasswordValid(int idemp, String password) {
        String query="Select idemp From LoginEmployee WHERE idemp LIKE BINARY ? AND password LIKE BINARY ?";
        Connection conn = getConnection();
        if (conn!=null) {
            try {
                PreparedStatement ps = conn.prepareStatement(query);
                ps.setInt(1, idemp);
                ps.setString(2, password);
                ResultSet rs = ps.executeQuery();
                boolean ret = rs.next();
                conn.close();
                return ret;
            } catch (SQLException ex) {
                System.out.println("isEmployeePasswordValidById Error: "+ex.toString());
            }
        }
        return false;
    }
    
    public int getEmployeeId(String username) {
        String query="SELECT idemp FROM LoginEmployee WHERE login LIKE BINARY ?";
        Connection conn = getConnection();
        int id=-1;
        if(conn!=null){
            try {
                 PreparedStatement ps= conn.prepareStatement(query);
                 ps.setString(1, username);
                 ResultSet rs = ps.executeQuery();
                 if(rs.next()){
                     id=rs.getInt("idemp");
                 }
                 conn.close();
            }catch(SQLException ex){
                System.out.println("getEmployeeId error: "+ex.toString());
            }
        }
        return id;
    }
    
    public void logEmployeeAccess(int id) {
        String query="INSERT INTO HistoryLoginEmployee (idemp, logindate)"+
                "VALUES (?, ?)";
        String date=getDateTime();
        Connection conn = getConnection();
        if (conn!=null) {
            try {
                PreparedStatement ps = conn.prepareStatement(query);
                ps.setInt(1, id);
                ps.setString(2, date);
                ps.execute();
                conn.close();
            } catch (SQLException ex) {
                System.out.println("logEmployeeAccess Error: "+ex.toString());
            }  
        }
    }
    
    public String getDateTime() {
        Date date = new Date();
        SimpleDateFormat sdf = new SimpleDateFormat("yyyy-MM-dd HH:mm:ss");
        String dateString = sdf.format(date);
        return dateString;
    }
    
    public Employee getEmployee(int id){
        String query = "SELECT * FROM Employees WHERE idemp = ?";
        Employee employee = null;
        Connection conn = getConnection();
        if (conn!=null) {
            try {
                PreparedStatement ps= conn.prepareStatement(query);
                ps.setInt(1, id);
                ResultSet rs=ps.executeQuery();
                if (rs.next()) {
                    String firstname = rs.getString("firstname");
                    String lastname = rs.getString("lastname");
                    String email = rs.getString("email");
                    char position = rs.getString("position").charAt(0);
                    
                    employee = new Employee(id, firstname,  lastname, email, position);
                }
            conn.close();
            } catch(SQLException ex) {
                System.out.println("getEmployee error: "+ex.toString());
            }
        }
        return employee;
    }

    public void changePassword(int idemp, String newPassword) {
        String query = "UPDATE LoginEmployee SET password = ? WHERE idemp = ?";
        Connection conn = getConnection();
        if (conn!=null) {
            try(PreparedStatement ps = conn.prepareStatement(query)) {
                ps.setString(1, newPassword);
                ps.setInt(2, idemp);
                ps.execute();
                conn.close();
            } catch (SQLException ex) {
                System.out.println("changePassword Error: "+ex.toString());
            }
        }
    }
    
    public List<Client> getListOfAllClients() {
        String query = "SELECT * FROM clients "+
                "INNER JOIN clientdetails ON clients.idc=clientdetails.idc "+
                "WHERE disable='F' ORDER BY lastname, firstname";
        Connection conn = getConnection();
        List<Client> clientList = new ArrayList<>();
        if (conn!=null) {
            try(Statement statement = conn.createStatement()) {
                ResultSet rs = statement.executeQuery(query);
                while(rs.next()) {
                    int idc = rs.getInt("clients.idc");
                    String firstname = rs.getString("firstname");
                    String lastname = rs.getString("lastname");
                    Date date = rs.getDate("dob");
                    Client client = new Client(idc, firstname, lastname, date);
                    clientList.add(client);
                }
                conn.close();
            } catch(SQLException ex) {
                System.out.println("getListOfAllClients error: "+ex.toString());
            }
        }
        return clientList;
    }
    
    public Client getClientDetails(int idc) {
        String query = "SELECT * FROM clients "+
                "INNER JOIN clientdetails ON clients.idc=clientdetails.idc "+
                "INNER JOIN loginclient ON clients.idc=loginclient.idc "+
                "WHERE clients.idc LIKE ?";
        Connection conn = getConnection();
        if (conn!=null) {
            try (PreparedStatement ps = conn.prepareStatement(query)) {
                ps.setInt(1, idc);
                ResultSet rs = ps.executeQuery();
                if (rs.next()) {
                    String firstname = rs.getString("firstname");
                    String lastname = rs.getString("lastname");
                    String street = rs.getString("street");
                    int houseNumber = rs.getInt("housenumber");
                    String postcode = rs.getString("postcode");
                    String city = rs.getString("city");
                    String email = rs.getString("email");
                    Date dob = rs.getDate("dob");
                    String username = rs.getString("login");
                    boolean disable = /*rs.getString("disable").charAt(0)=='T';*/ false;
                    boolean blocked = /*rs.getString("blocked").charAt(0)=='T';*/ false;
                    Client newClient = new Client(idc, firstname, lastname, email, street, houseNumber, city, postcode, username, dob, disable, blocked);
                    conn.close();
                    return newClient;
                }
                conn.close();
            } catch(SQLException ex) {
                System.out.println("getClientDetails error: "+ex.toString());
            }
        }
        return null;
    }
    
    public boolean isUsernameAlreadyUsed(String username) {
        String querry = "SELECT * FROM LoginClient WHERE login LIKE ?";
        Connection conn = getConnection();
        if (conn!=null) {
            try (PreparedStatement ps = conn.prepareStatement(querry)){
                ps.setString(1, username);
                ResultSet rs = ps.executeQuery();
                boolean state = rs.next();
                conn.close();
                return state;
            } catch(SQLException ex) {
                System.out.println("isUsernameAlreadyUsed error: "+ex.toString());                
            }
        }
        return false;
    }
   
    public void insertNewClient(Client client, String password) {
        Connection conn = getConnection();
        if (insertIntoClients(client, conn)) {
            int idc = getClientIdc(client, conn);
            if (idc>0) {
                client.setIdc(idc);
                insertNewClientDetails(client, conn);
                insertNewLoginClient(client, password, conn);
            }
        }
    }
    
    public boolean insertIntoClients(Client client, Connection conn) {
        String query = "INSERT INTO clients(firstname, lastname) VALUES(?, ?)";
        if (conn!=null) {
            try (PreparedStatement ps = conn.prepareStatement(query)) {
                ps.setString(1, client.getFirstname());
                ps.setString(2, client.getLastname());
                int x = ps.executeUpdate();
                return x==1;
            } catch(SQLException ex) {
                System.out.println("insertIntoClients error: "+ex.toString());
            }
        }
        return false;
    }
    
    public boolean insertNewClientDetails(Client client, Connection conn) {
        String query = "INSERT INTO ClientDetails(idc, street, housenumber, postcode, dob, email, city)"+
                " VALUES (?, ?, ?, ?, ?, ?, ?)";
        if (conn!=null) {
            try (PreparedStatement ps = conn.prepareStatement(query)) {
                ps.setInt(1, client.getIdc());
                ps.setString(2, client.getStreet());
                ps.setInt(3, client.getHousenumber());
                ps.setString(4, client.getPostcode());
                ps.setString(5, client.getStringDob());
                ps.setString(6, client.getEmail());
                ps.setString(7, client.getCity());
                int x = ps.executeUpdate();
                return x==1;
            } catch(SQLException ex) {
                System.out.println("insertNewClientDetails error: "+ex.toString());
            }
        }
        return false;
    }
    
    public boolean insertNewLoginClient(Client client, String password, Connection conn) {
        String query = "INSERT INTO LoginClient(idc, login, password) VALUES(?, ?, ?)";
        if (conn!=null) {
            try(PreparedStatement ps = conn.prepareStatement(query)) {
                ps.setInt(1, client.getIdc());
                ps.setString(2, client.getUsername());
                ps.setString(3, password);
                int x = ps.executeUpdate();
                return x==0;
            } catch(SQLException ex) {
                System.out.println("insertNewLoginClient error: "+ex.toString());
            }
        }
        return false;
    }
    
    public int getClientIdc(Client client, Connection conn){
        String query = "SELECT max(idc) AS idc FROM clients WHERE firstname LIKE ? AND lastname LIKE ?";
        int id = -1;
        if (conn!=null) {
            try (PreparedStatement ps = conn.prepareStatement(query)) {
                ps.setString(1, client.getFirstname());
                ps.setString(2, client.getLastname());
                ResultSet rs = ps.executeQuery();
                if (rs.next()) {
                    id=rs.getInt("idc");
                }
            } catch(SQLException ex) {
                System.out.println("getClientIds error: "+ex.toString());
            }
        }
        return id;
    }
    
    public List<Account> getListOfAccountsByIdc(int idc) {
        String query = "SELECT * FROM accounts WHERE idc LIKE ?";
        Connection conn = getConnection();
        List<Account> accountList = new ArrayList<>();
        if (conn!=null) {
            try(PreparedStatement ps = conn.prepareStatement(query)) {
                ps.setInt(1, idc);
                ResultSet rs = ps.executeQuery();
                while(rs.next()) {
                    long idacc = rs.getLong("idacc");
                    float balance = rs.getFloat("balance");
                    Account account = new Account(idacc, idc, balance);
                    accountList.add(account);
                }
                conn.close();
            } catch(SQLException ex) {
                System.out.println("getListOfAccountsByIdc error: "+ex.toString());
            }
        }
        return accountList;
    }
    
    public boolean isAccountAlreadyUsed(long proposalAccount) {
        String querry = "SELECT * FROM Accounts WHERE idacc LIKE ?";
        Connection conn = getConnection();
        if (conn!=null) {
            try (PreparedStatement ps = conn.prepareStatement(querry)){
                ps.setLong(1, proposalAccount);
                ResultSet rs = ps.executeQuery();
                boolean state = rs.next();
                conn.close();
                return state;
            } catch(SQLException ex) {
                System.out.println("isAccountAlreadyUsed error: "+ex.toString());                
            }
        }
        return false;
    }
    
    
    public boolean addNewAccount(int idc, long idacc) {
        String query = "INSERT INTO Accounts VALUES(?, ?, 0)";
        Connection conn = getConnection();
        if (conn!=null) {
            try(PreparedStatement ps = conn.prepareStatement(query)) {
                ps.setLong(1, idacc);
                ps.setInt(2, idc);
                int x = ps.executeUpdate();               
                conn.close();
                return x==1;
            } catch(SQLException ex) {
                System.out.println("addNewAccount error: "+ex.toString());
            }
        }
        return false;
    }
  
    public void updateAccountBalance(float amount, long idacc, Connection conn) {
        String query = "UPDATE Accounts SET Balance=balance+? WHERE idacc LIKE ?";
        if (conn!=null) { 
            try(PreparedStatement ps = conn.prepareStatement(query)) {
                ps.setFloat(1, amount);
                ps.setLong(2, idacc);
                ps.executeUpdate();
            } catch(SQLException ex) {
                System.out.println("updateAccountBalance error: "+ex.toString());
            }
        }
    }
    
    public void addNewCashTransactionLog(long idacc, float amount, int idemp, Connection conn) {
        String query="INSERT INTO cashtransactions (idemp, amount, idacc)"+
                "VALUES (?, ?, ?)";
        if (conn!=null) {
            try {
                PreparedStatement ps = conn.prepareStatement(query);
                ps.setInt(1, idemp);
                ps.setFloat(2, amount);
                ps.setLong(3, idacc);
                ps.execute();
            } catch (SQLException ex) {
                System.out.println("logEmployeeAccess Error: "+ex.toString());
            }  
        }        
    }
    
    public void insertCash(long idacc, float amount, int idemp) {
        Connection conn = getConnection();
        try {
            try {
                conn.setAutoCommit(false);
                updateAccountBalance(amount, idacc, conn);
                addNewCashTransactionLog(idacc, amount, idemp, conn);
                conn.commit();
                conn.close();
            } catch (SQLException ex) {
                conn.rollback();
            }
        } catch(SQLException ex) {
            
        }
    }
    
    // edit client
    public void editNewClient(Client client, String password) {
        Connection conn = getConnection();
        if (updateClients(client, conn)) {
            //System.out.println("update client OK");
            if (updateClientDetails(client, conn)) {
                //System.out.println("update clientDetails OK");
                updateLoginClient(client, password, conn);
            }
        }
    }
    
    public boolean updateClients(Client client, Connection conn) {
        String query = "UPDATE clients SET firstname=?, lastname=? WHERE idc=?";
        if (conn!=null) {
            try (PreparedStatement ps = conn.prepareStatement(query)) {
                ps.setString(1, client.getFirstname());
                ps.setString(2, client.getLastname());
                ps.setInt(3, client.getIdc());
                int x = ps.executeUpdate();
                return x==1;
            } catch(SQLException ex) {
                System.out.println("updateClients error: "+ex.toString());
            }
        }
        return false;
    }
    
    public boolean updateClientDetails(Client client, Connection conn) {
        String query = "UPDATE ClientDetails SET street=?, housenumber=?, postcode=?, email=?, city=?"+
                " WHERE idc=?";
        if (conn!=null) {
            try (PreparedStatement ps = conn.prepareStatement(query)) {
                ps.setString(1, client.getStreet());
                ps.setInt(2, client.getHousenumber());
                ps.setString(3, client.getPostcode());
                ps.setString(4, client.getEmail());
                ps.setString(5, client.getCity());
                ps.setInt(6, client.getIdc());
                int x = ps.executeUpdate();
                return x==1;
            } catch(SQLException ex) {
                System.out.println("updateClientDetails error: "+ex.toString());
            }
        }
        return false;
    }
    
    public boolean updateLoginClient(Client client, String password, Connection conn) {
        String query = "UPDATE LoginClient SET login=?, password=? WHERE idc=?";
        if (conn!=null) {
            try(PreparedStatement ps = conn.prepareStatement(query)) {
                ps.setString(1, client.getUsername());
                ps.setString(2, password);
                ps.setInt(3, client.getIdc());
                int x = ps.executeUpdate();
                return x==0;
            } catch(SQLException ex) {
                System.out.println("updateLoginClient error: "+ex.toString());
            }
        }
        return false;
    }
      
    public String getClientPassword(int idc) {
        String query = "SELECT password FROM LoginClient WHERE idc=?";
        Connection conn = getConnection();
        if (conn!=null) {
            try(PreparedStatement ps = conn.prepareStatement(query)) {
                ps.setInt(1, idc);
                ResultSet rs = ps.executeQuery();
                if (rs.next()) {
                    String password = rs.getString("password");
                    conn.close();
                    return password;
                }
            } catch(SQLException ex) {
                System.out.println("updateLoginClient error: "+ex.toString());
            }
        }
        return null;
    }   
  
    public List<Card> getCardsByIdAcc(long idAcc) {
        String query = "SELECT * FROM Cards WHERE idAcc=?";
        Connection conn = getConnection();
        List<Card> cards= new ArrayList<>();
        if (conn!=null) {
            try(PreparedStatement ps = conn.prepareStatement(query)) {
                ps.setLong(1, idAcc);
                ResultSet rs = ps.executeQuery();
                while (rs.next()) {
                    long cardNumber = rs.getLong("cardNumber");
                    int idCard = rs.getInt("idCard");
                    boolean blocked = rs.getString("blocked").charAt(0)=='T';
                    int pin = rs.getInt("pin");
                    Card card = new Card(idCard, cardNumber, idAcc, blocked, pin);
                    cards.add(card);
                }
                conn.close();
            } catch(SQLException ex) {
                System.out.println("getCardsByIdAcc error: "+toString());
            }
        }
        return cards;
    }
    
    public boolean blockCard(char blocked, long cardNumber) {
        String query = "UPDATE Cards SET bloacked=? WHERE cardNumber=?";
        Connection conn = getConnection();
        if (conn!=null) {
            try(PreparedStatement ps = conn.prepareStatement(query)) {
                ps.setString(1, new String().valueOf(blocked)); //Character.toString(char) or String.valueOf(char)
                ps.setLong(2, cardNumber);
                int x = ps.executeUpdate();
                conn.close();
                return x==0;
            } catch(SQLException ex) {
                System.out.println("blockCard error: "+toString());
            }
        } 
        return false;
    }
    
    public boolean changeCardPin(long cardNumber, int newPin) {
        String query = "UPDATE Cards SET pin=? WHERE cardNumber=?";
        Connection conn = getConnection();
        if (conn!=null) {
            try(PreparedStatement ps = conn.prepareStatement(query)) {
                ps.setInt(1, newPin);
                ps.setLong(2, cardNumber);
                int x = ps.executeUpdate();
                conn.close();
                return x==0;
            } catch(SQLException ex) {
                System.out.println("changeCardPin error: "+toString());
            }
        }
        return false;
    }
    
    public boolean isCardNumberAlreadyUsed(long proposalCardNumber) {
        String querry = "SELECT * FROM Cards WHERE cardNumber LIKE ?";
        Connection conn = getConnection();
        if (conn!=null) {
            try (PreparedStatement ps = conn.prepareStatement(querry)){
                ps.setLong(1, proposalCardNumber);
                ResultSet rs = ps.executeQuery();
                boolean state = rs.next();
                conn.close();
                return state;
            } catch(SQLException ex) {
                System.out.println("isCardNumberAlreadyUsed error: "+ex.toString());                
            }
        }
        return false;
    }
    
    public boolean addNewCard(Card card) {
        String querry = "INSERT INTO Cards(cardNumber, idAcc, pin) VALUES (?, ?, ?)";
        Connection conn = getConnection();
        if (conn!=null) {
            try (PreparedStatement ps = conn.prepareStatement(querry)){
                ps.setLong(1, card.getCardNumber());
                ps.setLong(2, card.getIdAcc());
                ps.setInt(3, card.getPin());
                int x = ps.executeUpdate();
                conn.close();
                return x==0;
            } catch(SQLException ex) {
                System.out.println("addNewCard error: "+ex.toString());                
            }
        }
        return false;
    }
}
