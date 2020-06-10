using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using System.Net;
using AppConfig;
using ACE.Banking.MPU.Businesslogic;
using ACE.Banking.MPU.CollectionSuit;
namespace SettlementFileProcess
{
    public partial class ProcessInfo : Form
    {
        Settlement_InfoCollections _dataSource = new Settlement_InfoCollections();
        public ProcessInfo()
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
                _dataSource = STFCtrl.SelectByStatus("'" + "A" + "'" + "," + "'" + "F" + "'");
                dgvSettlementLog.DataSource = _dataSource;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private bool SettlementProcessControllerForMerchant(int rowindex,out string Eno)
        {
            Eno = string.Empty;
            try
            {
                Settlement_InfoController StCtrl = new Settlement_InfoController();
                string AccountNo = string.Empty;
                char AmountSign = ' ';
                decimal Amount = 0;
                char FeeSign = ' ';
                decimal FeeAmount = 0;
                string TerminalNo = string.Empty;
                string _DateTime = string.Empty;
                string Currency = string.Empty;                
                string RefEno = string.Empty;
                string RespCode = string.Empty;

                AccountNo = Convert.ToString(dgvSettlementLog.Rows[rowindex].Cells["MerchantSTMAc"].Value);
                AmountSign = Convert.ToChar(dgvSettlementLog.Rows[rowindex].Cells["IncomingAmountSign"].Value);
                Amount = Convert.ToDecimal(dgvSettlementLog.Rows[rowindex].Cells["IncomingAmount"].Value);
                FeeSign = Convert.ToChar(dgvSettlementLog.Rows[rowindex].Cells["IncomingFeeSign"].Value);
                FeeAmount = Convert.ToDecimal(dgvSettlementLog.Rows[rowindex].Cells["IncomingFee"].Value);
                TerminalNo = "M0001";
                _DateTime = Convert.ToString(DateTime.Now);
                Currency = Convert.ToString(dgvSettlementLog.Rows[rowindex].Cells["SettlementCurrency"].Value);
                Eno = string.Empty;

                if (!StCtrl.SettlementProcessForMerchant(AccountNo, AmountSign, Amount, FeeSign, FeeAmount, _DateTime, Currency, Eno, TerminalNo, out RefEno, out RespCode))
                    throw new Exception("Settlement Process Fail for this account  No = > " + AccountNo);
                else
                    MessageBox.Show("Settlement Process Success for this account  No = > " + AccountNo + Environment.NewLine + " Transaction No is = > " + RefEno);
                Eno = RefEno;
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }
        private void MPUSettlementStatusUpdate(int rowIndex, string status,string eno,DateTime stfdate)
        {
            int i = rowIndex;
            MPUSettlementStatusInfo MpuStmStatusinfo = new MPUSettlementStatusInfo();
            MPUSettlementStatusController MPUSTFStaCol = new MPUSettlementStatusController();

            MpuStmStatusinfo.STATUS = status;
            MpuStmStatusinfo.TransactionNo = eno;
            MpuStmStatusinfo.TransactionDate = DateTime.Now;
            MpuStmStatusinfo.UPdatedDate = DateTime.Now;
            MpuStmStatusinfo.SettlementDate = stfdate;

            MPUSTFStaCol.UpdatebySTFdate(MpuStmStatusinfo);
            

            
        }
        private void MPU_Settlement_InfoDelete(DateTime stfdata)
        {
            try
            {

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion
        private void merchantProcessOnlyToolStripMenuItem_Click(object sender, EventArgs e)
        {
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
            Both();
        }
        private void btnCheckAll_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dgvSettlementLog.Rows.Count; i++)
            {
                dgvSettlementLog.Rows[i].Cells["Approve"].Value = 1;
            }
        }   
        private void btnSearch_Click(object sender, EventArgs e)
        {
            gpbFilter.Visible = true;
        }
        private void rdo_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dgvSettlementLog.Rows.Count; i++)
            {
                if (Convert.ToString(dgvSettlementLog.Rows[i].Cells["MPUDfCode"].Value) == txtFilter.Text)
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
                string _Eno=string.Empty;
                for (int i = 0; i < dgvSettlementLog.Rows.Count; i++)
                {
                    string hostname = Dns.GetHostName();
                    string myIP = Dns.GetHostByName(hostname).AddressList[0].ToString();

                    if (Convert.ToString(dgvSettlementLog.Rows[i].Cells["Approve"].Value) == "1" && Convert.ToString(dgvSettlementLog.Rows[i].Cells["FileType"].Value) == "MC")
                    {
                        MerchantStmInfo = new Settlement_InfoInfo();
                        MerchantStmInfo.MerchantCode = Convert.ToString(dgvSettlementLog.Rows[i].Cells["MerchantCode"].Value);
                        //MerchantStmInfo.ApproveBy = Dns.GetHostName();
                        MerchantStmInfo.ProcessBy = MerchantStmInfo.ApproveFrom;
                        MerchantStmInfo.ProcessFrom = myIP;
                        MerchantStmInfo.UpdatedDate = DateTime.Now;
                        STMCtrl.UpdateByMerchantCode(MerchantStmInfo);

                        if (SettlementProcessControllerForMerchant(i,out _Eno))
                            MerchantStmInfo.Status = "S";
                        else
                            MerchantStmInfo.Status = "F";

                        MerchantStmInfo.UpdatedDate = DateTime.Now;
                        MerchantStmInfo.FileType = Convert.ToString(dgvSettlementLog.Rows[i].Cells["FileType"].Value);
                        MerchantStmInfo.SettlementDate = Convert.ToDateTime(dgvSettlementLog.Rows[i].Cells["STFDate"].Value);
                        MerchantStmInfo.ProcessFrom = myIP;
                        STMCtrl.UpdateByMerchantCode(MerchantStmInfo);
                        
                        //MPUSettlementStatusUpdate(i, MerchantStmInfo.Status, _Eno, MerchantStmInfo.SettlementDate);

                        DataRetrieve();
                        MerchantSettlementFieldsShow();
                    }
                    else if (Convert.ToString(dgvSettlementLog.Rows[i].Cells["Approve"].Value) == "1" && Convert.ToString(dgvSettlementLog.Rows[i].Cells["FileType"].Value) == "MB")
                    {
                        MemberStmInfo = new Settlement_InfoInfo();
                        MemberStmInfo.MPUDfCode = Convert.ToString(dgvSettlementLog.Rows[i].Cells["MPUDfCode"].Value);
                        MemberStmInfo.Status = "A";
                        MemberStmInfo.ProcessFrom = myIP;
                        //MemberStmInfo.ApproveFrom = myIP;
                        MemberStmInfo.UpdatedDate = DateTime.Now;
                        MemberStmInfo.FileType = Convert.ToString(dgvSettlementLog.Rows[i].Cells["FileType"].Value);
                        MemberStmInfo.SettlementDate = Convert.ToDateTime(dgvSettlementLog.Rows[i].Cells["STFDate"].Value);
                        MemberStmInfo.OutgoingAmoutSign = Convert.ToString(dgvSettlementLog.Rows[i].Cells["OutgoingAmountSign"].Value);
                        MemberStmInfo.OutgoingFeeSign = Convert.ToString(dgvSettlementLog.Rows[i].Cells["OutgoingFeeSign"].Value);
                        MemberStmInfo.IncomingAmountSign = Convert.ToString(dgvSettlementLog.Rows[i].Cells["IncomingAmountSign"].Value);
                        MemberStmInfo.IncomingFeeSign = Convert.ToString(dgvSettlementLog.Rows[i].Cells["IncomingFeeSign"].Value);
                        MemberStmInfo.SettlementCurrency = Convert.ToString(dgvSettlementLog.Rows[i].Cells["SettlementCurrency"].Value);

                        MemberStmInfo.OutgoingAmount = Convert.ToDecimal(dgvSettlementLog.Rows[i].Cells["OutgoingAmount"].Value);
                        MemberStmInfo.OutgoingFee = Convert.ToDecimal(dgvSettlementLog.Rows[i].Cells["OutgoingFee"].Value);
                        MemberStmInfo.IncomingAmount = Convert.ToDecimal(dgvSettlementLog.Rows[i].Cells["IncomingAmount"].Value);
                        MemberStmInfo.IncomingFee = Convert.ToDecimal(dgvSettlementLog.Rows[i].Cells["IncomingFee"].Value);
                        MemberStmInfo.SettlementDate = Convert.ToDateTime(dgvSettlementLog.Rows[i].Cells["STFDate"].Value);
                        STMCtrl.UpdateByMemberCode(MemberStmInfo);
                        string Eno=string.Empty;
                        string RCode=string.Empty;
                        if (MemberBankSettlementProcess(MemberStmInfo,out Eno,out RCode))
                        {
                            MemberStmInfo.Status = "S";
                        }
                        else
                            MemberStmInfo.Status = "F";

                        STMCtrl.UpdateByMemberCode(MemberStmInfo);
                        MPUSettlementStatusUpdate(i, MemberStmInfo.Status, Eno, MemberStmInfo.SettlementDate);
                        //  dgvSettlementLog.Rows[i].Cells["Status"].Value = MemberStmInfo.Status;
                        if (String.IsNullOrEmpty(Eno))
                            MessageBox.Show("Data Processing is Complete");
                        else if (MemberStmInfo.Status == "S")
                            MessageBox.Show("Data Processing is Successful." + Environment.NewLine + "Entry No is " + Eno);
                        else
                            MessageBox.Show("Data Processing is Fail." + Environment.NewLine + "Response Code is  " + RCode);
                        DataRetrieve();
                        MemberBankSettlementFieldsShow();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private bool MemberBankSettlementProcess(Settlement_InfoInfo mbstfinfo, out string Eno, out string RCODE)
        {
            Eno = string.Empty;
            RCODE = string.Empty;
            try
            {
                Settlement_InfoController mbstfctl = new Settlement_InfoController();
                Settlement_InfoInfo membstf = new Settlement_InfoInfo();
                string channel = "SETTLEMENT FILE";
                
                try
                {
                    mbstfctl.SettlementProcessForMemberBank(mbstfinfo, channel, out Eno, out RCODE);

                    if (RCODE == "06")
                        return false;
                    else
                        return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
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

                for (int i = 0; i < dgvSettlementLog.Rows.Count; i++)
                {
                    if (Convert.ToString(dgvSettlementLog.Rows[i].Cells["Approve"].Value) == "1" && Convert.ToString(dgvSettlementLog.Rows[i].Cells["FileType"].Value) == "MC")
                    {
                        MerchantStmInfo = new Settlement_InfoInfo();
                        MerchantStmInfo.MerchantCode = Convert.ToString(dgvSettlementLog.Rows[i].Cells["MerchantCode"].Value);
                        MerchantStmInfo.FileType = Convert.ToString(dgvSettlementLog.Rows[i].Cells["FileType"].Value);
                        MerchantStmInfo.SettlementDate = Convert.ToDateTime(dgvSettlementLog.Rows[i].Cells["STFDate"].Value);
                        MerchantStmInfo.Status = "R";
                        MerchantStmInfo.RejectBy = Dns.GetHostName();
                        IPHostEntry Ip = Dns.GetHostEntry(MerchantStmInfo.RejectBy);
                        MerchantStmInfo.RejectFrom = Ip.AddressList[0].ToString();
                        MCStmColl.Add(MerchantStmInfo);
                    }
                    else if (Convert.ToString(dgvSettlementLog.Rows[i].Cells["Approve"].Value) == "1" && Convert.ToString(dgvSettlementLog.Rows[i].Cells["FileType"].Value) == "MB")
                    {
                        MemberStmInfo = new Settlement_InfoInfo();
                        MemberStmInfo.MPUDfCode = Convert.ToString(dgvSettlementLog.Rows[i].Cells["MPUDfCode"].Value);
                        MemberStmInfo.FileType = Convert.ToString(dgvSettlementLog.Rows[i].Cells["FileType"].Value);
                        MemberStmInfo.SettlementDate = Convert.ToDateTime(dgvSettlementLog.Rows[i].Cells["STFDate"].Value);
                        MemberStmInfo.OutgoingAmoutSign = Convert.ToString(dgvSettlementLog.Rows[i].Cells["OutgoingAmountSign"].Value);
                        MemberStmInfo.OutgoingFeeSign = Convert.ToString(dgvSettlementLog.Rows[i].Cells["OutgoingFeeSign"].Value);
                        MemberStmInfo.IncomingAmountSign = Convert.ToString(dgvSettlementLog.Rows[i].Cells["IncomingAmountSign"].Value);
                        MemberStmInfo.IncomingFeeSign = Convert.ToString(dgvSettlementLog.Rows[i].Cells["IncomingFeeSign"].Value);
                        MemberStmInfo.SettlementCurrency = Convert.ToString(dgvSettlementLog.Rows[i].Cells["SettlementCurrency"].Value);

                        MemberStmInfo.OutgoingAmount = Convert.ToDecimal(dgvSettlementLog.Rows[i].Cells["OutgoingAmount"].Value);
                        MemberStmInfo.OutgoingFee = Convert.ToDecimal(dgvSettlementLog.Rows[i].Cells["OutgoingFee"].Value);
                        MemberStmInfo.IncomingAmount = Convert.ToDecimal(dgvSettlementLog.Rows[i].Cells["IncomingAmount"].Value);
                        MemberStmInfo.IncomingFee = Convert.ToDecimal(dgvSettlementLog.Rows[i].Cells["IncomingFee"].Value);
                        MemberStmInfo.SettlementDate = Convert.ToDateTime(dgvSettlementLog.Rows[i].Cells["STFDate"].Value);
                        MemberStmInfo.Status = "R";
                        MemberStmInfo.RejectBy = Dns.GetHostName();
                        IPHostEntry Ip = Dns.GetHostEntry(MemberStmInfo.RejectBy);
                        MemberStmInfo.RejectFrom = Ip.AddressList[0].ToString();
                        MBStmColl.Add(MemberStmInfo);
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
                if (MCStmColl.Count <= 0 || MBStmColl.Count <= 0)
                    MessageBox.Show("There is no row to process.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }
        private void ProcessInfo_Load(object sender, EventArgs e)
        {
            gpbFilter.Visible = false;
            ConfigChanger();
            DataRetrieve();
            GridConfiguration();
        }        
        private void chkCheckAll_CheckedChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < dgvSettlementLog.Rows.Count; i++)
            {
                dgvSettlementLog.Rows[i].Cells["Approve"].Value = chkCheckAll.Checked == true ? 1 : 0;
            }
        }
    }
}