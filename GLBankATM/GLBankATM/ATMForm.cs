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
        public ATMForm()
        {
            InitializeComponent();
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
    }
}
