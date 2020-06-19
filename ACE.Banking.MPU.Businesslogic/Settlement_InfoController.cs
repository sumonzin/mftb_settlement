using System;
using System.Data;
using ACE.Banking.MPU.CollectionSuit;
using ACE.Banking.MPU.DataAccess;

namespace ACE.Banking.MPU.Businesslogic
{
    /// <summary>
    /// Settlement_Info Controller
    /// </summary>
    public class Settlement_InfoController
    {
        private Settlement_InfoDataController DataController;
        private int _recordCount;
        private string merchant_code;

        #region "Constructor"

        public Settlement_InfoController()
        {
            DataController = new Settlement_InfoDataController();
        }

        #endregion "Constructor"

        #region Insert into Settlement_Upload

        //Select OfficeAcc from Infosys for ATM ACQ
        public OfficeACCfromInfosys SelectOfficeAccForATMACQ()
        {
            DataSet DS = DataController.SelectOfficeAccForATMACQ();

            OfficeACCfromInfosys Model = new OfficeACCfromInfosys();

            if (DS.Tables[0].Rows.Count > 0)
            {
                if (!(DS.Tables[0].Rows[0]["ReceivableAcc"] is DBNull))
                {
                    Model.ReceivableAcc = DS.Tables[0].Rows[0]["ReceivableAcc"].ToString();
                }
                if (!(DS.Tables[0].Rows[0]["Acct_name"] is DBNull))
                {
                    Model.RecAccName = DS.Tables[0].Rows[0]["Acct_name"].ToString();
                }
            }

            if (DS.Tables[1].Rows.Count > 0)
            {
                if (!(DS.Tables[1].Rows[0]["IncomingAcc"] is DBNull))
                {
                    Model.IncomingAcc = DS.Tables[1].Rows[0]["IncomingAcc"].ToString();
                }
                if (!(DS.Tables[1].Rows[0]["Acct_name"] is DBNull))
                {
                    Model.IncomAccName = DS.Tables[1].Rows[0]["Acct_name"].ToString();
                }
            }

            if (DS.Tables[2].Rows.Count > 0)
            {
                if (!(DS.Tables[2].Rows[0]["MPUSettlementAcc"] is DBNull))
                {
                    Model.MPUSettlementAcc = DS.Tables[2].Rows[0]["MPUSettlementAcc"].ToString();
                }
                if (!(DS.Tables[2].Rows[0]["Acct_name"] is DBNull))
                {
                    Model.SetAccName = DS.Tables[2].Rows[0]["Acct_name"].ToString();
                }
            }

            if (DS.Tables[3].Rows.Count > 0)
            {
                if (!(DS.Tables[3].Rows[0]["PayableAcc"] is DBNull))
                {
                    Model.PayableAcc = DS.Tables[3].Rows[0]["PayableAcc"].ToString();
                }
                if (!(DS.Tables[3].Rows[0]["Acct_name"] is DBNull))
                {
                    Model.PayableAccName = DS.Tables[3].Rows[0]["Acct_name"].ToString();
                }
            }

            if (DS.Tables[4].Rows.Count > 0)
            {
                if (!(DS.Tables[4].Rows[0]["EcomPayableAcc"] is DBNull))
                {
                    Model.ECOMPayableAcc = DS.Tables[4].Rows[0]["EcomPayableAcc"].ToString();
                }
                if (!(DS.Tables[4].Rows[0]["Acct_name"] is DBNull))
                {
                    Model.ECOMPayAccName = DS.Tables[4].Rows[0]["Acct_name"].ToString();
                }
            }

            if (DS.Tables[5].Rows.Count > 0)
            {
                if (!(DS.Tables[5].Rows[0]["POSandECOMCrdPayAcc"] is DBNull))
                {
                    Model.POSandEcomCrdPayAcc = DS.Tables[5].Rows[0]["POSandECOMCrdPayAcc"].ToString();
                }
                if (!(DS.Tables[5].Rows[0]["Acct_name"] is DBNull))
                {
                    Model.POSandEcomCrdAccName = DS.Tables[5].Rows[0]["Acct_name"].ToString();
                }
            }

            //Commission on POS Acc

            if (DS.Tables[6].Rows.Count > 0)
            {
                if (!(DS.Tables[6].Rows[0]["CommissionOnPOSAcc"] is DBNull))
                {
                    Model.CommissiononPOs = DS.Tables[6].Rows[0]["CommissionOnPOSAcc"].ToString();
                }
                if (!(DS.Tables[6].Rows[0]["Acct_name"] is DBNull))
                {
                    Model.ComPOSName = DS.Tables[6].Rows[0]["Acct_name"].ToString();
                }
            }

            //Commission on Ecom
            if (DS.Tables[7].Rows.Count > 0)
            {
                if (!(DS.Tables[7].Rows[0]["CommissionOnECOMAcc"] is DBNull))
                {
                    Model.CommissiononEcom = DS.Tables[7].Rows[0]["CommissionOnECOMAcc"].ToString();
                }
                if (!(DS.Tables[7].Rows[0]["Acct_name"] is DBNull))
                {
                    Model.ComEcomName = DS.Tables[7].Rows[0]["Acct_name"].ToString();
                }
            }

            //Receivale Acc for Credit Card POS
            if (DS.Tables[8].Rows.Count > 0)
            {
                if (!(DS.Tables[8].Rows[0]["POSCrdReceveAcc"] is DBNull))
                {
                    Model.RecePOsCrdAcc = DS.Tables[8].Rows[0]["POSCrdReceveAcc"].ToString();
                }
                if (!(DS.Tables[8].Rows[0]["Acct_name"] is DBNull))
                {
                    Model.RecePOSCrdAccName = DS.Tables[8].Rows[0]["Acct_name"].ToString();
                }
            }

            //Sundry  Acc for Commission on ATM
            if (DS.Tables[9].Rows.Count > 0)
            {
                if (!(DS.Tables[9].Rows[0]["SundryAcCommATM"] is DBNull))
                {
                    Model.SundryAccComonATM = DS.Tables[9].Rows[0]["SundryAcCommATM"].ToString();
                }
                if (!(DS.Tables[9].Rows[0]["Acct_name"] is DBNull))
                {
                    Model.SundryAccComonATMName = DS.Tables[9].Rows[0]["Acct_name"].ToString();
                }
            }

            //Sundry  Acc for Commission on POS
            if (DS.Tables[10].Rows.Count > 0)
            {
                if (!(DS.Tables[10].Rows[0]["SundryAcCommPOS"] is DBNull))
                {
                    Model.SundryAccComonPOS = DS.Tables[10].Rows[0]["SundryAcCommPOS"].ToString();
                }
                if (!(DS.Tables[10].Rows[0]["Acct_name"] is DBNull))
                {
                    Model.SundryAccComonPOSName = DS.Tables[10].Rows[0]["Acct_name"].ToString();
                }
            }

            //Sundry  Acc for Commission on Ecom
            if (DS.Tables[11].Rows.Count > 0)
            {
                if (!(DS.Tables[11].Rows[0]["SundryAcComEcom"] is DBNull))
                {
                    Model.SundryAccComonEcom = DS.Tables[11].Rows[0]["SundryAcComEcom"].ToString();
                }
                if (!(DS.Tables[11].Rows[0]["Acct_name"] is DBNull))
                {
                    Model.SundryAccComonEcomName = DS.Tables[11].Rows[0]["Acct_name"].ToString();
                }
            }

            return Model;
        }

