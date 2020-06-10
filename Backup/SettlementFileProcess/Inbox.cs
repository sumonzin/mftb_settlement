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
//using Excel = Microsoft.Office.Interop.Excel; 
namespace SettlementFileProcess
{
    public partial class Inbox : Form
    {
        Settlement_InfoCollections _dataSource = new Settlement_InfoCollections();
        MerchantDetailTransaction_InfoCollections _mertaildatasource = new MerchantDetailTransaction_InfoCollections();
        public Inbox()
        {
            InitializeComponent();
        }
        #region Customize Events
        private void MerchantSettlementFieldsShow()
        {
            try
            {
                OutgoingAmountSign.Visible = false;
                OutgoingAmount.Visible = false;
                OutgoingFeeSign.Visible = false;
                OutgoingFee.Visible = false;
                STFAmountSign.Visible = false;
                STFAmount.Visible = false;
                STFFeeSign.Visible = false;
                STFFee.Visible = false;
                OutgoingSummary.Visible = false;

                MerchantCode.Visible = true;
                IncomingAmountSign.Visible = true;
                IncomingAmount.Visible = true;
                IncomingFeeSign.Visible = true;
                IncomingFee.Visible = true;
                IncomingSummary.Visible = true;
                TotalSTMAmtSign.Visible = true;
                TotalSTMAmt.Visible = true;
                IncomingSummary.Visible = true;
                SettlementCurrency.Visible = true;
                MerchantSTMAc.Visible = true;
                ReservedForUse.Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void MemberBankSettlementFieldsShow()
        {
            try
            {
                MPUDfCode.HeaderText = "Member Institution Code";

                OutgoingAmountSign.Visible = true;
                OutgoingAmount.Visible = true;
                OutgoingFeeSign.Visible = true;
                OutgoingFee.Visible = true;
                STFAmountSign.Visible = true;
                STFAmount.Visible = true;
                STFFeeSign.Visible = true;
                STFFee.Visible = true;
                OutgoingSummary.Visible = true;

                IncomingAmountSign.Visible = true;
                IncomingAmount.Visible = true;
                IncomingFeeSign.Visible = true;
                IncomingFee.Visible = true;
                IncomingSummary.Visible = true;
                SettlementCurrency.Visible = true;
                ReservedForUse.Visible = true;

                MerchantCode.Visible = false;
                MerchantSTMAc.Visible = false;
                TotalSTMAmtSign.Visible = false;
                TotalSTMAmt.Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void Both()
        {
            try
            {
                MPUDfCode.HeaderText = "MPU Code";
                OutgoingAmountSign.Visible = true;
                OutgoingAmount.Visible = true;
                OutgoingFeeSign.Visible = true;
                OutgoingFee.Visible = true;
                STFAmountSign.Visible = true;
                STFAmount.Visible = true;
                STFFeeSign.Visible = true;
                STFFee.Visible = true;
                OutgoingSummary.Visible = true;

                IncomingAmountSign.Visible = true;
                IncomingAmount.Visible = true;
                IncomingFeeSign.Visible = true;
                IncomingFee.Visible = true;
                IncomingSummary.Visible = true;
                SettlementCurrency.Visible = true;
                ReservedForUse.Visible = true;

                MerchantCode.Visible = true;
                MerchantSTMAc.Visible = true;
                TotalSTMAmtSign.Visible = true;
                TotalSTMAmt.Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void GridConfiguration()
        {
            for (int i = 1; i < dgvSettlementLog.Columns.Count; i++)
            {
                dgvSettlementLog.Columns[i].ReadOnly = true;
            }

            for (int i = 1; i < dgvMerchantDetailTransation.Columns.Count; i++)
            {
                dgvMerchantDetailTransation.Columns[i].ReadOnly = true;
            }
        }
        private void ConfigChanger()
        {
            SequenceLog Seqlog = new SequenceLog();
            try
            {
                string HostPort = string.Empty;
                string DBName = string.Empty;
                string DBUserName = string.Empty;
                string DBPassword = string.Empty;
                string ServerName = string.Empty;

                //Seqlog.TraceLog("Config Writing Event Start at = >" + DateTime.Now, FileName);

                DataRetriveFromReg dreg = new DataRetriveFromReg();
                AppConfigInfo.RegDataSuit = dreg.ServerConfigRetrieve();

                AppConfigInfo.RegDataSuit.Reset();
                while (AppConfigInfo.RegDataSuit.MoveNext())
                    switch (AppConfigInfo.RegDataSuit.Key.ToString())
                    {
                        case "DBName":
                            DBName = Convert.ToString(AppConfigInfo.RegDataSuit.Value);
                            break;
                        case "DBUserName":
                            DBUserName = Convert.ToString(AppConfigInfo.RegDataSuit.Value);
                            break;
                        case "DBPassword":
                            DBPassword = Convert.ToString(AppConfigInfo.RegDataSuit.Value);
                            break;
                        case "ServerName":
                            ServerName = Convert.ToString(AppConfigInfo.RegDataSuit.Value);
                            break;
                        default:
                            break;
                    }
                ConfigWriter cfw = new ConfigWriter();
                cfw.DBConnectionstringWriter("SettlementDB", ServerName, DBName, DBUserName, DBPassword);
                //Seqlog.TraceLog("Config Writing Event Finish at = >" + DateTime.Now, FileName);
            }
            catch (Exception ex)
            {
                //Seqlog.TraceLog("Config Writing Event Fail at = >" + DateTime.Now, FileName);
                //Seqlog.TraceLog("Err Desc = > " + ex.Message, FileName);
            }
        }
        private void DataRetrieve()
        {
            try
            {
                Settlement_InfoController STFCtrl = new Settlement_InfoController();
                dgvSettlementLog.AutoGenerateColumns = false;
                _dataSource = STFCtrl.Select();
                dgvSettlementLog.DataSource = _dataSource;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void MerchantDetailTranDataRetrieve(string MerchantCode, DateTime STFDate)
        {
            try
            {
                MerchantDetailTransaction_InfoController MERDetailTranCtrl = new MerchantDetailTransaction_InfoController();
                dgvMerchantDetailTransation.AutoGenerateColumns = true;
                dgvMerchantDetailTransation.DataSource = MERDetailTranCtrl.SelectByMerchantCode(MerchantCode, STFDate).Tables[0];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void MemberBankDetailTranDataRetrieve(string MemberBankCode,DateTime STFDate)
        {
            try
            {
                MemberBankDetailTransactionInfoController MemberBankCtrl = new MemberBankDetailTransactionInfoController();
                dgvMerchantDetailTransation.AutoGenerateColumns = true;
                dgvMerchantDetailTransation.DataSource = null;
                dgvMerchantDetailTransation.DataSource = MemberBankCtrl.SelectByBankCode(MemberBankCode, STFDate).Tables[0];
                dgvMerchantDetailTransation.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void DataReconcilation()
        {
            try
            {
                MPU_Settlement_InfoController MPUSTFCtrl = new MPU_Settlement_InfoController();
                MPU_Settlement_InfoCollections MPUSTFColl = MPUSTFCtrl.Select();
                //MPU_Settlement_InfoCollections MPUSTFColl = MPUSTFCtrl.SelectBySettlementDate(STFDate.ToString("yyyy/MM/dd"));
                string ErrorText = string.Empty;

                for (int j = 0; j < dgvSettlementLog.Rows.Count; j++)
                {
                    ErrorText = string.Empty;
                    if ((Convert.ToString(dgvSettlementLog.Rows[j].Cells["FileType"].Value) == "MB" && MPUSTFColl.Count <= 0))
                    {
                        dgvSettlementLog.Rows[j].ErrorText = "There is no transaction at core-banking.";
                        dgvSettlementLog.Rows[j].DefaultCellStyle.BackColor = Color.Red;
                        dgvSettlementLog.Rows[j].DefaultCellStyle.ForeColor = Color.White;
                    }
                    for (int i = 0; i < MPUSTFColl.Count; i++)
                    {
                        if (Convert.ToString(dgvSettlementLog.Rows[j].Cells["FileType"].Value) != "MB")
                            break;

                        if (Convert.ToDateTime(Convert.ToString(dgvSettlementLog.Rows[j].Cells["SettlementDate"].Value)).ToString("MM/dd/yyyy") == MPUSTFColl[i].MPUENDDATE.ToString("MM/dd/yyyy"))
                        {
                            if (MPUSTFColl[i].INCOMINGAMOUNT != Convert.ToDecimal(dgvSettlementLog.Rows[j].Cells["IncomingAmount"].Value))
                            {
                                ErrorText = "Incoming Amount isn't match.";
                            }
                            else if (MPUSTFColl[i].INCOMINGMPUFEE != Convert.ToDecimal(dgvSettlementLog.Rows[j].Cells["IncomingFee"].Value))
                            {
                                ErrorText = "Incoming Fee isn't match.";
                            }
                            else if (MPUSTFColl[i].OUTGOINGAMOUNT != Convert.ToDecimal(dgvSettlementLog.Rows[j].Cells["OutgoingAmount"].Value))
                            {
                                ErrorText = "Outgoing Amount isn't match.";
                            }
                            else if (MPUSTFColl[i].OUTGOINGMPUFEE != Convert.ToDecimal(dgvSettlementLog.Rows[j].Cells["OutgoingFee"].Value))
                            {
                                ErrorText = "Outgoing Fee isn't match.";
                            }
                            //else if (MPUSTFColl[i].STFAMOUNT != Convert.ToDecimal(dgvSettlementLog.Rows[j].Cells["STFAmount"].Value))
                            //{
                            //    ErrorText = "Settlement File Amount isn't match.";
                            //}
                            //else if (MPUSTFColl[i].STFFEE != Convert.ToDecimal(dgvSettlementLog.Rows[j].Cells["STFFee"].Value))
                            //{
                            //    ErrorText = "Settlement File Fee isn't match.";
                            //}
                            dgvSettlementLog.Rows[j].ErrorText = ErrorText;
                            dgvSettlementLog.Rows[j].DefaultCellStyle.BackColor = ErrorText == string.Empty ? Color.White : Color.Red;
                            dgvSettlementLog.Rows[j].DefaultCellStyle.ForeColor = ErrorText == string.Empty ? Color.Black : Color.White;
                        }
                        else
                        {
                            ErrorText = string.Empty;
                            dgvSettlementLog.Rows[j].ErrorText = ErrorText;
                            dgvSettlementLog.Rows[j].DefaultCellStyle.BackColor = ErrorText == string.Empty ? Color.White : Color.Red;
                            dgvSettlementLog.Rows[j].DefaultCellStyle.ForeColor = ErrorText == string.Empty ? Color.Black : Color.White;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void MPUSettlementStatusRecord(int rowIndex,string status)
        {
            int i = rowIndex;
            try
            {
                //aa

                DateTime STFDate = Convert.ToDateTime(dgvSettlementLog.Rows[i].Cells["SettlementDate"].Value);
                MPU_Settlement_InfoController MPUSTFCtrl = new MPU_Settlement_InfoController();
                MPU_Settlement_InfoCollections MPUSTFColl = MPUSTFCtrl.SelectBySettlementDate(STFDate.ToString("yyyy/MM/dd"));
                MPUSettlementStatusInfo MpuStmStatusinfo = new MPUSettlementStatusInfo();
                MPUSettlementStatusController MPUSTFStaCol = new MPUSettlementStatusController();

                MpuStmStatusinfo.MPUIncomingAmount = Convert.ToDecimal(dgvSettlementLog.Rows[i].Cells["IncomingAmount"].Value);
                MpuStmStatusinfo.MPUOutgoingAmount = Convert.ToDecimal(dgvSettlementLog.Rows[i].Cells["OUTGOINGAMOUNT"].Value);
                MpuStmStatusinfo.MPUIncomingFee = Convert.ToDecimal(dgvSettlementLog.Rows[i].Cells["INCOMINGFEE"].Value);
                MpuStmStatusinfo.MPUOutgoingFee = Convert.ToDecimal(dgvSettlementLog.Rows[i].Cells["OUTGOINGFEE"].Value);
                MpuStmStatusinfo.SettlementDate = Convert.ToDateTime(dgvSettlementLog.Rows[i].Cells["SettlementDate"].Value);
                MpuStmStatusinfo.CreatedDate = DateTime.Now;
                MpuStmStatusinfo.MPUSettlementID = Convert.ToString(System.Guid.NewGuid());
                MpuStmStatusinfo.STATUS = status;
                if (MPUSTFColl.Count > 0)
                {
                    MpuStmStatusinfo.CBSIncomingAmount = Convert.ToDecimal(MPUSTFColl[0].INCOMINGAMOUNT);
                    MpuStmStatusinfo.CBSIncomingFee = Convert.ToDecimal(MPUSTFColl[0].INCOMINGMPUFEE);
                    MpuStmStatusinfo.CBSOutgoingAmount = Convert.ToDecimal(MPUSTFColl[0].OUTGOINGAMOUNT);
                    MpuStmStatusinfo.CBSOutgoingFee = Convert.ToDecimal(MPUSTFColl[0].OUTGOINGMPUFEE);
                }
                MPUSTFStaCol.Add(MpuStmStatusinfo);
               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion
        private void merchantProcessOnlyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dgvSettlementLog.Visible = true;
            gpbDetailTran.Visible = false;
            MerchantSettlementFieldsShow();
            Settlement_InfoCollections MerchantdataSource = new Settlement_InfoCollections();
            for (int i = 0; i < _dataSource.Count; i++)
            {
                if (Convert.ToString(_dataSource[i].FileType) == "MC")
                {
                    Settlement_InfoInfo STInfo = _dataSource[i];
                    MerchantdataSource.Add(STInfo);
                }
            }
            dgvSettlementLog.DataSource = MerchantdataSource;
        }
        private void memberBankProcessOnlyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dgvSettlementLog.Visible = true;
            gpbDetailTran.Visible = false;
            MemberBankSettlementFieldsShow();
            Settlement_InfoCollections MBdataSource = new Settlement_InfoCollections();
            for (int i = 0; i < _dataSource.Count; i++)
            {
                if (Convert.ToString(_dataSource[i].FileType) == "MB")
                {
                    Settlement_InfoInfo STInfo = _dataSource[i];
                    MBdataSource.Add(STInfo);
                }
            }
            dgvSettlementLog.DataSource = MBdataSource;
        }
        private void bothMerchantMemberBankSettlementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dgvSettlementLog.Visible = true;
            gpbDetailTran.Visible = false;
            Both();
            dgvSettlementLog.DataSource = _dataSource;           
        }
        private void Inbox_Load(object sender, EventArgs e)
        {
            gpbFilter.Visible = false;
            gpbDetailTran.Visible = false;
            ConfigChanger();
            DataRetrieve();
            GridConfiguration();
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            gpbFilter.Visible = true;
        }
        private void rdo_Click(object sender, EventArgs e)
        {
            RadioButton rdo = (RadioButton)sender;

            for (int i = 0; i < dgvSettlementLog.Rows.Count; i++)
            {
                if (Convert.ToString(dgvSettlementLog.Rows[i].Cells[Convert.ToString(rdo.Tag)].Value) == txtFilter.Text)
                {
                    dgvSettlementLog.Rows[i].Selected = true;
                }
                else
                    dgvSettlementLog.Rows[i].Selected = false;
            }
            gpbFilter.Visible = false;
        }
        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataRetrieve();
            Both();
        }
        private void btnApprove_Click(object sender, EventArgs e)
        {
            try
            {
                Settlement_InfoController STMCtrl = new Settlement_InfoController();
                Settlement_InfoCollections MBStmColl = new Settlement_InfoCollections();
                Settlement_InfoCollections MCStmColl = new Settlement_InfoCollections();
                Settlement_InfoInfo MerchantStmInfo;
                Settlement_InfoInfo MemberStmInfo;

                for (int i = 0; i < dgvSettlementLog.Rows.Count; i++)
                {
                    string hostname = Dns.GetHostName();
                    string myIP = Dns.GetHostEntry(hostname).AddressList[0].ToString();//Dns.GetHostByName(hostname).AddressList[0].ToString();

                    if (Convert.ToString(dgvSettlementLog.Rows[i].Cells["Approve"].Value) == "1" && Convert.ToString(dgvSettlementLog.Rows[i].Cells["FileType"].Value) == "MC")
                    {
                        MerchantStmInfo = new Settlement_InfoInfo();
                        MerchantStmInfo.MerchantCode = Convert.ToString(dgvSettlementLog.Rows[i].Cells["MerchantCode"].Value);
                        MerchantStmInfo.Status = "A";
                        MerchantStmInfo.ApproveBy = "";
                        MerchantStmInfo.ApproveFrom = myIP;
                        MerchantStmInfo.FileType = Convert.ToString(dgvSettlementLog.Rows[i].Cells["FileType"].Value);
                        MerchantStmInfo.SettlementDate = Convert.ToDateTime(dgvSettlementLog.Rows[i].Cells["SettlementDate"].Value);
                        MCStmColl.Add(MerchantStmInfo);
                        //MPUSettlementStatusRecord(i, MerchantStmInfo.Status);
                        //}
                    }
                    else if (Convert.ToString(dgvSettlementLog.Rows[i].Cells["Approve"].Value) == "1" && Convert.ToString(dgvSettlementLog.Rows[i].Cells["FileType"].Value) == "MB")
                    {
                        if (dgvSettlementLog.Rows[i].ErrorText != string.Empty)
                            if (MessageBox.Show(dgvSettlementLog.Rows[i].ErrorText + Environment.NewLine + "Do you want to do it?",this.Text, MessageBoxButtons.YesNo) == DialogResult.No)
                                break;
                        //MemberStmInfo = new Settlement_InfoInfo();
                        //MemberStmInfo.MPUDfCode = Convert.ToString(dgvSettlementLog.Rows[i].Cells["MPUDfCode"].Value);
                        //MemberStmInfo.Status = "A";
                        //MemberStmInfo.ApproveBy = "";
                        //MemberStmInfo.ApproveFrom = myIP;
                        //MemberStmInfo.FileType = Convert.ToString(dgvSettlementLog.Rows[i].Cells["FileType"].Value);
                        //MemberStmInfo.SettlementDate = Convert.ToDateTime(dgvSettlementLog.Rows[i].Cells["SettlementDate"].Value);
                        //MBStmColl.Add(MemberStmInfo);
                        //MPUSettlementStatusRecord(i, MemberStmInfo.Status);
                    }
                    
                }
                if (MBStmColl.Count > 0)
                {
                    STMCtrl.UpdateByMemberCode(MBStmColl);
                    DataRetrieve();
                    MerchantSettlementFieldsShow();
                }
                if (MCStmColl.Count > 0)
                {
                    STMCtrl.UpdateByMerchantCode(MCStmColl);
                    DataRetrieve();
                    MemberBankSettlementFieldsShow();
                }
                if (MCStmColl.Count <= 0 && MBStmColl.Count <= 0)
                    MessageBox.Show("There is no row to process.");                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void btnReject_Click(object sender, EventArgs e)
        {
            try
            {
                Settlement_InfoController STMCtrl = new Settlement_InfoController();
                Settlement_InfoCollections MBStmColl = new Settlement_InfoCollections();
                Settlement_InfoCollections MCStmColl = new Settlement_InfoCollections();
                Settlement_InfoInfo MerchantStmInfo;
                Settlement_InfoInfo MemberStmInfo;
                
                string hostname = Dns.GetHostName();
                string myIP = Dns.GetHostByName(hostname).AddressList[0].ToString();
                
                for (int i = 0; i < dgvSettlementLog.Rows.Count; i++)
                {
                    if (Convert.ToString(dgvSettlementLog.Rows[i].Cells["Approve"].Value) == "1" && Convert.ToString(dgvSettlementLog.Rows[i].Cells["FileType"].Value) == "MC")
                    {
                        MerchantStmInfo = new Settlement_InfoInfo();
                        MerchantStmInfo.MerchantCode = Convert.ToString(dgvSettlementLog.Rows[i].Cells["MerchantCode"].Value);
                        MerchantStmInfo.FileType = Convert.ToString(dgvSettlementLog.Rows[i].Cells["FileType"].Value);
                        MerchantStmInfo.SettlementDate = Convert.ToDateTime(dgvSettlementLog.Rows[i].Cells["SettlementDate"].Value);
                        MerchantStmInfo.Status = "R";
                        MerchantStmInfo.RejectBy = "";
                        MerchantStmInfo.RejectFrom = myIP;
                        MCStmColl.Add(MerchantStmInfo);                        
                    }
                    else if (Convert.ToString(dgvSettlementLog.Rows[i].Cells["Approve"].Value) == "1" && Convert.ToString(dgvSettlementLog.Rows[i].Cells["FileType"].Value) == "MB")
                    {
                        MemberStmInfo = new Settlement_InfoInfo();
                        MemberStmInfo.MPUDfCode = Convert.ToString(dgvSettlementLog.Rows[i].Cells["MPUDfCode"].Value);
                        MemberStmInfo.FileType = Convert.ToString(dgvSettlementLog.Rows[i].Cells["FileType"].Value);
                        MemberStmInfo.SettlementDate = Convert.ToDateTime(dgvSettlementLog.Rows[i].Cells["SettlementDate"].Value);
                        MemberStmInfo.Status = "R";
                        MemberStmInfo.RejectBy = "";
                        MemberStmInfo.RejectFrom = myIP;
                        MBStmColl.Add(MemberStmInfo);
                        MPUSettlementStatusRecord(i, MemberStmInfo.Status);                        
                    }
                }
                if (MBStmColl.Count > 0)
                    STMCtrl.UpdateByMemberCode(MBStmColl);
                if (MCStmColl.Count > 0)
                    STMCtrl.UpdateByMerchantCode(MCStmColl);
                if (MCStmColl.Count <= 0 && MBStmColl.Count <= 0)
                    MessageBox.Show("There is no row to process.");
                DataRetrieve();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void chkCheckAll_CheckedChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < dgvSettlementLog.Rows.Count; i++)
            {
                dgvSettlementLog.Rows[i].Cells["Approve"].Value = chkCheckAll.Checked == true ? 1 : 0;
            }
        }
        private void dgvSettlementLog_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            try
            {
                dgvSettlementLog.ShowRowErrors = true;

                for (int i = 0; i < dgvSettlementLog.Rows.Count; i++)
                {
                    //if (Convert.ToString(dgvSettlementLog.Rows[i].Cells["FileType"].Value) == "MC" )
                    if (Convert.ToString(dgvSettlementLog.Rows[i].Cells["FileType"].Value) == "MB")
                    {
                        decimal incomingamount = Convert.ToDecimal(dgvSettlementLog.Rows[i].Cells["IncomingAmount"].Value);
                        string IncomingAmtSign = Convert.ToString(dgvSettlementLog.Rows[i].Cells["IncomingAmountSign"].Value);

                        decimal IncomingFeeamount = Convert.ToDecimal(dgvSettlementLog.Rows[i].Cells["IncomingFee"].Value);
                        string IncomingFeesign = Convert.ToString(dgvSettlementLog.Rows[i].Cells["IncomingFeeSign"].Value);

                        decimal Outgoingamount = Convert.ToDecimal(dgvSettlementLog.Rows[i].Cells["OutgoingAmount"].Value);
                        string OutgoingAmtSign = Convert.ToString(dgvSettlementLog.Rows[i].Cells["OutgoingAmountSign"].Value);

                        decimal OutgoingFeeamount = Convert.ToDecimal(dgvSettlementLog.Rows[i].Cells["OutgoingFee"].Value);
                        string OutgoingFeesign = Convert.ToString(dgvSettlementLog.Rows[i].Cells["OutgoingFeeSign"].Value);

                        decimal totalstmamt = Convert.ToDecimal(dgvSettlementLog.Rows[i].Cells["STFAmount"].Value);
                        string totalstmamtsign = Convert.ToString(dgvSettlementLog.Rows[i].Cells["STFAmountSign"].Value);

                        decimal totalstmfeeamt = Convert.ToDecimal(dgvSettlementLog.Rows[i].Cells["STFFee"].Value);
                        string totalstmamtfeesign = Convert.ToString(dgvSettlementLog.Rows[i].Cells["STFFeeSign"].Value);

                        if (IncomingAmtSign == "D")
                            incomingamount = 0 - incomingamount;
                        if (IncomingFeesign == "D")
                            IncomingFeeamount = 0 - IncomingFeeamount;

                        if (OutgoingAmtSign == "D")
                            Outgoingamount = 0 - Outgoingamount;
                        if (OutgoingFeesign == "D")
                            OutgoingFeeamount = 0 - OutgoingFeeamount;

                        if (totalstmamtsign == "D")
                            totalstmamt = 0 - totalstmamt;

                        if (totalstmamtfeesign == "D")
                            totalstmfeeamt = 0 - totalstmfeeamt;

                        if (!decimal.Equals((incomingamount + IncomingFeeamount + Outgoingamount + OutgoingFeeamount), totalstmamt + totalstmfeeamt))
                        {
                            dgvSettlementLog.Rows[i].ErrorText = "Amount didn't match.";
                            dgvSettlementLog.Rows[i].DefaultCellStyle.BackColor = Color.Red;
                            dgvSettlementLog.Rows[i].DefaultCellStyle.ForeColor = Color.White;
                        }
                    }
                    else if (Convert.ToString(dgvSettlementLog.Rows[i].Cells["FileType"].Value) == "MC")
                    {
                        decimal incomingamount = Convert.ToDecimal(dgvSettlementLog.Rows[i].Cells["IncomingAmount"].Value);
                        string IncomingAmtSign = Convert.ToString(dgvSettlementLog.Rows[i].Cells["IncomingAmountSign"].Value);

                        decimal Feeamount = Convert.ToDecimal(dgvSettlementLog.Rows[i].Cells["IncomingFee"].Value);
                        string Feesign = Convert.ToString(dgvSettlementLog.Rows[i].Cells["IncomingFeeSign"].Value);

                        decimal totalstmamt = Convert.ToDecimal(dgvSettlementLog.Rows[i].Cells["TotalSTMAmt"].Value);
                        string totalstmamtsign = Convert.ToString(dgvSettlementLog.Rows[i].Cells["TotalSTMAmtSign"].Value);

                        if (IncomingAmtSign == "D")
                            incomingamount = 0 - incomingamount;
                        if (Feesign == "D")
                            Feeamount = 0 - Feeamount;

                        if (totalstmamtsign == "D")
                            totalstmamt = 0 - totalstmamt;

                        if (!decimal.Equals((incomingamount + Feeamount), totalstmamt))
                        {
                            dgvSettlementLog.Rows[i].ErrorText = "Amount didn't match.";
                            dgvSettlementLog.Rows[i].DefaultCellStyle.BackColor = Color.Red;
                            dgvSettlementLog.Rows[i].DefaultCellStyle.ForeColor = Color.White;
                        }
                    }
                }
                DataReconcilation();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void mechantDetailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dgvSettlementLog.Visible = false;
            gpbDetailTran.Visible = true;
        }
        private void dgvSettlementLog_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0)
                    return;
                gpbDetailTran.Visible = true;

                if (Convert.ToString(dgvSettlementLog.Rows[e.RowIndex].Cells["FileType"].Value) == "MC")
                    MerchantDetailTranDataRetrieve(Convert.ToString(dgvSettlementLog.Rows[e.RowIndex].Cells["MerchantCode"].Value), Convert.ToDateTime(dgvSettlementLog.Rows[e.RowIndex].Cells["SettlementDate"].Value));
                else
                    MemberBankDetailTranDataRetrieve(Convert.ToString(dgvSettlementLog.Rows[e.RowIndex].Cells["MPUDfCode"].Value), Convert.ToDateTime(dgvSettlementLog.Rows[e.RowIndex].Cells["SettlementDate"].Value));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void dgvSettlementLog_Click(object sender, EventArgs e)
        {
            gpbDetailTran.Visible = false;
        }
        private void dgvSettlementLog_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex < 0 || e.RowIndex < 0)
                return;
            if (dgvSettlementLog.Columns[e.ColumnIndex].Name == "CBSTranShow" & Convert.ToString(dgvSettlementLog.Rows[e.RowIndex].Cells["FileType"].Value) == "MB")
            {
                DateTime STFDate = Convert.ToDateTime(dgvSettlementLog.Rows[e.RowIndex].Cells["SettlementDate"].Value);
                MPU_Settlement_InfoController MPUSTFCtrl = new MPU_Settlement_InfoController();
                MPU_Settlement_InfoCollections MPUSTFColl = MPUSTFCtrl.SelectBySettlementDate(STFDate.ToString("yyyy/MM/dd"));

                DataReconcile frm = new DataReconcile();
                frm.MPUIncomingAmount = Convert.ToString(dgvSettlementLog.Rows[e.RowIndex].Cells["IncomingAmount"].Value);
                frm.MPUIncomingFee = Convert.ToString(dgvSettlementLog.Rows[e.RowIndex].Cells["IncomingFee"].Value);
                frm.MPUOutgoingAmount = Convert.ToString(dgvSettlementLog.Rows[e.RowIndex].Cells["OutgoingAmount"].Value);
                frm.MPUOutgoingFee = Convert.ToString(dgvSettlementLog.Rows[e.RowIndex].Cells["OutgoingFee"].Value);

                if (MPUSTFColl.Count > 0)
                {
                    frm.CBSIncomingAmount = Convert.ToString(MPUSTFColl[0].INCOMINGAMOUNT);
                    frm.CBSIncomingFee = Convert.ToString(MPUSTFColl[0].INCOMINGMPUFEE);
                    frm.CBSOutgoingAmount = Convert.ToString(MPUSTFColl[0].OUTGOINGAMOUNT);
                    frm.CBSOutgoingFee = Convert.ToString(MPUSTFColl[0].OUTGOINGMPUFEE);
                }
                frm.ShowDialog(this);
            }
        }
    }
}