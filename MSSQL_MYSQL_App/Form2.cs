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
    public partial class Form2 : Form
    {

        public Form2()
        {
            InitializeComponent();
        }

        private void submitButton_Click(object sender, EventArgs e)
        {
            string age = ageTextBox.Text;
            bool isAgeNumeric = int.TryParse(age, out _);

            if (!isAgeNumeric || String.IsNullOrEmpty(age))
            {
                errorProvider1.SetError(ageTextBox, "Age needs to be number");
                return;
            }
            else
            {
                if (String.IsNullOrEmpty(nameTextBox.Text))
                {
                    errorProvider2.SetError(nameTextBox, "Name can not be empty");
                    return;
                }
                string name = nameTextBox.Text;
                name = name.Replace("'", "''");

                if (String.IsNullOrEmpty(addressTextBox.Text))
                {
                    errorProvider3.SetError(addressTextBox, "Address can not be empty");
                    return;
                }
                string address = addressTextBox.Text;
                address = address.Replace("'", "''");

                Guid id = Guid.NewGuid();

                // Open connection to sql server
                Form1 form1 = new Form1();
                using (SqlConnection connection = new SqlConnection(form1.ConnectionStrMssql()))
                {
                    System.Diagnostics.Debug.WriteLine(name + "|" + age + "|" + address);
                    // Open connection to MSSQL DB
                    connection.Open();

                    // Add data to MSSQL DB
                    string query = string.Format("INSERT INTO Person (Id,Name,Age,Address) " +
                        "VALUES('{0}','{1}', {2},'{3}')", id, name, age, address);
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
}