        //Delete Gam
        public void DeleteGam()
        {
            DataController.DeleteGam();
        }

        //Select sol_ID from Gam
        public string SelectSolID_ByAccountNo(string AccNo)
        {
            IDataReader dataReader = DataController.SelectSOlIDByAcctNo(AccNo);
            var solID = "";

            while (dataReader.Read())
            {
                if (!(dataReader["SOLID"] is DBNull))
                {
                    solID = Convert.ToString(dataReader["SOLID"]);
                }
            }
            return solID;
        }

        //Select Services_Outlet from Infosys core banking
        public Select_ServiceOutletCollection SelectAll_Gam()
        {
            Select_ServiceOutletCollection datacollection = new Select_ServiceOutletCollection();
            var Selectdata = DataController.Select_Gam();

            if (Selectdata != null)
            {
                if (Selectdata.Tables.Count > 0)
                {
                    if (Selectdata.Tables[0] != null)
                    {
                        if (Selectdata.Tables[0].Rows.Count > 0)
                        {
                            for (int i = 0; i < Selectdata.Tables[0].Rows.Count; i++)
                            {
                                Select_serviceOutlet Service_outlet = new Select_serviceOutlet();
                                Service_outlet.Sol_ID = Selectdata.Tables[0].Rows[i]["SOLID"].ToString();
                                Service_outlet.accountNo = Selectdata.Tables[0].Rows[i]["ACCTNO"].ToString();

                                datacollection.Add(Service_outlet);
                            }

                            return datacollection;
                        }
                    }
                    return datacollection;
                }
            }
            return datacollection;
        }

        public Settlement_UploadCollections SelectFromTLF(string Eno)
        {
            IDataReader dataReader = DataController.SelectFromTLF_SettlementUpload(Eno);
            Settlement_UploadCollections settlement_UploadCollections = new Settlement_UploadCollections();

            while (dataReader.Read())
            {
                Settlement_Upload settlement_InfoUpload = new Settlement_Upload();
                SettlementFill(dataReader, settlement_InfoUpload);
                settlement_UploadCollections.Add(settlement_InfoUpload);
            }
            return settlement_UploadCollections;
        }

        public Settlement_UploadCollections SelectFromtlf_ForATMACQ(string Eno)
        {
            IDataReader dataReader = DataController.Selectfromtlf_ForATMACQ(Eno);
            Settlement_UploadCollections settlement_UploadCollections = new Settlement_UploadCollections();

            while (dataReader.Read())
            {
                Settlement_Upload settlement_InfoUpload = new Settlement_Upload();
                SettlementFill(dataReader, settlement_InfoUpload);
                settlement_UploadCollections.Add(settlement_InfoUpload);
            }
            return settlement_UploadCollections;
        }

        public Settlement_UploadCollections SelectFromtlf_ForATMISS(string Eno)
        {
            IDataReader dataReader = DataController.Selectfromtlf_ForATMAISS(Eno);
            Settlement_UploadCollections settlement_UploadCollections = new Settlement_UploadCollections();

            while (dataReader.Read())
            {
                Settlement_Upload settlement_InfoUpload = new Settlement_Upload();
                SettlementFill(dataReader, settlement_InfoUpload);
                settlement_UploadCollections.Add(settlement_InfoUpload);
            }
            return settlement_UploadCollections;
        }

        public Settlement_UploadCollections SelectFromtlf_ForISSECOM(string Eno)
        {
            IDataReader dataReader = DataController.Selectfromtlf_ForISSECOM(Eno);
            Settlement_UploadCollections settlement_UploadCollections = new Settlement_UploadCollections();

            while (dataReader.Read())
            {
                Settlement_Upload settlement_InfoUpload = new Settlement_Upload();
                SettlementFill(dataReader, settlement_InfoUpload);
                settlement_UploadCollections.Add(settlement_InfoUpload);
            }
            return settlement_UploadCollections;
        }

        public Settlement_UploadCollections SelectFromtlf_ForISSPOS(string Eno)
        {
            IDataReader dataReader = DataController.Selectfromtlf_ForISSPOS(Eno);
            Settlement_UploadCollections settlement_UploadCollections = new Settlement_UploadCollections();

            while (dataReader.Read())
            {
                Settlement_Upload settlement_InfoUpload = new Settlement_Upload();
                SettlementFill(dataReader, settlement_InfoUpload);
                settlement_UploadCollections.Add(settlement_InfoUpload);
            }
            return settlement_UploadCollections;
        }

        public DirPOSCollections Select_DirPOS_Trans(string STFDate)
        {
            IDataReader dataReader = DataController.Select_DirPOS_Trans(STFDate);
            DirPOSCollections settlement_UploadCollections = new DirPOSCollections();

            while (dataReader.Read())
            {
                MemberBankDetailInfo settlement_InfoUpload = new MemberBankDetailInfo();
                settlement_InfoUpload = MemberBankDetailInfo_Fill(dataReader, settlement_InfoUpload);

                settlement_UploadCollections.Add(settlement_InfoUpload);

            }
            return settlement_UploadCollections;
        }
        public DIR_POS_Record Select_Sum_DirPOS_Trans(string STFDate)
        {
            IDataReader dataReader = DataController.Select_Sum_DirPOS_Trans(STFDate);
            DIR_POS_Record settlement_InfoUpload = new DIR_POS_Record();

            while (dataReader.Read())
            {             
                settlement_InfoUpload = Dir_POS_SUm(dataReader, settlement_InfoUpload);
            }
            return settlement_InfoUpload;
        }

        public DIR_POS_Record Select_Sum_DirPOS_Trans_03(string STFDate)
        {
            IDataReader dataReader = DataController.Select_Sum_DirPOS_Trans_03(STFDate);
            DIR_POS_Record settlement_InfoUpload = new DIR_POS_Record();

            while (dataReader.Read())
            {
                settlement_InfoUpload = Dir_POS_SUm(dataReader, settlement_InfoUpload);
            }
            return settlement_InfoUpload;
        }

