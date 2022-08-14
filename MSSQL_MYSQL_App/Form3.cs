using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MSSQL_MYSQL_App
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void confirmSyncButton_Click(object sender, EventArgs e)
        {
            // Code to Sync DB's records goes here

            closeCurrentFormOpenFormTwo();
        }

        private void cancelSyncButton_Click(object sender, EventArgs e)
        {
            closeCurrentFormOpenFormTwo();
        }

        private void closeCurrentFormOpenFormTwo()
        {
            this.Hide();
            Form2 newForm2 = new Form2();
            newForm2.ShowDialog();
            this.Close();
        }
    }
}
