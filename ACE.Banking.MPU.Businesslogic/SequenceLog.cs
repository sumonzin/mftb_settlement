using System;
using System.Collections.Generic;
using System.Text;

using System.IO;
using System.Windows.Forms;

namespace ACE.Banking.MPU.Businesslogic
{
    public class SequenceLog
    {
        public void TraceLog(string Message, string filename)
        {
            StreamWriter sw = null;
            try
            {
                string sLogFormat = DateTime.Now.ToShortDateString().ToString() + " " + DateTime.Now.ToLongTimeString().ToString() + " ==> ";
                //LogHelper.Logger.Info(Message);

                string sPathName = Application.StartupPath + @"\";

                string sYear = DateTime.Now.Year.ToString();
                string sMonth = DateTime.Now.Month.ToString();
                string sDay = DateTime.Now.Day.ToString();
                string sErrorTime = sDay + "-" + sMonth + "-" + sYear;

                sPathName = System.IO.Path.Combine(sPathName, "log");
                System.IO.Directory.CreateDirectory(sPathName);
                sPathName = System.IO.Path.Combine(sPathName, "Settlement");
                System.IO.Directory.CreateDirectory(sPathName);
                sPathName = System.IO.Path.Combine(sPathName, sErrorTime);
                System.IO.Directory.CreateDirectory(sPathName);
                sPathName = System.IO.Path.Combine(sPathName, filename + ".txt");
                sw = new StreamWriter(sPathName, true);

                sw.WriteLine(sLogFormat + Message);
                sw.Flush();
            }
            catch (Exception ex)
            {
              
            }
            finally
            {
                if (sw != null)
                {
                    sw.Dispose();
                    sw.Close();
                }
            }
        }
    }
}
