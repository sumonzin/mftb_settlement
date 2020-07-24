using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Net;
using AppConfig;
using ACE.Banking.MPU.Businesslogic;
using ACE.Banking.MPU.CollectionSuit;
using System.Linq;

namespace SettlementFileProcess
{
    public partial class ProcessInfo : Form
    {
        private Settlement_InfoCollections _dataSource = new Settlement_InfoCollections();
        private DataTable dt = new DataTable();
        private DateTime GSettlementDate;

        public ProcessInfo()
        {
            InitializeComponent();

            //Select SOl_ID form Gam table
            Settlement_InfoController controller = new Settlement_InfoController();
           
        }

        #region Customize Events

        //private void MerchantSettlementFieldsShow()
        //{
        //    try
        //    {
        //        OutgoingAmountSign.Visible = false;
        //        OutgoingAmount.Visible = false;
        //        OutgoingFeeSign.Visible = false;
        //        OutgoingFee.Visible = false;
        //        STFAmountSign.Visible = false;
        //        STFAmount.Visible = false;
        //        STFFeeSign.Visible = false;
        //        STFFee.Visible = false;
        //        OutgoingSummary.Visible = false;

        //        MerchantCode.Visible = true;
        //        IncomingAmountSign.Visible = true;
        //        IncomingAmount.Visible = true;
        //        IncomingFeeSign.Visible = true;
        //        IncomingFee.Visible = true;
        //        IncomingSummary.Visible = true;
        //        TotalSTMAmtSign.Visible = true;
        //        TotalSTMAmt.Visible = true;
        //        IncomingSummary.Visible = true;
        //        SettlementCurrency.Visible = true;
        //        MerchantSTMAc.Visible = true;
        //        ReservedForUse.Visible = true;
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //    }
        //}

        //private void MemberBankSettlementFieldsShow()
        //{
        //    try
        //    {
        //        MPUDfCode.HeaderText = "Member Institution Code";

        //        OutgoingAmountSign.Visible = true;
        //        OutgoingAmount.Visible = true;
        //        OutgoingFeeSign.Visible = true;
        //        OutgoingFee.Visible = true;
        //        STFAmountSign.Visible = true;
        //        STFAmount.Visible = true;
        //        STFFeeSign.Visible = true;
        //        STFFee.Visible = true;
        //        OutgoingSummary.Visible = true;

        //        IncomingAmountSign.Visible = true;
        //        IncomingAmount.Visible = true;
        //        IncomingFeeSign.Visible = true;
        //        IncomingFee.Visible = true;
        //        IncomingSummary.Visible = true;
        //        SettlementCurrency.Visible = true;
        //        ReservedForUse.Visible = true;

        //        MerchantCode.Visible = false;
        //        MerchantSTMAc.Visible = false;
        //        TotalSTMAmtSign.Visible = false;
        //        TotalSTMAmt.Visible = false;
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //    }
        //}

        //private void Both()
        //{
        //    try
        //    {
        //        MPUDfCode.HeaderText = "MPU Code";

        //        OutgoingAmountSign.Visible = true;
        //        OutgoingAmount.Visible = true;
        //        OutgoingFeeSign.Visible = true;
        //        OutgoingFee.Visible = true;
        //        STFAmountSign.Visible = true;
        //        STFAmount.Visible = true;
        //        STFFeeSign.Visible = true;
        //        STFFee.Visible = true;
        //        OutgoingSummary.Visible = true;

        //        IncomingAmountSign.Visible = true;
        //        IncomingAmount.Visible = true;
        //        IncomingFeeSign.Visible = true;
        //        IncomingFee.Visible = true;
        //        IncomingSummary.Visible = true;
        //        SettlementCurrency.Visible = true;
        //        ReservedForUse.Visible = true;

