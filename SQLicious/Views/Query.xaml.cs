﻿using System;
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

namespace SQLicious.Views
{
    /// <summary>
    /// Interaction logic for Query.xaml
    /// </summary>
    public partial class Query : UserControl
    {
        public Query()
        {
            InitializeComponent();
        }

        public void ExecuteQuery(Object sender, ExecutedRoutedEventArgs e)
        {
            //switch to ResultSet View
            ((MainWindow)System.Windows.Application.Current.MainWindow).NavigationTabs.SelectedIndex = 1;

            //refresh ResultSet View with new results
            //???
        }
    }
}
