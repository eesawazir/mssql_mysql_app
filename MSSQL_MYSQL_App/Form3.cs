using MySql.Data.MySqlClient;
using System;
using System.Collections;
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
            // Declare Form1 to access connection methods defined there
            Form1 form1 = new Form1();

            using (SqlConnection MssqlConnection = new SqlConnection(form1.ConnectionStrMssql()))
            {
                MssqlConnection.Open();

                var mssqlDb = GetMssqlDb();
                var mysqlDb = GetMysqlDb();

                foreach (string pKey in mssqlDb)
                {
                    if (!mysqlDb.ContainsKey(pKey))
                    {

                        string MssqlQuery = "SELECT * FROM Person WHERE Id='" + pKey + "'";

                        using (var mCommand = new SqlCommand(MssqlQuery, MssqlConnection))
                        {
                            using (var mReader = mCommand.ExecuteReader())
                            {
                                while (mReader.Read())
                                {
                                    var record = new Dictionary<string, string>();
                                    for (int i = 0, size = mReader.FieldCount; i < size; i++)
                                    {
                                        var key = mReader.GetName(i);
                                        record[key] = mReader[key].ToString();
                                    }

                                    MySqlConnection MysqlConnection = new MySqlConnection(form1.ConnectionStrMysql());
                                    MysqlConnection.Open();
                                    // Add data to MySQL DB
                                    string query = string.Format("INSERT INTO person_mysql_db.person_table (Id,Name,Age,Address) " +
                                        "VALUES('{0}','{1}', {2},'{3}')", record["Id"], record["Name"].Replace("'", "''"), record["Age"], record["Address"].Replace("'", "''"));

                                    System.Diagnostics.Debug.WriteLine(query + "\n" + form1.ConnectionStrMysql());
                                    MySqlCommand command = new MySqlCommand(query, MysqlConnection);
                                    command.ExecuteNonQuery();
                                    MysqlConnection.Close();
                                }

                            }
                        }
                    }
                }
                MssqlConnection.Close();
            }
            closeCurrentFormOpenFormTwo();
        }

        private List<string> GetMssqlDb()
        {
            // Declare Form1 to access connection methods defined there
            Form1 form1 = new Form1();

            var mssqlResult = new List<string>();

            using (SqlConnection MssqlConnection = new SqlConnection(form1.ConnectionStrMssql()))
            {
                // Get id's from Mysql
                string MssqlQuery = "SELECT Id FROM Person";

                MssqlConnection.Open();

                using (var mCommand = new SqlCommand(MssqlQuery, MssqlConnection))
                {
                    using (var mReader = mCommand.ExecuteReader())
                    {
                        while (mReader.Read())
                        {
                            var pKey = mReader["Id"].ToString();
                            mssqlResult.Add(pKey);
                        }

                        mReader.Close();
                    }

                    mCommand.Dispose();
                }

                MssqlConnection.Close();
                MssqlConnection.Dispose();

                return mssqlResult;
            }
        }

        private Dictionary<string, string> GetMysqlDb()
        {
            // Declare Form1 to access connection methods defined there
            Form1 form1 = new Form1();

            var mysqlResult = new Dictionary<string, string>();

            using (MySqlConnection MysqlConnection = new MySqlConnection(form1.ConnectionStrMysql()))
            {
                // Get id's from Mysql
                string MysqlQuery = "select Id from person_mysql_db.person_table;";

                MysqlConnection.Open();

                using (var mCommand = new MySqlCommand(MysqlQuery, MysqlConnection))
                {
                    using (var mReader = mCommand.ExecuteReader())
                    {
                        while (mReader.Read())
                        {
                            var map = new Dictionary<string, string>();

                            var pKey = mReader["Id"].ToString();
                            mysqlResult[pKey] = "1";
                        }

                        mReader.Close();
                    }

                    mCommand.Dispose();
                }

                MysqlConnection.Close();
                MysqlConnection.Dispose();

                return mysqlResult;
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
