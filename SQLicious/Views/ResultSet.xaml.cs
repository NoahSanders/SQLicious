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
            ResultSetVM vm = new ResultSetVM();
            this.DataContext = vm;

            InitializeComponent();

            foreach (string columnName in vm.Results.Columns)
            {
               var column = new DataGridTextColumn();
               column.Header = columnName;
               ResultSetGrid.Columns.Add(column);
            }

            foreach (var row in vm.Results.Rows)
            {
                //need to figure out best way to bind rows
            }
        }
    }
}
