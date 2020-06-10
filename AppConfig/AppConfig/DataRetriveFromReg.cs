using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using RegisterationSaving;
namespace AppConfig
{
    public class DataRetriveFromReg
    {
        public IDictionaryEnumerator ServerConfigRetrieve()
        {
            try
            {
                RegisterationSaver RegSav = new RegisterationSaver();
                //RegSav.ResourceReader(out AppConfig.MainServerName, out AppConfig.MainDBName, out AppConfig.MainDBUserName, out AppConfig.MainDBPassword);
                IDictionaryEnumerator RegData = RegSav.ResourceReader();
                AppConfigInfo.RegDataSuit = RegData;
                return AppConfigInfo.RegDataSuit;
            }
            catch
            {
                return null;
            }
        }
    }
}
