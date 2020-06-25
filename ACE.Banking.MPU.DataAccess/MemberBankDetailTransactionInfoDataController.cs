using System;
using System.Data;

using ACE.Banking.MPU.CollectionSuit;

namespace ACE.Banking.MPU.DataAccess
{
    public class MemberBankDetailTransactionInfoDataController : DataControllerBase
    {
        #region Generated Methods
        #region Select Methods
        public IDataReader Select()
        {
            Command = DB.GetStoredProcCommand("MemberBankDetailTransactionInfo_SelectList");
            return DB.ExecuteReader(Command);
        }

        #endregion

        #region Insert Methods

        public string Insert(string pAN, string processingCode, decimal transAmount, decimal settlementAmt, string setconservationrate, string systemTraceNo, string transDateTime,DateTime sETTLEMENTDATE,
                             string merchantType, string terminalNo, string acquireInstitutionID, string IssuerBankCode, string BeneficiaryBankCode, string forwardInstitutionID, string authResponseCode,
                             string retrievalRefNo, string CardAcceptorTerminalNo, string TransactionCurCode, string SetCurCode, string FromAcc, string ToAcc, string messageType, string cardAcceptorIDCode, 
                             string responseCode, decimal serviceFeeReceive, decimal serviceFeePayable, decimal interChangeServiceFee, string pOSEntryMode, string orgSystemTraceNo, string pOSConditionCode,
                             decimal acceptanceAmount, string cardHolderTransType, decimal cardHolderTransFee,string TranTranmissionDate,  string reservedForUse, DateTime createdDate, decimal batchNo,
                             string fILENAME, string fileType,string TranRespCode ,string RefundStatus)
        {
            Command = DB.GetStoredProcCommand("MemberBankDetailTransactionInfo_Insert_New");

            DB.AddInParameter(Command, "PAN", DbType.String, pAN);
            DB.AddInParameter(Command, "PROCESSINGCODE", DbType.String, GetNull(processingCode));
            DB.AddInParameter(Command, "TRANSAMOUNT", DbType.Decimal, GetNull(transAmount));
            DB.AddInParameter(Command, "SETTLEMENTAMOUNT", DbType.Decimal, GetNull(settlementAmt));
            DB.AddInParameter(Command, "SetConservationRate", DbType.String, GetNull(setconservationrate));
            DB.AddInParameter(Command, "SYSTEMTRACENO", DbType.String, GetNull(systemTraceNo));
            DB.AddInParameter(Command, "TRANSDATETIME", DbType.String, GetNull(transDateTime));
            DB.AddInParameter(Command, "SETTLEMENTDATE", DbType.DateTime, GetNull(sETTLEMENTDATE));
            DB.AddInParameter(Command, "MERCHANTTYPE", DbType.String, GetNull(merchantType));
            DB.AddInParameter(Command, "TERMINALNO", DbType.String, GetNull(terminalNo));
            DB.AddInParameter(Command, "ACQUIREINSTITUTIONID", DbType.String, GetNull(acquireInstitutionID));
            DB.AddInParameter(Command, "IssuerBankCode", DbType.String, GetNull(IssuerBankCode));
            DB.AddInParameter(Command, "BeneficiaryBankCode", DbType.String, GetNull(BeneficiaryBankCode));
            DB.AddInParameter(Command, "FORWARDINSTITUTIONID", DbType.String, GetNull(forwardInstitutionID));
            DB.AddInParameter(Command, "AUTHRESPONSECODE", DbType.String, GetNull(authResponseCode));
            DB.AddInParameter(Command, "RETRIEVALREFNO", DbType.String, GetNull(retrievalRefNo));
            DB.AddInParameter(Command, "CardAcceptorTerminalNo ", DbType.String, GetNull(CardAcceptorTerminalNo));
            DB.AddInParameter(Command, "TransactionCurCode", DbType.String, GetNull(TransactionCurCode));
            DB.AddInParameter(Command, "SettlementCurCode", DbType.String, GetNull(SetCurCode));
            DB.AddInParameter(Command, "FromAccount", DbType.String, GetNull(FromAcc));
            DB.AddInParameter(Command, "ToAccount", DbType.String, GetNull(ToAcc));
            DB.AddInParameter(Command, "MESSAGETYPE", DbType.String, GetNull(messageType));
            DB.AddInParameter(Command, "RESPONSECODE", DbType.String, GetNull(responseCode));
            DB.AddInParameter(Command, "SERVICEFEERECEIVE", DbType.Decimal, GetNull(serviceFeeReceive));
            DB.AddInParameter(Command, "SERVICEFEEPAYABLE", DbType.Decimal, GetNull(serviceFeePayable));
            DB.AddInParameter(Command, "INTERCHANGESERVICEFEE", DbType.Decimal, GetNull(interChangeServiceFee));
            DB.AddInParameter(Command, "POSENTRYMODE", DbType.String, GetNull(pOSEntryMode));
            DB.AddInParameter(Command, "ORGSYSTEMTRACENO", DbType.String, GetNull(orgSystemTraceNo));
            DB.AddInParameter(Command, "POSCONDITIONCODE", DbType.String, GetNull(pOSConditionCode));
            DB.AddInParameter(Command, "CARDACCEPTORIDCODE", DbType.String, GetNull(cardAcceptorIDCode));
            DB.AddInParameter(Command, "ACCEPTANCEAMOUNT", DbType.Decimal, GetNull(acceptanceAmount));

            DB.AddInParameter(Command, "CARDHOLDERTRANSTYPE", DbType.String, GetNull(cardHolderTransType));

            DB.AddInParameter(Command, "CARDHOLDERTRANSFEE", DbType.Decimal, GetNull(cardHolderTransFee));
            DB.AddInParameter(Command, "TranTranmissionDate", DbType.String, GetNull(TranTranmissionDate));
            //DB.AddInParameter(Command, "SANDDSWITCHFLAG", DbType.String, GetNull(sAndDSwitchFlag));
            DB.AddInParameter(Command, "RESERVEDFORUSE", DbType.String, GetNull(reservedForUse));
            DB.AddInParameter(Command, "CREATEDDATE", DbType.DateTime, GetNull(createdDate));
            DB.AddInParameter(Command, "BATCHNO", DbType.Decimal, GetNull(batchNo));
            DB.AddInParameter(Command, "FILENAME", DbType.String, GetNull(fILENAME));
            DB.AddInParameter(Command, "FILETYPE", DbType.String, GetNull(fileType));
            DB.AddInParameter(Command, "TranResCode", DbType.String, GetNull(TranRespCode));
            DB.AddInParameter(Command, "RefundStatus", DbType.String, GetNull(RefundStatus));

            if (UseTransaction)
                DB.ExecuteNonQuery(Command, Transaction);
            else
                DB.ExecuteNonQuery(Command);

            return DB.GetParameterValue(Command, "ACQUIREINSTITUTIONID").ToString();
        }

