/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package database;

import glbank.Employee;
import org.junit.After;
import org.junit.AfterClass;
import org.junit.Before;
import org.junit.BeforeClass;
import org.junit.Test;
import static org.junit.Assert.*;

/**
 *
 * @author Solanid
 */
public class ConnectionProviderTest {
    
    //constructor
    public ConnectionProviderTest() {
    }
    
    // ak potrebuje nejake pomocne veci napr pomocnu tabulku tak ju vytvori pred testovanim
    @BeforeClass
    public static void setUpClass() {
    }
    // tu ju po teste vymaze
    @AfterClass
    public static void tearDownClass() {
    }
    
    @Before
    public void setUp() {
    }
    
    @After
    public void tearDown() {
    }

    /**
     * Test of isEmployeePasswordValid method, of class ConnectionProvider.
     */
    @Test
    public void testIsEmployeePasswordValid1() {
        System.out.println("isEmployeePasswordValid");
        String username = "anicka";
        String password = "dusicka";
        ConnectionProvider instance = new ConnectionProvider();
        boolean expResult = true;
        boolean result = instance.isEmployeePasswordValid(username, password);
        assertEquals(expResult, result);
        // TODO review the generated test code and remove the default call to fail.
    }
    
    /**
     * Test of isEmployeePasswordValid method, of class ConnectionProvider.
     */
    @Test
    public void testIsEmployeePasswordValid2() {
        System.out.println("isEmployeePasswordValid");
        String username = "anicka";
        String password = "Dusicka";
        ConnectionProvider instance = new ConnectionProvider();
        boolean expResult = false;
        boolean result = instance.isEmployeePasswordValid(username, password);
        assertEquals(expResult, result);
        // TODO review the generated test code and remove the default call to fail.
    }
    
    @Test
    public void testIsEmployeePasswordValid3() {
        System.out.println("isEmployeePasswordValid");
        int idemp = 2;
        String password = "Dusicka";
        ConnectionProvider instance = new ConnectionProvider();
        boolean expResult = false;
        boolean result = instance.isEmployeePasswordValid(idemp, password);
        assertEquals(expResult, result);
        // TODO review the generated test code and remove the default call to fail.
    }    

    /**
     * Test of getEmployeeId method, of class ConnectionProvider.
     */
    @Test
    public void testGetEmployeeId1() {
        System.out.println("getEmployeeId");
        String username = "anicka";
        ConnectionProvider instance = new ConnectionProvider();
        int expResult = 2;
        int result = instance.getEmployeeId(username);
        assertEquals(expResult, result);
        // TODO review the generated test code and remove the default call to fail.
    }
  
    @Test
    public void testGetEmployeeId2() {
        System.out.println("getEmployeeId");
        String username = "Anicka";
        ConnectionProvider instance = new ConnectionProvider();
        int expResult = -1;
        int result = instance.getEmployeeId(username);
        assertEquals(expResult, result);
        // TODO review the generated test code and remove the default call to fail.
    }
       
    @Test
    public void testGetEmployeeId3() {
        System.out.println("getEmployeeId");
        String username = "x4dfg652";
        ConnectionProvider instance = new ConnectionProvider();
        int expResult = -1;
        int result = instance.getEmployeeId(username);
        assertEquals(expResult, result);
        // TODO review the generated test code and remove the default call to fail.
    }

    /**
     * Test of logEmployeeAccess method, of class ConnectionProvider.
     */
    /*
    @Test
    public void testLogEmployeeAccess() {
        System.out.println("logEmployeeAccess");
        int id = 2;
        ConnectionProvider instance = new ConnectionProvider();
        instance.logEmployeeAccess(id);
        // TODO review the generated test code and remove the default call to fail.
        fail("The test case is a prototype.");
    }*/
    
    /**
     * Test of getDateTime method, of class ConnectionProvider.
     */
    /*
    @Test
    public void testGetDateTime() {
        System.out.println("getDateTime");
        ConnectionProvider instance = new ConnectionProvider();
        String expResult = "";
        String result = instance.getDateTime();
        assertEquals(expResult, result);
        // TODO review the generated test code and remove the default call to fail.
        fail("The test case is a prototype.");
    }*/
    @Test
    public void testGetEmployee() {
        System.out.println("getEmployee");
        int id = 2;
        ConnectionProvider instance = new ConnectionProvider();
        Employee result = instance.getEmployee(id);
        System.out.println(result.getFirstname());
        assertEquals("Anicka", result.getFirstname());
        assertEquals("Dusicka", result.getLastname());
        assertEquals(2, result.getIdemp());
        assertEquals("a.dusicka@gmail.com", result.getEmail());
        assertEquals('C', result.getPosition());
        
        // TODO review the generated test code and remove the default call to fail.
    }
}
