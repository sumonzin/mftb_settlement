using System;
using System.Data;

//using System.Data.OracleClient;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Configuration;
using ACE.Banking.MPU.CollectionSuit;
using Oracle.DataAccess.Client;

namespace ACE.Banking.MPU.DataAccess
{
    public class Settlement_InfoDataController : DataControllerBase
    {
        #region Generated Methods

        #region Select Methods

        #region Insert into Settlement_Upload

        //Select Office Account from Infosys for ATM ACQ
        public DataSet SelectOfficeAccForATMACQ()
        {
            var ConnectionString = ConfigurationManager.AppSettings["OrclConnection"];
            DataSet ds = new DataSet();

            try
            {
                using (OracleConnection conn = new OracleConnection(ConnectionString))
                {
                    conn.Open();

                    OracleDataAdapter da = new OracleDataAdapter();
                    OracleCommand cmd = new OracleCommand();
                    cmd.Connection = conn;
                    cmd.CommandText = "custom.Select_OfficeAc_ForATMACQ";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("CV_1", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("CV_2", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("CV_3", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("CV_4", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("CV_5", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("CV_6", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("CV_7", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("CV_8", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("CV_9", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("CV_10", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("CV_11", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("CV_12", OracleDbType.RefCursor).Direction = ParameterDirection.Output;

                    OracleDataAdapter oracleDataAdapter = new OracleDataAdapter(cmd);
                    oracleDataAdapter.Fill(ds);

                    conn.Close();
                    return ds;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IDataReader Selectfromtlf_ForATMACQ(string Eno)
        {
            Command = DB.GetStoredProcCommand("Select_TLF_forATMACQ");
            DB.AddInParameter(Command, "ENO", DbType.String, Eno);
            return DB.ExecuteReader(Command);
        }

        public IDataReader Selectfromtlf_ForATMAISS(string Eno)
        {
            Command = DB.GetStoredProcCommand("Select_TLF_forATMISS");
            DB.AddInParameter(Command, "ENO", DbType.String, Eno);
            return DB.ExecuteReader(Command);
        }

        public IDataReader Selectfromtlf_ForISSECOM(string Eno)
        {
            Command = DB.GetStoredProcCommand("Select_TLF_forISSECOM");
            DB.AddInParameter(Command, "ENO", DbType.String, Eno);
            return DB.ExecuteReader(Command);
        }

        public IDataReader Selectfromtlf_ForISSPOS(string Eno)
        {
            Command = DB.GetStoredProcCommand("Select_TLF_forISSPOS");
            DB.AddInParameter(Command, "ENO", DbType.String, Eno);
            return DB.ExecuteReader(Command);
        }

        public IDataReader Select_DirPOS_Trans(string STFdate)
        {
            Command = DB.GetStoredProcCommand("Select_DirPOS_Trans");
            DB.AddInParameter(Command, "STFDateTime", DbType.String, STFdate);
            return DB.ExecuteReader(Command);
        }
        public IDataReader Select_Sum_DirPOS_Trans(string STFdate)
        {
            Command = DB.GetStoredProcCommand("Select_Sum_DirPOS_Trans");
            DB.AddInParameter(Command, "STFDateTime", DbType.String, STFdate);
            return DB.ExecuteReader(Command);   
        }

        public IDataReader Select_Sum_DirPOS_Trans_03(string STFdate)
        {
            Command = DB.GetStoredProcCommand("Select_Sum_DirPOS_Trans_03");
            DB.AddInParameter(Command, "STFDateTime", DbType.String, STFdate);
            return DB.ExecuteReader(Command);
        }
        public IDataReader Select_Sum_MemberBankDirPOS_Trans(string STFdate)
        {
            Command = DB.GetStoredProcCommand("Select_Sum_MemberBankDirPOS_Trans");
            DB.AddInParameter(Command, "STFDateTime", DbType.String, STFdate);
            return DB.ExecuteReader(Command);
        }


        public IDataReader Select_Sum_MemberBankDirPOS_Trans_3merchant(string STFdate)
        {
            Command = DB.GetStoredProcCommand("[Select_Sum_MemberBankDirPOS_Trans_0.3]");
            DB.AddInParameter(Command, "STFDateTime", DbType.String, STFdate);
            return DB.ExecuteReader(Command);
        }


        public IDataReader Select_Sum_DirPOS_Trans_GroupByMerchantID(string STFdate)
        {
            Command = DB.GetStoredProcCommand("Select_Sum_DirPOS_Trans_GroupByMerchantID");
            DB.AddInParameter(Command, "STFDateTime", DbType.String, STFdate);
            return DB.ExecuteReader(Command);
        }
        public IDataReader SelectAll_Merchant_Rate()
        {
            Command = DB.GetStoredProcCommand("SelectAll_Merchant_Rate");         
            return DB.ExecuteReader(Command);
        }

        public IDataReader Select_commision_byrate(string MerchantID)
        {
            Command = DB.GetStoredProcCommand("Select_commision_byrate");
            DB.AddInParameter(Command, "MerchantID", DbType.String, MerchantID);
            return DB.ExecuteReader(Command);
        }

        public IDataReader Selectfromtlf_ForISSPOSCredit(string Eno)
        {
            Command = DB.GetStoredProcCommand("Select_SettlementUpload_CreditCard");
            return DB.ExecuteReader(Command);
        }

        public IDataReader Select_tlf_CreditCard(string Eno)
        {
            Command = DB.GetStoredProcCommand("Select_tlf_Credit");
            DB.AddInParameter(Command, "ENO", DbType.String, Eno);
            return DB.ExecuteReader(Command);
        }

        public DataSet Select_Gam()
        {
            Select_ServiceOutletCollection datacollection = new Select_ServiceOutletCollection();

          
            var ConnectionString = ConfigurationManager.AppSettings["OrclConnection"];
            try
            {
                using (OracleConnection conn = new OracleConnection(ConnectionString))
                {
                    conn.Open();
                    OracleCommand Orclcommand = new OracleCommand();
                    Orclcommand = conn.CreateCommand();
                    Orclcommand.CommandText = "select g.sol_id as SOLID,g.foracid as ACCTNO from tbaadm.gam g where g.acct_ownership in ('C','E') and SCHM_TYPE='CAA'";
                    OracleDataAdapter oracleDataAdapter = new OracleDataAdapter(Orclcommand);

                    DataSet dt = new DataSet();
                    oracleDataAdapter.Fill(dt);
                    conn.Close();
                    return dt;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IDataReader SelectSOlIDByAcctNo(string ACCNO)
        {
            Command = DB.GetStoredProcCommand("Select_SolIDByAccNo");
            DB.AddInParameter(Command, "ACCNO", DbType.String, ACCNO);
            return DB.ExecuteReader(Command);
        }

        public IDataReader SelectFromTLF_SettlementUpload(string Eno)
        {
            Command = DB.GetStoredProcCommand("SelectTLF_SettlementUpload");
            DB.AddInParameter(Command, "ENO", DbType.String, Eno);
            return DB.ExecuteReader(Command);
        }

        public IDataReader Select_Settlement_Upload()
        {
            Command = DB.GetStoredProcCommand("Select_Settlement_Upload");
            return DB.ExecuteReader(Command);
        }

        #endregion Insert into Settlement_Upload

        public IDataReader SelectRefundList(string STFdatetime)
        {
            Command = DB.GetStoredProcCommand("Select_Refund_List");
            DB.AddInParameter(Command, "STFDateTime", DbType.String, STFdatetime);
            return DB.ExecuteReader(Command);
        }

        public IDataReader SelectRefundListToprocess(string STFdatetime)
        {
            Command = DB.GetStoredProcCommand("Select_Refund_ListToProcess");
            DB.AddInParameter(Command, "STFDateTime", DbType.String, STFdatetime);
            return DB.ExecuteReader(Command);
        }

        public IDataReader Select(string STFdatetime)
        {
            Command = DB.GetStoredProcCommand("Settlement_Info_SelectList_New");

            //0001/01/01
           // STFdatetime  = "2020/07/06";
            // STFdatetime = '2020-05-02 00:00:00.000'


            DB.AddInParameter(Command, "STFdate", DbType.String, STFdatetime);
            return DB.ExecuteReader(Command);
        }

        public IDataReader SelectByStatus(string Status)
        {
            Command = DB.GetStoredProcCommand("Settlement_Info_SelectListByStatus_New");
            DB.AddInParameter(Command, "Status", DbType.String, Status);
            return DB.ExecuteReader(Command);
        }

        public IDataReader SelectByStatus_New(string Status)
        {
            Command = DB.GetStoredProcCommand("Settlement_Info_SelectListForMemberBank_New");
            DB.AddInParameter(Command, "Status", DbType.String, Status);
            return DB.ExecuteReader(Command);
        }

        #endregion Select Methods

        #region Insert Methods

        public void DeleteGam()
        {
            Command = DB.GetStoredProcCommand("Delete_Gam");
            DB.ExecuteNonQuery(Command);
        }

        public void DeleteSettlementuploadforCredit(string ENo)
        {
            Command = DB.GetStoredProcCommand("Delect_Settlementupload_Credit");
            DB.AddInParameter(Command, "Eno", DbType.String, ENo);
            DB.ExecuteNonQuery(Command);
        }

        public void InsertCutOffStartandEndDate(DateTime StartDate, DateTime EndDate, DateTime TranDate)
        {
            Command = DB.GetStoredProcCommand("Insert_CutOffDetail_Info");

            DB.AddInParameter(Command, "StartDate", DbType.DateTime, StartDate);
            DB.AddInParameter(Command, "EndDate", DbType.DateTime, GetNull(EndDate));
            DB.AddInParameter(Command, "TranDate", DbType.DateTime, GetNull(TranDate));

            DB.ExecuteNonQuery(Command);
        }

        //Insert into Own Gam Table
        public void InsertGam(string ACCTNO, string SolID)
        {
            Command = DB.GetStoredProcCommand("Insert_Gam");

            DB.AddInParameter(Command, "ACCTNO", DbType.String, ACCTNO);
            DB.AddInParameter(Command, "SOLID", DbType.String, GetNull(SolID));

            DB.ExecuteNonQuery(Command);
        }

        public void Insert_IBFT_SettlementUpload(IBFT_Request_model model)
        {
            try
            {
                Command = DB.GetStoredProcCommand("Option1_IBFT_Issuer_BNB_Acquirer");

                DB.AddInParameter(Command, "Acq_Debit", DbType.Decimal, model.Acq_Debit);
                DB.AddInParameter(Command, "Iss_Debit", DbType.Decimal, GetNull(model.Iss_Debit));
                DB.AddInParameter(Command, "Iss_Credit", DbType.Decimal, model.Iss_Credit);
                DB.AddInParameter(Command, "Bene_Debit", DbType.Decimal, GetNull(model.Bene_Debit));
                DB.AddInParameter(Command, "Bene_Credit", DbType.Decimal, model.Bene_Credit);
                DB.AddInParameter(Command, "IssandBene_Debit", DbType.Decimal, GetNull(model.IssandBene_Debit));
                DB.AddInParameter(Command, "IssandBene_Credit2", DbType.Decimal, GetNull(model.IssandBene_Credit2));

                DB.ExecuteNonQuery(Command);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public void Insert_POS_ACQ_Merchant_tlf(DIR_POS_Record model)
        {
            try
            {
                Command = DB.GetStoredProcCommand("Insert_POS_ACQ_Merchant_tlf");

                DB.AddInParameter(Command, "MerchantID", DbType.String, model.MerchantID);
                DB.AddInParameter(Command, "TranAmt", DbType.String, GetNull(model.TranAmt));
                DB.AddInParameter(Command, "ServiceFeePayable", DbType.String, model.ServiceFeePayable);
                DB.AddInParameter(Command, "ServiceFeeRecieve", DbType.String, GetNull(model.ServiceFeeReceive));
                DB.AddInParameter(Command, "MerchantRate", DbType.Decimal, model.MerchantRate);
                DB.AddInParameter(Command, "MerchantType", DbType.String, GetNull(model.MerchantType));
                DB.AddInParameter(Command, "STFDate", DbType.DateTime, GetNull(model.STFDate));
                DB.AddInParameter(Command, "CashAdv_Receive", DbType.String, model.CashAdvReceive);

                DB.ExecuteNonQuery(Command);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //Insert into Merchant Settlement Upload
        public void MerchantSettlementUpload(string ACCTNO, string CURCODE, string SERVICEOUTLET, string TRANTYPE, decimal TRANAMT, string TRANPARTICULAR, string ACCRESPCODE, string REFERENCENO,
            string INSTRUMENTTYPE, string INSTRUMENTDATE, string INSTRUMENTALPHA, string INSTRUMENTNUM, string NAVIGAIONFLAT, decimal REFERENCEAMT, string RefCurCode, string RateCode, string ValueDate, string GLDate, string CategoryCode, string ENo, decimal Rate, string Channel)
        {
            Command = DB.GetStoredProcCommand("MerchantSettlement_Upload");

            DB.AddInParameter(Command, "ACCTNO", DbType.String, ACCTNO);
            DB.AddInParameter(Command, "CURCODE", DbType.String, GetNull(CURCODE));
            DB.AddInParameter(Command, "SERVICEOUTLET", DbType.String, GetNull(SERVICEOUTLET));
            DB.AddInParameter(Command, "TRANTYPE", DbType.String, GetNull(TRANTYPE));
            DB.AddInParameter(Command, "TRANAMT", DbType.Decimal, GetNull(TRANAMT));
            DB.AddInParameter(Command, "TRANPARTICULAR", DbType.String, GetNull(TRANPARTICULAR));
            DB.AddInParameter(Command, "ACCRESPCODE", DbType.String, GetNull(ACCRESPCODE));
            DB.AddInParameter(Command, "REFERENCENO", DbType.String, GetNull(REFERENCENO));
            DB.AddInParameter(Command, "INSTRUMENTTYPE", DbType.String, GetNull(INSTRUMENTTYPE));
            DB.AddInParameter(Command, "INSTRUMENTDATE", DbType.DateTime, GetNull(INSTRUMENTDATE));
            DB.AddInParameter(Command, "INSTRUMENTALPHA", DbType.String, GetNull(INSTRUMENTALPHA));
            DB.AddInParameter(Command, "INSTRUMENTNUM", DbType.String, GetNull(INSTRUMENTNUM));
            DB.AddInParameter(Command, "NAVIGAIONFLAT", DbType.String, GetNull(NAVIGAIONFLAT));
            DB.AddInParameter(Command, "REFERENCEAMT", DbType.Decimal, GetNull(REFERENCEAMT));
            DB.AddInParameter(Command, "RefCurCode", DbType.String, GetNull(RefCurCode));
            DB.AddInParameter(Command, "RateCode", DbType.String, GetNull(RateCode));
            DB.AddInParameter(Command, "ValueDate", DbType.DateTime, GetNull(ValueDate));
            DB.AddInParameter(Command, "GLDate", DbType.DateTime, GetNull(GLDate));
            DB.AddInParameter(Command, "CategoryCode", DbType.String, GetNull(CategoryCode));
            DB.AddInParameter(Command, "ENo", DbType.String, GetNull(ENo));
            DB.AddInParameter(Command, "Rate", DbType.Decimal, GetNull(Rate));
            DB.AddInParameter(Command, "Channel", DbType.String, GetNull(Channel));

            DB.ExecuteNonQuery(Command);
            
        }

        public string Insert(string RespCode, string mPUDfCode, string outgoingAmoutSign, decimal outgoingAmount, string outgoingFeeSign, decimal outgoingFee, string incomingAmountSign, decimal incomingAmount, string incomingFeeSign, decimal incomingFee, string sTFAmountSign, decimal sTFAmount, string sTFFeeSign, decimal sTFFee, decimal outgoingSummary, decimal incomingSummary, string settlementCurrency, string reserved, DateTime createdDate, DateTime updatedDate, string status, string approveBy, string approveFrom, string RejectBy, string RejectFrom, string processBy, string processFrom, string fileType, string merchantCode, string totalSettlementAmtSign, decimal totalSettlementAmt, string merchantSettlementAccount, string STFFileName, DateTime STFDate)
        {
            Command = DB.GetStoredProcCommand("Settlement_Info_Insert_New");

            DB.AddInParameter(Command, "RESPCODE", DbType.String, RespCode);
            DB.AddInParameter(Command, "MPUDfCode", DbType.String, mPUDfCode);
            DB.AddInParameter(Command, "OutgoingAmoutSign", DbType.String, GetNull(outgoingAmoutSign));
            DB.AddInParameter(Command, "OutgoingAmount", DbType.Decimal, GetNull(outgoingAmount));
            DB.AddInParameter(Command, "OutgoingFeeSign", DbType.String, GetNull(outgoingFeeSign));
            DB.AddInParameter(Command, "OutgoingFee", DbType.Decimal, GetNull(outgoingFee));
            DB.AddInParameter(Command, "IncomingAmountSign", DbType.String, GetNull(incomingAmountSign));
            DB.AddInParameter(Command, "IncomingAmount", DbType.Decimal, GetNull(incomingAmount));
            DB.AddInParameter(Command, "IncomingFeeSign", DbType.String, GetNull(incomingFeeSign));
            DB.AddInParameter(Command, "IncomingFee", DbType.Decimal, GetNull(incomingFee));
            DB.AddInParameter(Command, "STFAmountSign", DbType.String, GetNull(sTFAmountSign));
            DB.AddInParameter(Command, "STFAmount", DbType.Decimal, GetNull(sTFAmount));
            DB.AddInParameter(Command, "STFFeeSign", DbType.String, GetNull(sTFFeeSign));
            DB.AddInParameter(Command, "STFFee", DbType.Decimal, GetNull(sTFFee));
            DB.AddInParameter(Command, "OutgoingSummary", DbType.Decimal, GetNull(outgoingSummary));
            DB.AddInParameter(Command, "IncomingSummary", DbType.Decimal, GetNull(incomingSummary));
            DB.AddInParameter(Command, "SettlementCurrency", DbType.String, GetNull(settlementCurrency));
            DB.AddInParameter(Command, "Reserved", DbType.String, GetNull(reserved));
            DB.AddInParameter(Command, "CreatedDate", DbType.DateTime, GetNull(createdDate));
            DB.AddInParameter(Command, "UpdatedDate", DbType.DateTime, GetNull(updatedDate));
            DB.AddInParameter(Command, "Status", DbType.String, GetNull(status));
            DB.AddInParameter(Command, "ApproveBy", DbType.String, GetNull(approveBy));
            DB.AddInParameter(Command, "ApproveFrom", DbType.String, GetNull(approveFrom));
            DB.AddInParameter(Command, "RejectBy", DbType.String, GetNull(RejectBy));
            DB.AddInParameter(Command, "RejectFrom", DbType.String, GetNull(RejectFrom));
            DB.AddInParameter(Command, "ProcessBy", DbType.String, GetNull(processBy));
            DB.AddInParameter(Command, "ProcessFrom", DbType.String, GetNull(processFrom));
            DB.AddInParameter(Command, "FileType", DbType.String, GetNull(fileType));
            DB.AddInParameter(Command, "MerchantCode", DbType.String, GetNull(merchantCode));
            DB.AddInParameter(Command, "TotalSettlementAmtSign", DbType.String, GetNull(totalSettlementAmtSign));
            DB.AddInParameter(Command, "TotalSettlementAmt", DbType.Decimal, GetNull(totalSettlementAmt));
            DB.AddInParameter(Command, "MerchantSettlementAccount", DbType.String, GetNull(merchantSettlementAccount));
            DB.AddInParameter(Command, "STFFileName", DbType.String, GetNull(STFFileName));
            DB.AddInParameter(Command, "STFDate", DbType.DateTime, GetNull(STFDate));
            DB.ExecuteNonQuery(Command);

            return mPUDfCode;
        }

        #endregion Insert Methods

        #region Update Methods

        public void UpdateByMemberCode(string mPUDfCode, string status, string approveBy, string approveFrom, string RejectBy, string RejectFrom, string processBy, string processFrom, string fileType, DateTime stfdate)
        {
            Command = DB.GetStoredProcCommand("Settlement_Info_UpdateByMemberCode_New");

            DB.AddInParameter(Command, "MPUDfCode", DbType.String, GetNull(mPUDfCode));
            DB.AddInParameter(Command, "Status", DbType.String, GetNull(status));
            DB.AddInParameter(Command, "ApproveBy", DbType.String, GetNull(approveBy));
            DB.AddInParameter(Command, "ApproveFrom", DbType.String, GetNull(approveFrom));
            DB.AddInParameter(Command, "RejectBy", DbType.String, GetNull(RejectBy));
            DB.AddInParameter(Command, "RejectFrom", DbType.String, GetNull(RejectFrom));
            DB.AddInParameter(Command, "ProcessBy", DbType.String, GetNull(processBy));
            DB.AddInParameter(Command, "ProcessFrom", DbType.String, GetNull(processFrom));
            DB.AddInParameter(Command, "FileType", DbType.String, GetNull(fileType));
            DB.AddInParameter(Command, "STFDate", DbType.DateTime, GetNull(stfdate));

            DB.ExecuteNonQuery(Command);
        }

        public void UpdateByMerchantCode(string status, string approveBy, string approveFrom, string RejectBy, string RejectFrom, string processBy, string processFrom, string merchantCode, DateTime UpdateDate, string fileType, DateTime stfdate)
        {
            Command = DB.GetStoredProcCommand("Settlement_Info_UpdateByMerchantCode_New");

            DB.AddInParameter(Command, "Status", DbType.String, GetNull(status));
            DB.AddInParameter(Command, "ApproveBy", DbType.String, GetNull(approveBy));
            DB.AddInParameter(Command, "ApproveFrom", DbType.String, GetNull(approveFrom));
            DB.AddInParameter(Command, "RejectBy", DbType.String, GetNull(RejectBy));
            DB.AddInParameter(Command, "RejectFrom", DbType.String, GetNull(RejectFrom));
            DB.AddInParameter(Command, "ProcessBy", DbType.String, GetNull(processBy));
            DB.AddInParameter(Command, "ProcessFrom", DbType.String, GetNull(processFrom));
            DB.AddInParameter(Command, "MerchantCode", DbType.String, GetNull(merchantCode));
            DB.AddInParameter(Command, "UpdateDate", DbType.String, GetNull(UpdateDate));
            DB.AddInParameter(Command, "FileType", DbType.String, GetNull(fileType));
            DB.AddInParameter(Command, "STFDate", DbType.DateTime, GetNull(stfdate));

            DB.ExecuteNonQuery(Command);
        }

        #endregion Update Methods

        #region Delete Methods

        public void DeleteSettlement_Upload()
        {
            Command = DB.GetStoredProcCommand("Delete_Settlement_Upload");
            DB.ExecuteNonQuery(Command);
        }

        public void DeleteByMPUDfCode(string mPUDfCode)
        {
            Command = DB.GetStoredProcCommand("Settlement_Info_DeleteByMPUDfCode");

            DB.AddInParameter(Command, "MPUDfCode", DbType.String, GetNull(mPUDfCode));
            DB.ExecuteNonQuery(Command);
        }

        public void DeleteByMerchantCode(string MerchantCode)
        {
            Command = DB.GetStoredProcCommand("Settlement_Info_DeleteByMerchantCode");

            DB.AddInParameter(Command, "MerchantCode", DbType.String, GetNull(MerchantCode));
            DB.ExecuteNonQuery(Command);
        }

        public void DeleteByFileName(string STFFileName)
        {
            Command = DB.GetStoredProcCommand("Settlement_Info_DeleteByFileName");

            DB.AddInParameter(Command, "STFFileName", DbType.String, GetNull(STFFileName));
            DB.ExecuteNonQuery(Command);
        }

        #endregion Delete Methods

        #endregion Generated Methods

        #region Customized Methods

        public IDataReader FindBy(string mPUDfCode, string outgoingAmoutSign, decimal outgoingAmount, string outgoingFeeSign, decimal outgoingFee, string incomingAmountSign, decimal incomingAmount, string incomingFeeSign, decimal incomingFee, string sTFAmountSign, decimal sTFAmount, string sTFFeeSign, decimal sTFFee, decimal outgoingSummary, decimal incomingSummary, string settlementCurrency, string reserved, DateTime createdDate, DateTime updatedDate, string status, string approveBy, string approveFrom, string RejectBy, string RejectFrom, string processBy, string processFrom, string fileType, string merchantCode, string totalSettlementAmtSign, decimal totalSettlementAmt, string merchantSettlementAccount)
        {
            Command = DB.GetStoredProcCommand("Settlement_Info_Find");

            DB.AddInParameter(Command, "MPUDfCode", DbType.String, mPUDfCode);
            DB.AddInParameter(Command, "OutgoingAmoutSign", DbType.String, GetNull(outgoingAmoutSign));
            DB.AddInParameter(Command, "OutgoingAmount", DbType.Decimal, GetNull(outgoingAmount));
            DB.AddInParameter(Command, "OutgoingFeeSign", DbType.String, GetNull(outgoingFeeSign));
            DB.AddInParameter(Command, "OutgoingFee", DbType.Decimal, GetNull(outgoingFee));
            DB.AddInParameter(Command, "IncomingAmountSign", DbType.String, GetNull(incomingAmountSign));
            DB.AddInParameter(Command, "IncomingAmount", DbType.Decimal, GetNull(incomingAmount));
            DB.AddInParameter(Command, "IncomingFeeSign", DbType.String, GetNull(incomingFeeSign));
            DB.AddInParameter(Command, "IncomingFee", DbType.Decimal, GetNull(incomingFee));
            DB.AddInParameter(Command, "STFAmountSign", DbType.String, GetNull(sTFAmountSign));
            DB.AddInParameter(Command, "STFAmount", DbType.Decimal, GetNull(sTFAmount));
            DB.AddInParameter(Command, "STFFeeSign", DbType.String, GetNull(sTFFeeSign));
            DB.AddInParameter(Command, "STFFee", DbType.Decimal, GetNull(sTFFee));
            DB.AddInParameter(Command, "OutgoingSummary", DbType.Decimal, GetNull(outgoingSummary));
            DB.AddInParameter(Command, "IncomingSummary", DbType.Decimal, GetNull(incomingSummary));
            DB.AddInParameter(Command, "SettlementCurrency", DbType.String, GetNull(settlementCurrency));
            DB.AddInParameter(Command, "Reserved", DbType.String, GetNull(reserved));
            DB.AddInParameter(Command, "CreatedDate", DbType.DateTime, GetNull(createdDate));
            DB.AddInParameter(Command, "UpdatedDate", DbType.DateTime, GetNull(updatedDate));
            DB.AddInParameter(Command, "Status", DbType.String, GetNull(status));
            DB.AddInParameter(Command, "ApproveBy", DbType.String, GetNull(approveBy));
            DB.AddInParameter(Command, "ApproveFrom", DbType.String, GetNull(approveFrom));
            DB.AddInParameter(Command, "RejectBy", DbType.String, GetNull(RejectBy));
            DB.AddInParameter(Command, "RejectFrom", DbType.String, GetNull(RejectFrom));
            DB.AddInParameter(Command, "ProcessBy", DbType.String, GetNull(processBy));
            DB.AddInParameter(Command, "ProcessFrom", DbType.String, GetNull(processFrom));
            DB.AddInParameter(Command, "FileType", DbType.String, GetNull(fileType));
            DB.AddInParameter(Command, "MerchantCode", DbType.String, GetNull(merchantCode));
            DB.AddInParameter(Command, "TotalSettlementAmtSign", DbType.String, GetNull(totalSettlementAmtSign));
            DB.AddInParameter(Command, "TotalSettlementAmt", DbType.Decimal, GetNull(totalSettlementAmt));
            DB.AddInParameter(Command, "MerchantSettlementAccount", DbType.String, GetNull(merchantSettlementAccount));

            return DB.ExecuteReader(Command);
        }

        public bool SettlementProcess(string accountno, char amountsign, decimal amount, string datetime, string currency, string eno, string terminalNo, string merchantcode, DateTime settlementdate, out string refEno, out string ResponseCode)
        {
            Command = DB.GetStoredProcCommand("MerchantSettlementProcess");

            DB.AddInParameter(Command, "Acctno", DbType.String, GetNull(accountno));
            DB.AddInParameter(Command, "AmountSign", DbType.String, GetNull(amountsign));
            DB.AddInParameter(Command, "AMOUNT", DbType.Decimal, GetNull(amount));
            DB.AddInParameter(Command, "DATETIME", DbType.String, GetNull(datetime));
            DB.AddInParameter(Command, "SOURCECUR", DbType.String, GetNull(currency));
            DB.AddInParameter(Command, "ENO", DbType.String, GetNull(eno));
            DB.AddInParameter(Command, "TERMINALNO", DbType.String, GetNull(terminalNo));
            DB.AddInParameter(Command, "MERCHANTCODE", DbType.String, GetNull(merchantcode));
            DB.AddInParameter(Command, "STFDate", DbType.String, GetNull(settlementdate.ToString("yyyy/MM/dd")));
            DB.AddOutParameter(Command, "RefEno", DbType.String, 11);
            DB.AddOutParameter(Command, "RCODE", DbType.String, 2);
            if (UseTransaction)
                DB.ExecuteNonQuery(Command, Transaction);
            else
                DB.ExecuteNonQuery(Command);

            refEno = Convert.ToString(DB.GetParameterValue(Command, "RefEno"));
            ResponseCode = Convert.ToString(DB.GetParameterValue(Command, "RCODE"));

            return true;
        }

        //------------------for Ecom Tran(sym)---------------------
        public bool SettlementProcessECOM(string accountno, char amountsign, decimal amount, string datetime, string currency, string eno, string terminalNo, string merchantcode, DateTime settlementdate, out string refEno, out string ResponseCode)
        {
            Command = DB.GetStoredProcCommand("MerchantSettlementProcess_ECOM");

            DB.AddInParameter(Command, "Acctno", DbType.String, GetNull(accountno));
            DB.AddInParameter(Command, "AmountSign", DbType.String, GetNull(amountsign));
            DB.AddInParameter(Command, "AMOUNT", DbType.Decimal, GetNull(amount));
            DB.AddInParameter(Command, "DATETIME", DbType.String, GetNull(datetime));
            DB.AddInParameter(Command, "SOURCECUR", DbType.String, GetNull(currency));
            DB.AddInParameter(Command, "ENO", DbType.String, GetNull(eno));
            DB.AddInParameter(Command, "TERMINALNO", DbType.String, GetNull(terminalNo));
            DB.AddInParameter(Command, "MERCHANTCODE", DbType.String, GetNull(merchantcode));
            DB.AddInParameter(Command, "STFDate", DbType.String, GetNull(settlementdate.ToString("yyyy/MM/dd")));
            DB.AddOutParameter(Command, "RefEno", DbType.String, 11);
            DB.AddOutParameter(Command, "RCODE", DbType.String, 2);
            if (UseTransaction)
                DB.ExecuteNonQuery(Command, Transaction);
            else
                DB.ExecuteNonQuery(Command);

            refEno = Convert.ToString(DB.GetParameterValue(Command, "RefEno"));
            ResponseCode = Convert.ToString(DB.GetParameterValue(Command, "RCODE"));

            return true;
        }

        //---------------------end--------------------------------

        public bool MemberBankSettlementProcess(string channel, DateTime STFDateTime, out string eno, out string Rcode)
        {
            Command = DB.GetStoredProcCommand("MEMBERBANKSETTLEMENTPROCESS_NEW");

            DB.AddInParameter(Command, "SOURCECUR", DbType.String, GetNull("104"));
            DB.AddInParameter(Command, "Channel", DbType.String, GetNull(channel));

            DB.AddOutParameter(Command, "REF@ENO", DbType.String, 11);
            DB.AddOutParameter(Command, "RCODE", DbType.String, 2);

            // Rcode = Convert.ToString(DB.GetParameterValue(Command, "RCODE"));

            DB.ExecuteNonQuery(Command);

            eno = Convert.ToString(DB.GetParameterValue(Command, "REF@ENO"));
            Rcode = Convert.ToString(DB.GetParameterValue(Command, "RCODE"));
            return true;
        }

        #endregion Customized Methods

        #region Update for Refund

        public void UpdateRefundStatus(string pan, decimal settlementamt, decimal transamt, decimal servicefeeres, decimal servicefeepay,
                                       string filename, string Refundstatus, string filetype, DateTime settlementdate)
        {
            Command = DB.GetStoredProcCommand("Update_RefundStatus");

            DB.AddInParameter(Command, "pan", DbType.String, GetNull(pan));
            DB.AddInParameter(Command, "settlementamt", DbType.Decimal, GetNull(settlementamt));
            DB.AddInParameter(Command, "transamt", DbType.Decimal, GetNull(transamt));
            DB.AddInParameter(Command, "servicefeeres", DbType.Decimal, GetNull(servicefeeres));
            DB.AddInParameter(Command, "servicefeepay", DbType.Decimal, GetNull(servicefeepay));
            DB.AddInParameter(Command, "filename", DbType.String, GetNull(filename));
            DB.AddInParameter(Command, "Refundstatus", DbType.String, GetNull(Refundstatus));
            DB.AddInParameter(Command, "filetype", DbType.String, GetNull(filetype));
            DB.AddInParameter(Command, "settlementdate", DbType.DateTime, GetNull(settlementdate));

            DB.ExecuteNonQuery(Command);
        }

        #endregion Update for Refund
    }
}