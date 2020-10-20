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
    /// Interaction logic for Doctor_List.xaml
    /// </summary>
    public partial class Doctor_List : Window
    {
        public Doctor_List()
        {
            InitializeComponent();
            LoadDataIntoDataGridView();

        }
        
                private void LoadDataIntoDataGridView()
                {


                    string MyConString =

                        "SERVER=localhost;" +
                        "DATABASE=hospital_management;" +
                        "UID=root;" +
                        "PASSWORD=;";

          //  string SearchId="1";
        
                    string sql = "SELECT * FROM doctor_information";
           // string sql1 = "SELECT * FROM doctor_information Where Id= " + SearchId + ";";

            using (MySqlConnection connection = new MySqlConnection(MyConString))
                        {
                            connection.Open();
                            using (MySqlCommand cmdSel = new MySqlCommand(sql, connection))
                            {
                                DataTable dt = new DataTable();
                                MySqlDataAdapter da = new MySqlDataAdapter(cmdSel);
                                da.Fill(dt);
                    //DataGridView.DataContext = dt;
                    DataGridView.ItemsSource = dt.DefaultView;
                            }
                            connection.Close();
                        }
                    }
                

        

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            Doctor_Information d = new Doctor_Information();
            d.Show();
        }

        private void DataGridView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
