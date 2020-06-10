using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using AppConfig;
namespace TestApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            DataRetriveFromReg dreg = new DataRetriveFromReg();
            dreg.ServerConfigRetrieve();

            AppConfigInfo.RegDataSuit.Reset();
            while (AppConfigInfo.RegDataSuit.MoveNext())
            {

            }
            ConfigWriter cf = new ConfigWriter();
            //cf.DBConnectionstringWriter();
            cf.AppSettingWriter("PortNo", "12222");
        }
    }
}