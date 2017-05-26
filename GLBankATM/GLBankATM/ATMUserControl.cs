using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GLBankATM
{
    public partial class ATMUserControl : UserControl
    {
        public ATMUserControl()
        {
            InitializeComponent();
        }

        public void setLabels(string str)
        {
            lblSkuska.Text = str;
        }

        private void lblSkuska_Click(object sender, EventArgs e)
        {

        }
    }
}
