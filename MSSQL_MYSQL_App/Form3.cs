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
            string MssqlUsername = ConfigList[0];
            string MssqlPassword = ConfigList[1];

            // Open connection to sql server
            Form1 form1 = new Form1();
            using (SqlConnection MssqlConnection = new SqlConnection(form1.ConnectionStrMssql(MssqlUsername, MssqlPassword)))
            {

                // Connect to MySQL DB using user inputs
                string MysqlUsername = ConfigList[2];
                string MysqlPassword = ConfigList[3];

                using (MySqlConnection MysqlConnection = new MySqlConnection(form1.ConnectionStrMysql(MysqlUsername, MysqlPassword)))
                {
                    // Open connection to MSSQL DB
                    MssqlConnection.Open();

                    // Get id's from Mssql
                    string MssqlQuery = "SELECT Id FROM Person";
                    SqlCommand MssqlCommand = new SqlCommand(MssqlQuery, MssqlConnection);
                    string[] MssqlIdArray = MssqlCommand.ExecuteNonQuery();

                    // Get id's from Mysql
                    string MysqlQuery = "SELECT Id FROM person_table";
                    MySqlCommand MysqlCommand = new MySqlCommand(MysqlQuery, MysqlConnection);
                    string[] MysqlIdArray = MysqlCommand.ExecuteNonQuery();

                    // Keep id's which do not exist in MySQL
                    var MssqlUniqueIdOnly = MssqlIdArray.Except(MysqlIdArray).ToArray;

                    for (int i = 0; i < MssqlUniqueIdOnly.length; i++)
                    {
                        // Get record from Mysql with id from MssqlIdOnly array
                        string MysqlGetRecordQuery = "SELECT Id FROM person_table WHERE Id='" + MssqlUniqueIdOnly[i] + "'";
                        SqlCommand MssqlGetRecordCommand = new SqlCommand(MysqlGetRecordQuery, MssqlConnection);
                        string[] MssqlRecordArray = MssqlGetRecordCommand.ExecuteNonQuery();

                        // Add data to MySQL DB
                        string query = "INSERT INTO person_table (Id,Name,Age,Address) " +
                            "VALUES('" + MssqlRecordArray[0] + "','" + MssqlRecordArray[1] + "','" + 
                            MssqlRecordArray[2] + "','" + MssqlRecordArray[3] + "')";
                        MySqlCommand MysqlAddRecordCommand = new MySqlCommand(query, MysqlConnection);
                        MysqlAddRecordCommand.ExecuteNonQuery();
                    }

                    MssqlConnection.Close();
                    MysqlConnection.Close();
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
