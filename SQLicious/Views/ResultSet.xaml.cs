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
            ResultSetVM vm = new ResultSetVM();
            InitializeComponent();

            // Create a table
            System.Data.DataTable table = new System.Data.DataTable();
            
            // Add the columns to the table
            foreach (string columnName in vm.Results.Columns)
            {
                table.Columns.Add(columnName);
            }

            //// Foreach row
            for (int i = 0; i<5; i++)
            {
                // The current dictionary value
                Dictionary<string, object> rowDictionary = vm.Results.Rows[i];
                var tableRow = table.NewRow();

                // table's row->column = dictionary's row->column
                foreach (string columnName in vm.Results.Columns)
                {
                    tableRow[columnName] = rowDictionary[columnName];
                }

                // Add the row to the system table
                table.Rows.Add(tableRow);
            }

            ResultSetGrid.DataContext = table.DefaultView;
            ResultSetGrid.ItemsSource = table.DefaultView;
        }
    }
}
