using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

using InterSystems.Data.CacheClient;
using InterSystems.Data.CacheTypes;

namespace SQLicious.Models
{
    class ResultSetData
    {
        public List<string> Columns
        {
            get;
            set;
        }

        public List<Dictionary<string,dynamic>> Rows
        {
            get;
            set;
        }
    }

    class ResultSet
    {
        private CacheConnection _cacheConnect;
        private dynamic _sqlObject;

        public ResultSet()
        {
            try
            {
                _cacheConnect = new CacheConnection();
                _cacheConnect.ConnectionString = "Server = localhost;Port = 1972;Namespace=SAMPLES;"
                                                 + "Password=v00d00; User ID=chmthompson";

                _cacheConnect.Open();
                // Should this be created in readQuery perhaps?
            
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        // Will pass the select query to CacheCommand
        public ResultSetData readQuery(string sql) {
            CacheCommand Command = new CacheCommand(sql, _cacheConnect);
            CacheDataReader reader = Command.ExecuteReader();
            ResultSetData rsData = new ResultSetData();
            int record = 0;

            while (reader.Read())
            {
                // Get the column number
                int fields = reader.VisibleFieldCount;
                Dictionary<string, dynamic> values = new Dictionary<string, dynamic>();
                // We only do this once to get column names
                if (record == 0) {
                    // Get name based off ordinal position
                    for (int i = 0; i < fields; i++) {
                        rsData.Columns.Add(reader.GetName(i));
                    }
                }
                // Now get values
                for (int i = 0; i < fields; i++)
                {
                    values.Add(reader.GetName(i),reader.GetValue(i));
                }

                rsData.Rows.Add(values);
            }

            return rsData;
        }
    }
}
 