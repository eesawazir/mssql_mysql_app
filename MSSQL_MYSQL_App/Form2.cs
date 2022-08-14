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

            // Not complete. Have to figure out how to to use inputs from Form1 here
            // Open connection to MSSQL DB
            string mssql_connection_string = @"Data Source=DESKTOP-81FNLHJ\SQLEXPRESS;Initial Catalog=PersonDb;Integrated Security=True";
            SqlConnection connection = new SqlConnection(mssql_connection_string);
            connection.Open();

            // Add data to MSSQL DB
            string query = "INSERT INTO Person (Id,Name,Age,Address) VALUES('" + id + "','" + name + "','" + age + "','" + address + "';";
            SqlCommand command = new SqlCommand(query, connection);
            command.ExecuteNonQuery();

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
