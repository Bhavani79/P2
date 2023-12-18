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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace P2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string connectionString = "Data Source=BHAVANI\\SQLEXPRESS01;Initial Catalog=p2;Integrated Security=True";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    textBox4.Text = "CONNECTION ESTABLISHED";
                    //  Form existingForm = new Form();
                    //  existingForm.Show();
                }
                catch (SqlException ex)
                {

                    Console.WriteLine("Database connection error: " + ex.Message);
                }
                connection.Close();
            }

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string connectionString = "Data Source=BHAVANI\\SQLEXPRESS01;Initial Catalog=p2;Integrated Security=True;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string value1 = textBox1.Text;
                string value2 = textBox2.Text;
                string value3 = textBox3.Text;
                string value4 = textBox5.Text; // Add TextBox 5
                string value5 = textBox6.Text; // Add TextBox 6
                string value6 = textBox7.Text; // Add TextBox 7

                string query = "INSERT INTO p2 (Name, ID, Attendance, Marks_1, Marks_2, Marks_3) " +
                               "VALUES (@Value1, @Value2, @Value3, @Value4, @Value5, @Value6)";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Value1", value1);
                    command.Parameters.AddWithValue("@Value2", value2);
                    command.Parameters.AddWithValue("@Value3", value3);
                    command.Parameters.AddWithValue("@Value4", value4);
                    command.Parameters.AddWithValue("@Value5", value5);
                    command.Parameters.AddWithValue("@Value6", value6);
                    command.ExecuteNonQuery();
                }

                // Optional: Display a success message or perform any additional actions
                MessageBox.Show("Data saved to the database.");

                textBox1.Text = string.Empty;
                textBox2.Text = string.Empty;
                textBox3.Text = string.Empty;
                textBox5.Text = string.Empty; // Clear TextBox 5
                textBox6.Text = string.Empty; // Clear TextBox 6
                textBox7.Text = string.Empty; // Clear TextBox 7
            }
        }
    }
}
