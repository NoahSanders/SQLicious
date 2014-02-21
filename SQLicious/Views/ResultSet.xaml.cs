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

using System.Dynamic;

using SQLicious.ViewModels;
using System.Collections.ObjectModel;

namespace SQLicious.Views
{
    /// <summary>
    /// Interaction logic for ResultSet.xaml
    /// </summary>
    public partial class ResultSet : UserControl
    {
        public ResultSet()
        {   
            // mvvm bullshit
            ResultSetVM vm = new ResultSetVM("SELECT * FROM Sample.Person");
            this.DataContext = vm;
            //ResultSetGrid.ItemsSource = vm.Results.DefaultView;
            InitializeComponent();
        }

        public void UpdateResultSet(string sqlQuery)
        {
            // mvvm bullshit
            ResultSetVM vm = new ResultSetVM(sqlQuery);
            this.DataContext = vm;

            //probably need an event handler for the data context change... or something
        }
    }
}
