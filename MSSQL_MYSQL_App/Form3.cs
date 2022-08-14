using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
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
            string FilePath = @"C:/Users/Eesa/Desktop/EasySales%20Internship/Projects/MSSQL_MYSQL_App/MSSQL_MYSQL_App/ConfigData.txt";
            var ConfigData = File.ReadAllLines(FilePath);
            var ConfigList = new List<string>(ConfigData);

            // Connect to MSSQL DB using user inputs
            string mssqlUsername = ConfigList[0];
            string mssqlPassword = ConfigList[1];

            // Open connection to sql server
            Form1 form1 = new Form1();
            using (SqlConnection connection = new SqlConnection(form1.ConnectionStrMssql(mssqlUsername, mssqlPassword)))
            {

                // Connect to MySQL DB using user inputs
                string mysqlUsername = ConfigList[2];
                string mysqlPassword = ConfigList[3];

                using (MySqlConnection mysqlConnection = new MySqlConnection(form1.ConnectionStrMysql(mysqlUsername, mysqlPassword)))
                {

                }
                closeCurrentFormOpenFormTwo();
            }
        }

        private void cancelSyncButton_Click(object sender, EventArgs e)
        {
            closeCurrentFormOpenFormTwo();
        }

        private void closeCurrentFormOpenFormTwo()
        {
            // Hide confirm sync form and show data entry form
            this.Hide();
            Form2 newForm2 = new Form2();
            newForm2.ShowDialog();
            this.Close();
        }
    }
}
