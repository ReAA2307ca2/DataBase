using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Net;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Data.SqlClient;

namespace Database
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ObservableCollection<string> listofObj = new ObservableCollection<string>();
        public ObservableCollection<string> ListofObj
        {
            get { return listofObj; }
            set 
            { 
                listofObj = value;
                OnPropertyChanged("ListofObj");
            }
        }

        public List<Object> listRaw = new List<Object>();
        public List<Object> ListOfTables = new List<Object>();

        
        public MainWindow()
        {
            InitializeComponent();

            DataContext = this;
            string connectionString = @"Data Source=DBSRV\vip2024;Initial Catalog=ReAA;Integrated Security=True;Encrypt=True;Trust Server Certificate=True;Multi Subnet Failover=False";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT TABLE_SCHEMA + '.' + TABLE_NAME AS FullTableName " +
                               "FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_TYPE = 'BASE TABLE';";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Execute the query and read the results
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        listofObj.Add(reader["FullTableName"].ToString());
                        listRaw.Add(reader["FullTableName"]);
                    }

                    lb_Objs.Items.Refresh();
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

        private void lb_Objs_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            object selectedTable = lb_Objs.SelectedItem;
            foreach (object obj in listRaw)
            {
                if (selectedTable == obj)
                {
                    
                    MessageBox.Show("Ты пиджор");
                }
            }
        }
    }
}