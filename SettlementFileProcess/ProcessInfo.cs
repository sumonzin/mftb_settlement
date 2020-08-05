namespace SettlementFileProcess
{
    using ACE.Banking.MPU.Businesslogic;
    using ACE.Banking.MPU.CollectionSuit;
    using AppConfig;
    using Microsoft.VisualStudio.Data;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Runtime.InteropServices;
    using System.Windows.Forms;
    using Excel = Microsoft.Office.Interop.Excel;

    /// <summary>
    /// Defines the <see cref="ProcessInfo" />.
    /// </summary>
    public partial class ProcessInfo : Form
    {
        /// <summary>
        /// Defines the _dataSource.
        /// </summary>
        private Settlement_InfoCollections _dataSource = new Settlement_InfoCollections();

        /// <summary>
        /// Defines the dt.
        /// </summary>
        private DataTable dt = new DataTable();

        /// <summary>
        /// Defines the GSettlementDate.
        /// </summary>
        private DateTime GSettlementDate;

        /// <summary>
        /// Initializes a new instance of the <see cref="ProcessInfo"/> class.
        /// </summary>
        public ProcessInfo()
        {
            InitializeComponent();

            //Select SOl_ID form Gam table
            Settlement_InfoController controller = new Settlement_InfoController();
        }

        /// <summary>
        /// The ConfigChanger.
        /// </summary>
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

        /// <summary>
        /// The DataRetrieve.
        /// </summary>
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

        /// <summary>
        /// The MPUSettlementStatusUpdate.
        /// </summary>
        /// <param name="status">The status<see cref="string"/>.</param>
        /// <param name="eno">The eno<see cref="string"/>.</param>
        /// <param name="stfdate">The stfdate<see cref="DateTime"/>.</param>
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

        /// <summary>
        /// The MPU_Settlement_InfoDelete.
        /// </summary>
        /// <param name="stfdata">The stfdata<see cref="DateTime"/>.</param>
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

        /// <summary>
        /// The merchantProcessOnlyToolStripMenuItem_Click.
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/>.</param>
        /// <param name="e">The e<see cref="EventArgs"/>.</param>
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
        }

        /// <summary>
        /// The memberBankProcessOnlyToolStripMenuItem_Click.
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/>.</param>
        /// <param name="e">The e<see cref="EventArgs"/>.</param>
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
        }

        /// <summary>
        /// The bothMerchantMemberBankSettlementToolStripMenuItem_Click.
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/>.</param>
        /// <param name="e">The e<see cref="EventArgs"/>.</param>
        private void bothMerchantMemberBankSettlementToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// The refreshToolStripMenuItem_Click.
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/>.</param>
        /// <param name="e">The e<see cref="EventArgs"/>.</param>
        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataRetrieve();
        }

        /// <summary>
        /// The btnApprove_Click.
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/>.</param>
        /// <param name="e">The e<see cref="EventArgs"/>.</param>
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



                //Select Office Acc from Infosys DB for ATM ACQ process
                Settlement_InfoController controller = new Settlement_InfoController();
                OfficeACCfromInfosys data = new OfficeACCfromInfosys();

                data.MPUSettlementAcc = "1111108910100001";
                data.SundryAccComonATM = "1111300470100003";
                data.ReceivableAcc = "1111108880100001";
                data.ECOMPayableAcc = "1111703010100002";
                data.SundryAccComonEcom = "1111300470100005";
                data.SundryAccComonPOS = "1111300470100004";
                data.POSandEcomCrdPayAcc = "1111703010100004";
                data.PayableAcc = "1111703010100001";


                Settlement_UploadCollections SettlementCollection = new Settlement_UploadCollections();

                SettlementCollection = controller.SelectFromtlf_ForATMACQ(Eno);

                for (int j = 0; j < SettlementCollection.Count; j++)
                {

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

                }



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
                        if (com_result == "0.40")
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

                if (Resmodel.Count > 0)
                {
                    for (int j = 0; j < Resmodel.Count; j++)
                    {
                        DIR_POS_Record MerchantInfo = new DIR_POS_Record();
                        MerchantInfo.MerchantID = Resmodel[j].CardAcceptorIDCode;
                        Seqlog.TraceLog("Before Compare With MerchantID= >" + DateTime.Now, "INC01C");
                        if (Resmodel[j].CardAcceptorIDCode == "300015065000024")
                        {
                            var mtskk = 1;
                        }
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
                        controller.InsertSettlementUpload("1111108910100001", "MMK", "1111", "D", Dr_Amt, null, null, null, null, null,
                                              null, null, null, Dr_Amt, "MMK", null, null, null, null, Eno, 0, "Dir_POS");

                        //Cr = ServiceFeeRecieve - ServiceFeePayable
                        controller.InsertSettlementUpload("1111300470100004", "MMK", "1111", "C", Cr_Amt, null, null, null, null,
                                              null, null, null, null, Cr_Amt, "MMK", null, null, null, null, Eno, 0, "Dir_POS");

                        //Cr = TranAmt - ServiceFeeRecieve
                        controller.InsertSettlementUpload("1111108660020002", "MMK", "1111", "C", Cr2_Amt, null, null, null, null, null,
                                              null, null, null, Cr2_Amt, "MMK", null, null, null, null, Eno, 0, "Dir_POS");

                        Seqlog.TraceLog("InsertSettlementUpload is successful.= >" + DateTime.Now, "INC01C");
                    }

                    MessageBox.Show("Direct POS process is Successful.");
                }
                else
                {
                    //log for no record                               
                    Seqlog.TraceLog("No Data For Direct POs merchant = >" + DateTime.Now, "INC01C");
                }

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
                            MerchantInfo_3.MerchantRate = Convert.ToDecimal(0.40);
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
                                              null, null, null, Cr_Amt, "MMK", null, null, null, null, Eno, 0, "03_POS");

                        controller.InsertSettlementUpload("1111108660020002", "MMK", "1111", "C", Dr_Amt, null, null, null, null, null,
                                             null, null, null, Cr2_Amt, "MMK", null, null, null, null, Eno, 0, "03_POS");

                        Seqlog.TraceLog("InsertSettlementUpload for 03_POS Merchant is successful.= >" + DateTime.Now, "INC01C");
                    }

                    MessageBox.Show("Point 03 POS process is Successful.");
                }


                //}
                /*  else
                  {
                      MessageBox.Show("Data Processing is Fail." + Environment.NewLine + "Response Code is  " + RCode);
                  }*/

                DataRetrieve();

                MessageBox.Show("Data Processing is Completed.");
                //MemberBankSettlementFieldsShow();
                //}
                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// The MemberBankSettlementProcess.
        /// </summary>
        /// <param name="mbstfinfo">The mbstfinfo<see cref="Settlement_InfoInfo"/>.</param>
        /// <param name="Eno">The Eno<see cref="string"/>.</param>
        /// <param name="RCODE">The RCODE<see cref="string"/>.</param>
        /// <returns>The <see cref="bool"/>.</returns>
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

        /// <summary>
        /// The ProcessInfo_Load.
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/>.</param>
        /// <param name="e">The e<see cref="EventArgs"/>.</param>
        private void ProcessInfo_Load(object sender, EventArgs e)
        {
            // gpbFilter.Visible = false;
            ConfigChanger();
            DataRetrieve();
        }

        /// <summary>
        /// The btnImport_Click.
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/>.</param>
        /// <param name="e">The e<see cref="EventArgs"/>.</param>
        private void btnImport_Click(object sender, EventArgs e)
        {
            #region Export Txt File
            Settlement_InfoController Ctrl = new Settlement_InfoController();
            Settlement_UploadCollections settlement_UploadCollections = new Settlement_UploadCollections();
            settlement_UploadCollections = Ctrl.Select_Settlement_Upload();


            dt = ConvertToDataTable(settlement_UploadCollections);

            string filename = "SettlementUpload_IST.TXT";
            string sPathName = @"C:\SettlementUploadFiles_IST\";
            sPathName = System.IO.Path.Combine(sPathName, System.DateTime.Now.ToString("ddMMyyyy"));

            System.IO.Directory.CreateDirectory(sPathName);
            sPathName = System.IO.Path.Combine(sPathName, filename);

            SequenceLog Seqlog = new SequenceLog();
            StreamWriter sw = null;
            sw = new StreamWriter(sPathName, false);
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
            #endregion

            #region Export Excel
            if (backgroundWorker.IsBusy)
            {
                return;
            }
           
            progressBar.Minimum = 0;
            progressBar.Value = 0;
            backgroundWorker.RunWorkerAsync(_inputParameter);
                

            //ExportExcel(dt);
            #endregion



            MessageBox.Show("Export Successful");

            //Delete Gam
            Ctrl.DeleteGam();
        }

        /// <summary>
        /// The ExportExcel.
        /// </summary>
        /// <param name="_table">The _table<see cref="DataTable"/>.</param>
        private void ExportExcel(DataTable _table)
        {

            try
            {
                DataSet ds = new DataSet();
                ds.Tables.Add(_table);
                //Creae an Excel application instance
                Excel.Application excelApp = new Excel.Application();
                if (excelApp == null)
                {

                    MessageBox.Show("Excel is not properly installed!!");
                    return;
                }

                Excel.Workbook xlWorkBook;
                Excel.Worksheet xlWorkSheet;
                object misValue = System.Reflection.Missing.Value;

                xlWorkBook = excelApp.Workbooks.Add(misValue);
                xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);

                foreach (DataTable table in ds.Tables)
                {
                    //Add a new worksheet to workbook with the Datatable name
                    Excel.Worksheet excelWorkSheet = (Microsoft.Office.Interop.Excel.Worksheet)xlWorkBook.Sheets.Add();
                    excelWorkSheet.Name = table.TableName;

                    // create the column
                    for (int i = 1; i < table.Columns.Count + 1; i++)
                    {
                        excelWorkSheet.Cells[1, i] = table.Columns[i - 1].ColumnName;
                    }

                    // create the row
                    for (int j = 0; j < table.Rows.Count; j++)
                    {
                        for (int k = 0; k < table.Columns.Count; k++)
                        {
                            excelWorkSheet.Cells[j + 2, k + 1] = table.Rows[j].ItemArray[k].ToString();
                            excelWorkSheet.Cells[j + 2, k + 1] = table.Rows[j].ItemArray[k].ToString();
                        }
                    }
                }

                xlWorkBook.SaveAs("c:\\Test\\csharp-Excel.xls", Excel.XlFileFormat.xlWorkbookNormal,
                                    misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive,
                                    misValue, misValue, misValue, misValue, misValue);
                xlWorkBook.Close(true, misValue, misValue);
                excelApp.Quit();

                Marshal.ReleaseComObject(xlWorkSheet);
                Marshal.ReleaseComObject(xlWorkBook);
                Marshal.ReleaseComObject(excelApp);

                MessageBox.Show("Excel file created , you can find the file C:\\Test\\csharp-Excel.xls");

            }
            catch (Exception ex)
            {

                throw;
            }
        }

        /// <summary>
        /// The ConvertToDataTable.
        /// </summary>
        /// <typeparam name="T">.</typeparam>
        /// <param name="data">The data<see cref="IList{T}"/>.</param>
        /// <returns>The <see cref="DataTable"/>.</returns>
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

        /// <summary>
        /// The CreateTempTable.
        /// </summary>
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

        struct DataParameter
        {
            public List<String> dataList;
        }

        DataParameter _inputParameter;

        private void BackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {

        }

        private void BackgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {

        }

        private void BackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

        }
    }
}
