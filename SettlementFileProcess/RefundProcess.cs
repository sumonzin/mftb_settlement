using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using AppConfig;
using ACE.Banking.MPU.Businesslogic;
using ACE.Banking.MPU.CollectionSuit;
using System.Net;

namespace SettlementFileProcess
{
    public partial class RefundProcess : Form
    {
        MemberBankDetailTransactionInfoCollections _dataSource = new MemberBankDetailTransactionInfoCollections();

        public RefundProcess()
        {
            InitializeComponent();
        }

        private void DataRetrieve()
        {
            try
            {
                Settlement_InfoController STFCtrl = new Settlement_InfoController();
                dgvRefundLog.AutoGenerateColumns = false;
                _dataSource = STFCtrl.SelectRefundListtoProcess(clsGlobal.vSTFDate.ToString("yyyy/MM/dd"));
                dgvRefundLog.DataSource = _dataSource;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void chkCheckAll_CheckedChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < dgvRefundLog.Rows.Count; i++)
            {
                dgvRefundLog.Rows[i].Cells["Approve"].Value = chkCheckAll.Checked == true ? 1 : 0;
            }
        }

        private void GridConfiguration()
        {
            for (int i = 1; i < dgvRefundLog.Columns.Count; i++)
            {
                dgvRefundLog.Columns[i].ReadOnly = true;
            }
        }

        private void RefundProcess_Load(object sender, EventArgs e)
        {
            DataRetrieve();
            GridConfiguration();
        }

        private void btnApprove_Click(object sender, EventArgs e)
        {
            try
            {
                Settlement_InfoController STMCtrl = new Settlement_InfoController();
                MemberBankDetailTransactionInfoCollections MBStmColl = new MemberBankDetailTransactionInfoCollections();
                MemberBankDetailTransactionInfoInfo MBInfo;

                for (int i = 0; i < dgvRefundLog.Rows.Count; i++)
                {
                    string hostname = Dns.GetHostName();
                    string myIP = Dns.GetHostEntry(hostname).AddressList[0].ToString();//Dns.GetHostByName(hostname).AddressList[0].ToString();

                    if (Convert.ToString(dgvRefundLog.Rows[i].Cells["Approve"].Value) == "1" && Convert.ToString(dgvRefundLog.Rows[i].Cells["FileType"].Value) == "MBA")
                    {
                        MBInfo = new MemberBankDetailTransactionInfoInfo();
                        MBInfo.PAN = Convert.ToString(dgvRefundLog.Rows[i].Cells["PAN"].Value);
                        MBInfo.settlementAmount = Convert.ToDecimal(dgvRefundLog.Rows[i].Cells["settlementAmount"].Value);
                        MBInfo.transAmount = Convert.ToDecimal(dgvRefundLog.Rows[i].Cells["transAmount"].Value);
                        MBInfo.ServiceFeeReceive = Convert.ToDecimal(dgvRefundLog.Rows[i].Cells["ServiceFeeReceive"].Value);
                        MBInfo.ServiceFeePayable = Convert.ToDecimal(dgvRefundLog.Rows[i].Cells["ServiceFeePayable"].Value);
                        MBInfo.FILENAME = Convert.ToString(dgvRefundLog.Rows[i].Cells["FILENAME"].Value);
                        MBInfo.RefundStatus = "A";
                        MBInfo.FileType = Convert.ToString(dgvRefundLog.Rows[i].Cells["FileType"].Value);
                        MBInfo.strSettlementDatetime = Convert.ToString(dgvRefundLog.Rows[i].Cells["SETTLEMENTDATE"].Value);
                        MBStmColl.Add(MBInfo);

                    }
                    else if (Convert.ToString(dgvRefundLog.Rows[i].Cells["Approve"].Value) == "1" && Convert.ToString(dgvRefundLog.Rows[i].Cells["FileType"].Value) == "MBI")
                    {
                        MBInfo = new MemberBankDetailTransactionInfoInfo();
                        MBInfo.PAN = Convert.ToString(dgvRefundLog.Rows[i].Cells["PAN"].Value);
                        MBInfo.settlementAmount = Convert.ToDecimal(dgvRefundLog.Rows[i].Cells["settlementAmount"].Value);
                        MBInfo.transAmount = Convert.ToDecimal(dgvRefundLog.Rows[i].Cells["transAmount"].Value);
                        MBInfo.ServiceFeeReceive = Convert.ToDecimal(dgvRefundLog.Rows[i].Cells["ServiceFeeReceive"].Value);
                        MBInfo.ServiceFeePayable = Convert.ToDecimal(dgvRefundLog.Rows[i].Cells["ServiceFeePayable"].Value);
                        MBInfo.FILENAME = Convert.ToString(dgvRefundLog.Rows[i].Cells["FILENAME"].Value);
                        MBInfo.RefundStatus = "A";
                        MBInfo.FileType = Convert.ToString(dgvRefundLog.Rows[i].Cells["FileType"].Value);
                        MBInfo.strSettlementDatetime = Convert.ToString(dgvRefundLog.Rows[i].Cells["SETTLEMENTDATE"].Value);
                        MBStmColl.Add(MBInfo);
                    }
                } //end of for loop

                if (MBStmColl.Count > 0)
                    STMCtrl.UpdateRefundStatus(MBStmColl); // Update Refund Status
                if (MBStmColl.Count <= 0)
                    MessageBox.Show("There is no row to process.");
                DataRetrieve();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
