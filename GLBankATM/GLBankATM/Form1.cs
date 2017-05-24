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
            //Console.Write("dfsfsd");
            long id;

            if (long.TryParse(idcard, out id))
            {
                if (new Database().existCard(id) && new Database().isCardBlocked(id)==false)
                {
                    ATMForm formAtm = new ATMForm(id);
                    formAtm.Show();
                    this.Hide();
                }
                else
                {
                    Console.Write("Card doesn't exists!");
                }
            }
        }
    }
}
