using InterSystems.Data.CacheClient;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SQLicious
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public CacheConnection connection;

        public MainWindow()
        {
            // connect to database (default for now, takes place at startup)
            connection = new CacheConnection();
            connection.ConnectionString = "Server = localhost;Port = 1972;Namespace=SAMPLES;Password=v00d00; User ID=cacheusr";
            connection.Open();

            InitializeComponent();           
        }
    }
}