        #endregion

        #region Update Methods
        public void Update(string acquireInstitutionID, string forwardInstitutionID, string systemTraceNo, string transDateTime, 
            string pAN, decimal transAmount, decimal acceptanceAmount, decimal cardHolderTransFee, string messageType, string processingCode, 
            string merchantType, string terminalNo, string cardAcceptorIDCode, string retrievalRefNo, string pOSConditionCode, string authResponseCode, 
            string recInstitutionID, string orgSystemTraceNo, string responseCode, string pOSEntryMode, decimal serviceFeeReceive, decimal serviceFeePayable, 
            decimal interChangeServiceFee, string sAndDSwitchFlag, string reservedForUse, DateTime createdDate, decimal batchNo, string fILENAME, 
            string fileType, DateTime sETTLEMENTDATE)
        {
            Command = DB.GetStoredProcCommand("MemberBankDetailTransactionInfo_Update");

            DB.AddInParameter(Command, "AcquireInstitutionID", DbType.String, GetNull(acquireInstitutionID));
            DB.AddInParameter(Command, "ForwardInstitutionID", DbType.String, GetNull(forwardInstitutionID));
            DB.AddInParameter(Command, "SystemTraceNo", DbType.String, GetNull(systemTraceNo));
            DB.AddInParameter(Command, "TransDateTime", DbType.String, GetNull(transDateTime));
            DB.AddInParameter(Command, "PAN", DbType.String, GetNull(pAN));
            DB.AddInParameter(Command, "transAmount", DbType.Decimal, GetNull(transAmount));
            DB.AddInParameter(Command, "AcceptanceAmount", DbType.Decimal, GetNull(acceptanceAmount));
            DB.AddInParameter(Command, "CardHolderTransFee", DbType.Decimal, GetNull(cardHolderTransFee));
            DB.AddInParameter(Command, "MessageType", DbType.Decimal, GetNull(messageType));
            DB.AddInParameter(Command, "ProcessingCode", DbType.String, GetNull(processingCode));
            DB.AddInParameter(Command, "MerchantType", DbType.String, GetNull(merchantType));
            DB.AddInParameter(Command, "TerminalNo", DbType.String, GetNull(terminalNo));
            DB.AddInParameter(Command, "CardAcceptorIDCode", DbType.String, GetNull(cardAcceptorIDCode));
            DB.AddInParameter(Command, "RetrievalRefNo", DbType.String, GetNull(retrievalRefNo));
            DB.AddInParameter(Command, "POSConditionCode", DbType.String, GetNull(pOSConditionCode));
            DB.AddInParameter(Command, "AuthResponseCode", DbType.String, GetNull(authResponseCode));
            DB.AddInParameter(Command, "RecInstitutionID", DbType.String, GetNull(recInstitutionID));
            DB.AddInParameter(Command, "OrgSystemTraceNo", DbType.String, GetNull(orgSystemTraceNo));
            DB.AddInParameter(Command, "ResponseCode", DbType.String, GetNull(responseCode));
            DB.AddInParameter(Command, "POSEntryMode", DbType.String, GetNull(pOSEntryMode));
            DB.AddInParameter(Command, "ServiceFeeReceive", DbType.Decimal, GetNull(serviceFeeReceive));
            DB.AddInParameter(Command, "ServiceFeePayable", DbType.Decimal, GetNull(serviceFeePayable));
            DB.AddInParameter(Command, "InterChangeServiceFee", DbType.Decimal, GetNull(interChangeServiceFee));
            DB.AddInParameter(Command, "SAndDSwitchFlag", DbType.String, GetNull(sAndDSwitchFlag));
            DB.AddInParameter(Command, "ReservedForUse", DbType.String, GetNull(reservedForUse));
            DB.AddInParameter(Command, "CreatedDate", DbType.DateTime, GetNull(createdDate));
            DB.AddInParameter(Command, "BatchNo", DbType.Decimal, GetNull(batchNo));
            DB.AddInParameter(Command, "FILENAME", DbType.String, GetNull(fILENAME));
            DB.AddInParameter(Command, "FileType", DbType.String, GetNull(fileType));
            DB.AddInParameter(Command, "SETTLEMENTDATE", DbType.DateTime, GetNull(sETTLEMENTDATE));

            if (UseTransaction)
                DB.ExecuteNonQuery(Command, Transaction);
            else
                DB.ExecuteNonQuery(Command);

        }
        #endregion

        #region Delete Methods

        public void DeleteByAcquireInstitutionID(string acquireInstitutionID)
        {
            Command = DB.GetStoredProcCommand("MemberBankDetailTransactionInfo_DeleteByAcquireInstitutionID");

            DB.AddInParameter(Command, "AcquireInstitutionID", DbType.String, GetNull(acquireInstitutionID));

            if (UseTransaction)
                DB.ExecuteNonQuery(Command, Transaction);
            else
                DB.ExecuteNonQuery(Command);

        }

        #endregion


        #endregion

        #region Customized Methods
        #region Select Methods
        public DataSet SelectByBankID(string BankInstitutionId, DateTime STFDate)
        {
            Command = DB.GetStoredProcCommand("MemberBankDetailTransactionInfo_SelectListByLocalInsID");
            DB.AddInParameter(Command, "LocalInsID", DbType.String, BankInstitutionId);
            DB.AddInParameter(Command, "STFDate", DbType.String, STFDate.ToString("yyyy/MM/dd"));            
            return DB.ExecuteDataSet(Command);
        }

        #endregion
        #endregion
    }
}