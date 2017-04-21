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
import java.util.List;
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
        String password = "Dusicka1.";
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

    /**
     * Test of isEmployeePasswordValid method, of class ConnectionProvider.
     */
    @Test
    public void testIsEmployeePasswordValid_String_String() {
        System.out.println("isEmployeePasswordValid");
        String username = "";
        String password = "";
        ConnectionProvider instance = new ConnectionProvider();
        boolean expResult = false;
        boolean result = instance.isEmployeePasswordValid(username, password);
        assertEquals(expResult, result);
        // TODO review the generated test code and remove the default call to fail.
        fail("The test case is a prototype.");
    }

    /**
     * Test of isEmployeePasswordValid method, of class ConnectionProvider.
     */
    @Test
    public void testIsEmployeePasswordValid_int_String() {
        System.out.println("isEmployeePasswordValid");
        int idemp = 0;
        String password = "";
        ConnectionProvider instance = new ConnectionProvider();
        boolean expResult = false;
        boolean result = instance.isEmployeePasswordValid(idemp, password);
        assertEquals(expResult, result);
        // TODO review the generated test code and remove the default call to fail.
        fail("The test case is a prototype.");
    }

    /**
     * Test of getEmployeeId method, of class ConnectionProvider.
     */
    @Test
    public void testGetEmployeeId() {
        System.out.println("getEmployeeId");
        String username = "";
        ConnectionProvider instance = new ConnectionProvider();
        int expResult = 0;
        int result = instance.getEmployeeId(username);
        assertEquals(expResult, result);
        // TODO review the generated test code and remove the default call to fail.
        fail("The test case is a prototype.");
    }

    /**
     * Test of logEmployeeAccess method, of class ConnectionProvider.
     */
    @Test
    public void testLogEmployeeAccess() {
        System.out.println("logEmployeeAccess");
        int id = 0;
        ConnectionProvider instance = new ConnectionProvider();
        instance.logEmployeeAccess(id);
        // TODO review the generated test code and remove the default call to fail.
        fail("The test case is a prototype.");
    }

    /**
     * Test of getDateTime method, of class ConnectionProvider.
     */
    @Test
    public void testGetDateTime() {
        System.out.println("getDateTime");
        ConnectionProvider instance = new ConnectionProvider();
        String expResult = "";
        String result = instance.getDateTime();
        assertEquals(expResult, result);
        // TODO review the generated test code and remove the default call to fail.
        fail("The test case is a prototype.");
    }

    /**
     * Test of changePassword method, of class ConnectionProvider.
     */
    @Test
    public void testChangePassword() {
        System.out.println("changePassword");
        int idemp = 0;
        String newPassword = "";
        ConnectionProvider instance = new ConnectionProvider();
        instance.changePassword(idemp, newPassword);
        // TODO review the generated test code and remove the default call to fail.
        fail("The test case is a prototype.");
    }

    /**
     * Test of getListOfAllClients method, of class ConnectionProvider.
     */
    @Test
    public void testGetListOfAllClients() {
        System.out.println("getListOfAllClients");
        ConnectionProvider instance = new ConnectionProvider();
        List<Client> expResult = null;
        List<Client> result = instance.getListOfAllClients();
        assertEquals(expResult, result);
        // TODO review the generated test code and remove the default call to fail.
        fail("The test case is a prototype.");
    }

    /**
     * Test of getClientDetails method, of class ConnectionProvider.
     */
    @Test
    public void testGetClientDetails() {
        System.out.println("getClientDetails");
        int idc = 0;
        ConnectionProvider instance = new ConnectionProvider();
        Client expResult = null;
        Client result = instance.getClientDetails(idc);
        assertEquals(expResult, result);
        // TODO review the generated test code and remove the default call to fail.
        fail("The test case is a prototype.");
    }

    /**
     * Test of isUsernameAlreadyUsed method, of class ConnectionProvider.
     */
    @Test
    public void testIsUsernameAlreadyUsed() {
        System.out.println("isUsernameAlreadyUsed");
        String username = "";
        ConnectionProvider instance = new ConnectionProvider();
        boolean expResult = false;
        boolean result = instance.isUsernameAlreadyUsed(username);
        assertEquals(expResult, result);
        // TODO review the generated test code and remove the default call to fail.
        fail("The test case is a prototype.");
    }

    /**
     * Test of insertNewClient method, of class ConnectionProvider.
     */
    @Test
    public void testInsertNewClient() {
        System.out.println("insertNewClient");
        Client client = null;
        String password = "";
        ConnectionProvider instance = new ConnectionProvider();
        instance.insertNewClient(client, password);
        // TODO review the generated test code and remove the default call to fail.
        fail("The test case is a prototype.");
    }

    /**
     * Test of insertIntoClients method, of class ConnectionProvider.
     */
    @Test
    public void testInsertIntoClients() {
        System.out.println("insertIntoClients");
        Client client = null;
        Connection conn = null;
        ConnectionProvider instance = new ConnectionProvider();
        boolean expResult = false;
        boolean result = instance.insertIntoClients(client, conn);
        assertEquals(expResult, result);
        // TODO review the generated test code and remove the default call to fail.
        fail("The test case is a prototype.");
    }

    /**
     * Test of insertNewClientDetails method, of class ConnectionProvider.
     */
    @Test
    public void testInsertNewClientDetails() {
        System.out.println("insertNewClientDetails");
        Client client = null;
        Connection conn = null;
        ConnectionProvider instance = new ConnectionProvider();
        boolean expResult = false;
        boolean result = instance.insertNewClientDetails(client, conn);
        assertEquals(expResult, result);
        // TODO review the generated test code and remove the default call to fail.
        fail("The test case is a prototype.");
    }

    /**
     * Test of insertNewLoginClient method, of class ConnectionProvider.
     */
    @Test
    public void testInsertNewLoginClient() {
        System.out.println("insertNewLoginClient");
        Client client = null;
        String password = "";
        Connection conn = null;
        ConnectionProvider instance = new ConnectionProvider();
        boolean expResult = false;
        boolean result = instance.insertNewLoginClient(client, password, conn);
        assertEquals(expResult, result);
        // TODO review the generated test code and remove the default call to fail.
        fail("The test case is a prototype.");
    }

    /**
     * Test of getClientIdc method, of class ConnectionProvider.
     */
    @Test
    public void testGetClientIdc() {
        System.out.println("getClientIdc");
        Client client = null;
        Connection conn = null;
        ConnectionProvider instance = new ConnectionProvider();
        int expResult = 0;
        int result = instance.getClientIdc(client, conn);
        assertEquals(expResult, result);
        // TODO review the generated test code and remove the default call to fail.
        fail("The test case is a prototype.");
    }

    /**
     * Test of getListOfAccountsByIdc method, of class ConnectionProvider.
     */
    @Test
    public void testGetListOfAccountsByIdc() {
        System.out.println("getListOfAccountsByIdc");
        int idc = 0;
        ConnectionProvider instance = new ConnectionProvider();
        List<Account> expResult = null;
        List<Account> result = instance.getListOfAccountsByIdc(idc);
        assertEquals(expResult, result);
        // TODO review the generated test code and remove the default call to fail.
        fail("The test case is a prototype.");
    }

    /**
     * Test of isAccountAlreadyUsed method, of class ConnectionProvider.
     */
    @Test
    public void testIsAccountAlreadyUsed() {
        System.out.println("isAccountAlreadyUsed");
        long proposalAccount = 0L;
        ConnectionProvider instance = new ConnectionProvider();
        boolean expResult = false;
        boolean result = instance.isAccountAlreadyUsed(proposalAccount);
        assertEquals(expResult, result);
        // TODO review the generated test code and remove the default call to fail.
        fail("The test case is a prototype.");
    }

    /**
     * Test of addNewAccount method, of class ConnectionProvider.
     */
    @Test
    public void testAddNewAccount() {
        System.out.println("addNewAccount");
        int idc = 0;
        long idacc = 0L;
        ConnectionProvider instance = new ConnectionProvider();
        boolean expResult = false;
        boolean result = instance.addNewAccount(idc, idacc);
        assertEquals(expResult, result);
        // TODO review the generated test code and remove the default call to fail.
        fail("The test case is a prototype.");
    }

    /**
     * Test of updateAccountBalance method, of class ConnectionProvider.
     */
    @Test
    public void testUpdateAccountBalance() {
        System.out.println("updateAccountBalance");
        float amount = 0.0F;
        long idacc = 0L;
        Connection conn = null;
        ConnectionProvider instance = new ConnectionProvider();
        instance.updateAccountBalance(amount, idacc, conn);
        // TODO review the generated test code and remove the default call to fail.
        fail("The test case is a prototype.");
    }

    /**
     * Test of addNewCashTransactionLog method, of class ConnectionProvider.
     */
    @Test
    public void testAddNewCashTransactionLog() {
        System.out.println("addNewCashTransactionLog");
        long idacc = 0L;
        float amount = 0.0F;
        int idemp = 0;
        Connection conn = null;
        ConnectionProvider instance = new ConnectionProvider();
        instance.addNewCashTransactionLog(idacc, amount, idemp, conn);
        // TODO review the generated test code and remove the default call to fail.
        fail("The test case is a prototype.");
    }

    /**
     * Test of insertCash method, of class ConnectionProvider.
     */
    @Test
    public void testInsertCash() {
        System.out.println("insertCash");
        long idacc = 0L;
        float amount = 0.0F;
        int idemp = 0;
        ConnectionProvider instance = new ConnectionProvider();
        instance.insertCash(idacc, amount, idemp);
        // TODO review the generated test code and remove the default call to fail.
        fail("The test case is a prototype.");
    }

    /**
     * Test of editNewClient method, of class ConnectionProvider.
     */
    @Test
    public void testEditNewClient() {
        System.out.println("editNewClient");
        Client client = null;
        String password = "";
        ConnectionProvider instance = new ConnectionProvider();
        instance.editNewClient(client, password);
        // TODO review the generated test code and remove the default call to fail.
        fail("The test case is a prototype.");
    }

    /**
     * Test of updateClients method, of class ConnectionProvider.
     */
    @Test
    public void testUpdateClients() {
        System.out.println("updateClients");
        Client client = null;
        Connection conn = null;
        ConnectionProvider instance = new ConnectionProvider();
        boolean expResult = false;
        boolean result = instance.updateClients(client, conn);
        assertEquals(expResult, result);
        // TODO review the generated test code and remove the default call to fail.
        fail("The test case is a prototype.");
    }

    /**
     * Test of updateClientDetails method, of class ConnectionProvider.
     */
    @Test
    public void testUpdateClientDetails() {
        System.out.println("updateClientDetails");
        Client client = null;
        Connection conn = null;
        ConnectionProvider instance = new ConnectionProvider();
        boolean expResult = false;
        boolean result = instance.updateClientDetails(client, conn);
        assertEquals(expResult, result);
        // TODO review the generated test code and remove the default call to fail.
        fail("The test case is a prototype.");
    }

    /**
     * Test of updateLoginClient method, of class ConnectionProvider.
     */
    @Test
    public void testUpdateLoginClient() {
        System.out.println("updateLoginClient");
        Client client = null;
        String password = "";
        Connection conn = null;
        ConnectionProvider instance = new ConnectionProvider();
        boolean expResult = false;
        boolean result = instance.updateLoginClient(client, password, conn);
        assertEquals(expResult, result);
        // TODO review the generated test code and remove the default call to fail.
        fail("The test case is a prototype.");
    }

    /**
     * Test of getClientPassword method, of class ConnectionProvider.
     */
    @Test
    public void testGetClientPassword() {
        System.out.println("getClientPassword");
        int idc = 0;
        ConnectionProvider instance = new ConnectionProvider();
        String expResult = "";
        String result = instance.getClientPassword(idc);
        assertEquals(expResult, result);
        // TODO review the generated test code and remove the default call to fail.
        fail("The test case is a prototype.");
    }

    /**
     * Test of getCardsByIdAcc method, of class ConnectionProvider.
     */
    @Test
    public void testGetCardsByIdAcc() {
        System.out.println("getCardsByIdAcc");
        long idAcc = 0L;
        ConnectionProvider instance = new ConnectionProvider();
        List<Card> expResult = null;
        List<Card> result = instance.getCardsByIdAcc(idAcc);
        assertEquals(expResult, result);
        // TODO review the generated test code and remove the default call to fail.
        fail("The test case is a prototype.");
    }

    /**
     * Test of blockCard method, of class ConnectionProvider.
     */
    @Test
    public void testBlockCard() {
        System.out.println("blockCard");
        char blocked = ' ';
        long cardNumber = 0L;
        ConnectionProvider instance = new ConnectionProvider();
        boolean expResult = false;
        boolean result = instance.blockCard(blocked, cardNumber);
        assertEquals(expResult, result);
        // TODO review the generated test code and remove the default call to fail.
        fail("The test case is a prototype.");
    }

    /**
     * Test of changeCardPin method, of class ConnectionProvider.
     */
    @Test
    public void testChangeCardPin() {
        System.out.println("changeCardPin");
        long cardNumber = 0L;
        int newPin = 0;
        ConnectionProvider instance = new ConnectionProvider();
        boolean expResult = false;
        boolean result = instance.changeCardPin(cardNumber, newPin);
        assertEquals(expResult, result);
        // TODO review the generated test code and remove the default call to fail.
        fail("The test case is a prototype.");
    }

    /**
     * Test of isCardNumberAlreadyUsed method, of class ConnectionProvider.
     */
    @Test
    public void testIsCardNumberAlreadyUsed() {
        System.out.println("isCardNumberAlreadyUsed");
        long proposalCardNumber = 0L;
        ConnectionProvider instance = new ConnectionProvider();
        boolean expResult = false;
        boolean result = instance.isCardNumberAlreadyUsed(proposalCardNumber);
        assertEquals(expResult, result);
        // TODO review the generated test code and remove the default call to fail.
        fail("The test case is a prototype.");
    }

    /**
     * Test of addNewCard method, of class ConnectionProvider.
     */
    @Test
    public void testAddNewCard() {
        System.out.println("addNewCard");
        Card card = null;
        ConnectionProvider instance = new ConnectionProvider();
        boolean expResult = false;
        boolean result = instance.addNewCard(card);
        assertEquals(expResult, result);
        // TODO review the generated test code and remove the default call to fail.
        fail("The test case is a prototype.");
    }

    /**
     * Test of bankTransaction method, of class ConnectionProvider.
     */
    @Test
    public void testBankTransaction() throws Exception {
        System.out.println("bankTransaction");
        float amount = 0.0F;
        long srcAcc = 0L;
        long destAcc = 0L;
        int idemp = 0;
        String description = "";
        int srcBank = 0;
        int destBank = 0;
        ConnectionProvider instance = new ConnectionProvider();
        boolean expResult = false;
        boolean result = instance.bankTransaction(amount, srcAcc, destAcc, idemp, description, srcBank, destBank);
        assertEquals(expResult, result);
        // TODO review the generated test code and remove the default call to fail.
        fail("The test case is a prototype.");
    }
    
    
}
