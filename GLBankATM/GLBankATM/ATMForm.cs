using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GLBankATM
{
    public enum States
    {
        LANGUAGE, ENTERPIN, PINOK, BALANCE, CHANGELANGUAGE, EXIT, CHANGEPIN, REENTEROLDPIN, PINCHANGED, PINNOTCHANGED, CARDBLOCKED, WITHDRAWAL
    }
    public enum Languages
    {
        SVK, ENG, DE, JPN
    }

    public partial class ATMForm : Form
    {
        public ATMForm(long cardNumber, int idCard)
        {
            InitializeComponent();
            stateLanguage();
            this.cardNumber = cardNumber;
            this.idCard = idCard;
            lblEnterPin.center();
            this.CenterToScreen();
            panelChangePin.Visible = false;
            panelATM.BorderStyle = BorderStyle.FixedSingle;
            panelChangePin.BorderStyle = BorderStyle.FixedSingle;
        }

        int amount;
        TextBox txtInput;
        int newPin;
        long cardNumber;
        int idCard;
        States state = new States();
        Languages lang = new Languages();
        
        private void panelATM_Paint(object sender, PaintEventArgs e)
        {
            /*switch (state)
            {
                case States.LANGUAGE:
                    stateLanguage();
                    break;
                case States.ENTERPIN:
                    stateEnterPin();
                    break;
                case States.PINOK:
                    statePinOk();
                    break;
                case States.PINWRONG:
                    txtPin.Text = "";
                    break;
                default:
                    break;
            }*/
        
        }

        void changeState(States newState)
        {
            state = newState;
            switch (state)
            {
                case States.LANGUAGE:
                    stateLanguage();
                    break;
                case States.CHANGELANGUAGE:
                    stateLanguage();
                    break;
                case States.ENTERPIN:
                    stateEnterPin();
                    break;
                case States.PINOK:
                    statePinOk();
                    break;
                case States.BALANCE:
                    stateBalance();
                    break;
                case States.EXIT:
                    stateExit();
                    break;
                case States.CHANGEPIN:
                    stateChangePin();
                    break;
                case States.REENTEROLDPIN:
                    stateReenterOldPin();
                    break;
                case States.PINCHANGED:
                    statePinChanged();
                    break;
                case States.PINNOTCHANGED:
                    statePinNotChanged();
                    break;
                case States.CARDBLOCKED:
                    stateCardBlocked();
                    break;
                case States.WITHDRAWAL:
                    stateWithdrawal();
                    break;
                default:
                    break;
            }
        }

        void stateExit()
        {
            this.Close();
        }
        
        void stateWithdrawal()
        {
            enableAmountLabels();
            panelChangePin.Visible = true;
            disableKeyboard();
            enableSideButtons();
            btnKeyboardOK.Enabled = true;
            btnKeyboardC.Enabled = true;
            lblP2ChangePinTab.Text = MessagesLang.getMessageWithdrawMoney(lang);
            lblP2ChangePinTab.center();
            lblP2EnterNewPin.Visible = false;
            lblP2ReEnterPin.Visible = false;
            txtP2NewPass.Visible = false;
            txtP2ReNewPass.Visible = false;

            lblSum.Text = "0 €";
            lblSum.center();
            amount = 0;

        }

        void disableAmountsLabels()
        {
            lbl10eur.Visible = false;
            lbl20eur.Visible = false;
            lbl50eur.Visible = false;
            lbl100eur.Visible = false;
            lbl200eur.Visible = false;
            lbl500eur.Visible = false;
            lblSum.Visible = false;
        }

        void enableAmountLabels()
        {
            lbl10eur.Visible = true;
            lbl20eur.Visible = true;
            lbl50eur.Visible = true;
            lbl100eur.Visible = true;
            lbl200eur.Visible = true;
            lbl500eur.Visible = true;
            lblSum.Visible = true;
        }

        void statePinChanged()
        {
            disableKeyboard();
            btnKeyboardOK.Enabled = true;
            disableSideButtons();
            btnRightPanel1.Enabled = true;
            lblP2ChangePinTab.Text = MessagesLang.getMessagePinChanged(lang);
            lblP2ChangePinTab.center();
            lblP2Back.Visible = false;
            lblP2EnterNewPin.Visible = false;
            lblP2ReEnterPin.Visible = false;
            txtP2NewPass.Visible = false;
            txtP2ReNewPass.Visible = false;
        }

        void statePinNotChanged()
        {
            disableKeyboard();
            btnKeyboardOK.Enabled = true;
            disableSideButtons();
            btnRightPanel1.Enabled = true;
            lblP2ChangePinTab.Text = MessagesLang.getMessagePinNotChanged(lang);
            lblP2ChangePinTab.center();
            lblP2Back.Visible = false;
            lblP2EnterNewPin.Visible = false;
            lblP2ReEnterPin.Visible = false;
            txtP2NewPass.Visible = false;
            txtP2ReNewPass.Visible = false;
        }

        void stateCardBlocked()
        {
            disableKeyboard();
            btnKeyboardOK.Enabled = true;
            disableSideButtons();
            btnRightPanel1.Enabled = true;
            lblP2ChangePinTab.Text = MessagesLang.getMessageCardBlocked(lang);
            lblP2ChangePinTab.center();
            lblP2Back.Visible = false;
            lblP2EnterNewPin.Visible = false;
            lblP2ReEnterPin.Visible = false;
            txtP2NewPass.Visible = false;
            txtP2ReNewPass.Visible = false;
        }

        void stateReenterOldPin()
        {
            btnRightPanel2.Enabled = false;
            btnRightPanel3.Enabled = false;
            txtP2ReNewPass.Visible = false;
            lblP2ReEnterPin.Visible = false;

            lblP2EnterNewPin.Text = MessagesLang.getMessageEnterOldPin(lang);
            txtP2NewPass.Text = "";
            txtP2ReNewPass.Text = "";
            txtInput = txtP2NewPass;
        }

        void stateChangePin()
        {
            disableAmountsLabels();
            disableSideButtons();
            enableKeyboard();
            panelChangePin.Visible = true;

            txtInput = txtP2NewPass;
            txtP2NewPass.Text = "";
            txtP2ReNewPass.Text = "";

            btnRightPanel1.Enabled = true;
            btnRightPanel2.Enabled = true;
            btnRightPanel3.Enabled = true;
            btnLeftPanel4.Enabled = true;

            lblP2Back.Text = MessagesLang.getMessageBack(lang);
            lblP2Hints.Text = MessagesLang.getMessageHintsPressOk(lang);
            lblP2ChangePinTab.Text = MessagesLang.getMessageMenuPin(lang);
            lblP2EnterNewPin.Text = MessagesLang.getMessageEnterNewPin(lang);
            lblP2ReEnterPin.Text = MessagesLang.getMessageReEnterNewPi(lang);

            lblP2Back.Visible = true;
            lblP2Exit.Visible = true;
            lblP2Hints.Visible = true;
            lblP2EnterNewPin.Visible = true;
            lblP2ChangePinTab.Visible = true;
            lblP2ReEnterPin.Visible = true;
            txtP2NewPass.Visible = true;
            txtP2ReNewPass.Visible = true;
            
        }

        void stateLanguage()
        {
            hideLabels();
            disableSideButtons();
            lblLangEnglish.Visible = true;
            lblLangSlovak.Visible = true;
            lblMenuLanguage.Visible = true;
            lblMenuLanguage.Text = "日本の";

            lblMenuPin.Visible = true;
            lblMenuPin.Text = "Deutsch";
            btnLeftPanel3.Enabled = true;
            btnLeftPanel4.Enabled = true;
            btnRightPanel3.Enabled = true;
            btnRightPanel4.Enabled = true;
            disableKeyboard();
        }

        void stateEnterPin()
        {
            hideLabels();
            disableSideButtons();
            enableKeyboard();

            lblEnterPin.Text = MessagesLang.getMessageEnterPin(lang);
            lblEnterPin.center();
            lblEnterPin.Visible = true;
            txtPin.Visible = true;
        }

        void stateBalance()
        {
            hideLabels();
            disableKeyboard();
            disableSideButtons();
            btnLeftPanel4.Enabled = true;
            lblEnterPin.Text = MessagesLang.getMessageBalance(lang);
            lblEnterPin.Visible = true;
            lblBalance.Visible = true;
            lblBack.Text = MessagesLang.getMessageBack(lang);
            lblBack.Visible = true;
        }

        void statePinOk()
        {
            panelChangePin.Visible = false;
            hideLabels();
            disableSideButtons();
            disableKeyboard();
            btnLeftPanel2.Enabled = true;
            btnLeftPanel3.Enabled = true;
            btnRightPanel2.Enabled = true;
            btnRightPanel3.Enabled = true;

            lblMenuBalance.Text = MessagesLang.getMessageMenuBalance(lang);
            lblMenuMoney.Text = MessagesLang.getMessageMenuMoney(lang);
            lblMenuPin.Text = MessagesLang.getMessageMenuPin(lang);
            lblMenuLanguage.Text = MessagesLang.getMessageMenuLanguage(lang);

            lblMenuBalance.Visible = true;
            lblMenuMoney.Visible = true;
            lblMenuPin.Visible = true;
            lblMenuLanguage.Visible = true;
        }

        void hideLabels()
        {
            lblLangEnglish.Visible = false;
            lblLangSlovak.Visible = false;
            lblMenuBalance.Visible = false;
            lblMenuMoney.Visible = false;
            lblMenuPin.Visible = false;
            lblMenuLanguage.Visible = false;
            lblBalance.Visible = false;
            lblBack.Visible = false;
            txtPin.Visible = false;
            lblEnterPin.Visible = false;
        }

        void disableSideButtons()
        {
            btnLeftPanel1.Enabled = false;
            btnLeftPanel2.Enabled = false;
            btnLeftPanel3.Enabled = false;
            btnLeftPanel4.Enabled = false;
            btnRightPanel2.Enabled = false;
            btnRightPanel3.Enabled = false;
            btnRightPanel4.Enabled = false;
        }

        void enableSideButtons()
        {
            btnLeftPanel1.Enabled = true;
            btnLeftPanel2.Enabled = true;
            btnLeftPanel3.Enabled = true;
            btnLeftPanel4.Enabled = true;
            btnRightPanel2.Enabled = true;
            btnRightPanel3.Enabled = true;
            btnRightPanel4.Enabled = true;
        }

        void disableKeyboard()
        {
            btnKeyboard0.Enabled = false;
            btnKeyboard1.Enabled = false;
            btnKeyboard2.Enabled = false;
            btnKeyboard3.Enabled = false;
            btnKeyboard4.Enabled = false;
            btnKeyboard5.Enabled = false;
            btnKeyboard6.Enabled = false;
            btnKeyboard7.Enabled = false;
            btnKeyboard8.Enabled = false;
            btnKeyboard9.Enabled = false;
            btnKeyboardC.Enabled = false;
            btnKeyboardOK.Enabled = false;
        }

        void enableKeyboard()
        {
            btnKeyboard0.Enabled = true;
            btnKeyboard1.Enabled = true;
            btnKeyboard2.Enabled = true;
            btnKeyboard3.Enabled = true;
            btnKeyboard4.Enabled = true;
            btnKeyboard5.Enabled = true;
            btnKeyboard6.Enabled = true;
            btnKeyboard7.Enabled = true;
            btnKeyboard8.Enabled = true;
            btnKeyboard9.Enabled = true;
            btnKeyboardC.Enabled = true;
            btnKeyboardOK.Enabled = true;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnLeftPanel4_Click(object sender, EventArgs e)
        {
            if (state == States.LANGUAGE)
            {
                lang = Languages.SVK;
                changeState(States.ENTERPIN);
            }
            else if (state == States.BALANCE || state == States.CHANGEPIN || state == States.REENTEROLDPIN || state == States.WITHDRAWAL)
            {
                changeState(States.PINOK);
            }
            else if (state == States.CHANGELANGUAGE)
            {
                lang = Languages.SVK;
                changeState(States.PINOK);
            }
        }

        private void btnRightPanel4_Click(object sender, EventArgs e)
        {
            if (state == States.LANGUAGE)
            {
                lang = Languages.ENG;
                changeState(States.ENTERPIN);
            }
            else if (state == States.CHANGELANGUAGE)
            {
                lang = Languages.ENG;
                changeState(States.PINOK);
            }
            else if (state == States.WITHDRAWAL)
            {
                amount += 500;
                lblSum.Text = amount + " €";
            }
        }

        private void txtPin_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnKeyboardC_Click(object sender, EventArgs e)
        {
            if (state == States.ENTERPIN)
            {
                txtPin.Text = "";
            }
            else if (state == States.CHANGEPIN || state == States.REENTEROLDPIN)
            {
                txtInput.Text = "";
            }
            if (state == States.WITHDRAWAL)
            {
                amount = 0;
                lblSum.Text = "0 €";
            }
        }

        private void btnKeyboard1_Click(object sender, EventArgs e)
        {
            if (state == States.ENTERPIN && txtPin.TextLength < 4)
            {
                txtPin.Text += 1;
            }
            if ((state == States.CHANGEPIN || state == States.REENTEROLDPIN) && txtInput.TextLength < 4)
            {
                txtInput.Text += 1;
            }
        }

        private void btnKeyboard2_Click(object sender, EventArgs e)
        {
            if (state == States.ENTERPIN && txtPin.TextLength < 4)
            {
                txtPin.Text += 2;
            }
            if ((state == States.CHANGEPIN || state == States.REENTEROLDPIN) && txtInput.TextLength < 4)
            {
                txtInput.Text += 2;
            }
        }

        private void btnKeyboard3_Click(object sender, EventArgs e)
        {
            if (state == States.ENTERPIN && txtPin.TextLength < 4)
            {
                txtPin.Text += 3;
            }
            if ((state == States.CHANGEPIN || state == States.REENTEROLDPIN) && txtInput.TextLength < 4)
            {
                txtInput.Text += 3;
            }
        }

        private void btnKeyboard4_Click(object sender, EventArgs e)
        {
            if (state == States.ENTERPIN && txtPin.TextLength < 4)
            {
                txtPin.Text += 4;
            }
            if ((state == States.CHANGEPIN || state == States.REENTEROLDPIN) && txtInput.TextLength < 4)
            {
                txtInput.Text += 4;
            }
        }

        private void btnKeyboard5_Click(object sender, EventArgs e)
        {
            if (state == States.ENTERPIN && txtPin.TextLength < 4)
            {
                txtPin.Text += 5;
            }
            if ((state == States.CHANGEPIN || state == States.REENTEROLDPIN) && txtInput.TextLength < 4)
            {
                txtInput.Text += 5;
            }
        }

        private void btnKeyboard6_Click(object sender, EventArgs e)
        {
            if (state == States.ENTERPIN && txtPin.TextLength < 4)
            {
                txtPin.Text += 6;
            }
            if ((state == States.CHANGEPIN || state == States.REENTEROLDPIN) && txtInput.TextLength < 4)
            {
                txtInput.Text += 6;
            }
        }

        private void btnKeyboard7_Click(object sender, EventArgs e)
        {
            if (state == States.ENTERPIN && txtPin.TextLength < 4)
            {
                txtPin.Text += 7;
            }
            if ((state == States.CHANGEPIN || state == States.REENTEROLDPIN) && txtInput.TextLength < 4)
            {
                txtInput.Text += 7;
            }
        }

        private void btnKeyboard8_Click(object sender, EventArgs e)
        {
            if (state == States.ENTERPIN && txtPin.TextLength < 4)
            {
                txtPin.Text += 8;
            }
            if ((state == States.CHANGEPIN || state == States.REENTEROLDPIN) && txtInput.TextLength < 4)
            {
                txtInput.Text += 8;
            }
        }

        private void btnKeyboard9_Click(object sender, EventArgs e)
        {
            if (state == States.ENTERPIN && txtPin.TextLength < 4)
            {
                txtPin.Text += 9;
            }
            if ((state == States.CHANGEPIN || state == States.REENTEROLDPIN) && txtInput.TextLength < 4)
            {
                txtInput.Text += 9;
            }
        }

        private void btnKeyboard0_Click(object sender, EventArgs e)
        {
            if (state == States.ENTERPIN && txtPin.TextLength < 4)
            {
                txtPin.Text += 0;
            }
            if ((state == States.CHANGEPIN || state == States.REENTEROLDPIN) && txtInput.TextLength < 4)
            {
                txtInput.Text += 0;
            }
        }

        private void btnKeyboardOK_Click(object sender, EventArgs e)
        {
            if (state == States.ENTERPIN && txtPin.TextLength == 4)
            {
                int loginAttemnts = new Database().getNumOfUnsuccessfullLoginAttemnts(idCard);

                if (new Database().isPinCorrect(Int32.Parse(txtPin.Text), cardNumber) && new Database().isCardBlocked(cardNumber) == false && loginAttemnts < 3)
                {
                    new Database().resetLoginAttemnts(idCard);
                    txtPin.Text = "";
                    changeState(States.PINOK);
                }
                else if (loginAttemnts < 2)
                {
                    txtPin.Text = "";
                    new Database().incorrectPin(idCard);
                }
                else if (loginAttemnts >= 2)
                {
                    new Database().incorrectPin(idCard);
                    disableKeyboard();
                    lblEnterPin.Text = MessagesLang.getMessageBlockedCard(lang);
                }
            }
            else if (state == States.CHANGEPIN && txtP2NewPass.Text == txtP2ReNewPass.Text && txtP2NewPass.TextLength == 4)
            {
                newPin = Int32.Parse(txtP2NewPass.Text);
                changeState(States.REENTEROLDPIN);
            }
            else if (state == States.REENTEROLDPIN && txtP2NewPass.TextLength == 4)
            {
                int loginAttemnts = new Database().getNumOfUnsuccessfullLoginAttemnts(idCard);

                if (new Database().isPinCorrect(Int32.Parse(txtP2NewPass.Text), cardNumber) && new Database().isCardBlocked(cardNumber) == false && loginAttemnts < 3)
                {
                    new Database().resetLoginAttemnts(idCard);
                    if (new Database().changePin(Int32.Parse(txtP2NewPass.Text), newPin, idCard))
                    {
                        txtP2NewPass.Text = "";
                        changeState(States.PINCHANGED);
                    }
                    else
                    {
                        txtP2NewPass.Text = "";
                        changeState(States.PINNOTCHANGED);
                    }
                }
                else if (loginAttemnts < 2)
                {
                    txtPin.Text = "";
                    new Database().incorrectPin(idCard);
                }
                else if (loginAttemnts >= 2)
                {
                    new Database().incorrectPin(idCard);
                    disableKeyboard();
                    changeState(States.CARDBLOCKED);
                }

            }
            else if (state == States.CARDBLOCKED)
            {
                changeState(States.EXIT);
            }
            else if (state == States.PINCHANGED)
            {
                changeState(States.PINOK);
            }
            else if (state == States.PINNOTCHANGED)
            {
                changeState(States.PINOK);
            }
        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void lblMenuMoney_Click(object sender, EventArgs e)
        {

        }

        private void lblMenuPin_Click(object sender, EventArgs e)
        {

        }

        private void lblMenuLanguage_Click(object sender, EventArgs e)
        {

        }

        private void lblMenu_Click(object sender, EventArgs e)
        {

        }

        private void btnRightPanel2_Click(object sender, EventArgs e)
        {
            if (state == States.PINOK)
            {
                lblBalance.Text = new Database().getBalance(idCard) + " €";
                changeState(States.BALANCE);
            }
            else if (state == States.CHANGEPIN)
            {
                txtInput = txtP2NewPass;
            }
            else if (state == States.WITHDRAWAL)
            {
                amount += 100;
                lblSum.Text = amount + " €";
            }
        }

        private void btnRightPanel3_Click(object sender, EventArgs e)
        {
            if (state == States.PINOK)
            {
                changeState(States.CHANGELANGUAGE);
            }
            else if (state == States.CHANGEPIN)
            {
                txtInput = txtP2ReNewPass;
            }
            else if (state == States.LANGUAGE)
            {
                lang = Languages.JPN;
                changeState(States.ENTERPIN);
            }
            else if (state == States.CHANGELANGUAGE)
            {
                lang = Languages.JPN;
                changeState(States.PINOK);
            }
            else if (state == States.WITHDRAWAL)
            {
                amount += 200;
                lblSum.Text = amount + " €";
            }
        }

        private void btnRightPanel1_Click(object sender, EventArgs e)
        {
            changeState(States.EXIT);
        }

        private void label1_Click_2(object sender, EventArgs e)
        {

        }

        private void btnLeftPanel3_Click(object sender, EventArgs e)
        {
            if (state == States.LANGUAGE)
            {
                lang = Languages.DE;
                changeState(States.ENTERPIN);
            }
            else if (state == States.CHANGELANGUAGE)
            {
                lang = Languages.DE;
                changeState(States.PINOK);
            }
            else if (state == States.PINOK)
            {
                changeState(States.CHANGEPIN);
            }
            else if (state == States.WITHDRAWAL)
            {
                amount += 50;
                lblSum.Text = amount + " €";
            }
        }

        private void panelChangePin_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnLeftPanel2_Click(object sender, EventArgs e)
        {
            if (state == States.PINOK)
            {
                changeState(States.WITHDRAWAL);
            }
            else if (state == States.WITHDRAWAL)
            {
                amount += 20;
                lblSum.Text = amount + " €";
            }
        }

        private void panelWithdrowals_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnLeftPanel1_Click(object sender, EventArgs e)
        {
            if (state == States.WITHDRAWAL)
            {
                amount += 10;
                lblSum.Text = amount + " €";
            }
        }
    }
}
