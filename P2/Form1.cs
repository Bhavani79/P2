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
          
            
            string connectionString = "Data Source=BHAVANI\\SQLEXPRESS01;Initial Catalog=p2;Integrated Security=SSPI;";
            SqlConnection connection = new SqlConnection(connectionString);

            connection.Open();

            string value1 = textBox1.Text;
            string value2 = textBox2.Text;
            string value3 = textBox3.Text;

            string query = "INSERT INTO p2 (Name, ID, Attendance) VALUES (@Value1, @Value2, @Value3)";
           
            using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Value1", value1);
                    command.Parameters.AddWithValue("@Value2", value2);
                    command.Parameters.AddWithValue("@Value3", value3);
                    command.ExecuteNonQuery();
                }
            

            // Optional: Display a success message or perform any additional actions
            MessageBox.Show("Data saved to the database.");

            textBox1.Text = string.Empty;
            textBox2.Text = string.Empty;
            textBox3.Text = string.Empty;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
