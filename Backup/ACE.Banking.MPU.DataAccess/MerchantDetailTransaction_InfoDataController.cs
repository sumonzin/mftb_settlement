using System;
using System.Data;
using ACE.Banking.MPU.CollectionSuit;

namespace ACE.Banking.MPU.DataAccess
{
    public class MerchantDetailTransaction_InfoDataController : DataControllerBase
    {
        #region Generated Methods
        #region Select Methods
        public IDataReader Select()
        {
            Command = DB.GetStoredProcCommand("MerchantDetailTransaction_Info_SelectList");
            return DB.ExecuteReader(Command);
        }
        #endregion

        #region Insert Methods

        public void Insert(decimal acquireInstitutionID, decimal forwardingInstitutionID, decimal systemTraceNo, decimal tranDateTime, decimal pAN, decimal transactionAmount, decimal accptAmount, decimal merchantTranFee, decimal messageType, decimal processingCode, decimal merchantType, string acceptorTerminalID, string acceptorID, string retrievalReferenceNo, decimal pOSConditionCode, string authorizeResponseCode, decimal institutionCode, decimal orgTraceNo, string responseCode, decimal pOSEntryMode, decimal svcFeeRec, decimal svcFeePayable, decimal interchangeSvcFee, decimal switchFlag, string reservedForUse, DateTime createdDate, decimal batchNo,string FileName,DateTime STFDate)
        {
            Command = DB.GetStoredProcCommand("MerchantDetailTransaction_Info_Insert");

            DB.AddInParameter(Command, "AcquireInstitutionID", DbType.Decimal, acquireInstitutionID);
            DB.AddInParameter(Command, "ForwardingInstitutionID", DbType.Decimal, GetNull(forwardingInstitutionID));
            DB.AddInParameter(Command, "SystemTraceNo", DbType.Decimal, GetNull(systemTraceNo));
            DB.AddInParameter(Command, "TranDateTime", DbType.Decimal, GetNull(tranDateTime));
            DB.AddInParameter(Command, "PAN", DbType.Decimal, GetNull(pAN));
            DB.AddInParameter(Command, "TransactionAmount", DbType.Decimal, GetNull(transactionAmount));
            DB.AddInParameter(Command, "AccptAmount", DbType.Decimal, GetNull(accptAmount));
            DB.AddInParameter(Command, "MerchantTranFee", DbType.Decimal, GetNull(merchantTranFee));
            DB.AddInParameter(Command, "MessageType", DbType.Decimal, GetNull(messageType));
            DB.AddInParameter(Command, "ProcessingCode", DbType.Decimal, GetNull(processingCode));
            DB.AddInParameter(Command, "MerchantType", DbType.Decimal, GetNull(merchantType));
            DB.AddInParameter(Command, "AcceptorTerminalID", DbType.String, GetNull(acceptorTerminalID));
            DB.AddInParameter(Command, "AcceptorID", DbType.String, GetNull(acceptorID));
            DB.AddInParameter(Command, "RetrievalReferenceNo", DbType.String, GetNull(retrievalReferenceNo));
            DB.AddInParameter(Command, "POSConditionCode", DbType.Decimal, GetNull(pOSConditionCode));
            DB.AddInParameter(Command, "AuthorizeResponseCode", DbType.String, GetNull(authorizeResponseCode));
            DB.AddInParameter(Command, "InstitutionCode", DbType.Decimal, GetNull(institutionCode));
            DB.AddInParameter(Command, "OrgTraceNo", DbType.Decimal, GetNull(orgTraceNo));
            DB.AddInParameter(Command, "ResponseCode", DbType.String, GetNull(responseCode));
            DB.AddInParameter(Command, "POSEntryMode", DbType.Decimal, GetNull(pOSEntryMode));
            DB.AddInParameter(Command, "SvcFeeRec", DbType.Decimal, GetNull(svcFeeRec));
            DB.AddInParameter(Command, "SvcFeePayable", DbType.Decimal, GetNull(svcFeePayable));
            DB.AddInParameter(Command, "InterchangeSvcFee", DbType.Decimal, GetNull(interchangeSvcFee));
            DB.AddInParameter(Command, "SwitchFlag", DbType.Decimal, GetNull(switchFlag));
            DB.AddInParameter(Command, "ReservedForUse", DbType.String, GetNull(reservedForUse));
            DB.AddInParameter(Command, "CreatedDate", DbType.DateTime, GetNull(createdDate));
            DB.AddInParameter(Command, "BatchNo", DbType.Decimal, GetNull(batchNo));
            DB.AddInParameter(Command, "FILENAME", DbType.String, GetNull(FileName));
            DB.AddInParameter(Command, "STFDate", DbType.Date, GetNull(STFDate));
            DB.ExecuteNonQuery(Command);

        }

        #endregion

