using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace AppConfig
{
    public static class AppConfigInfo
    {
        //public static Dictionary<string, string> DBFields = new Dictionary<string, string>();
        public static IDictionaryEnumerator RegDataSuit =null;
        //public static string MainDBConnectionName = "MainDB";
        //public static string MainDBName = "Device";
        //public static string MainDBUserName;
        //public static string MainDBPassword;
        //public static string MainServerName;
        //public static string PortNo;
        //public static string DenoPortNo;
        public readonly static string FormatMainDBConnectionstring = "Data Source={0};Initial Catalog={1};User ID={2};Password={3}";
        public static string MainDBConnectionstring;       
    }
}
