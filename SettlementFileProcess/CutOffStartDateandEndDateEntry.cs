using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ACE.Banking.MPU.Businesslogic;

namespace SettlementFileProcess
{
    public partial class CutOffStartDateandEndDateEntry : Form
    {
        public CutOffStartDateandEndDateEntry()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var StartDate = dtptranDate.Value;
            var sdate = new DateTime(StartDate.Year, StartDate.Month, StartDate.Day, 00, 00, 00);
            DateTime ssdate = Convert.ToDateTime(sdate);

            var EndDate = dtptranDate.Value;
            var edate = new DateTime(EndDate.Year, EndDate.Month, EndDate.Day, 23, 59, 59);
            DateTime eedate = Convert.ToDateTime(edate);

            var TranDate = dtptranDate.Value;
            var tdate = new DateTime(TranDate.Year, TranDate.Month, TranDate.Day, 00, 00, 00);
            DateTime ttdate = Convert.ToDateTime(tdate);

            //DateTime StartDate = dtpStart.Value;
            //DateTime EndDate = dtpEnd.Value;
            //DateTime TranDate = dtptranDate.Value;

            CutOffDateEntryController Controller = new CutOffDateEntryController();
            Controller.InsertintoCutoffdetail_Info(ssdate, eedate, ttdate);

            MessageBox.Show("Setup Complete.");
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}