        public sum_memB_record Select_Sum_MemberBankDirPOS_Trans(string STFDate)
        {
            IDataReader dataReader = DataController.Select_Sum_MemberBankDirPOS_Trans(STFDate);
            sum_memB_record settlement_InfoUpload = new sum_memB_record();

            while (dataReader.Read())
            {
                settlement_InfoUpload = Dir_MemBerPOS_SUm(dataReader, settlement_InfoUpload);
            }
            return settlement_InfoUpload;
        }

        public sum_memB_record Select_Sum_MemberBankDirPOS_Trans_3merchant(string STFDate)
        {
            IDataReader dataReader = DataController.Select_Sum_MemberBankDirPOS_Trans_3merchant(STFDate);
            sum_memB_record settlement_InfoUpload = new sum_memB_record();

            while (dataReader.Read())
            {
                settlement_InfoUpload = Dir_MemBerPOS_SUm(dataReader, settlement_InfoUpload);
            }
            return settlement_InfoUpload;
        }

        public DIR_POS_Record_Collection Select_Sum_DirPOS_Trans_GroupByMerchantID(string STFDate)
        {
            IDataReader dataReader = DataController.SelectAll_Merchant_Rate();
            DIR_POS_Record_Collection settlement_UploadCollections = new DIR_POS_Record_Collection();

            while (dataReader.Read())
            {
                DIR_POS_Record settlement_InfoUpload = new DIR_POS_Record();
                settlement_InfoUpload = Dir_POS_SUm(dataReader, settlement_InfoUpload);

                settlement_UploadCollections.Add(settlement_InfoUpload);

            }
            return settlement_UploadCollections;
        }
        public MerchantRateCollections SelectAll_Merchant_Rate()
        {
            IDataReader dataReader = DataController.SelectAll_Merchant_Rate();
            MerchantRateCollections settlement_UploadCollections = new MerchantRateCollections();

            while (dataReader.Read())
            {
                MerchantRateDetail settlement_InfoUpload = new MerchantRateDetail();
                settlement_InfoUpload = MerchantRate_Fill(dataReader, settlement_InfoUpload);

                settlement_UploadCollections.Add(settlement_InfoUpload);

            }
            return settlement_UploadCollections;
        }

        public Decimal Select_CommisionRate_ByMerchantID(string ID)
        {
            IDataReader dataReader = DataController.Select_commision_byrate(ID);
            decimal commision = 0;

            while (dataReader.Read())
            {
                decimal commision_test = 0;
                commision = CommissionRate_Fill(dataReader, commision_test);

            }
            return commision;
        }

        public Settlement_UploadCollections SelectFromtlf_ForECOMPOSCredit(string Eno)
        {
            IDataReader dataReader = DataController.Select_tlf_CreditCard(Eno);
            Settlement_UploadCollections settlement_UploadCollections = new Settlement_UploadCollections();

            while (dataReader.Read())
            {
                Settlement_Upload settlement_InfoUpload = new Settlement_Upload();
                SettlementFill(dataReader, settlement_InfoUpload);
                settlement_UploadCollections.Add(settlement_InfoUpload);
            }
            return settlement_UploadCollections;
        }

        public Settlement_UploadCollections Select_Settlement_Upload()
        {
            IDataReader dataReader = DataController.Select_Settlement_Upload();
            Settlement_UploadCollections settlement_UploadCollections = new Settlement_UploadCollections();

            while (dataReader.Read())
            {
                Settlement_Upload settlement_InfoUpload = new Settlement_Upload();
                SettlementUploadFill(dataReader, settlement_InfoUpload);
                settlement_UploadCollections.Add(settlement_InfoUpload);
            }
            return settlement_UploadCollections;
        }

        public Settlement_UploadCollections Select_SettlementUpload_CreditCard(String ENo)
        {
            IDataReader dataReader = DataController.Selectfromtlf_ForISSPOSCredit(ENo);
            Settlement_UploadCollections settlement_UploadCollections = new Settlement_UploadCollections();

            while (dataReader.Read())
            {
                Settlement_Upload settlement_InfoUpload = new Settlement_Upload();
                SettlementUploadFillforCredit(dataReader, settlement_InfoUpload);
                settlement_UploadCollections.Add(settlement_InfoUpload);
            }
            return settlement_UploadCollections;
        }

        //Insert into Gam
        public void InsertIntoGam(string ACCTNO, string SOLID)
        {
            DataController.InsertGam(ACCTNO, SOLID);
        }

        public void Insert_DirPoS(DIR_POS_Record model)
        {
            DataController.Insert_POS_ACQ_Merchant_tlf(model);
        }

        public void InsertSettlementUpload(string ACCTNO, string CURCODE, string SERVICEOUTLET, string TRANTYPE, decimal TRANAMT, string TRANPARTICULAR, string ACCRESPCODE, string REFERENCENO,
                                           string INSTRUMENTTYPE, string INSTRUMENTDATE, string INSTRUMENTALPHA, string INSTRUMENTNUM, string NAVIGAIONFLAT, decimal REFERENCEAMT, string RefCurCode, string RateCode, string ValueDate, string GLDate, string CategoryCode, string ENo, decimal Rate, string Channel)
        {
            DataController.MerchantSettlementUpload(ACCTNO, CURCODE, SERVICEOUTLET, TRANTYPE, TRANAMT, TRANPARTICULAR, ACCRESPCODE, REFERENCENO,
                                                    INSTRUMENTTYPE, INSTRUMENTDATE, INSTRUMENTALPHA, INSTRUMENTNUM, NAVIGAIONFLAT, REFERENCEAMT,
                                                    RefCurCode, RateCode, ValueDate, GLDate, CategoryCode, ENo, Rate, Channel);
        }

        private void SettlementFill(IDataReader dataReader, Settlement_Upload SettlementUploadInfos)
        {
            if (!(dataReader["ENO"] is DBNull))
            {
                SettlementUploadInfos.ENo = Convert.ToString(dataReader["ENO"]);
            }
            if (!(dataReader["ACCTNO"] is DBNull))
            {
                SettlementUploadInfos.AccountNo = Convert.ToString(dataReader["ACCTNO"]);
            }
            if (!(dataReader["AMOUNT"] is DBNull))
            {
                SettlementUploadInfos.TranAmount = Convert.ToDecimal(dataReader["AMOUNT"]);
            }
            if (!(dataReader["ACODE"] is DBNull))
            {
                SettlementUploadInfos.Acode = Convert.ToString(dataReader["ACODE"]);
            }
            if (!(dataReader["SOURCECUR"] is DBNull))
            {
                SettlementUploadInfos.CurrencyCode = Convert.ToString(dataReader["SOURCECUR"]);
            }
            if (!(dataReader["DESP"] is DBNull))
            {
                SettlementUploadInfos.Desp = Convert.ToString(dataReader["DESP"]);
            }
            if (!(dataReader["NARRATION"] is DBNull))
            {
                SettlementUploadInfos.Narration = Convert.ToString(dataReader["NARRATION"]);
            }
            if (!(dataReader["STATUS"] is DBNull))
            {
                SettlementUploadInfos.TranType = Convert.ToString(dataReader["STATUS"]);

                if (SettlementUploadInfos.TranType.ToString().Trim().Equals("TCV"))
                {
                    SettlementUploadInfos.TranType = "Cr";
                }
                else
                {
                    SettlementUploadInfos.TranType = "Dr";
                }
            }
        }

