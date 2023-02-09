using System;
using System.Configuration;

namespace Resource
{
    public class ConfigDA
    {
        public static string ConexionString(string strName)
        {
            return ConfigurationManager.ConnectionStrings[strName].ConnectionString;
        }

        public static string ReadConfig(string strKey)
        {
            return Convert.ToString(ConfigurationManager.AppSettings[strKey]);
        }

        public static int Sleep()
        {
            try
            {
                return Convert.ToInt32(ReadConfig("Sleep"));
            }
            catch
            {
                return 0;
            }
        }
    }
}

