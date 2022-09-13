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
            // MSSQL DB using user inputs
            string mssqlUsername = mssqlUsernameTextBox.Text;
            string mssqlPassword = mssqlPasswordTextBox.Text;

            // MySQL DB using user inputs
            string mysqlUsername = mysqlUsernameTextBox.Text;
            string mysqlPassword = mysqlPasswordTextBox.Text;

            string FilePath = @"C:\Users\Eesa\Desktop\EasySales Internship\Projects\MSSQL_MYSQL_App\MSSQL_MYSQL_App\ConfigData.txt";
            string[] config = new string[] { mssqlUsername, mssqlPassword, mysqlUsername, mysqlPassword };

            using (StreamWriter sw = new StreamWriter(FilePath))
            {

                foreach (string s in config)
                {
                    sw.WriteLine(s);
                }
            }

            // Connect to MSSQL DB using user inputs
            // Open connection to sql server
            using (SqlConnection sqlConnection = new SqlConnection(ConnectionStrMssql()))
            {
                try
                {
                    //System.Diagnostics.Debug.WriteLine(ConnectionStrMssql());
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
            //System.Diagnostics.Debug.WriteLine(ConnectionStrMysql());
            MySqlConnection mysqlConnection = new MySqlConnection(ConnectionStrMysql());
            using (mysqlConnection)
            {
                try
                {
                    mysqlConnection.Open();

                    // Hide DB config form and show data entry form
                    this.Hide();
                    Form2 newForm2 = new Form2();
                    newForm2.ShowDialog();
                    this.Close();
                }
                catch(MySqlException ex)
                {
                    MessageBox.Show($"{ex.Message}", "MySQL Configuratioon", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    mysqlUsernameTextBox.Text = "";
                    mysqlPasswordTextBox.Text = "";
                }
                finally
                {
                    mysqlConnection.Close();
                }

            }
            
        }

        public string ConnectionStrMssql()
        {
            var configData = getConfigData();

            // Build the connection string using SqlConnectionStringBuilder
            SqlConnectionStringBuilder connectionStrBuilder = new SqlConnectionStringBuilder();
            connectionStrBuilder.PersistSecurityInfo = true;
            connectionStrBuilder.DataSource = "DESKTOP-81FNLHJ\\SQLEXPRESS";
            connectionStrBuilder.InitialCatalog = "PersonDb";
            connectionStrBuilder.IntegratedSecurity = false;
            connectionStrBuilder.UserID = "newUser"; // configData[0]; // "newUser";
            connectionStrBuilder.Password = "abcd.1234";  // configData[1]; // "abcd.1234";

            return connectionStrBuilder.ToString();
        }

        public string ConnectionStrMysql()
        {

            var configData = getConfigData();

            // Required strings for MySQL connection string
            string server = "localhost";
            string database = "person_mysql_db";
            string username = "root"; // configData[2]; //
            string password = "abcd.1234"; // configData[3]; // 
            //string server = "easyecosystem.com";
            //string database = "easyicec_testing";
            //string username = "easyicec_testing";
            //string password = "easyicec_testing123@";

            var connection =                                             // password missing if not here
                string.Format("Server={0}; database={1}; UID={2}; pwd={3}; Persist Security Info=true; Pooling=false; SslMode=None;",
                    server, database, username, password);

            return connection;
        }

        private List<string> getConfigData()
        {
            // Code to Sync DB's records goes here
            string FilePath = @"C:\Users\Eesa\Desktop\EasySales Internship\Projects\MSSQL_MYSQL_App\MSSQL_MYSQL_App\ConfigData.txt";
            var ConfigList = new List<string>();

            using (StreamReader sr = new StreamReader(FilePath))
            {
                string line;

                while ((line = sr.ReadLine()) != null)
                {
                    ConfigList.Add(line);
                }
            }

            return ConfigList;
        }
    }
}