        private MemberBankDetailInfo MemberBankDetailInfo_Fill(IDataReader dataReader, MemberBankDetailInfo  MemberDetail)
        {
            if (!(dataReader["PAN"] is DBNull))
            {
                MemberDetail.PAN = Convert.ToString(dataReader["PAN"]);
            }
            if (!(dataReader["cardAcceptorIDCode"] is DBNull))
            {
                MemberDetail.CardAcceptorIDCode = Convert.ToString(dataReader["cardAcceptorIDCode"]);
            }
            if (!(dataReader["transAmount"] is DBNull))
            {
                MemberDetail.TranAmt = Convert.ToString(dataReader["transAmount"]);
            }
            if (!(dataReader["ProcessingCode"] is DBNull))
            {
                MemberDetail.ProcessingCode = Convert.ToString(dataReader["ProcessingCode"]);
            }
            if (!(dataReader["SettlementAmount"] is DBNull))
            {
                MemberDetail.SettlememtAmt = Convert.ToString(dataReader["SettlementAmount"]);
            }
            if (!(dataReader["MerchantType"] is DBNull))
            {
                MemberDetail.MerchantType = Convert.ToString(dataReader["MerchantType"]);
            }
            if (!(dataReader["AcquireInstitutionID"] is DBNull))
            {
                MemberDetail.AcquireInstitutionID = Convert.ToString(dataReader["AcquireInstitutionID"]);
            }
            if (!(dataReader["MessageType"] is DBNull))
            {
                MemberDetail.MessageType = Convert.ToString(dataReader["MessageType"]);               
            }
            if (!(dataReader["ServiceFeeReceive"] is DBNull))
            {
                MemberDetail.ServiceFeeReceive = Convert.ToString(dataReader["ServiceFeeReceive"]);
            }
            if (!(dataReader["ServiceFeePayable"] is DBNull))
            {
                MemberDetail.ServiceFeePayable = Convert.ToString(dataReader["ServiceFeePayable"]);
            }
            if (!(dataReader["FILENAME"] is DBNull))
            {
                MemberDetail.FileName = Convert.ToString(dataReader["FILENAME"]);
            }
            if (!(dataReader["FileType"] is DBNull))
            {
                MemberDetail.FileType = Convert.ToString(dataReader["FileType"]);
            }
            if (!(dataReader["TranResponseCode"] is DBNull))
            {
                MemberDetail.TranResponseCode = Convert.ToString(dataReader["TranResponseCode"]);
            }
            if (!(dataReader["RefundStatus"] is DBNull))
            {
                MemberDetail.RefundStatus = Convert.ToString(dataReader["RefundStatus"]);
            }
            return MemberDetail;

        }

        private sum_memB_record Dir_MemBerPOS_SUm(IDataReader dataReader, sum_memB_record MemberDetail)
        {
            if (!(dataReader["DebitAmt"] is DBNull))
            {
                MemberDetail.DebitAmt = Convert.ToDecimal(dataReader["DebitAmt"]);
            }
            if (!(dataReader["CreditAmt"] is DBNull))
            {
                MemberDetail.CreditAmt = Convert.ToDecimal(dataReader["CreditAmt"]);
            }
            if (!(dataReader["Credit2_Amt"] is DBNull))
            {
                MemberDetail.Credit2Amt = Convert.ToDecimal(dataReader["Credit2_Amt"]);
            }                 
            return MemberDetail;

        }
        private DIR_POS_Record Dir_POS_SUm(IDataReader dataReader, DIR_POS_Record MemberDetail)
        {
            if (!(dataReader["TranAmt"] is DBNull))
            {
                MemberDetail.TranAmt = Convert.ToDecimal(dataReader["TranAmt"]);
            }
            if (!(dataReader["ServiceFeePayable"] is DBNull))
            {
                MemberDetail.ServiceFeePayable = Convert.ToDecimal(dataReader["ServiceFeePayable"]);
            }
            if (!(dataReader["ServiceFeeRecieve"] is DBNull))
            {
                MemberDetail.ServiceFeeReceive = Convert.ToDecimal(dataReader["ServiceFeeRecieve"]);
            }
            return MemberDetail;

        }

        private MerchantRateDetail MerchantRate_Fill(IDataReader dataReader, MerchantRateDetail MemberDetail)
        {
            if (!(dataReader["MerchantID"] is DBNull))
            {
                MemberDetail.MerchantID = Convert.ToString(dataReader["MerchantID"]);
            }
            if (!(dataReader["NewACCTNO"] is DBNull))
            {
                MemberDetail.NewAccountNo = Convert.ToString(dataReader["NewACCTNO"]);
            }
            if (!(dataReader["Rate"] is DBNull))
            {
                MemberDetail.Rate = Convert.ToString(dataReader["Rate"]);
            }
            if (!(dataReader["NAME"] is DBNull))
            {
                MemberDetail.Name = Convert.ToString(dataReader["NAME"]);
            }
             
            return MemberDetail;

        }

        private decimal CommissionRate_Fill(IDataReader dataReader, Decimal comission)
        {
            if (!(dataReader["Commision_Rate"] is DBNull))
            {
                comission = Convert.ToDecimal(dataReader["Commision_Rate"]);
            }         
            return comission;
        }

