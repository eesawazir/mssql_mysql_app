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


            // Open connection to sql server
            using (SqlConnection sqlConnection = new SqlConnection(ConnectionStrMssql(mssqlUsername, mssqlPassword)))
            {
                try
                {
                    sqlConnection.Open();
                }
                catch
                {
                    MessageBox.Show("Incorrect MSSQL UserID and Password", "MSSQL Configuratioon", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    mssqlUsernameTextBox.Text = "";
                    mssqlPasswordTextBox.Text = "";
                }
                finally
                {
                    sqlConnection.Close();
                }
            }

            // Connect to MySQL DB using user inputs
            string mysqlUsername = mysqlUsernameTextBox.Text;
            string mysqlPassword = mysqlPasswordTextBox.Text;

            
            using (MySqlConnection mysqlConnection = new MySqlConnection(ConnectionStrMysql(mysqlUsername, mysqlPassword)))
            {
                try
                {
                    mysqlConnection.Open();

                    string FilePath = @"C:/Users/Eesa/Desktop/EasySales%20Internship/Projects/MSSQL_MYSQL_App/MSSQL_MYSQL_App/ConfigData.txt";
                    File.WriteAllText(FilePath, mssqlUsername);
                    File.WriteAllText(FilePath, mssqlPassword);
                    File.WriteAllText(FilePath, mysqlUsername);
                    File.WriteAllText(FilePath, mysqlUsername);

                    // Hide DB config form and show data entry form
                    this.Hide();
                    Form2 newForm2 = new Form2();
                    newForm2.ShowDialog();
                    this.Close();
                }
                catch
                {
                    MessageBox.Show("Incorrect MySQL UserID and Password", "MySQL Configuratioon", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    mysqlUsernameTextBox.Text = "";
                    mysqlPasswordTextBox.Text = "";
                }
                finally
                {
                    mysqlConnection.Close();
                }

            }
            
        }

        public string ConnectionStrMssql(string username, string password)
        {
            // Build the connection string using SqlConnectionStringBuilder
            SqlConnectionStringBuilder connectionStrBuilder = new SqlConnectionStringBuilder();
            connectionStrBuilder.DataSource = "DESKTOP-81FNLHJ\\SQLEXPRESS";
            connectionStrBuilder.InitialCatalog = "PersonDb";
            connectionStrBuilder.IntegratedSecurity = false;
            connectionStrBuilder.UserID = username;
            connectionStrBuilder.Password = password;

            return connectionStrBuilder.ToString();
        }

        public string ConnectionStrMysql(string username, string password)
        {
            // Required strings for MySQL connection string
            string server = "127.0.0.1";
            string database = "person_mysql_db";
            //string server = "easyecosystem.com";
            //string database = "easyicec_testing";
            //string username = "easyicec_testing";
            //string password = "easyicec_testing123@";

            //string connectionString = "SERVER=" + server + ";" + "DATABASE=" + database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";

            var connection =
                string.Format("Server={0}; database={1}; UID={2}; password={3}; Pooling=false;",
                    server, database, username, password);

            return connection;
        }
    }
}
