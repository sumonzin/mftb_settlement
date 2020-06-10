using System;
using System.Data;

namespace ACE.Banking.MPU.DataAccess
{
    public class Settlement_InfoDataController : DataControllerBase
    {
        #region Generated Methods
        #region Select Methods
        public IDataReader Select()
        {
            Command = DB.GetStoredProcCommand("Settlement_Info_SelectList");
            return DB.ExecuteReader(Command);
        }

        public IDataReader SelectByStatus(string Status)
        {
            Command = DB.GetStoredProcCommand("Settlement_Info_SelectListByStatus");
            DB.AddInParameter(Command, "Status", DbType.String, Status);
            return DB.ExecuteReader(Command);
        }

        #endregion

        #region Insert Methods
        public string Insert(string mPUDfCode, string outgoingAmoutSign, decimal outgoingAmount, string outgoingFeeSign, decimal outgoingFee, string incomingAmountSign, decimal incomingAmount, string incomingFeeSign, decimal incomingFee, string sTFAmountSign, decimal sTFAmount, string sTFFeeSign, decimal sTFFee, decimal outgoingSummary, decimal incomingSummary, string settlementCurrency, string reserved, DateTime createdDate, DateTime updatedDate, string status, string approveBy, string approveFrom, string RejectBy, string RejectFrom, string processBy, string processFrom, string fileType, string merchantCode, string totalSettlementAmtSign, decimal totalSettlementAmt, string merchantSettlementAccount, string STFFileName,DateTime STFDate)
        {
            Command = DB.GetStoredProcCommand("Settlement_Info_Insert");

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
            DB.AddInParameter(Command, "STFDate", DbType.String, GetNull(STFDate));
            DB.ExecuteNonQuery(Command);

            return mPUDfCode;
        }        
        #endregion

        #region Update Methods
        public void UpdateByMemberCode(string mPUDfCode ,string status , string approveBy , string approveFrom ,string RejectBy,string RejectFrom, string processBy , string processFrom,string fileType,DateTime stfdate )
		{
            Command = DB.GetStoredProcCommand("Settlement_Info_UpdateByMemberCode");
			
			DB.AddInParameter(Command, "MPUDfCode" ,DbType.String ,GetNull(mPUDfCode));
			DB.AddInParameter(Command, "Status" ,DbType.String ,GetNull(status));
			DB.AddInParameter(Command, "ApproveBy" ,DbType.String ,GetNull(approveBy));
			DB.AddInParameter(Command, "ApproveFrom" ,DbType.String ,GetNull(approveFrom));
            DB.AddInParameter(Command, "RejectBy", DbType.String, GetNull(RejectBy));
            DB.AddInParameter(Command, "RejectFrom", DbType.String, GetNull(RejectFrom));
			DB.AddInParameter(Command, "ProcessBy" ,DbType.String ,GetNull(processBy));
			DB.AddInParameter(Command, "ProcessFrom" ,DbType.String ,GetNull(processFrom));
            DB.AddInParameter(Command, "FileType", DbType.String, GetNull(fileType));
            DB.AddInParameter(Command, "STFDate", DbType.DateTime, GetNull(stfdate));
            
		
			DB.ExecuteNonQuery(Command);
        }
        public void UpdateByMerchantCode(string status, string approveBy, string approveFrom, string RejectBy, string RejectFrom, string processBy, string processFrom, string merchantCode, DateTime UpdateDate,string fileType,DateTime stfdate)
        {
            Command = DB.GetStoredProcCommand("Settlement_Info_UpdateByMerchantCode");

            
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
        #endregion

        #region Delete Methods

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
        #endregion
        #endregion

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
        public bool SettlementProcess(string accountno,char amountsign,decimal amount,string datetime,string currency,string eno,string terminalNo,out string refEno,out string ResponseCode)
        {
            Command = DB.GetStoredProcCommand("MerchantSettlementProcess");

            DB.AddInParameter(Command, "Acctno", DbType.String, GetNull(accountno));
            DB.AddInParameter(Command, "AmountSign", DbType.String, GetNull(amountsign));
            DB.AddInParameter(Command, "AMOUNT", DbType.Decimal, GetNull(amount));
            DB.AddInParameter(Command, "DATETIME", DbType.String, GetNull(datetime));
            DB.AddInParameter(Command, "SOURCECUR", DbType.String, GetNull(currency));
            DB.AddInParameter(Command, "ENO", DbType.String, GetNull(eno));
            DB.AddInParameter(Command, "TERMINALNO", DbType.String, GetNull(terminalNo));

            DB.AddOutParameter(Command, "RefEno", DbType.String,11);
            DB.AddOutParameter(Command, "RCODE", DbType.String,2);
            if (UseTransaction)
                DB.ExecuteNonQuery(Command, Transaction);
            else
                DB.ExecuteNonQuery(Command);

            refEno = Convert.ToString(DB.GetParameterValue(Command, "RefEno"));
            ResponseCode = Convert.ToString(DB.GetParameterValue(Command, "RCODE"));

            return true;
        }

        public bool MemberBankSettlementProcess(string InstitutionCode,decimal outgoingAmt,string outgoingAmtSign,decimal outgoingFee,string outgoinfeesign,decimal incomeAmt,string incomeAmtSign,decimal incomefee,string incomefeesign,string STFcurrency,string channel,DateTime STFDateTime,out string eno,out string Rcode)
        {
            Command = DB.GetStoredProcCommand("MEMBERBANKSETTLEMENTPROCESS");
            DB.AddInParameter(Command,"InstitutionID",DbType.String,GetNull(InstitutionCode));
            DB.AddInParameter(Command, "OutgoingAmount", DbType.Decimal, GetNull(outgoingAmt));
            DB.AddInParameter(Command, "OutgoingCharges", DbType.Decimal, GetNull(outgoingFee));
            DB.AddInParameter(Command, "OutgoingAmtSign", DbType.String, GetNull(outgoingAmtSign));
            DB.AddInParameter(Command, "OGTChargesAmtSign", DbType.String, GetNull(outgoinfeesign));
            DB.AddInParameter(Command, "IncomingAmount", DbType.Decimal, GetNull(incomeAmt));
            DB.AddInParameter(Command, "IncomingCharges", DbType.Decimal, GetNull(incomefee));
            DB.AddInParameter(Command, "IncomingAmtSign", DbType.String, GetNull(incomeAmtSign));
            DB.AddInParameter(Command, "IncChargesSign", DbType.String, GetNull(incomefeesign));
            DB.AddInParameter(Command, "SOURCECUR", DbType.String, GetNull(STFcurrency));
            DB.AddInParameter(Command, "Channel", DbType.String, GetNull(channel));
            DB.AddInParameter(Command, "STFDateTime", DbType.String, GetNull(STFDateTime.ToString("yyyy/MM/dd")));
            
            DB.AddOutParameter(Command, "REF@ENO", DbType.String, 11);
            DB.AddOutParameter(Command, "RCODE", DbType.String, 2);
           
           // Rcode = Convert.ToString(DB.GetParameterValue(Command, "RCODE"));

            DB.ExecuteNonQuery(Command);

            eno = Convert.ToString(DB.GetParameterValue(Command, "REF@ENO"));
            Rcode = Convert.ToString(DB.GetParameterValue(Command, "RCODE"));
            return true;

        }
        #endregion
    }
}