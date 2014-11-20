using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Data;

using InterSystems.Data.CacheClient;
using InterSystems.Data.CacheTypes;

namespace SQLicious.Models
{
    class ResultSet : ConnectionBase
    {
        public ResultSet()
        {
        }

        // Will pass the select query to CacheCommand
        public DataTable readQuery(string sql) {
            DataTable dataTable = new DataTable();
            // set the global sql statement so our views can read them 
            CacheCommand Command = new CacheCommand(sql, _cacheConnect);
            CacheDataReader reader = Command.ExecuteReader();

            int record = 0;

            while (reader.Read())
            {
                // Get the column number
                int fields = reader.VisibleFieldCount;
                var tableRow = dataTable.NewRow();

                // We only do this once to get column names
                if (record == 0) {
                    // Get name based off ordinal position
                    for (int i = 0; i < fields; i++) {
                        var sname = reader.GetName(i);
                        dataTable.Columns.Add(sname);
                    }
                }
                // Now get values
                for (int i = 0; i < fields; i++)
                {
                    tableRow[reader.GetName(i)] = reader.GetValue(i);
                }


                dataTable.Rows.Add(tableRow);
                record++;
            }
            
            return dataTable;
        }
    }
}
 