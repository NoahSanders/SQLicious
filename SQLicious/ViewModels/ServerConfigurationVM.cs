#region Using
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Prism.Commands;

using InterSystems.Data.CacheTypes;
using InterSystems.Data.CacheClient;
#endregion

namespace SQLicious.ViewModels
{
    public class ServerConfigurationVM
    {
        #region private fields
        private DelegateCommand _saveSettings, _testConnection;
        #endregion

        #region Public Properties

        public string ConnectionHost
        {
            get { return SQLicious.Properties.Settings.Default.Host; }
            set { SQLicious.Properties.Settings.Default.Host = value; }
        }

        public string ConnectionUser
        {
            get { return SQLicious.Properties.Settings.Default.Username; }
            set { SQLicious.Properties.Settings.Default.Username = value; }
        }

        public string ConnectionPass
        {
            get { return SQLicious.Properties.Settings.Default.Password; }
            set { SQLicious.Properties.Settings.Default.Password = value; }
        }
        #endregion

        #region Delegates
        public DelegateCommand SaveSettingsCommand
        {
            get { return _saveSettings ?? (_saveSettings = new DelegateCommand(SaveSettings)); }
        }

        public DelegateCommand TestConnectionCommand
        {
            get { return _testConnection ?? (_testConnection = new DelegateCommand(TestConnection)); }
        }
        #endregion

        #region Private methods
        private void TestConnection()
        {
            try
            {
                CacheConnection cacheConnection = new CacheConnection();
                cacheConnection.ConnectionString = String.Format(
                                                                "Server = {0};Port = 1972;Namespace=SAMPLES;Password={1}; User ID={2}",
                                                                ConnectionHost,
                                                                ConnectionPass,
                                                                ConnectionUser);

                cacheConnection.Open();
                if (cacheConnection.State == System.Data.ConnectionState.Open)
                {
                    // ViewModelNotification = String.Format("Successfully connected to {0}!",ConnectionHost);
                }
                cacheConnection.Close();
            }
            catch (Exception ex)
            {
                //ViewModelNotification = ex.Message;
            }
        }

        private void SaveSettings()
        {
            SQLicious.Properties.Settings.Default.Save();
        }
        #endregion
    }
}
