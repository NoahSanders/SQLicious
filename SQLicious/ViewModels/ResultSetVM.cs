using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

using SQLicious.Models;

namespace SQLicious.ViewModels
{
    class ResultSetVM
    {
        private ResultSet _resultSet = new ResultSet();
        private string _sql;

        public System.Data.DataTable Results
        {
            get { return _resultSet.readQuery(_sql); }
        }

        public ResultSetVM(string sql)
        {
            _sql = sql;
        }
    }
}
