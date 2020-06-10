using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SettlementFileProcess
{
    public partial class DataReconcile : Form
    {
        public DataReconcile()
        {
            InitializeComponent();
        }

        private string _MPUIncomingAmount = string.Empty;
        public string MPUIncomingAmount
        {
            set { _MPUIncomingAmount = value; }
        }

        private string _MPUIncomingFee = string.Empty;
        public string MPUIncomingFee
        {
            set { _MPUIncomingFee = value; }
        }

        private string _MPUOutgoingAmount = string.Empty;
        public string MPUOutgoingAmount
        {
            set { _MPUOutgoingAmount = value; }
        }

        private string _MPUOutgoingFee = string.Empty;
        public string MPUOutgoingFee
        {
            set { _MPUOutgoingFee = value; }
        }

        /// <summary>
        /// Core Banking Transaction
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private string _CBSIncomingAmount = string.Empty;
        public string CBSIncomingAmount
        {
            set { _CBSIncomingAmount = value; }
        }

        private string _CBSIncomingFee = string.Empty;
        public string CBSIncomingFee
        {
            set { _CBSIncomingFee = value; }
        }

        private string _CBSOutgoingAmount = string.Empty;
        public string CBSOutgoingAmount
        {
            set { _CBSOutgoingAmount = value; }
        }

        private string _CBSOutgoingFee = string.Empty;
        public string CBSOutgoingFee
        {
            set { _CBSOutgoingFee = value; }
        }
        
        private void btnhide_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DataReconcile_Load(object sender, EventArgs e)
        {
            label1.Text = DateTime.Now.ToString("dd-MMM-yyyy");
            dgvMPUSTFData.Rows.Add(_MPUIncomingAmount, _MPUIncomingFee, _MPUOutgoingAmount, _MPUOutgoingFee);
            dgvCBSSFTData.Rows.Add(_CBSIncomingAmount, _CBSIncomingFee, _CBSOutgoingAmount, _CBSOutgoingFee);
        }
    }
}