using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MSSQL_MYSQL_App
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void configDbButton_Click(object sender, EventArgs e)
        {
            // Connect to MSSQL DB using user inputs
            string mssqlUsername = mssqlUsernameTextBox.Text;
            string mssqlPassword = mssqlPasswordTextBox.Text;

            // Build the connection string using SqlConnectionStringBuilder
            SqlConnectionStringBuilder connectionStrBuilder = new SqlConnectionStringBuilder();
            connectionStrBuilder.DataSource = "DESKTOP-81FNLHJ\\SQLEXPRESS";
            connectionStrBuilder.InitialCatalog = "PersonDb";
            connectionStrBuilder.IntegratedSecurity = false;
            connectionStrBuilder.UserID = mssqlUsername;
            connectionStrBuilder.Password = mssqlPassword;

            // Open connection to sql server
            using (SqlConnection sqlConnection = new SqlConnection(connectionStrBuilder.ToString()))
            {
                sqlConnection.Open();
            }

            // Connect to MSSQL DB using user inputs
            string mysqlUsername = mysqlUsernameTextBox.Text;
            string mysqlPassword = mysqlPasswordTextBox.Text;

            // Required strings for MySQL connection string
            string server = "localhost:3306";
            string database = "person_mysql_db";
            string uid = mysqlUsername;
            string password = mysqlPassword;

            string connectionString = "SERVER=" + server + ";" + "DATABASE=" + database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";

            MySqlConnection mysqlConnection = new MySqlConnection(connectionString);

            // Hide DB config form and show data entry form
            this.Hide();
            Form2 newForm2 = new Form2();
            newForm2.ShowDialog();
            this.Close();
        }
    }
}
