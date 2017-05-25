using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace GLBankATM
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.CenterToScreen();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            String idcard = txtCardNumber.Text;
            long cardNumber;

            if (long.TryParse(idcard, out cardNumber))
            {
                int? idCard = new Database().existCard(cardNumber);
                if (idCard != null && new Database().isCardBlocked(cardNumber) == false)
                {
                    txtCardNumber.Text = "";
                    this.Hide();
                    ATMForm formAtm = new ATMForm(cardNumber, idCard.Value);
                    formAtm.ShowDialog();
                    this.Show();
                }
                else
                {
                    Console.Write("Card doesn't exists!");
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            txtCardNumber.Text = "";
        }
    }
}
