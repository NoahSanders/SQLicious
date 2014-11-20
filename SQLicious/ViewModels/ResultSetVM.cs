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
    public class ResultSetVM : INotifyPropertyChanged
    {
        private ResultSet _resultSet = new ResultSet();
        private System.Data.DataTable _results;
        private string _sqlStatement;
 
        public string SQLStatement
        {
            get { return _sqlStatement; }
            set
            {
                Results = _resultSet.readQuery(value);
                OnPropertyChanged("SQLStatement");
            }
        }

        public System.Data.DataTable Results
        {
            get { return _results ?? new System.Data.DataTable(); }
            set
            {
                _results = value;
                OnPropertyChanged("Results");
            }
        }

        public ResultSetVM()
        {
            if (SQLStatement != null)
            {
                _results = _resultSet.readQuery(SQLStatement);
            }
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
