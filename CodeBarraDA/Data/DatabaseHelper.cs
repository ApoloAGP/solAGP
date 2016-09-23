using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CodeBarraDA
{
    public static class DatabaseHelper
    {
        public const string ConexionData = "MyConnection";
        public const string ConexionDataSistemas = "ConexionSistemas";
        public static string GetDbConnectionString(string ConnectionString)
        {
            return ConfigurationManager.ConnectionStrings[ConnectionString].ConnectionString;
        }

        public static string GetDbProvider(string ConnectionString)
        {
            string ss = ConfigurationManager.ConnectionStrings[ConnectionString].ProviderName;
            return ConfigurationManager.ConnectionStrings[ConnectionString].ProviderName;
        }

        public static string GetSchema()
        {
            return ConfigurationManager.AppSettings.Get("BDEsquema").ToString();
        }

    }
}