        private void SettlementUploadFill(IDataReader dataReader, Settlement_Upload SettlementUploadInfos)
        {
            if (!(dataReader["AccountNo"] is DBNull))
            {
                SettlementUploadInfos.AccountNo = Convert.ToString(dataReader["AccountNo"]);
            }
            if (!(dataReader["CurrencyCode"] is DBNull))
            {
                SettlementUploadInfos.CurrencyCode = Convert.ToString(dataReader["CurrencyCode"]);
            }
            if (!(dataReader["ServiceOutlet"] is DBNull))
            {
                SettlementUploadInfos.ServiceOutlet = Convert.ToString(dataReader["ServiceOutlet"]);
            }
            if (!(dataReader["TranType"] is DBNull))
            {
                SettlementUploadInfos.TranType = Convert.ToString(dataReader["TranType"]);
            }
            if (!(dataReader["TranAmount"] is DBNull))
            {
                SettlementUploadInfos.TranAmount = Convert.ToDecimal(dataReader["TranAmount"]);
            }
            if (!(dataReader["TranParticular"] is DBNull))
            {
                SettlementUploadInfos.TranParticular = Convert.ToString(dataReader["TranParticular"]);
            }
            if (!(dataReader["AccountRespCode"] is DBNull))
            {
                SettlementUploadInfos.AccountRespCode = Convert.ToString(dataReader["AccountRespCode"]);
            }
            if (!(dataReader["ReferenceNo"] is DBNull))
            {
                SettlementUploadInfos.ReferenceNo = Convert.ToString(dataReader["ReferenceNo"]);
            }
            if (!(dataReader["InstrumentType"] is DBNull))
            {
                SettlementUploadInfos.InstrumentType = Convert.ToString(dataReader["InstrumentType"]);
            }
            if (!(dataReader["InstrumentDate"] is DBNull))
            {
                SettlementUploadInfos.strInsdate = Convert.ToString(dataReader["InstrumentDate"]).ToString();
            }
            else
            {
                SettlementUploadInfos.strInsdate = "";
            }
            if (!(dataReader["InstrumentAlpha"] is DBNull))
            {
                SettlementUploadInfos.InstrumentAlpha = Convert.ToString(dataReader["InstrumentAlpha"]);
            }
            if (!(dataReader["InstrumentNumber"] is DBNull))
            {
                SettlementUploadInfos.InstrumentNumber = Convert.ToString(dataReader["InstrumentNumber"]);
            }
            if (!(dataReader["NavigationFlat"] is DBNull))
            {
                SettlementUploadInfos.NavigationFlat = Convert.ToString(dataReader["NavigationFlat"]);
            }
            if (!(dataReader["ReferenceAmount"] is DBNull))
            {
                SettlementUploadInfos.ReferenceAmount = Convert.ToDecimal(dataReader["ReferenceAmount"]);
            }
            if (!(dataReader["RefCurCode"] is DBNull))
            {
                SettlementUploadInfos.RefCurCode = Convert.ToString(dataReader["RefCurCode"]);
            }
            if (!(dataReader["RateCode"] is DBNull))
            {
                SettlementUploadInfos.RateCode = Convert.ToString(dataReader["RateCode"]);
            }
            if (!(dataReader["Rate"] is DBNull))
            {
                if (dataReader["Rate"].ToString() == "0.00")
                {
                    SettlementUploadInfos.strRate = " ";
                }
                else
                {
                    SettlementUploadInfos.strRate = dataReader["Rate"].ToString();
                }
                // SettlementUploadInfos.Rate = Convert.ToDecimal(dataReader["Rate"]);
            }
            if (!(dataReader["ValueDate"] is DBNull))
            {
                SettlementUploadInfos.strValuedate = (Convert.ToString(dataReader["ValueDate"])).ToString();
            }
            else
            {
                SettlementUploadInfos.strValuedate = "";
            }

            if (!(dataReader["GLDate"] is DBNull))
            {
                SettlementUploadInfos.strGLDate = (Convert.ToString(dataReader["GLDate"])).ToString();
            }
            else
            {
                SettlementUploadInfos.strGLDate = "";
            }

            if (!(dataReader["CategoryCode"] is DBNull))
            {
                SettlementUploadInfos.CategoryCode = Convert.ToString(dataReader["CategoryCode"]);
            }
            if (!(dataReader["ENo"] is DBNull))
            {
                SettlementUploadInfos.ENo = Convert.ToString(dataReader["ENo"]);
            }
        }

        private void SettlementUploadFillforCredit(IDataReader dataReader, Settlement_Upload SettlementUploadInfos)
        {
            if (!(dataReader["TranAmt"] is DBNull))
            {
                SettlementUploadInfos.TranAmount = Convert.ToDecimal(dataReader["TranAmt"]);
            }
        }

        #endregion Insert into Settlement_Upload

        #region "Helper Methods"

        private void RefundFill(IDataReader dataReader, MemberBankDetailTransactionInfoInfo Memberbankinfo)
        {
            if (!(dataReader["PAN"] is DBNull))
            {
                Memberbankinfo.PAN = Convert.ToString(dataReader["PAN"]);
            }

            if (!(dataReader["transAmount"] is DBNull))
            {
                Memberbankinfo.transAmount = Convert.ToDecimal(dataReader["transAmount"]);
            }

            if (!(dataReader["SettlementAmount"] is DBNull))
            {
                Memberbankinfo.settlementAmount = Convert.ToDecimal(dataReader["SettlementAmount"]);
            }

            if (!(dataReader["ServiceFeeReceive"] is DBNull))
            {
                Memberbankinfo.ServiceFeeReceive = Convert.ToDecimal(dataReader["ServiceFeeReceive"]);
            }

            if (!(dataReader["ServiceFeePayable"] is DBNull))
            {
                Memberbankinfo.ServiceFeePayable = Convert.ToDecimal(dataReader["ServiceFeePayable"]);
            }

            if (!(dataReader["MerchantType"] is DBNull))
            {
                Memberbankinfo.MerchantType = Convert.ToString(dataReader["MerchantType"]);
            }

            if (!(dataReader["FileType"] is DBNull))
            {
                Memberbankinfo.FileType = Convert.ToString(dataReader["FileType"]);
            }

            if (!(dataReader["FILENAME"] is DBNull))
            {
                Memberbankinfo.FILENAME = Convert.ToString(dataReader["FILENAME"]);
            }

            if (!(dataReader["SettlementCurcode"] is DBNull))
            {
                Memberbankinfo.SettlementCurcode = Convert.ToString(dataReader["SettlementCurcode"]);
            }

            if (!(dataReader["SETTLEMENTDATE"] is DBNull))
            {
                Memberbankinfo.SETTLEMENTDATE = Convert.ToDateTime(dataReader["SETTLEMENTDATE"]);
            }
        }

