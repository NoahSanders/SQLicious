using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.ComponentModel;

using SQLicious.Models;

namespace SQLicious.ViewModels
{
    class ResultSetVM : INotifyPropertyChanged
    {
        private ResultSet _resultSet = new ResultSet();
        private System.Data.DataTable _results;
        private string _sqlStatement;

        public string SQLStatement
        {
            get { return _sqlStatement; }
            set
            {
                _sqlStatement = value;
                Results = _resultSet.readQuery(value);
                OnPropertyChanged("SQLStatement");
            }
        }

        public System.Data.DataTable Results
        {
            // SQLStatement could be undefined when the view is binding to this, return null if so
            get { return _results; }
            set
            {
                _results = value;
                OnPropertyChanged("Results");
            }
        }

        public ResultSetVM()
        {
            _results = _resultSet.readQuery("Select * From Sample.Person");
        }

        #region Implement INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged = delegate { };

        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion    
    }
}
