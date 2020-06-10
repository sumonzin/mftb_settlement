using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ACE.Banking.MPU.Businesslogic;
using ACE.Banking.MPU.CollectionSuit;
namespace SettlementFileProcess
{
    public partial class MasterDisputeFileDetail : Form
    {
        public MasterDisputeFileDetail()
        {
            InitializeComponent();
            MasterFileRetrieve();
        }
        private void MasterFileRetrieve()
        {
            DMLStringExecuterController DMLCtrl = new DMLStringExecuterController();
            dataGridView1.DataSource = DMLCtrl.DMLStringExecuter("Select * from MasterT464NREC_Info");
            dataGridView1.Refresh();
        }
    }
}