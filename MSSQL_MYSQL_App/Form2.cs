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
    public partial class Form2 : Form
    {

        public Form2()
        {
            InitializeComponent();
        }

        private void submitButton_Click(object sender, EventArgs e)
        {
            // Get data from text field and generate id (primary key)
            string name = nameTextBox.Text;
            int age = int.Parse(ageTextBox.Text);
            string address = addressTextBox.Text;
            Guid id = Guid.NewGuid();

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
                // Open connection to MSSQL DB
                connection.Open();

                // Add data to MSSQL DB
                string query = "INSERT INTO Person (Id,Name,Age,Address) VALUES('" + id + "','" + name + "','" + age + "','" + address + "')";
                SqlCommand command = new SqlCommand(query, connection);
                command.ExecuteNonQuery();

                connection.Close();
            }

            ageTextBox.Text = "";
            nameTextBox.Text = "";
            addressTextBox.Text = "";

            // Hide data entry form and show confirm sync form
            this.Hide();
            Form3 newForm3 = new Form3();
            newForm3.ShowDialog();
            this.Close();
        }
    }
}
