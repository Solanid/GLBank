/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package ui;

import database.ConnectionProvider;
import glbank.Card;
import java.awt.Dimension;
import java.awt.event.KeyEvent;
import java.sql.Connection;
import javax.swing.JOptionPane;

/**
 *
 * @author Solanid
 */
public class EditCardForm extends javax.swing.JDialog {
    Card card = null;
    boolean status;
    
    /**
     * Creates new form EditCardForm
     */
    public EditCardForm(java.awt.Frame parent, boolean modal, Card selectedCard) {
        super(parent, modal);
        this.card=selectedCard;
        initComponents();
        if (selectedCard.isBlocked()) {
            radioBlocked.setSelected(true);
        }
        this.status = radioBlocked.isSelected();
        lblCardInfo.setText(""+card.getCardNumber());
    }

    @SuppressWarnings("unchecked")
    // <editor-fold defaultstate="collapsed" desc="Generated Code">//GEN-BEGIN:initComponents
    private void initComponents() {

        jLabel1 = new javax.swing.JLabel();
        lblCardInfo = new javax.swing.JLabel();
        txtNewPin = new javax.swing.JTextField();
        radioBlocked = new javax.swing.JRadioButton();
        btnSave = new javax.swing.JButton();
        btnCancel = new javax.swing.JButton();

        setDefaultCloseOperation(javax.swing.WindowConstants.DISPOSE_ON_CLOSE);

        jLabel1.setText("New pin:");

        lblCardInfo.setText("Edit Card number");

        txtNewPin.addKeyListener(new java.awt.event.KeyAdapter() {
            public void keyTyped(java.awt.event.KeyEvent evt) {
                txtNewPinKeyTyped(evt);
            }
        });

        radioBlocked.setText("Blocked");
        radioBlocked.setToolTipText("");

        btnSave.setText("Save");
        btnSave.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                btnSaveActionPerformed(evt);
            }
        });

        btnCancel.setText("Cancel");
        btnCancel.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                btnCancelActionPerformed(evt);
            }
        });

        javax.swing.GroupLayout layout = new javax.swing.GroupLayout(getContentPane());
        getContentPane().setLayout(layout);
        layout.setHorizontalGroup(
            layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
            .addGroup(layout.createSequentialGroup()
                .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
                    .addGroup(layout.createSequentialGroup()
                        .addGap(101, 101, 101)
                        .addComponent(lblCardInfo))
                    .addGroup(layout.createSequentialGroup()
                        .addGap(78, 78, 78)
                        .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.TRAILING)
                            .addComponent(radioBlocked)
                            .addGroup(layout.createSequentialGroup()
                                .addComponent(jLabel1)
                                .addGap(18, 18, 18)
                                .addComponent(txtNewPin, javax.swing.GroupLayout.PREFERRED_SIZE, 65, javax.swing.GroupLayout.PREFERRED_SIZE))))
                    .addGroup(javax.swing.GroupLayout.Alignment.TRAILING, layout.createSequentialGroup()
                        .addContainerGap()
                        .addComponent(btnCancel, javax.swing.GroupLayout.PREFERRED_SIZE, 80, javax.swing.GroupLayout.PREFERRED_SIZE)
                        .addGap(83, 83, 83)))
                .addContainerGap(84, Short.MAX_VALUE))
            .addGroup(javax.swing.GroupLayout.Alignment.TRAILING, layout.createSequentialGroup()
                .addGap(0, 0, Short.MAX_VALUE)
                .addComponent(btnSave, javax.swing.GroupLayout.PREFERRED_SIZE, 80, javax.swing.GroupLayout.PREFERRED_SIZE)
                .addGap(36, 36, 36))
        );
        layout.setVerticalGroup(
            layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
            .addGroup(layout.createSequentialGroup()
                .addGap(23, 23, 23)
                .addComponent(lblCardInfo)
                .addGap(18, 18, 18)
                .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE)
                    .addComponent(jLabel1)
                    .addComponent(txtNewPin, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE))
                .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.UNRELATED)
                .addComponent(radioBlocked)
                .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.UNRELATED)
                .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE)
                    .addComponent(btnSave)
                    .addComponent(btnCancel))
                .addContainerGap(18, Short.MAX_VALUE))
        );

        pack();
    }// </editor-fold>//GEN-END:initComponents

    private void btnCancelActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_btnCancelActionPerformed
        this.setVisible(false);
        this.dispose();
    }//GEN-LAST:event_btnCancelActionPerformed

    private void btnSaveActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_btnSaveActionPerformed
        ConnectionProvider cp = new ConnectionProvider();
        boolean blocked = radioBlocked.isSelected();
        String stringPin = txtNewPin.getText().trim();
        int pin = 0;
        char blockChar;
        
        if (stringPin.length()>0) {
            try {
                pin = Integer.parseInt(stringPin);
            } catch(NumberFormatException ex) {
            }
        }
        
        if (stringPin.length()!=0) {
            cp.changeCardPin(card.getCardNumber(), pin);
            JOptionPane.showMessageDialog(this, "Card pin changed.");
        }
        else if (status!=blocked) {
            if (blocked) {
                blockChar='T';
                cp.blockCard(blockChar, card.getCardNumber());
                JOptionPane.showMessageDialog(this, "Card blocked.");
            } else {
                blockChar='F';
                cp.blockCard(blockChar, card.getCardNumber());
                JOptionPane.showMessageDialog(this, "Card unlocked.");
            }   
        }
        else if (status!=blocked && stringPin.length()!=0) {
            if (blocked) {
                blockChar='T';
                cp.changeCardPin(card.getCardNumber(), pin);
                cp.blockCard(blockChar, card.getCardNumber());
                JOptionPane.showMessageDialog(this, "Card pin changed and card blocked.");
            } else {
                blockChar='F';
                cp.changeCardPin(card.getCardNumber(), pin);
                cp.blockCard(blockChar, card.getCardNumber());
                JOptionPane.showMessageDialog(this, "Card pin changed and card unlocked.");
            }   
        }
    }//GEN-LAST:event_btnSaveActionPerformed

    private void txtNewPinKeyTyped(java.awt.event.KeyEvent evt) {//GEN-FIRST:event_txtNewPinKeyTyped
        char c = evt.getKeyChar();
        if (!(Character.isDigit(c) || (c==KeyEvent.VK_BACK_SPACE) || c==KeyEvent.VK_DELETE)) {
            getToolkit().beep();
            evt.consume();
        }
        if (txtNewPin.getText().length() >= 4 ) // limit textfield to 4 characters
            evt.consume();
    }//GEN-LAST:event_txtNewPinKeyTyped


    // Variables declaration - do not modify//GEN-BEGIN:variables
    private javax.swing.JButton btnCancel;
    private javax.swing.JButton btnSave;
    private javax.swing.JLabel jLabel1;
    private javax.swing.JLabel lblCardInfo;
    private javax.swing.JRadioButton radioBlocked;
    private javax.swing.JTextField txtNewPin;
    // End of variables declaration//GEN-END:variables
}
