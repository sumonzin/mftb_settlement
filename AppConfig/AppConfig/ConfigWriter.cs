using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;

namespace AppConfig
{
    public class ConfigWriter
    {
     
        public void DBConnectionstringWriter(string ConnectionstringName,string ServerName,string DBName,string UserName,string Password)
        {
            string[] DBInfo ={ ServerName, DBName, UserName, Password };
            AppConfigInfo.MainDBConnectionstring = string.Format(AppConfigInfo.FormatMainDBConnectionstring, DBInfo);   //Connectionstring format change 
            Configuration Config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);      // Config file Opening
            ConnectionStringSettings MainConnSetting = new ConnectionStringSettings(ConnectionstringName, AppConfigInfo.MainDBConnectionstring, "System.Data.SqlClient");
            Config.ConnectionStrings.ConnectionStrings.Remove(ConnectionstringName.ToString());
            Config.ConnectionStrings.ConnectionStrings.Add(MainConnSetting);
            Config.ConnectionStrings.SectionInformation.ProtectSection("RsaProtectedConfigurationProvider");
            Config.Save(ConfigurationSaveMode.Full);
            ConfigurationManager.RefreshSection("connectionStrings");
        }
        public void AppSettingWriter(string PortName,string PortNo)
        {
            Configuration Config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);      // Config file Opening
            Config.AppSettings.Settings.Remove(PortName);
            Config.AppSettings.Settings.Add(PortName, PortNo);
            Config.AppSettings.SectionInformation.ProtectSection("RsaProtectedConfigurationProvider");
            ConfigurationManager.RefreshSection("appSettings");
        }
        public void OtherSettingWriter(string SectionName)
        {
            Configuration Config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);      // Config file Opening            
            Config.AppSettings.Settings.Add(PortName, PortNo);
            Config.AppSettings.SectionInformation.ProtectSection("RsaProtectedConfigurationProvider");
            ConfigurationManager.RefreshSection("appSettings");
        }
    }
}