        #region Update Methods
        public void Update(decimal acquireInstitutionID, decimal forwardingInstitutionID, decimal systemTraceNo, decimal tranDateTime, decimal pAN, decimal transactionAmount, decimal accptAmount, decimal merchantTranFee, decimal messageType, decimal processingCode, decimal merchantType, string acceptorTerminalID, string acceptorID, string retrievalReferenceNo, decimal pOSConditionCode, string authorizeResponseCode, decimal institutionCode, decimal orgTraceNo, string responseCode, decimal pOSEntryMode, decimal svcFeeRec, decimal svcFeePayable, decimal interchangeSvcFee, decimal switchFlag, string reservedForUse, DateTime createdDate, decimal batchNo, string FileName, DateTime STFDate)
        {
            Command = DB.GetStoredProcCommand("MerchantDetailTransaction_Info_Update");

            DB.AddInParameter(Command, "AcquireInstitutionID", DbType.Decimal, GetNull(acquireInstitutionID));
            DB.AddInParameter(Command, "ForwardingInstitutionID", DbType.Decimal, GetNull(forwardingInstitutionID));
            DB.AddInParameter(Command, "SystemTraceNo", DbType.Decimal, GetNull(systemTraceNo));
            DB.AddInParameter(Command, "TranDateTime", DbType.Decimal, GetNull(tranDateTime));
            DB.AddInParameter(Command, "PAN", DbType.Decimal, GetNull(pAN));
            DB.AddInParameter(Command, "TransactionAmount", DbType.Decimal, GetNull(transactionAmount));
            DB.AddInParameter(Command, "AccptAmount", DbType.Decimal, GetNull(accptAmount));
            DB.AddInParameter(Command, "MerchantTranFee", DbType.Decimal, GetNull(merchantTranFee));
            DB.AddInParameter(Command, "MessageType", DbType.Decimal, GetNull(messageType));
            DB.AddInParameter(Command, "ProcessingCode", DbType.Decimal, GetNull(processingCode));
            DB.AddInParameter(Command, "MerchantType", DbType.Decimal, GetNull(merchantType));
            DB.AddInParameter(Command, "AcceptorTerminalID", DbType.String, GetNull(acceptorTerminalID));
            DB.AddInParameter(Command, "AcceptorID", DbType.String, GetNull(acceptorID));
            DB.AddInParameter(Command, "RetrievalReferenceNo", DbType.String, GetNull(retrievalReferenceNo));
            DB.AddInParameter(Command, "POSConditionCode", DbType.Decimal, GetNull(pOSConditionCode));
            DB.AddInParameter(Command, "AuthorizeResponseCode", DbType.String, GetNull(authorizeResponseCode));
            DB.AddInParameter(Command, "InstitutionCode", DbType.Decimal, GetNull(institutionCode));
            DB.AddInParameter(Command, "OrgTraceNo", DbType.Decimal, GetNull(orgTraceNo));
            DB.AddInParameter(Command, "ResponseCode", DbType.String, GetNull(responseCode));
            DB.AddInParameter(Command, "POSEntryMode", DbType.Decimal, GetNull(pOSEntryMode));
            DB.AddInParameter(Command, "SvcFeeRec", DbType.Decimal, GetNull(svcFeeRec));
            DB.AddInParameter(Command, "SvcFeePayable", DbType.Decimal, GetNull(svcFeePayable));
            DB.AddInParameter(Command, "InterchangeSvcFee", DbType.Decimal, GetNull(interchangeSvcFee));
            DB.AddInParameter(Command, "SwitchFlag", DbType.Decimal, GetNull(switchFlag));
            DB.AddInParameter(Command, "ReservedForUse", DbType.String, GetNull(reservedForUse));
            DB.AddInParameter(Command, "CreatedDate", DbType.DateTime, GetNull(createdDate));
            DB.AddInParameter(Command, "BatchNo", DbType.Decimal, GetNull(batchNo));
            DB.AddInParameter(Command, "FILENAME", DbType.String, GetNull(FileName));
            DB.AddInParameter(Command, "STFDate", DbType.Date, GetNull(STFDate));

            if (UseTransaction)
                DB.ExecuteNonQuery(Command, Transaction);
            else
                DB.ExecuteNonQuery(Command);

        }
        #endregion

        #region Delete Methods

        public void DeleteByAcquireInstitutionID(decimal acquireInstitutionID)
        {
            Command = DB.GetStoredProcCommand("MerchantDetailTransaction_Info_DeleteByAcquireInstitutionID");

            DB.AddInParameter(Command, "AcquireInstitutionID", DbType.Decimal, GetNull(acquireInstitutionID));

            if (UseTransaction)
                DB.ExecuteNonQuery(Command, Transaction);
            else
                DB.ExecuteNonQuery(Command);

        }

        #endregion


        #endregion

        #region Customized Methods
        
        #region Select Methods
        public DataSet SelectByMerchantCode(string MerchantCode,DateTime FileName)
        {
            Command = DB.GetStoredProcCommand("MerchantDetailTransaction_Info_SelectListByMerchantCode");
            DB.AddInParameter(Command, "AcceptorID", DbType.String, MerchantCode);
            DB.AddInParameter(Command, "STFDate", DbType.DateTime, FileName);
            return DB.ExecuteDataSet(Command);
        }
        #endregion

        #endregion
    }
}