        private void Fill(IDataReader dataReader, Settlement_InfoInfo settlement_InfoInfo)
        {
            if (!(dataReader["MPUDfCode"] is DBNull))
            {
                settlement_InfoInfo.MPUDfCode = Convert.ToString(dataReader["MPUDfCode"]);
            }

            if (!(dataReader["OutgoingAmoutSign"] is DBNull))
            {
                settlement_InfoInfo.OutgoingAmoutSign = Convert.ToString(dataReader["OutgoingAmoutSign"]);
            }

            if (!(dataReader["OutgoingAmount"] is DBNull))
            {
                settlement_InfoInfo.OutgoingAmount = Convert.ToDecimal(dataReader["OutgoingAmount"]);
            }

            if (!(dataReader["OutgoingFeeSign"] is DBNull))
            {
                settlement_InfoInfo.OutgoingFeeSign = Convert.ToString(dataReader["OutgoingFeeSign"]);
            }

            if (!(dataReader["OutgoingFee"] is DBNull))
            {
                settlement_InfoInfo.OutgoingFee = Convert.ToDecimal(dataReader["OutgoingFee"]);
            }

            if (!(dataReader["IncomingAmountSign"] is DBNull))
            {
                settlement_InfoInfo.IncomingAmountSign = Convert.ToString(dataReader["IncomingAmountSign"]);
            }

            if (!(dataReader["IncomingAmount"] is DBNull))
            {
                settlement_InfoInfo.IncomingAmount = Convert.ToDecimal(dataReader["IncomingAmount"]);
            }

            if (!(dataReader["IncomingFeeSign"] is DBNull))
            {
                settlement_InfoInfo.IncomingFeeSign = Convert.ToString(dataReader["IncomingFeeSign"]);
            }

            if (!(dataReader["IncomingFee"] is DBNull))
            {
                settlement_InfoInfo.IncomingFee = Convert.ToDecimal(dataReader["IncomingFee"]);
            }

            if (!(dataReader["STFAmountSign"] is DBNull))
            {
                settlement_InfoInfo.STFAmountSign = Convert.ToString(dataReader["STFAmountSign"]);
            }

            if (!(dataReader["STFAmount"] is DBNull))
            {
                settlement_InfoInfo.STFAmount = Convert.ToDecimal(dataReader["STFAmount"]);
            }

            if (!(dataReader["STFFeeSign"] is DBNull))
            {
                settlement_InfoInfo.STFFeeSign = Convert.ToString(dataReader["STFFeeSign"]);
            }

            if (!(dataReader["STFFee"] is DBNull))
            {
                settlement_InfoInfo.STFFee = Convert.ToDecimal(dataReader["STFFee"]);
            }

            if (!(dataReader["OutgoingSummary"] is DBNull))
            {
                settlement_InfoInfo.OutgoingSummary = Convert.ToDecimal(dataReader["OutgoingSummary"]);
            }

            if (!(dataReader["IncomingSummary"] is DBNull))
            {
                settlement_InfoInfo.IncomingSummary = Convert.ToDecimal(dataReader["IncomingSummary"]);
            }

            if (!(dataReader["SettlementCurrency"] is DBNull))
            {
                settlement_InfoInfo.SettlementCurrency = Convert.ToString(dataReader["SettlementCurrency"]);
            }

          
            if (!(dataReader["FileType"] is DBNull))
            {
                settlement_InfoInfo.FileType = Convert.ToString(dataReader["FileType"]);
            }

            
            if (!(dataReader["TotalSettlementAmtSign"] is DBNull))
            {
                settlement_InfoInfo.TotalSettlementAmtSign = Convert.ToString(dataReader["TotalSettlementAmtSign"]);
            }

            if (!(dataReader["TotalSettlementAmt"] is DBNull))
            {
                settlement_InfoInfo.TotalSettlementAmt = Convert.ToDecimal(dataReader["TotalSettlementAmt"]);
            }


            if (!(dataReader["STFFileName"] is DBNull))
            {
                settlement_InfoInfo.SettlementFileName = Convert.ToString(dataReader["STFFileName"]);
            }

            if (!(dataReader["STFDate"] is DBNull))
            {
                settlement_InfoInfo.SettlementDate = Convert.ToDateTime(dataReader["STFDate"]);
            }
        }

        #endregion "Helper Methods"

        #region "Select Methods"

        public MemberBankDetailTransactionInfoCollections SelectRefundListtoProcess(string STFdatetime)
        {
            IDataReader dataReader = DataController.SelectRefundListToprocess(STFdatetime);
            MemberBankDetailTransactionInfoCollections RefundinfoCollection = new MemberBankDetailTransactionInfoCollections();

            while (dataReader.Read())
            {
                MemberBankDetailTransactionInfoInfo memberbank_Info = new MemberBankDetailTransactionInfoInfo();
                RefundFill(dataReader, memberbank_Info);
                RefundinfoCollection.Add(memberbank_Info);
            }
            return RefundinfoCollection;
        }

        public MemberBankDetailTransactionInfoCollections SelectRefundList(string STFdatetime)
        {
            IDataReader dataReader = DataController.SelectRefundList(STFdatetime);
            MemberBankDetailTransactionInfoCollections RefundinfoCollection = new MemberBankDetailTransactionInfoCollections();

            while (dataReader.Read())
            {
                MemberBankDetailTransactionInfoInfo memberbank_Info = new MemberBankDetailTransactionInfoInfo();
                RefundFill(dataReader, memberbank_Info);
                RefundinfoCollection.Add(memberbank_Info);
            }
            return RefundinfoCollection;
        }

        public Settlement_InfoCollections Select(string STFdate)
        {
            IDataReader dataReader = DataController.Select(STFdate);
            Settlement_InfoCollections settlement_InfoCollections = new Settlement_InfoCollections();

            while (dataReader.Read())
            {
                Settlement_InfoInfo settlement_InfoInfo = new Settlement_InfoInfo();
                Fill(dataReader, settlement_InfoInfo);
                settlement_InfoCollections.Add(settlement_InfoInfo);
            }
            return settlement_InfoCollections;
        }

        public Settlement_InfoCollections SettlementInfo_SelectListForMemberBank_New(string status)
        {
            IDataReader dataReader = DataController.SelectByStatus_New(status);
            Settlement_InfoCollections settlement_InfoCollections = new Settlement_InfoCollections();

            while (dataReader.Read())
            {
                Settlement_InfoInfo settlement_InfoInfo = new Settlement_InfoInfo();
                Fill(dataReader, settlement_InfoInfo);
                settlement_InfoCollections.Add(settlement_InfoInfo);
            }
            return settlement_InfoCollections;
        }

        public Settlement_InfoCollections SelectByStatus(string status)
        {
            IDataReader dataReader = DataController.SelectByStatus(status);
            Settlement_InfoCollections settlement_InfoCollections = new Settlement_InfoCollections();

            while (dataReader.Read())
            {
                Settlement_InfoInfo settlement_InfoInfo = new Settlement_InfoInfo();
                Fill(dataReader, settlement_InfoInfo);
                settlement_InfoCollections.Add(settlement_InfoInfo);
            }
            return settlement_InfoCollections;
        }

