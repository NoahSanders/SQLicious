using InterSystems.Data.CacheClient;

namespace SQLicious.Models
{
    class ConnectionBase
    {
        public CacheConnection _cacheConnect = new CacheConnection("localhost","1972","SAMPLES","cacheusr","v00d00");

        public ConnectionBase()
        {
            _cacheConnect.Open();
        }
    }
}
