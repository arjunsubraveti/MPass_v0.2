using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class MulakatUK : Form
    {
        public MulakatUK()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            GPass frm = new GPass();
            frm.Show();
            this.Hide();
            frm.FormClosed += new FormClosedEventHandler(frm_Closed);
        }

        private void frm_Closed(object sender, FormClosedEventArgs e)
        {
            this.Close();
        }
    }
}