        public Settlement_InfoCollections SelectBy(Settlement_InfoInfo settlement_InfoInfo)
        {
            IDataReader dataReader = DataController.FindBy(settlement_InfoInfo.MPUDfCode, settlement_InfoInfo.OutgoingAmoutSign, settlement_InfoInfo.OutgoingAmount, settlement_InfoInfo.OutgoingFeeSign, settlement_InfoInfo.OutgoingFee, settlement_InfoInfo.IncomingAmountSign, settlement_InfoInfo.IncomingAmount, settlement_InfoInfo.IncomingFeeSign, settlement_InfoInfo.IncomingFee, settlement_InfoInfo.STFAmountSign, settlement_InfoInfo.STFAmount, settlement_InfoInfo.STFFeeSign, settlement_InfoInfo.STFFee, settlement_InfoInfo.OutgoingSummary, settlement_InfoInfo.IncomingSummary, settlement_InfoInfo.SettlementCurrency, settlement_InfoInfo.Reserved, settlement_InfoInfo.CreatedDate, settlement_InfoInfo.UpdatedDate, settlement_InfoInfo.Status, settlement_InfoInfo.ApproveBy, settlement_InfoInfo.ApproveFrom, settlement_InfoInfo.RejectBy, settlement_InfoInfo.RejectFrom, settlement_InfoInfo.ProcessBy, settlement_InfoInfo.ProcessFrom, settlement_InfoInfo.FileType, settlement_InfoInfo.MerchantCode, settlement_InfoInfo.TotalSettlementAmtSign, settlement_InfoInfo.TotalSettlementAmt, settlement_InfoInfo.MerchantSettlementAccount);
            Settlement_InfoCollections settlement_InfoCollections = new Settlement_InfoCollections();

            while (dataReader.Read())
            {
                settlement_InfoInfo = new Settlement_InfoInfo();
                Fill(dataReader, settlement_InfoInfo);
                settlement_InfoCollections.Add(settlement_InfoInfo);
            }
            return settlement_InfoCollections;
        }

        #endregion "Select Methods"

        #region "Add Methods"

        public bool Add(Settlement_InfoInfo settlement_InfoInfo)
        {
            Settlement_InfoCollections settlement_InfoCollections = new Settlement_InfoCollections();
            settlement_InfoCollections.Add(settlement_InfoInfo);

            return Add(settlement_InfoCollections);
        }

        public SelectDirPOSResponseModel MemberDetailInfo_Add(MemberBankDetailInfo settlement_InfoInfo)
        {
            SelectDirPOSResponseModel settlement_InfoCollections = new SelectDirPOSResponseModel();
            settlement_InfoCollections.lstMemberBank.Add(settlement_InfoInfo);

            return settlement_InfoCollections;
        }

        public bool Add(Settlement_InfoCollections settlement_InfoCollections)
        {
            string uniqueKey = "";
            try
            {
                DataController.StartTransaction();
                foreach (Settlement_InfoInfo settlement_InfoInfo in settlement_InfoCollections)
                {
                    uniqueKey = settlement_InfoInfo.MPUDfCode;
                    settlement_InfoInfo.MPUDfCode = DataController.Insert(settlement_InfoInfo.ResCode, settlement_InfoInfo.MPUDfCode, settlement_InfoInfo.OutgoingAmoutSign, settlement_InfoInfo.OutgoingAmount, settlement_InfoInfo.OutgoingFeeSign, settlement_InfoInfo.OutgoingFee, settlement_InfoInfo.IncomingAmountSign, settlement_InfoInfo.IncomingAmount, settlement_InfoInfo.IncomingFeeSign, settlement_InfoInfo.IncomingFee, settlement_InfoInfo.STFAmountSign, settlement_InfoInfo.STFAmount, settlement_InfoInfo.STFFeeSign, settlement_InfoInfo.STFFee, settlement_InfoInfo.OutgoingSummary, settlement_InfoInfo.IncomingSummary, settlement_InfoInfo.SettlementCurrency, settlement_InfoInfo.Reserved, settlement_InfoInfo.CreatedDate, settlement_InfoInfo.UpdatedDate, settlement_InfoInfo.Status, settlement_InfoInfo.ApproveBy, settlement_InfoInfo.ApproveFrom, settlement_InfoInfo.RejectBy, settlement_InfoInfo.RejectFrom, settlement_InfoInfo.ProcessBy, settlement_InfoInfo.ProcessFrom, settlement_InfoInfo.FileType, settlement_InfoInfo.MerchantCode, settlement_InfoInfo.TotalSettlementAmtSign, settlement_InfoInfo.TotalSettlementAmt, settlement_InfoInfo.MerchantSettlementAccount, settlement_InfoInfo.SettlementFileName, settlement_InfoInfo.SettlementDate);
                }
                DataController.CommitTransaction();
            }
            catch (Exception ex)
            {
                DataController.RollbackTransaction();
                return false;
            }
            return true;
        }

        public bool SettlementProcessForMerchant(string accountno, char amountsign, decimal amount, char feesign, decimal feeamount, string datetime, string currency, string eno, string terminalNo, string merchantcode, DateTime settlementdate, out string refEno, out string ResponseCode)
        {
            try
            {
                DataController.StartTransaction();
                //-------For EcommerenceTran(sym)---------------
                merchant_code = merchantcode.Substring(0, 1);
                if (merchant_code == "2")
                {
                    if (DataController.SettlementProcessECOM(accountno, amountsign, amount, datetime, currency, eno, terminalNo, merchantcode, settlementdate, out refEno, out ResponseCode))
                    {
                        if (ResponseCode == "00")
                        {
                            eno = refEno;
                           
                            DataController.CommitTransaction();
                        }
                        else
                            throw new Exception("Error");
                        //}
                    }
                }
                // }

                //-----------end-------------------------------
                else if (DataController.SettlementProcess(accountno, amountsign, amount, datetime, currency, eno, terminalNo, merchantcode, settlementdate, out refEno, out ResponseCode))
                {
                    if (ResponseCode == "00")
                    {
                        eno = refEno;
                        
                        DataController.CommitTransaction();
                    }
                    else
                        throw new Exception("Error");
                }
                else
                    throw new Exception("Error.");
                refEno = eno;
                return true;
            }
            catch (Exception ex)
            {
                ResponseCode = "06";
                refEno = string.Empty;
                DataController.RollbackTransaction();
                return false;
            }
        }

