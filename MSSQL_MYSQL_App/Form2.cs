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
            string name = nameTextBox.Text;
            int age = int.Parse(ageTextBox.Text);
            string address = addressTextBox.Text;
            Guid id = Guid.NewGuid();

            string connection_string = @"Data Source=DESKTOP-81FNLHJ\SQLEXPRESS;Initial Catalog=PersonDb;Integrated Security=True";
            SqlConnection connection = new SqlConnection(connection_string);
            connection.Open();

            string query = "INSERT INTO Person (Id,Name,Age,Address) VALUES('" + id + "','" + name + "','" + age + "','" + address + "';";
            SqlCommand command = new SqlCommand(query, connection);
            command.ExecuteNonQuery();

            ageTextBox.Text = "";
            nameTextBox.Text = "";
            addressTextBox.Text = "";

            this.Hide();
            Form3 newForm3 = new Form3();
            newForm3.ShowDialog();
            this.Close();

        }
    }
}
