using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Data;
using MySql.Data.MySqlClient;

namespace Hospital_Management
{
    /// <summary>
    /// Interaction logic for Doctor_Information.xaml
    /// </summary>
    public partial class Doctor_Information : Window
    {

        MySqlConnection connection = new MySqlConnection("datasource=localhost;port=3306;username=root;password=;");
        MySqlCommand command;

        public Doctor_Information()
        {
            InitializeComponent();
        }

        public void openConnection()
        {
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }
        }
        public void closeConnection()
        {
            if (connection.State == ConnectionState.Open)
            {
                connection.Close();
            }
        }
        public void executeQuery(String query)
        {
            try
            {
                openConnection();
                command = new MySqlCommand(query, connection);
                if (command.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("Query Executed");

                }
                else
                {
                    MessageBox.Show("Query Not Executed");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                closeConnection();
            }
        }

      

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string insertQuery = "INSERT INTO hospital_management.doctor_information(Id,Name,Age,Gender,Phone,Address) VALUES('" + textBox.Text + "' , '" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','"+textBox4.Text + "','"+textBox5.Text + "')";
            executeQuery(insertQuery);

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

            this.Hide();
            Menu m = new Menu();
            m.Show();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            string updateQuery = "UPDATE hospital_management.doctor_information SET Name='" + textBox1.Text + "',Age=" + textBox2.Text + ",Gender='" + textBox3.Text + "',Phone='"+textBox4.Text + "',Address='"+textBox5.Text + "' WHERE Id=" + textBox.Text;
            executeQuery(updateQuery);
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            string deleteQuery = "DELETE FROM hospital_management.doctor_information WHERE Id=" + textBox.Text;
            executeQuery(deleteQuery);
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            this.Hide();
            Doctor_List dl = new Doctor_List();
            dl.Show();


        }
    }
}
