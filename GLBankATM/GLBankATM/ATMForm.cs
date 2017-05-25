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
        LANGUAGE, ENTERPIN, PINOK, BALANCE, CHANGELANGUAGE, EXIT
    }
    public enum Languages
    {
        SVK, ENG, DE
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
        }

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
                default:
                    break;
            }
        }

        void stateExit()
        {
            this.Close();
        }

        void stateLanguage()
        {
            hideLabels();
            disableSideButtons();
            lblLangEnglish.Visible = true;
            lblLangSlovak.Visible = true;
            lblMenuPin.Visible = true;
            lblMenuPin.Text = "Deutsch";
            btnLeftPanel3.Enabled = true;
            btnLeftPanel4.Enabled = true;
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
            if (state == States.BALANCE)
            {
                changeState(States.PINOK);
            }
            if (state == States.CHANGELANGUAGE)
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
            if (state == States.CHANGELANGUAGE)
            {
                lang = Languages.ENG;
                changeState(States.PINOK);
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
        }

        private void btnKeyboard1_Click(object sender, EventArgs e)
        {
            if (state == States.ENTERPIN && txtPin.TextLength < 4)
            {
                txtPin.Text += 1;
            }
        }

        private void btnKeyboard2_Click(object sender, EventArgs e)
        {
            if (state == States.ENTERPIN && txtPin.TextLength < 4)
            {
                txtPin.Text += 2;
            }
        }

        private void btnKeyboard3_Click(object sender, EventArgs e)
        {
            if (state == States.ENTERPIN && txtPin.TextLength < 4)
            {
                txtPin.Text += 3;
            }
        }

        private void btnKeyboard4_Click(object sender, EventArgs e)
        {
            if (state == States.ENTERPIN && txtPin.TextLength < 4)
            {
                txtPin.Text += 4;
            }
        }

        private void btnKeyboard5_Click(object sender, EventArgs e)
        {
            if (state == States.ENTERPIN && txtPin.TextLength < 4)
            {
                txtPin.Text += 5;
            }
        }

        private void btnKeyboard6_Click(object sender, EventArgs e)
        {
            if (state == States.ENTERPIN && txtPin.TextLength < 4)
            {
                txtPin.Text += 6;
            }
        }

        private void btnKeyboard7_Click(object sender, EventArgs e)
        {
            if (state == States.ENTERPIN && txtPin.TextLength < 4)
            {
                txtPin.Text += 7;
            }
        }

        private void btnKeyboard8_Click(object sender, EventArgs e)
        {
            if (state == States.ENTERPIN && txtPin.TextLength < 4)
            {
                txtPin.Text += 8;
            }
        }

        private void btnKeyboard9_Click(object sender, EventArgs e)
        {
            if (state == States.ENTERPIN && txtPin.TextLength < 4)
            {
                txtPin.Text += 9;
            }
        }

        private void btnKeyboard0_Click(object sender, EventArgs e)
        {
            if (state == States.ENTERPIN && txtPin.TextLength < 4)
            {
                txtPin.Text += 0;
            }
        }

        private void btnKeyboardOK_Click(object sender, EventArgs e)
        {
            if (state == States.ENTERPIN && txtPin.TextLength == 4)
            {
                int loginAttemnts = new Database().getNumOfUnsuccessfullLoginAttemnts(idCard);

                if (new Database().isPinCorrect(Int32.Parse(txtPin.Text), cardNumber) && loginAttemnts < 3)
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
                    disableKeyboard();
                    lblEnterPin.Text = MessagesLang.getMessageBlockedCard(lang);
                }
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
        }

        private void btnRightPanel3_Click(object sender, EventArgs e)
        {
            if (state == States.PINOK)
            {
                changeState(States.CHANGELANGUAGE);
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
            if (state == States.CHANGELANGUAGE)
            {
                lang = Languages.DE;
                changeState(States.PINOK);
            }
        }
    }
}