        //        MerchantCode.Visible = true;
        //        MerchantSTMAc.Visible = true;
        //        TotalSTMAmtSign.Visible = true;
        //        TotalSTMAmt.Visible = true;
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //    }
        //}

       

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
               
            }
            catch (Exception ex)
            {
               
            }
        }

        private void DataRetrieve()
        {
            try
            {
                Settlement_InfoController STFCtrl = new Settlement_InfoController();
               // dgvSettlementLog.AutoGenerateColumns = false; 
                _dataSource = STFCtrl.SettlementInfo_SelectListForMemberBank_New("'" + "A" + "'" + "," + "'" + "F" + "'");
               // dgvSettlementLog.DataSource = _dataSource;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //private bool SettlementProcessControllerForMerchant(int rowindex, out string Eno)
        //{
        //    Eno = string.Empty;
        //    try
        //    {
        //        Settlement_InfoController StCtrl = new Settlement_InfoController();
        //        string AccountNo = string.Empty;
        //        char AmountSign = ' ';
        //        decimal Amount = 0;
        //        char FeeSign = ' ';
        //        decimal FeeAmount = 0;
        //        string TerminalNo = string.Empty;
        //        string MerchantCode = string.Empty;
        //        string _DateTime = string.Empty;
        //        string Currency = string.Empty;
        //        string RefEno = string.Empty;
        //        string RespCode = string.Empty;
        //        DateTime SettlementDate;

        //        AccountNo = Convert.ToString(dgvSettlementLog.Rows[rowindex].Cells["MerchantSTMAc"].Value);
        //        AmountSign = Convert.ToChar(dgvSettlementLog.Rows[rowindex].Cells["IncomingAmountSign"].Value);
        //        Amount = Convert.ToDecimal(dgvSettlementLog.Rows[rowindex].Cells["IncomingAmount"].Value);
        //        FeeSign = Convert.ToChar(dgvSettlementLog.Rows[rowindex].Cells["IncomingFeeSign"].Value);
        //        FeeAmount = Convert.ToDecimal(dgvSettlementLog.Rows[rowindex].Cells["IncomingFee"].Value);
        //        TerminalNo = "M0001";
        //        MerchantCode = Convert.ToString(dgvSettlementLog.Rows[rowindex].Cells["MerchantCode"].Value);
        //        _DateTime = Convert.ToString(DateTime.Now);
        //        Currency = Convert.ToString(dgvSettlementLog.Rows[rowindex].Cells["SettlementCurrency"].Value);
        //        Eno = string.Empty;
        //        SettlementDate = Convert.ToDateTime(dgvSettlementLog.Rows[rowindex].Cells["STFDATE"].Value);
        //        GSettlementDate = SettlementDate;

        //        if (!StCtrl.SettlementProcessForMerchant(AccountNo, AmountSign, Amount, FeeSign, FeeAmount, _DateTime, Currency, Eno, TerminalNo, MerchantCode, SettlementDate, out RefEno, out RespCode))
        //            throw new Exception("Settlement Process Fail for this account  No = > " + AccountNo);
        //        else
        //            MessageBox.Show("Settlement Process Success for this account  No = > " + AccountNo + Environment.NewLine + " Transaction No is = > " + RefEno);
        //        Eno = RefEno;

        //        //Select from Tlf by RefNo(or)Eno
        //        Settlement_UploadCollections settlement_UploadCollections = new Settlement_UploadCollections();
        //        settlement_UploadCollections = StCtrl.SelectFromTLF(Eno);

        //        //Insert into Settlement_Upload
        //        for (int i = 0; i < settlement_UploadCollections.Count; i++)
        //        {
        //            //Prepare data for Service_outlet

        //            if (settlement_UploadCollections[i].TranType == "Dr")
        //            {
        //                settlement_UploadCollections[i].ServiceOutlet = "1111";
        //            }
        //            else
        //            {
        //                //Select ServiceOutlet from Gam table

        //                var solid = "";
        //                if (settlement_UploadCollections[i].AccountNo != null)
        //                {
        //                    if (i == 0)
        //                    {
        //                        solid = StCtrl.SelectSolID_ByAccountNo(settlement_UploadCollections[i].AccountNo);
        //                        if (solid != null)
        //                        {
        //                            settlement_UploadCollections[i].ServiceOutlet = solid;
        //                        }
        //                        else
        //                        {
        //                            settlement_UploadCollections[i].ServiceOutlet = null;
        //                        }
        //                    }
        //                    else
        //                    {
        //                        if (settlement_UploadCollections[i].ENo.ToString().Trim() == settlement_UploadCollections[i - 1].ENo.ToString().Trim())
        //                        {
        //                            solid = StCtrl.SelectSolID_ByAccountNo(settlement_UploadCollections[0].AccountNo);
        //                            if (solid != null)
        //                            {
        //                                settlement_UploadCollections[i].ServiceOutlet = solid;
        //                            }
        //                            else
        //                            {
        //                                settlement_UploadCollections[i].ServiceOutlet = null;
        //                            }
        //                        }
        //                    }
        //                }
        //            }

        //            //Account No prepare
        //            if (settlement_UploadCollections[i].AccountNo.Length <= 6 && settlement_UploadCollections[i].AccountNo.Contains("AAC"))
        //            {
        //                settlement_UploadCollections[i].AccountNo = settlement_UploadCollections[i].ServiceOutlet.ToString().Trim() + "108910100001";
        //            }
        //            if (settlement_UploadCollections[i].AccountNo.Length <= 6 && settlement_UploadCollections[i].AccountNo.Contains("LAN"))
        //            {
        //                settlement_UploadCollections[i].AccountNo = settlement_UploadCollections[i].ServiceOutlet.ToString().Trim() + "400500100001";
        //            }

        //            //Insert into Settlemnt_Upload table
        //            StCtrl.InsertSettlementUpload(settlement_UploadCollections[i].AccountNo,
        //                                                    settlement_UploadCollections[i].CurrencyCode,
        //                                                    settlement_UploadCollections[i].ServiceOutlet,
        //                                                    settlement_UploadCollections[i].TranType,
        //                                                    settlement_UploadCollections[i].TranAmount,
        //                                                    settlement_UploadCollections[i].TranParticular,
        //                                                    settlement_UploadCollections[i].AccountRespCode,
        //                                                    "",
        //                                                    settlement_UploadCollections[i].InstrumentType,
        //                                                    settlement_UploadCollections[i].strInsdate,
        //                                                    settlement_UploadCollections[i].InstrumentAlpha,
        //                                                    settlement_UploadCollections[i].InstrumentNumber,
        //                                                    settlement_UploadCollections[i].NavigationFlat,
        //                                                    settlement_UploadCollections[i].TranAmount,
        //                                                    settlement_UploadCollections[i].CurrencyCode,
        //                                                    "",
        //                                                    null,
        //                                                    null,
        //                                                    settlement_UploadCollections[i].CategoryCode,
        //                                                    settlement_UploadCollections[i].ENo,
        //                                                    settlement_UploadCollections[i].Rate,
        //                                                    "MC");
        //        }

        //        return true;
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //        return false;
        //    }
        //}

        private void MPUSettlementStatusUpdate(string status, string eno, DateTime stfdate)
        {
            
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

        #endregion Customize Events

        private void merchantProcessOnlyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //MerchantSettlementFieldsShow();
            Settlement_InfoCollections MerchantdataSource = new Settlement_InfoCollections();
            for (int i = 0; i < _dataSource.Count; i++)
            {
                if (Convert.ToString(_dataSource[i].FileType) == "MC")
                {
                    Settlement_InfoInfo STInfo = _dataSource[i];
                    MerchantdataSource.Add(STInfo);
                }
            }
            //dgvSettlementLog.DataSource = MerchantdataSource;
        }

        private void memberBankProcessOnlyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //MemberBankSettlementFieldsShow();
            Settlement_InfoCollections MBdataSource = new Settlement_InfoCollections();
            for (int i = 0; i < _dataSource.Count; i++)
            {
                if (Convert.ToString(_dataSource[i].FileType) == "MB")
                {
                    Settlement_InfoInfo STInfo = _dataSource[i];
                    MBdataSource.Add(STInfo);
                }
            }
            //dgvSettlementLog.DataSource = MBdataSource;
        }

        private void bothMerchantMemberBankSettlementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Both();
        }

        //private void btnCheckAll_Click(object sender, EventArgs e)
        //{
        //    for (int i = 0; i < dgvSettlementLog.Rows.Count; i++)
        //    {
        //        dgvSettlementLog.Rows[i].Cells["Approve"].Value = 1;
        //    }
        //}

        //private void btnSearch_Click(object sender, EventArgs e)
        //{
        //    gpbFilter.Visible = true;
        //}

        //private void rdo_Click(object sender, EventArgs e)
        //{
        //    for (int i = 0; i < dgvSettlementLog.Rows.Count; i++)
        //    {
        //        if (Convert.ToString(dgvSettlementLog.Rows[i].Cells["MPUDfCode"].Value) == txtFilter.Text)
        //        {
        //            dgvSettlementLog.Rows[i].Selected = true;
        //        }
        //        else
        //            dgvSettlementLog.Rows[i].Selected = false;
        //    }
        //    gpbFilter.Visible = false;
        //}

        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataRetrieve();
            //Both();
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
                string _Eno = string.Empty;
                SequenceLog Seqlog = new SequenceLog();

                //for (int i = 0; i < dgvSettlementLog.Rows.Count; i++)
                //{
                    string hostname = Dns.GetHostName();
                    string myIP = Dns.GetHostByName(hostname).AddressList[0].ToString();
                    MemberStmInfo = new Settlement_InfoInfo();
                      
                        MemberStmInfo.Status = "A";
                        MemberStmInfo.ProcessFrom = myIP;

                //  MemberStmInfo.SettlementDate = Convert.ToDateTime(dgvSettlementLog.Rows[i].Cells["STFDate"].Value);
                //  STMCtrl.UpdateByMemberCode(MemberStmInfo); 
                 string Eno = string.Empty;
                 string RCode = string.Empty;
                MemberStmInfo.SettlementDate = clsGlobal.vSTFDate;
                        if (MemberBankSettlementProcess(MemberStmInfo, out Eno, out RCode))
                        {
                            MemberStmInfo.Status = "S";
                        }
                        else
                        {
                           MemberStmInfo.Status = "F";
                        }

                        STMCtrl.UpdateByMemberCode(MemberStmInfo);
                        MPUSettlementStatusUpdate(MemberStmInfo.Status, Eno, MemberStmInfo.SettlementDate);

                     #region IBFT
                // select all from member bank detail transcation
                IBFTController iBFTController = new IBFTController();
                iBFTController.BankAsAquirer();
                iBFTController.BankAsBefiniciaryOnly();
                iBFTController.BankAsIssuerOnly();
                IBFT_Request_model reqmodel = new IBFT_Request_model();
                reqmodel.Acq_Debit = iBFTController.acqDebit;
                reqmodel.Iss_Debit = iBFTController.ISS_Debit_Only;
                reqmodel.Iss_Credit = iBFTController.ISS_Credit_Only;
                reqmodel.Bene_Debit = iBFTController.Bene_Debit;
                reqmodel.Bene_Credit = iBFTController.Bene_Credit;
                reqmodel.IssandBene_Debit = iBFTController.Iss_Debit;
                reqmodel.IssandBene_Credit2 = iBFTController.Iss_Credit2;
                Settlement_InfoController IBFTcontroller = new Settlement_InfoController();
                IBFTcontroller.Insert_IBFT_SettlementUpload_call(reqmodel);
                #endregion

                       
                            //MessageBox.Show("Data Processing is Successful." + Environment.NewLine + "Entry No is " + Eno);

                            //Select Office Acc from Infosys DB for ATM ACQ process
                            Settlement_InfoController controller = new Settlement_InfoController();
                            OfficeACCfromInfosys data = new OfficeACCfromInfosys();

                            #region Variable Declaration
                            data.MPUSettlementAcc = "1111108910100001";
                            data.SundryAccComonATM = "1111300470100003";
                            data.ReceivableAcc = "1111108880100001";
                            data.ECOMPayableAcc = "1111703010100002";
                            data.SundryAccComonEcom = "1111300470100005";
                            data.SundryAccComonPOS = "1111300470100004";
                            data.POSandEcomCrdPayAcc = "1111703010100004";
                            data.PayableAcc = "1111703010100001";
                    #endregion

                            #region Select ATM ACQ Trans from Tlf

                    Settlement_UploadCollections SettlementCollection = new Settlement_UploadCollections();

                            SettlementCollection = controller.SelectFromtlf_ForATMACQ(Eno);

                            for (int j = 0; j < SettlementCollection.Count; j++)
                            {
                                #region Set Value for AccountNo/TranAmt/ServiceOutlet/TranAmt

                                if (SettlementCollection[j].TranType == "Dr" && SettlementCollection[j].AccountNo == "AAC001")
                                {
                                    SettlementCollection[j].Channel = "STFACQ";
                                    SettlementCollection[j].AccountNo = data.MPUSettlementAcc;
                                    SettlementCollection[j].TranAmount = SettlementCollection[j].TranAmount;
                                    SettlementCollection[j].ServiceOutlet = "1111";
                                }
                                else if (SettlementCollection[j].TranType == "Cr" && SettlementCollection[j].AccountNo == "ABB001")
                                {
                                    SettlementCollection[j].Channel = "STFACQ";
                                    SettlementCollection[j].AccountNo = data.MPUSettlementAcc;
                                    SettlementCollection[j].TranAmount = SettlementCollection[j].TranAmount;
                                    SettlementCollection[j].ServiceOutlet = "1111";
                                }
                                else if (SettlementCollection[j].TranType == "Cr" && SettlementCollection[j].AccountNo == "LAN001")
                                {
                                    SettlementCollection[j].Channel = "STFACQ";
                                    SettlementCollection[j].AccountNo = data.SundryAccComonATM;
                                    SettlementCollection[j].TranAmount = SettlementCollection[j].TranAmount;
                                    SettlementCollection[j].ServiceOutlet = "1111";
                                }
                                else if (SettlementCollection[j].TranType == "Dr" && SettlementCollection[j].AccountNo == "LAU001")
                                {
                                    SettlementCollection[j].Channel = "STFACQ";
                                    SettlementCollection[j].AccountNo = data.ReceivableAcc;
                                    SettlementCollection[j].TranAmount = SettlementCollection[j - 1].TranAmount - SettlementCollection[j].TranAmount;
                                    SettlementCollection[j].TranType = "Cr";
                                    SettlementCollection[j].ServiceOutlet = "1111";
                                }
                                else
                                {
                                    SettlementCollection[j].Channel = "STFACQ";
                                    SettlementCollection[j].ServiceOutlet = "1111";
                                    SettlementCollection[j].AccountNo = data.ReceivableAcc;
                                    SettlementCollection[j].TranAmount = SettlementCollection[j - 2].TranAmount - SettlementCollection[j].TranAmount;
                                }

                                #endregion Set Value for AccountNo/TranAmt/ServiceOutlet/TranAmt

                                #region Insert into Settlement_upload Table (CDB) (ACQ Trans)

                                if ((SettlementCollection[j].AccountNo == data.MPUSettlementAcc 
                                    && SettlementCollection[j].TranType == "Dr") 
                                    || SettlementCollection[j].AccountNo == data.SundryAccComonATM 
                                    || SettlementCollection[j].AccountNo == data.ReceivableAcc)
                                {
                                    controller.InsertSettlementUpload(SettlementCollection[j].AccountNo,
                                                          "MMK",
                                                          SettlementCollection[j].ServiceOutlet,
                                                          SettlementCollection[j].TranType,
                                                          SettlementCollection[j].TranAmount,
                                                          SettlementCollection[j].TranParticular,
                                                          SettlementCollection[j].AccountRespCode,
                                                          SettlementCollection[j].ReferenceNo,
                                                          SettlementCollection[j].InstrumentType,
                                                          SettlementCollection[j].strInsdate,
                                                          SettlementCollection[j].InstrumentAlpha,
                                                          SettlementCollection[j].InstrumentNumber,
                                                          SettlementCollection[j].NavigationFlat,
                                                          SettlementCollection[j].TranAmount,
                                                          "MMK",
                                                          SettlementCollection[j].RateCode,
                                                          null,
                                                          null,
                                                          SettlementCollection[j].CategoryCode,
                                                          SettlementCollection[j].ENo,
                                                          SettlementCollection[j].Rate,
                                                          SettlementCollection[j].Channel);
                                }

                                #endregion Insert into Settlement_upload Table (CDB) (ACQ Trans)
                            }

                            #endregion Select ATM ACQ Trans from Tlf

                            #region Select ISS Trans from Tlf

                            Settlement_Upload ThirdDataRecord = new Settlement_Upload();

                            Settlement_UploadCollections ISSDataCollection = new Settlement_UploadCollections();
                            ISSDataCollection = controller.SelectFromtlf_ForATMISS(Eno);

                            for (int k = 0; k < (ISSDataCollection.Count); k++)
                            {
                                //Prepare Data for Third Record
                                if (k == ISSDataCollection.Count - 1)
                                {
                                    ThirdDataRecord.AccountNo = data.ECOMPayableAcc;
                                    ThirdDataRecord.CurrencyCode = "MMK";
                                    ThirdDataRecord.ServiceOutlet = "1111";
                                    ThirdDataRecord.TranType = "Dr";
                                    ThirdDataRecord.TranAmount = ISSDataCollection[k - 1].TranAmount + ISSDataCollection[k].TranAmount;
                                    ThirdDataRecord.TranParticular = ISSDataCollection[k].TranParticular;
                                    ThirdDataRecord.AccountRespCode = ISSDataCollection[k].AccountRespCode;
                                    ThirdDataRecord.ReferenceNo = " ";
                                    ThirdDataRecord.InstrumentType = ISSDataCollection[k].InstrumentType;
                                    ThirdDataRecord.strInsdate = ISSDataCollection[k].strInsdate;
                                    ThirdDataRecord.InstrumentAlpha = ISSDataCollection[k].InstrumentAlpha;
                                    ThirdDataRecord.InstrumentNumber = ISSDataCollection[k].InstrumentNumber;
                                    ThirdDataRecord.NavigationFlat = ISSDataCollection[k].NavigationFlat;
                                    ThirdDataRecord.ReferenceAmount = ISSDataCollection[k].TranAmount;
                                    ThirdDataRecord.RefCurCode = "MMK";
                                    ThirdDataRecord.RateCode = " ";
                                    ThirdDataRecord.strValuedate = ISSDataCollection[k].strValuedate; //Settlement Date
                                    ThirdDataRecord.strGLDate = ISSDataCollection[k].strGLDate;
                                    ThirdDataRecord.CategoryCode = ISSDataCollection[k].CategoryCode;
                                    ThirdDataRecord.ENo = ISSDataCollection[k].ENo;
                                    ThirdDataRecord.Rate = ISSDataCollection[k].Rate;
                                    ThirdDataRecord.Channel = "STFISS";
                                }

                                if (ISSDataCollection[k].AccountNo == "LAB001" || ISSDataCollection[k].AccountNo == "LAN001")
                                {
                                    #region Insert ISS Trans into Settlement Upload

                                    if (ISSDataCollection[k].AccountNo == "LAB001" && ISSDataCollection[k].TranType == "Dr")
                                    {
                                        ISSDataCollection[k].AccountNo = data.MPUSettlementAcc;
                                        ISSDataCollection[k].ServiceOutlet = "1111";
                                        ISSDataCollection[k].Channel = "STFISS";
                                        ISSDataCollection[k].TranType = "Cr";
                                    }
                                    else if (ISSDataCollection[k].AccountNo == "LAN001" && ISSDataCollection[k].TranType == "Cr")
                                    {
                                        ISSDataCollection[k].AccountNo = data.SundryAccComonATM;
                                        ISSDataCollection[k].ServiceOutlet = "1111";
                                        ISSDataCollection[k].Channel = "STFISS";
                                        ISSDataCollection[k].TranType = "Cr";
                                    }

                                    controller.InsertSettlementUpload(ISSDataCollection[k].AccountNo,
                                                          "MMK",
                                                          ISSDataCollection[k].ServiceOutlet,
                                                          ISSDataCollection[k].TranType,
                                                          ISSDataCollection[k].TranAmount,
                                                          ISSDataCollection[k].TranParticular,
                                                          ISSDataCollection[k].AccountRespCode,

                                                          ISSDataCollection[k].ReferenceNo,
                                                          ISSDataCollection[k].InstrumentType,
                                                          ISSDataCollection[k].strInsdate,
                                                          ISSDataCollection[k].InstrumentAlpha,
                                                          ISSDataCollection[k].InstrumentNumber,
                                                          ISSDataCollection[k].NavigationFlat,
                                                          ISSDataCollection[k].TranAmount,
                                                          "MMK",

                                                          ISSDataCollection[k].RateCode,
                                                       
                                                          null, 
                                                          null,
                                                          ISSDataCollection[k].CategoryCode,
                                                          ISSDataCollection[k].ENo,
                                                          ISSDataCollection[k].Rate,
                                                          ISSDataCollection[k].Channel
                                                          );

                                    #endregion Insert ISS Trans into Settlement Upload
                                }
                            }

                            //Insert Third Trans Record for ATM ISS
                            controller.InsertSettlementUpload(ThirdDataRecord.AccountNo,
                                                         "MMK",
                                                         ThirdDataRecord.ServiceOutlet,
                                                         ThirdDataRecord.TranType,
                                                         ThirdDataRecord.TranAmount,
                                                         ThirdDataRecord.TranParticular,
                                                         ThirdDataRecord.AccountRespCode,
                                                         ThirdDataRecord.ReferenceNo,
                                                         ThirdDataRecord.InstrumentType,
                                                         ThirdDataRecord.strInsdate,
                                                         ThirdDataRecord.InstrumentAlpha,
                                                         ThirdDataRecord.InstrumentNumber,
                                                         ThirdDataRecord.NavigationFlat,
                                                         ThirdDataRecord.TranAmount,
                                                         "MMK",
                                                         "",                              
                                                         null,
                                                         null,
                                                         ThirdDataRecord.CategoryCode,
                                                         ThirdDataRecord.ENo,
                                                         ThirdDataRecord.Rate,
                                                         ThirdDataRecord.Channel);

                            #endregion Select ISS Trans from Tlf

                            #region ECOM Debit Trans from tlf

                            Settlement_Upload ISSECOMData = new Settlement_Upload();

                            Settlement_UploadCollections ISSECOMDataCollection = new Settlement_UploadCollections();
                            ISSECOMDataCollection = controller.SelectFromtlf_ForISSECOM(Eno);

                            for (int l = 0; l < (ISSECOMDataCollection.Count); l++)
                            {
                                //Prepare Data for ECOM Record
                                if (ISSECOMDataCollection[l].AccountNo == "LAB001")
                                {
                                    ISSECOMDataCollection[l].AccountNo = data.ECOMPayableAcc;
                                    ISSECOMDataCollection[l].Channel = "ECOMDr";
                                    ISSECOMDataCollection[l].ServiceOutlet = "1111";
                                }
                                else if (ISSECOMDataCollection[l].AccountNo == "AAC001")
                                {
                                    ISSECOMDataCollection[l].AccountNo = data.MPUSettlementAcc;
                                    ISSECOMDataCollection[l].Channel = "ECOMDr";
                                    ISSECOMDataCollection[l].ServiceOutlet = "1111";
                                }
                                else
                                {
                                    ISSECOMDataCollection[l].AccountNo = data.SundryAccComonEcom;
                                    ISSECOMDataCollection[l].Channel = "ECOMDr";
                                    ISSECOMDataCollection[l].ServiceOutlet = "1111";
                                }

                                controller.InsertSettlementUpload(ISSECOMDataCollection[l].AccountNo,
                                                      "MMK",
                                                      ISSECOMDataCollection[l].ServiceOutlet,
                                                      ISSECOMDataCollection[l].TranType,
                                                      ISSECOMDataCollection[l].TranAmount,
                                                      ISSECOMDataCollection[l].TranParticular,
                                                      ISSECOMDataCollection[l].AccountRespCode,
                                                      "",
                                                    
                                                      ISSECOMDataCollection[l].InstrumentType,
                                                      ISSECOMDataCollection[l].strInsdate,
                                                      ISSECOMDataCollection[l].InstrumentAlpha,
                                                      ISSECOMDataCollection[l].InstrumentNumber,
                                                      ISSECOMDataCollection[l].NavigationFlat,
                                                      ISSECOMDataCollection[l].TranAmount,
                                                      "MMK",
                                                      "",
                                                      null, 
                                                      null,
                                                      ISSECOMDataCollection[l].CategoryCode,
                                                      ISSECOMDataCollection[l].ENo,
                                                      ISSECOMDataCollection[l].Rate,
                                                      ISSECOMDataCollection[l].Channel
                                                      );
                            }

                            #endregion ECOM Debit Trans from tlf

                            #region POS Debit Transactions from TLF

                            Settlement_Upload ISSPOSData = new Settlement_Upload();

                            Settlement_UploadCollections ISSPOSDataCollection = new Settlement_UploadCollections();
                            ISSPOSDataCollection = controller.SelectFromtlf_ForISSPOS(Eno);

                            for (int h = 0; h < (ISSPOSDataCollection.Count); h++)
                            {
                                //Prepare Data for ECOM Record
                                if (ISSPOSDataCollection[h].AccountNo == "LAB001")
                                {
                                    ISSPOSDataCollection[h].AccountNo = data.ECOMPayableAcc;
                                    ISSPOSDataCollection[h].Channel = "POSDr";
                                    ISSPOSDataCollection[h].ServiceOutlet = "1111";
                                }
                                else if (ISSPOSDataCollection[h].AccountNo == "AAC001")
                                {
                                    ISSPOSDataCollection[h].AccountNo = data.MPUSettlementAcc;
                                    ISSPOSDataCollection[h].Channel = "POSDr";
                                    ISSPOSDataCollection[h].ServiceOutlet = "1111";
                                }
                                else
                                {
                                    ISSPOSDataCollection[h].AccountNo = data.SundryAccComonPOS;
                                    ISSPOSDataCollection[h].Channel = "POSDr";
                                    ISSPOSDataCollection[h].ServiceOutlet = "1111";
                                }

                                controller.InsertSettlementUpload(ISSPOSDataCollection[h].AccountNo,
                                                      "MMK",
                                                      ISSPOSDataCollection[h].ServiceOutlet,
                                                      ISSPOSDataCollection[h].TranType,
                                                      ISSPOSDataCollection[h].TranAmount,
                                                      ISSPOSDataCollection[h].TranParticular,
                                                      ISSPOSDataCollection[h].AccountRespCode,
                                                      "",
                                                      ISSPOSDataCollection[h].InstrumentType,
                                                      ISSPOSDataCollection[h].strInsdate,
                                                      ISSPOSDataCollection[h].InstrumentAlpha,
                                                      ISSPOSDataCollection[h].InstrumentNumber,
                                                      ISSPOSDataCollection[h].NavigationFlat,
                                                      ISSPOSDataCollection[h].TranAmount,
                                                      "MMK",
                                                      "",         
                                                      null,  
                                                      null,
                                                      ISSPOSDataCollection[h].CategoryCode,
                                                      ISSPOSDataCollection[h].ENo,
                                                      ISSPOSDataCollection[h].Rate,
                                                      ISSPOSDataCollection[h].Channel
                                                      );
                            }

                    #endregion POS Debit Transactions from TLF

                            #region Select Direct POS Merchant
                          DirPOSCollections Resmodel = new DirPOSCollections();
                          DirPOSCollections Pos_Collection = new DirPOSCollections();
                            DirPOSCollections Pos_normal_Collection = new DirPOSCollections();
                            var test = MemberStmInfo.SettlementDate.ToString("yyyy/MM/dd");
                            Pos_normal_Collection = controller.Select_DirPOS_Trans(test);

                            if (Pos_normal_Collection.Count > 0)
                            {
                                for (int p = 0; p < Pos_normal_Collection.Count; p++)
                                 {
                                     Console.WriteLine("Opening the connection time : " + p);
                                     var com_result = controller.Select_CommisionRate_ByMerchantID(Pos_normal_Collection[p].CardAcceptorIDCode).ToString();
                                    if(com_result == "0.40")
                                    {
                                        MemberBankDetailInfo merchant3 = new MemberBankDetailInfo();
                                        merchant3.AcquireInstitutionID = Pos_normal_Collection[p].AcquireInstitutionID;
                                        merchant3.CardAcceptorIDCode = Pos_normal_Collection[p].CardAcceptorIDCode;
                                        merchant3.FileName = Pos_normal_Collection[p].FileName;
                                        merchant3.FileType = Pos_normal_Collection[p].FileType;
                                        merchant3.MerchantType = Pos_normal_Collection[p].MerchantType;
                                        merchant3.MessageType = Pos_normal_Collection[p].MessageType;
                                        merchant3.PAN = Pos_normal_Collection[p].PAN;
                                        merchant3.ProcessingCode = Pos_normal_Collection[p].ProcessingCode;
                                        merchant3.RefundStatus = Pos_normal_Collection[p].RefundStatus;
                                        merchant3.ServiceFeePayable = Pos_normal_Collection[p].ServiceFeePayable;
                                        merchant3.ServiceFeeReceive = Pos_normal_Collection[p].ServiceFeeReceive;
                                        merchant3.SettlememtAmt = Pos_normal_Collection[p].SettlememtAmt;
                                        merchant3.TranAmt = Pos_normal_Collection[p].TranAmt;
                                        merchant3.TranResponseCode = Pos_normal_Collection[p].TranResponseCode;
                                        Pos_Collection.Add(merchant3);
                                    }
                                    else
                                    {
                                        MemberBankDetailInfo merchantnormal = new MemberBankDetailInfo();
                                        merchantnormal.AcquireInstitutionID = Pos_normal_Collection[p].AcquireInstitutionID;
                                        merchantnormal.CardAcceptorIDCode = Pos_normal_Collection[p].CardAcceptorIDCode;
                                        merchantnormal.FileName = Pos_normal_Collection[p].FileName;
                                        merchantnormal.FileType = Pos_normal_Collection[p].FileType;
                                        merchantnormal.MerchantType = Pos_normal_Collection[p].MerchantType;
                                        merchantnormal.MessageType = Pos_normal_Collection[p].MessageType;
                                        merchantnormal.PAN = Pos_normal_Collection[p].PAN;
                                        merchantnormal.ProcessingCode = Pos_normal_Collection[p].ProcessingCode;
                                        merchantnormal.RefundStatus = Pos_normal_Collection[p].RefundStatus;
                                        merchantnormal.ServiceFeePayable = Pos_normal_Collection[p].ServiceFeePayable;
                                        merchantnormal.ServiceFeeReceive = Pos_normal_Collection[p].ServiceFeeReceive;
                                        merchantnormal.SettlememtAmt = Pos_normal_Collection[p].SettlememtAmt;
                                        merchantnormal.TranAmt = Pos_normal_Collection[p].TranAmt;
                                        merchantnormal.TranResponseCode = Pos_normal_Collection[p].TranResponseCode;
                                        Resmodel.Add(merchantnormal);
                                    }
                                }

                            }


                            Seqlog.TraceLog("Select_DirPOS_Trans Complete=> " + test, "INC01C");
                            //select all Merchant Rate
                            MerchantRateCollections MerchantRateCollections = new MerchantRateCollections();
                            MerchantRateCollections = controller.SelectAll_Merchant_Rate();
                            Seqlog.TraceLog("SelectAll_Merchant_Rate Complete= >" + DateTime.Now, "INC01C");
                    #endregion

                            #region For Normal POS Merchant
                    if (Resmodel.Count > 0)
                            {
                                for (int j = 0; j < Resmodel.Count; j++)
                                {
                                    DIR_POS_Record MerchantInfo = new DIR_POS_Record();
                                    MerchantInfo.MerchantID = Resmodel[j].CardAcceptorIDCode;
                                    Seqlog.TraceLog("Before Compare With MerchantID= >" + DateTime.Now, "INC01C");
                                    var DetailInfo = MerchantRateCollections.Where(x => x.MerchantID == Resmodel[j].CardAcceptorIDCode).ToList();
                                    Seqlog.TraceLog("After Compare With MerchantID= >" + DateTime.Now, "INC01C");
                                    //Need to modify (0.6% for 5555 and 1% for 4444)

                                    if (DetailInfo[0].MerchantID != null)
                                    {
                                        MerchantInfo.MerchantRate = Convert.ToDecimal(DetailInfo[0].Rate);
                                    }
                                    else
                                    {
                                        Seqlog.TraceLog("MerchantID compare process is null.= >" + DateTime.Now, "INC01C");
                                    }
                                    MerchantInfo.TranAmt = Convert.ToDecimal(Resmodel[j].TranAmt) / 100;
                                    MerchantInfo.ServiceFeePayable = Convert.ToDecimal(Resmodel[j].ServiceFeePayable) / 100;

                                    if (Convert.ToDecimal(MerchantInfo.ServiceFeePayable) == 0)
                                    {
                                        MerchantInfo.ServiceFeeReceive = Convert.ToDecimal(Resmodel[j].ServiceFeeReceive) / 100;
                                        MerchantInfo.CashAdvReceive = MerchantInfo.ServiceFeeReceive;
                                    }
                                    else
                                    {
                                        MerchantInfo.ServiceFeeReceive = (MerchantInfo.TranAmt * MerchantInfo.MerchantRate) / 100;
                                        MerchantInfo.CashAdvReceive = 0;
                                    }
                                    MerchantInfo.MerchantType = Resmodel[j].MerchantType;
                                    MerchantInfo.STFDate = Convert.ToDateTime(test);

                                    //Insert into POS_ACQ_Merchant_tlf
                                    controller.Insert_DirPoS(MerchantInfo);
                                    Seqlog.TraceLog("Insert_DirPoS process is successful.= >" + DateTime.Now, "INC01C");

                                } //end of loop

                                //select summary Value from POS_ACQ_Merchant_tlf Table only for one Voucher
                                DIR_POS_Record sum_result = new DIR_POS_Record();
                                sum_result = controller.Select_Sum_DirPOS_Trans(test);
                                Seqlog.TraceLog("Select_Sum_DirPOS_Trans is successful.= >" + DateTime.Now, "INC01C");
                                sum_memB_record sum_Mem_result = new sum_memB_record();
                                sum_Mem_result = controller.Select_Sum_MemberBankDirPOS_Trans(test);
                                Seqlog.TraceLog("Select_Sum_MemberBankDirPOS_Trans is successful.= >" + DateTime.Now, "INC01C");

                                var Dr_Amt = sum_Mem_result.DebitAmt;
                                var Cr_Amt = sum_result.ServiceFeeReceive - sum_result.ServiceFeePayable;
                                var Cr2_Amt = sum_Mem_result.Credit2Amt - Cr_Amt;
                                Seqlog.TraceLog("After Amount Calculation is successful.= >" + DateTime.Now, "INC01C");

                                //Insert into Merchant Settlement upload
                                if (sum_result.TranAmt != 0 || sum_result.ServiceFeePayable != 0 || sum_result.ServiceFeeReceive != 0)
                                {
                                    //Dr (TranAmt - ServiceFeePayable)
                                    controller.InsertSettlementUpload("1111108910100001","MMK","1111","D", Dr_Amt,null,null,null,null,null,
                                                          null,null,null,Dr_Amt,"MMK",null,null,null,null,Eno,0,"Dir_POS");

                                    //Cr = ServiceFeeRecieve - ServiceFeePayable
                                    controller.InsertSettlementUpload("1111300470100004","MMK","1111","C",Cr_Amt,null,null,null,null,
                                                          null, null,null,null,Cr_Amt,"MMK",null,null,null,null,Eno,0,"Dir_POS");

                                    //Cr = TranAmt - ServiceFeeRecieve
                                    controller.InsertSettlementUpload("1111108660020002","MMK","1111","C",Cr2_Amt,null,null, null,null,null,
                                                          null,null, null,Cr2_Amt,"MMK",null,null,null,null,Eno,0,"Dir_POS");

                                    Seqlog.TraceLog("InsertSettlementUpload is successful.= >" + DateTime.Now, "INC01C");
                                }

                                MessageBox.Show("Direct POS process is Successful.");
                            }
                            else
                            {
                                //log for no record                               
                                Seqlog.TraceLog("No Data For Direct POs merchant = >" + DateTime.Now, "INC01C");
                            }
                            #endregion

                            #region  For 0.4 Merchant 
                            if (Pos_Collection.Count > 0)
                            {
                                for (int l = 0; l < Pos_Collection.Count; l++)
                                {
                                    DIR_POS_Record MerchantInfo_3 = new DIR_POS_Record();
                                    MerchantInfo_3.MerchantID = Pos_Collection[l].CardAcceptorIDCode;
                                    Seqlog.TraceLog("Before Compare With MerchantID= >" + DateTime.Now, "INC01C");
                                    var DetailInfo = MerchantRateCollections.Where(x => x.MerchantID == Pos_Collection[l].CardAcceptorIDCode).ToList();
                                    Seqlog.TraceLog("After Compare With MerchantID= >" + DateTime.Now, "INC01C");

                                    if (DetailInfo[0].MerchantID != null)
                                    {
                                        MerchantInfo_3.MerchantRate = Convert.ToDecimal(DetailInfo[0].Rate);
                                    }
                                    else
                                    {
                                        Seqlog.TraceLog("MerchantID compare process is null.= >" + DateTime.Now, "INC01C");
                                    }
                                    MerchantInfo_3.TranAmt = Convert.ToDecimal(Pos_Collection[l].TranAmt) / 100;
                                    MerchantInfo_3.ServiceFeePayable = Convert.ToDecimal(Pos_Collection[l].ServiceFeePayable) / 100;

                                    if (Convert.ToDecimal(MerchantInfo_3.ServiceFeePayable) == 0)
                                    {
                                        MerchantInfo_3.ServiceFeeReceive = Convert.ToDecimal(Pos_Collection[l].ServiceFeeReceive) / 100;
                                        MerchantInfo_3.CashAdvReceive = MerchantInfo_3.ServiceFeeReceive;
                                    }
                                    else
                                    {
                                        MerchantInfo_3.ServiceFeeReceive = (MerchantInfo_3.TranAmt * MerchantInfo_3.MerchantRate) / 100;
                                        MerchantInfo_3.CashAdvReceive = 0;
                                    }
                                    MerchantInfo_3.MerchantType = Pos_Collection[l].MerchantType;
                                    MerchantInfo_3.STFDate = Convert.ToDateTime(test);

                                    //Insert into POS_ACQ_Merchant_tlf
                                    controller.Insert_DirPoS(MerchantInfo_3);
                                    Seqlog.TraceLog("Insert_DirPoS_0.3Merchant process is successful.= >" + DateTime.Now, "INC01C");
                                   
                                }

                                //select summary Value from POS_ACQ_Merchant_tlf Table only for one Voucher
                                DIR_POS_Record sum_result = new DIR_POS_Record();
                                sum_result = controller.Select_Sum_DirPOS_Trans_03(test);
                                Seqlog.TraceLog("Select_Sum_DirPOS_Trans_03 is successful.= >" + DateTime.Now, "INC01C");
                                sum_memB_record sum_Mem_result = new sum_memB_record();
                                sum_Mem_result = controller.Select_Sum_MemberBankDirPOS_Trans_3merchant(test);
                                Seqlog.TraceLog("Select_Sum_MemberBankDirPOS_Trans_03 is successful.= >" + DateTime.Now, "INC01C");

                                var Dr_Amt = sum_Mem_result.DebitAmt;
                                var Cr_Amt = sum_result.ServiceFeeReceive - sum_result.ServiceFeePayable;
                                var Cr2_Amt = sum_Mem_result.Credit2Amt - Cr_Amt;

                                Seqlog.TraceLog("After Amount Calculation is successful.= >" + DateTime.Now, "INC01C");

                                if (sum_result.TranAmt != 0 || sum_result.ServiceFeePayable != 0 || sum_result.ServiceFeeReceive != 0)
                                {
                                    //Dr (TranAmt - ServiceFeePayable)
                                    controller.InsertSettlementUpload("1111108910100001", "MMK", "1111", "D", Dr_Amt, null, null, null, null, null,
                                                          null, null, null, Dr_Amt, "MMK", null, null, null, null, Eno, 0, "03_POS");

                                    //Cr = TranAmt - ServiceFeeRecieve
                                    controller.InsertSettlementUpload("1111108660020002", "MMK", "1111", "C", Dr_Amt, null, null, null, null, null,
                                                          null, null, null, Dr_Amt, "MMK", null, null, null, null, Eno, 0, "03_POS");

                                    Seqlog.TraceLog("InsertSettlementUpload for 03_POS Merchant is successful.= >" + DateTime.Now, "INC01C");
                                }

                                MessageBox.Show("Point 03 POS process is Successful.");
                            }

                            #endregion
  
                        //}
                      /*  else
                        {
                            MessageBox.Show("Data Processing is Fail." + Environment.NewLine + "Response Code is  " + RCode);
                        }*/

                        DataRetrieve();
                        //MemberBankSettlementFieldsShow();
                    //}
                //}
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

        //private void btnReject_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        Settlement_InfoController STMCtrl = new Settlement_InfoController();
        //        Settlement_InfoCollections MBStmColl = new Settlement_InfoCollections();
        //        Settlement_InfoCollections MCStmColl = new Settlement_InfoCollections();
        //        Settlement_InfoInfo MerchantStmInfo;
        //        Settlement_InfoInfo MemberStmInfo;

        //        for (int i = 0; i < dgvSettlementLog.Rows.Count; i++)
        //        {
        //            if (Convert.ToString(dgvSettlementLog.Rows[i].Cells["Approve"].Value) == "1" && Convert.ToString(dgvSettlementLog.Rows[i].Cells["FileType"].Value) == "MC")
        //            {
        //                MerchantStmInfo = new Settlement_InfoInfo();
        //                MerchantStmInfo.MerchantCode = Convert.ToString(dgvSettlementLog.Rows[i].Cells["MerchantCode"].Value);
        //                MerchantStmInfo.FileType = Convert.ToString(dgvSettlementLog.Rows[i].Cells["FileType"].Value);
        //                MerchantStmInfo.SettlementDate = Convert.ToDateTime(dgvSettlementLog.Rows[i].Cells["STFDate"].Value);
        //                MerchantStmInfo.Status = "R";
        //                MerchantStmInfo.RejectBy = Dns.GetHostName();
        //                IPHostEntry Ip = Dns.GetHostEntry(MerchantStmInfo.RejectBy);
        //                MerchantStmInfo.RejectFrom = Ip.AddressList[0].ToString();
        //                MCStmColl.Add(MerchantStmInfo);
        //            }
        //            else if (Convert.ToString(dgvSettlementLog.Rows[i].Cells["Approve"].Value) == "1" && Convert.ToString(dgvSettlementLog.Rows[i].Cells["FileType"].Value) == "MB")
        //            {
        //                MemberStmInfo = new Settlement_InfoInfo();
        //                MemberStmInfo.MPUDfCode = Convert.ToString(dgvSettlementLog.Rows[i].Cells["MPUDfCode"].Value);
        //                MemberStmInfo.FileType = Convert.ToString(dgvSettlementLog.Rows[i].Cells["FileType"].Value);
        //                MemberStmInfo.SettlementDate = Convert.ToDateTime(dgvSettlementLog.Rows[i].Cells["STFDate"].Value);
        //                MemberStmInfo.OutgoingAmoutSign = Convert.ToString(dgvSettlementLog.Rows[i].Cells["OutgoingAmountSign"].Value);
        //                MemberStmInfo.OutgoingFeeSign = Convert.ToString(dgvSettlementLog.Rows[i].Cells["OutgoingFeeSign"].Value);
        //                MemberStmInfo.IncomingAmountSign = Convert.ToString(dgvSettlementLog.Rows[i].Cells["IncomingAmountSign"].Value);
        //                MemberStmInfo.IncomingFeeSign = Convert.ToString(dgvSettlementLog.Rows[i].Cells["IncomingFeeSign"].Value);
        //                MemberStmInfo.SettlementCurrency = Convert.ToString(dgvSettlementLog.Rows[i].Cells["SettlementCurrency"].Value);

        //                MemberStmInfo.OutgoingAmount = Convert.ToDecimal(dgvSettlementLog.Rows[i].Cells["OutgoingAmount"].Value);
        //                MemberStmInfo.OutgoingFee = Convert.ToDecimal(dgvSettlementLog.Rows[i].Cells["OutgoingFee"].Value);
        //                MemberStmInfo.IncomingAmount = Convert.ToDecimal(dgvSettlementLog.Rows[i].Cells["IncomingAmount"].Value);
        //                MemberStmInfo.IncomingFee = Convert.ToDecimal(dgvSettlementLog.Rows[i].Cells["IncomingFee"].Value);
        //                MemberStmInfo.SettlementDate = Convert.ToDateTime(dgvSettlementLog.Rows[i].Cells["STFDate"].Value);
        //                MemberStmInfo.Status = "R";
        //                MemberStmInfo.RejectBy = Dns.GetHostName();
        //                IPHostEntry Ip = Dns.GetHostEntry(MemberStmInfo.RejectBy);
        //                MemberStmInfo.RejectFrom = Ip.AddressList[0].ToString();
        //                MBStmColl.Add(MemberStmInfo);
        //            }
        //        }
        //        if (MBStmColl.Count > 0)
        //        {
        //            STMCtrl.UpdateByMemberCode(MBStmColl);
        //            DataRetrieve();
        //            MerchantSettlementFieldsShow();
        //        }
        //        if (MCStmColl.Count > 0)
        //        {
        //            STMCtrl.UpdateByMerchantCode(MCStmColl);
        //            DataRetrieve();
        //            MemberBankSettlementFieldsShow();
        //        }
        //        if (MCStmColl.Count <= 0 || MBStmColl.Count <= 0)
        //            MessageBox.Show("There is no row to process.");
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //    }
        //}

        private void ProcessInfo_Load(object sender, EventArgs e)
        {
           // gpbFilter.Visible = false;
            ConfigChanger();
            DataRetrieve();
            //GridConfiguration();
        }

        //private void chkCheckAll_CheckedChanged(object sender, EventArgs e)
        //{
        //    for (int i = 0; i < dgvSettlementLog.Rows.Count; i++)
        //    {
        //        dgvSettlementLog.Rows[i].Cells["Approve"].Value = chkCheckAll.Checked == true ? 1 : 0;
        //    }
        //}

        private void btnImport_Click(object sender, EventArgs e)
        {
            Settlement_InfoController Ctrl = new Settlement_InfoController();
            Settlement_UploadCollections settlement_UploadCollections = new Settlement_UploadCollections();
            settlement_UploadCollections = Ctrl.Select_Settlement_Upload();
            //CreateTempTable();

            dt = ConvertToDataTable(settlement_UploadCollections);

            string filename = "SettlementUpload_IST.TXT";
            string sPathName = @"D:\SettlementUploadFiles_IST\";
            sPathName = System.IO.Path.Combine(sPathName, System.DateTime.Now.ToString("ddMMyyyy"));

            System.IO.Directory.CreateDirectory(sPathName);
            sPathName = System.IO.Path.Combine(sPathName, filename);

            SequenceLog Seqlog = new SequenceLog();
            StreamWriter sw = null;
            sw = new StreamWriter(sPathName, false);

            #region Manually

            string line = "";

            foreach (DataRow dr in this.dt.Rows)
            {

                line = dr[0].ToString().PadLeft(16, ' ')
                    + dr[1].ToString().PadLeft(3, ' ')
                    + dr[2].ToString().PadLeft(8, ' ')
                    + dr[3].ToString().PadLeft(1, ' ')//NA
                    + dr[4].ToString().PadRight(17, ' ')//

                    + dr[5].ToString().PadLeft(30, ' ')//Tran_Particular
                    + dr[6].ToString().PadLeft(5, ' ')//Acc_Report_Code
                    + dr[7].ToString().PadLeft(20, ' ')//Ref_Number
                    + dr[8].ToString().PadLeft(5, ' ')//Ins_Type
                    + dr[9].ToString().PadLeft(10, ' ')//Ins_Date

                    + dr[10].ToString().PadLeft(6, ' ')//Ins_Alpha
                    + dr[11].ToString().PadLeft(16, ' ')//Ins_Number
                    + dr[12].ToString().PadLeft(1, ' ')//NA  Nav_Flag
                    + dr[13].ToString().PadRight(17, ' ')//Ref_Amount
                    + dr[14].ToString().PadLeft(3, ' ')//Ref_CurCode

                    + dr[15].ToString().PadLeft(5, ' ')//Rate_Code  (-)
                    + dr[17].ToString().PadRight(15, ' ')//Rate
                    + dr[18].ToString().PadLeft(10, ' ')//Value_Date
                    + dr[19].ToString().PadLeft(10, ' ')//GL_Date
                    + dr[19].ToString().PadLeft(5, ' ')//GL_Date

                    + dr[19].ToString().PadLeft(6, ' ')//GL_Date
                    + dr[19].ToString().PadLeft(6, ' ')//GL_Date
                    + dr[19].ToString().PadLeft(2, ' ')//GL_Date
                    + dr[19].ToString().PadLeft(1, ' ')//GL_Date
                    + dr[19].ToString().PadLeft(12, ' ')//GL_Date

                    + dr[19].ToString().PadLeft(10, ' ')//GL_Date
                    + dr[19].ToString().PadLeft(20, ' ')//GL_Date
                    + dr[19].ToString().PadLeft(5, ' ')//GL_Date
                    + dr[19].ToString().PadLeft(30, ' ')//GL_Date
                    + dr[19].ToString().PadLeft(40, ' ')//GL_Date

                    + dr[19].ToString().PadLeft(40, ' ')//GL_Date
                    + dr[19].ToString().PadLeft(40, ' ')//GL_Date
                    + dr[19].ToString().PadLeft(40, ' ')//GL_Date
                    + dr[19].ToString().PadLeft(40, ' ')//GL_Date
                    + dr[19].ToString().PadLeft(17, ' ')//GL_Date

                    + dr[19].ToString().PadLeft(17, ' ')//GL_Date
                    + dr[19].ToString().PadLeft(17, ' ')//GL_Date
                    + dr[19].ToString().PadLeft(17, ' ')//GL_Date
                    + dr[19].ToString().PadLeft(17, ' ')//GL_Date

                    + dr[19].ToString().PadLeft(30, ' ')//GL_Date
                    + dr[19].ToString().PadLeft(16, ' ')//GL_Date
                    + dr[19].ToString().PadLeft(12, ' ')//GL_Date
                    + dr[19].ToString().PadLeft(10, ' ')//GL_Date
                    + dr[19].ToString().PadLeft(10, ' ')//GL_Date

                    + dr[19].ToString().PadLeft(9, ' ')//GL_Date
                    + dr[19].ToString().PadLeft(4, ' ')//GL_Date
                    + dr[19].ToString().PadLeft(256, ' ')//GL_Date
                    + dr[19].ToString().PadLeft(16, ' ')//GL_Date
                    + dr[19].ToString().PadLeft(5, ' ')//GL_Date

                    + dr[19].ToString().PadLeft(5, ' ')//GL_Date
                    + dr[19].ToString().PadLeft(5, ' ')//GL_Date
                    + dr[19].ToString().PadLeft(50, ' ')//GL_Date

                    + System.Environment.NewLine;

                sw.Write(line);
            }
            sw.Dispose();

            #endregion Manually

            MessageBox.Show("Export Successful");

            //Delete Gam
            Ctrl.DeleteGam();

            
        }

        public DataTable ConvertToDataTable<T>(IList<T> data)
        {
            PropertyDescriptorCollection properties =
               TypeDescriptor.GetProperties(typeof(T));
            DataTable table = new DataTable();
            foreach (PropertyDescriptor prop in properties)
                table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
            foreach (T item in data)
            {
                DataRow row = table.NewRow();
                foreach (PropertyDescriptor prop in properties)
                    row[prop.Name] = prop.GetValue(item) ?? DBNull.Value;
                table.Rows.Add(row);
            }
            return table;
        }

        private void CreateTempTable()
        {
            dt = new System.Data.DataTable();

            dt.Columns.Add(new DataColumn("Acc_No", typeof(System.String)));//7
            dt.Columns.Add(new DataColumn("Currency_Code", typeof(System.String)));//16
            dt.Columns.Add(new DataColumn("Service_Outlet", typeof(System.String)));//3
            dt.Columns.Add(new DataColumn("Part_Tran_Type", typeof(System.String)));//8
            dt.Columns.Add(new DataColumn("Tran_Amount", typeof(System.String)));//1

            dt.Columns.Add(new DataColumn("Tran_Particular", typeof(System.Decimal)));//17
            dt.Columns.Add(new DataColumn("Acc_Report_Code", typeof(System.String)));//30
            dt.Columns.Add(new DataColumn("Ref_Number", typeof(System.String)));//5
            dt.Columns.Add(new DataColumn("Ins_Type", typeof(System.String)));//20
            dt.Columns.Add(new DataColumn("Ins_Date", typeof(System.String)));//5

            dt.Columns.Add(new DataColumn("Ins_Alpha", typeof(System.String)));//10
            dt.Columns.Add(new DataColumn("Ins_Number", typeof(System.String)));//6
            dt.Columns.Add(new DataColumn("Nav_Flag", typeof(System.String)));//16
            dt.Columns.Add(new DataColumn("Ref_Amount", typeof(System.String)));//1
            dt.Columns.Add(new DataColumn("Ref_CurCode", typeof(System.Decimal)));
            //17
            dt.Columns.Add(new DataColumn("Rate_Code", typeof(System.String)));//3
            dt.Columns.Add(new DataColumn("Rate", typeof(System.String)));//5
            dt.Columns.Add(new DataColumn("Value_Date", typeof(System.String)));//15
            dt.Columns.Add(new DataColumn("GL_Date", typeof(System.String)));//10
        }
    }
}