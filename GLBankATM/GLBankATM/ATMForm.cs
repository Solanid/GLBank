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
        LANGUAGE, ENTERPIN, PINOK, PINWRONG, INVALIDCARD
    }
    public enum Languages
    {
        SVK, ENG
    }

    public partial class ATMForm : Form
    {
        public ATMForm(long id)
        {
            InitializeComponent();
            stateLanguage();
        }

        private void panelATM_Paint(object sender, PaintEventArgs e)
        {
            States state = new States();
            switch (state)
            {
                case States.LANGUAGE:
                    break;
                case States.ENTERPIN:
                    break;
                case States.PINOK:
                    break;
                case States.PINWRONG:
                    break;
                case States.INVALIDCARD:
                    break;
                default:
                    break;
            }
            if (state == States.ENTERPIN)
            {
                if (true)
                {

                }
            }
        }

        void stateLanguage()
        {
            btnLeftPanel1.Enabled = false;
            btnLeftPanel2.Enabled = false;
            btnLeftPanel3.Enabled = false;
            btnLeftPanel4.Enabled = true;
            btnRightPanel1.Enabled = false;
            btnRightPanel2.Enabled = false;
            btnRightPanel3.Enabled = false;
            btnRightPanel4.Enabled = true;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnLeftPanel4_Click(object sender, EventArgs e)
        {

        }
    }
}
