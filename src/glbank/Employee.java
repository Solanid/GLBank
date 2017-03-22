/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package glbank;

/**
 *
 * @author Solanid
 */
public class Employee {
    private String idemp;
    private String firstname;
    private String lastname;
    private String email;
    private char position;

    public Employee(int id, String string, String string0, String string1, String string2) {
        throw new UnsupportedOperationException("Not supported yet."); //To change body of generated methods, choose Tools | Templates.
    }

    public Employee(int id, String firstname, String lastname, String email, char position) {
        throw new UnsupportedOperationException("Not supported yet."); //To change body of generated methods, choose Tools | Templates.
    }

    public String getIdemp() {
        return idemp;
    }

    public String getFirstname() {
        return firstname;
    }

    public String getLastname() {
        return lastname;
    }

    public String getEmail() {
        return email;
    }

    public char getPosition() {
        return position;
    }

    public Employee(String idemp, String firstname, String lastname, String email, char position) {
        this.idemp = idemp;
        this.firstname = firstname;
        this.lastname = lastname;
        this.email = email;
        this.position = position;
    }
    
    
}
