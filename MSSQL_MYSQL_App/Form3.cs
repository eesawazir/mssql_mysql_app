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

            // Declare Form1 to access connection methods defined there
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
                    string[] MssqlIdArray = MssqlCommand.ExecuteNonQuery(); // Figure out how to execute a SQL command and getting an array of MSSQL id's

                    // Get id's from Mysql
                    string MysqlQuery = "SELECT Id FROM person_table";
                    MySqlCommand MysqlCommand = new MySqlCommand(MysqlQuery, MysqlConnection);
                    string[] MysqlIdArray = MysqlCommand.ExecuteNonQuery(); // Figure out how to execute a SQL command and getting an array of MySQL id's

                    // Keep MSSQl id's which do not exist in MySQL
                    var MssqlUniqueIdOnly = MssqlIdArray.Except(MysqlIdArray).ToArray();

                    for (int i = 0; i < MssqlUniqueIdOnly.Length; i++)
                    {
                        // Get record from Mysql with id from MssqlIdOnly array
                        string MysqlGetRecordQuery = string.Format("SELECT Id FROM person_table WHERE Id='{0}'", MssqlUniqueIdOnly[i]);
                        SqlCommand MssqlGetRecordCommand = new SqlCommand(MysqlGetRecordQuery, MssqlConnection);
                        string[] MssqlRecordArray = MssqlGetRecordCommand.ExecuteNonQuery(); // Figure out how to get record in an array data structure

                        // Add data to MySQL DB
                        string MysqlAddRecordQuery = string.Format("INSERT INTO person_table (Id,Name,Age,Address) VALUES('{0}','{1}',{2},'{3}')", MssqlRecordArray[0], MssqlRecordArray[1], MssqlRecordArray[2], MssqlRecordArray[3]);
                        MySqlCommand MysqlAddRecordCommand = new MySqlCommand(MysqlAddRecordQuery, MysqlConnection);
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
