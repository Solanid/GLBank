/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package database;

import glbank.Employee;
import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.text.SimpleDateFormat;
import java.util.Date;

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
    
    public boolean isEmployeePasswordValidById(int idemp, String password) {
        String query="Select idemp From LoginEmployee WHERE login LIKE BINARY ? AND password LIKE BINARY ?";
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
}
