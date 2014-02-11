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

            for (int i = 0; i < vm.Results.Columns.Count; i++)
            {
                ResultSetGrid.Columns.Add(vm.Results.Columns[i]);
            }
                ResultSetGrid.Columns.

                InitializeComponent();
        }
    }
}
