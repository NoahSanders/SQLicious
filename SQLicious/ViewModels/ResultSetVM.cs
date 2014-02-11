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

        public ResultSetData Results
        {
            get { return _resultSet.readQuery("SELECT * FROM Sample.Person"); }
        }

        public ResultSetVM()
        {
            // do stuff
        }
    
    }
}
