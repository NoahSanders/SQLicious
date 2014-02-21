using InterSystems.Data.CacheClient;

namespace SQLicious.Models
{
    abstract class ConnectionBase
    {
        protected CacheConnection _cacheConnect = ((MainWindow)System.Windows.Application.Current.MainWindow).connection;
    }
}
