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
public class Card {
    private int idCard;
    private long cardNumber;
    private long idAcc;
    private boolean blocked;
    private int pin;

    public Card(int idCard, long cardNumber, long idAcc, boolean blocked, int pin) {
        this.idCard = idCard;
        this.cardNumber = cardNumber;
        this.idAcc = idAcc;
        this.blocked = blocked;
        this.pin = pin;
    }

    public Card(long cardNumber, long idAcc, int pin) {
        this.cardNumber = cardNumber;
        this.idAcc = idAcc;
        this.pin = pin;
        this.idCard = 0;
        this.blocked = false;
    }
    
    public int getIdCard() {
        return idCard;
    }

    public long getCardNumber() {
        return cardNumber;
    }

    public long getIdAcc() {
        return idAcc;
    }

    public boolean isBlocked() {
        return blocked;
    }

    public int getPin() {
        return pin;
    }
    
    
}