        public bool SettlementProcessForMemberBank(Settlement_InfoInfo stfmbinfo, string channel, out string ENO, out string RCODE)
        {
            try
            {
                DataController.StartTransaction();

                if (DataController.MemberBankSettlementProcess(stfmbinfo.MPUDfCode, stfmbinfo.OutgoingAmount, stfmbinfo.OutgoingAmoutSign, stfmbinfo.OutgoingFee, stfmbinfo.OutgoingFeeSign, stfmbinfo.IncomingAmount, stfmbinfo.IncomingAmountSign, stfmbinfo.IncomingFee, stfmbinfo.IncomingFeeSign, stfmbinfo.SettlementCurrency, channel, stfmbinfo.SettlementDate, out ENO, out RCODE))
                {
                    if (RCODE == "00")
                        DataController.CommitTransaction();
                    else

                        throw new Exception("Error");
                }
                else
                    throw new Exception("Error");

                return true;
            }
            catch (Exception ex)
            {
                DataController.RollbackTransaction();
                ENO = string.Empty;
                RCODE = "06";
                return false;
            }
        }

        #endregion "Add Methods"

        #region "Update Methods"

        public bool UpdateByMemberCode(Settlement_InfoCollections settlement_InfoCollections)
        {
            try
            {
                DataController.StartTransaction();
                foreach (Settlement_InfoInfo settlement_InfoInfo in settlement_InfoCollections)
                    DataController.UpdateByMemberCode(settlement_InfoInfo.MPUDfCode, settlement_InfoInfo.Status, settlement_InfoInfo.ApproveBy, settlement_InfoInfo.ApproveFrom, settlement_InfoInfo.RejectBy, settlement_InfoInfo.RejectFrom, settlement_InfoInfo.ProcessBy, settlement_InfoInfo.ProcessFrom, settlement_InfoInfo.FileType, settlement_InfoInfo.SettlementDate);

                DataController.CommitTransaction();
            }
            catch (Exception ex)
            {
                DataController.RollbackTransaction();
                return false;
            }
            return true;
        }

        public bool UpdateByMemberCode(Settlement_InfoInfo settlement_InfoInfo)
        {
            try
            {
                DataController.StartTransaction();
                DataController.UpdateByMemberCode(settlement_InfoInfo.MPUDfCode, settlement_InfoInfo.Status, settlement_InfoInfo.ApproveBy, settlement_InfoInfo.ApproveFrom, settlement_InfoInfo.RejectBy, settlement_InfoInfo.RejectFrom, settlement_InfoInfo.ProcessBy, settlement_InfoInfo.ProcessFrom, settlement_InfoInfo.FileType, settlement_InfoInfo.SettlementDate);
                DataController.CommitTransaction();
            }
            catch (Exception ex)
            {
                DataController.RollbackTransaction();
                return false;
            }
            return true;
        }

        public bool UpdateByMerchantCode(Settlement_InfoCollections settlement_InfoCollections)
        {
            try
            {
                DataController.StartTransaction();
                foreach (Settlement_InfoInfo settlement_InfoInfo in settlement_InfoCollections)
                    DataController.UpdateByMerchantCode(settlement_InfoInfo.Status, settlement_InfoInfo.ApproveBy, settlement_InfoInfo.ApproveFrom, settlement_InfoInfo.RejectBy, settlement_InfoInfo.RejectFrom, settlement_InfoInfo.ProcessBy, settlement_InfoInfo.ProcessFrom, settlement_InfoInfo.MerchantCode, settlement_InfoInfo.UpdatedDate, settlement_InfoInfo.FileType, settlement_InfoInfo.SettlementDate);

                DataController.CommitTransaction();
            }
            catch (Exception ex)
            {
                DataController.RollbackTransaction();
                return false;
            }
            return true;
        }

        public bool UpdateByMerchantCode(Settlement_InfoInfo settlement_InfoInfo)
        {
            try
            {
                DataController.StartTransaction();
                DataController.UpdateByMerchantCode(settlement_InfoInfo.Status, settlement_InfoInfo.ApproveBy, settlement_InfoInfo.ApproveFrom, settlement_InfoInfo.RejectBy, settlement_InfoInfo.RejectFrom, settlement_InfoInfo.ProcessBy, settlement_InfoInfo.ProcessFrom, settlement_InfoInfo.MerchantCode, settlement_InfoInfo.UpdatedDate, settlement_InfoInfo.FileType, settlement_InfoInfo.SettlementDate);
                DataController.CommitTransaction();
            }
            catch (Exception ex)
            {
                DataController.RollbackTransaction();
                return false;
            }
            return true;
        }

        #endregion "Update Methods"

        #region "Delete Methods"

        public void DeleteSettlementUpload()
        {
            DataController.DeleteSettlement_Upload();
        }

        public void DeleteSettlementUpload_forcredit(string Eno)
        {
            DataController.DeleteSettlementuploadforCredit(Eno);
        }

        public bool DeleteByMPUDfCode(Settlement_InfoInfo settlement_InfoInfo)
        {
            Settlement_InfoCollections settlement_InfoCollections = new Settlement_InfoCollections();
            settlement_InfoCollections.Add(settlement_InfoInfo);
            return DeleteByMPUDfCode(settlement_InfoCollections);
        }

        public bool DeleteByMPUDfCode(Settlement_InfoCollections settlement_InfoCollections)
        {
            string uniqueKey = "";
            try
            {
                DataController.StartTransaction();
                foreach (Settlement_InfoInfo settlement_InfoInfo in settlement_InfoCollections)
                {
                    uniqueKey = settlement_InfoInfo.MPUDfCode;
                    DataController.DeleteByMPUDfCode(settlement_InfoInfo.MPUDfCode);
                }
                DataController.CommitTransaction();
            }
            catch (Exception ex)
            {
                DataController.RollbackTransaction();
                return false;
            }

            return true;
        }

        public bool DeleteBySTFFileName(string SettlementFileName)
        {
            string uniqueKey = "";
            try
            {
                DataController.StartTransaction();
                DataController.DeleteByFileName(SettlementFileName);
                DataController.CommitTransaction();
            }
            catch (Exception ex)
            {
                DataController.RollbackTransaction();
                return false;
            }

            return true;
        }

        #endregion "Delete Methods"

        #region Update for Refund

        public bool UpdateRefundStatus(MemberBankDetailTransactionInfoCollections MBCollection)
        {
            try
            {
                DataController.StartTransaction();
                foreach (MemberBankDetailTransactionInfoInfo MBInfo in MBCollection)
                    DataController.UpdateRefundStatus(MBInfo.PAN, MBInfo.settlementAmount,
                                                          MBInfo.transAmount, MBInfo.ServiceFeeReceive,
                                                          MBInfo.ServiceFeePayable, MBInfo.FILENAME,
                                                          MBInfo.RefundStatus, MBInfo.FileType, MBInfo.SETTLEMENTDATE);

                DataController.CommitTransaction();
            }
            catch (Exception ex)
            {
                DataController.RollbackTransaction();
                return false;
            }
            return true;
        }

        #endregion Update for Refund
    }
}