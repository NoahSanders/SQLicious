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
    class ResultSet
    {
        private CacheConnection _cacheConnect;

        public ResultSet()
        {
            try
            {
                _cacheConnect = new CacheConnection();
                _cacheConnect.ConnectionString = "Server = localhost;Port = 1972;Namespace=SAMPLES;"
                                                                + "Password=v00d00; User ID=cacheusr";
                _cacheConnect.Open();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        // Will pass the select query to CacheCommand
        public DataTable readQuery(string sql) {
            DataTable dataTable = new DataTable();
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
 