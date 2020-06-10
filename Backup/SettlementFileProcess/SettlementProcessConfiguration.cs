using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Resources;

namespace SettlementFileProcess
{
    public partial class SettlementProcessConfiguration : Form
    {
        public SettlementProcessConfiguration()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                ResourceWriter(dtpSchedule.Value, chkManual.Checked == true ? "M" : "A");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void ResourceWriter(DateTime dtschedule,string _type)
        {
            ResourceWriter rsw = new ResourceWriter(Application.StartupPath + @"\STFCongif");
            rsw.AddResource("Schedule", dtschedule.Hour + ":"+dtschedule.Minute);
            rsw.AddResource("Type", _type);
            rsw.Close();            
        }
    }
}