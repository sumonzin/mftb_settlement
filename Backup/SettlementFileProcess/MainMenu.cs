using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SettlementFileProcess
{
    public partial class MainMenu : Form
    {        

        public MainMenu()
        {
            InitializeComponent();
        }

        private void settlementFileDownloadScheduleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SettlementProcessConfiguration frm = new SettlementProcessConfiguration();            
            frm.MdiParent = this;
            frm.Show();
        }

        private void settlementFileDownloadProcessToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SettlementFileDownloadProcess frm = new SettlementFileDownloadProcess();
            frm.MdiParent = this;
            frm.Show();
        }

        private void inboxToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Inbox frm = new Inbox();
            frm.MdiParent = this;
            frm.Show();
        }

        private void processBoxToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProcessInfo frm = new ProcessInfo();
            frm.MdiParent = this;
            frm.Show();
        }

        private void masterT464ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MasterDisputeFileDetail frm = new MasterDisputeFileDetail();
            frm.MdiParent = this;
            frm.Show();
        }
        
    }
}
