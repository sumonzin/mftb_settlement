
using System;
using System.Data;

namespace ACE.Banking.MPU.DataAccess
{
    public class Settlement_ERR_DetailDataController : DataControllerBase
    {
        #region Generated Methods
        #region Select Methods
        public IDataReader Select()
        {
            Command = DB.GetStoredProcCommand("Settlement_ERR_Detail_SelectList");
            return DB.ExecuteReader(Command);
        }

        #endregion

        #region Insert Methods

        public string Insert(string disputeTransactionFlag, decimal acquiringInstitutionID, decimal forwardingInstitutionID, decimal systemTraceNumber, decimal transmissionDateTime, decimal pAN, decimal transactionAmount, decimal messageType, decimal processingCode, decimal merchantType, string cardAcceptorTerminalID, string originalTransactionRetrievalRefNo, decimal poitOfServiceCondition, string authorizationIDResponse, decimal receivingInstitutionID, decimal cardIssBankID, decimal originalTranSystemTraceNo, string responseCode, decimal pointOfServiceEntryModeCode, decimal feeCharged, decimal feePaid, decimal interchangeServiceFee, decimal cardHolderTransFee, decimal commissionReceivable, decimal disputeReason, string reservedforUse, DateTime createDate, decimal bathNo, string fileName, string fileType, DateTime sTFDate)
        {
            Command = DB.GetStoredProcCommand("Settlement_ERR_Detail_Insert");

            DB.AddOutParameter(Command, "DisputeTransactionFlag", DbType.String, 36);
            DB.AddInParameter(Command, "AcquiringInstitutionID", DbType.Decimal, GetNull(acquiringInstitutionID));
            DB.AddInParameter(Command, "ForwardingInstitutionID", DbType.Decimal, GetNull(forwardingInstitutionID));
            DB.AddInParameter(Command, "SystemTraceNumber", DbType.Decimal, GetNull(systemTraceNumber));
            DB.AddInParameter(Command, "TransmissionDateTime", DbType.Decimal, GetNull(transmissionDateTime));
            DB.AddInParameter(Command, "PAN", DbType.Decimal, GetNull(pAN));
            DB.AddInParameter(Command, "TransactionAmount", DbType.Decimal, GetNull(transactionAmount));
            DB.AddInParameter(Command, "MessageType", DbType.Decimal, GetNull(messageType));
            DB.AddInParameter(Command, "ProcessingCode", DbType.Decimal, GetNull(processingCode));
            DB.AddInParameter(Command, "MerchantType", DbType.Decimal, GetNull(merchantType));
            DB.AddInParameter(Command, "CardAcceptorTerminalId", DbType.String, GetNull(cardAcceptorTerminalID));
            DB.AddInParameter(Command, "OriginalTransactionRetrievalRefNo", DbType.String, GetNull(originalTransactionRetrievalRefNo));
            DB.AddInParameter(Command, "PoitOfServiceCondition", DbType.Decimal, GetNull(poitOfServiceCondition));
            DB.AddInParameter(Command, "AuthorizationIDResponse", DbType.String, GetNull(authorizationIDResponse));
            DB.AddInParameter(Command, "ReceivingInstitutionID", DbType.Decimal, GetNull(receivingInstitutionID));
            DB.AddInParameter(Command, "CardIssBankID", DbType.Decimal, GetNull(cardIssBankID));
            DB.AddInParameter(Command, "OriginalTranSystemTraceNo", DbType.Decimal, GetNull(originalTranSystemTraceNo));
            DB.AddInParameter(Command, "ResponseCode", DbType.String, GetNull(responseCode));
            DB.AddInParameter(Command, "PointOfServiceEntryModeCode", DbType.Decimal, GetNull(pointOfServiceEntryModeCode));
            DB.AddInParameter(Command, "FeeCharged", DbType.Decimal, GetNull(feeCharged));
            DB.AddInParameter(Command, "FeePaid", DbType.Decimal, GetNull(feePaid));
            DB.AddInParameter(Command, "InterchangeServiceFee", DbType.Decimal, GetNull(interchangeServiceFee));
            DB.AddInParameter(Command, "CardHolderTransFee", DbType.Decimal, GetNull(cardHolderTransFee));
            DB.AddInParameter(Command, "CommissionReceivable", DbType.Decimal, GetNull(commissionReceivable));
            DB.AddInParameter(Command, "DisputeReason", DbType.Decimal, GetNull(disputeReason));
            DB.AddInParameter(Command, "ReservedforUse", DbType.String, GetNull(reservedforUse));
            DB.AddInParameter(Command, "CreateDate", DbType.DateTime, GetNull(createDate));
            DB.AddInParameter(Command, "BathNo", DbType.Decimal, GetNull(bathNo));
            DB.AddInParameter(Command, "FileName", DbType.String, GetNull(fileName));
            DB.AddInParameter(Command, "FileType", DbType.String, GetNull(fileType));
            DB.AddInParameter(Command, "STFDate", DbType.DateTime, GetNull(sTFDate));


            if (UseTransaction)
                DB.ExecuteNonQuery(Command, Transaction);
            else
                DB.ExecuteNonQuery(Command);

            return DB.GetParameterValue(Command, "DisputeTransactionFlag").ToString();
        }

        #endregion

        #region Update Methods
        public void Update(string disputeTransactionFlag, decimal acquiringInstitutionID, decimal forwardingInstitutionID, decimal systemTraceNumber, decimal transmissionDateTime, decimal pAN, decimal transactionAmount, decimal messageType, decimal processingCode, decimal merchantType, string cardAcceptorTerminalID, string originalTransactionRetrievalRefNo, decimal poitOfServiceCondition, string authorizationIDResponse, decimal receivingInstitutionID, decimal cardIssBankID, decimal originalTranSystemTraceNo, string responseCode, decimal pointOfServiceEntryModeCode, decimal feeCharged, decimal feePaid, decimal interchangeServiceFee, decimal cardHolderTransFee, decimal commissionReceivable, decimal disputeReason, string reservedforUse, DateTime createDate, decimal bathNo, string fileName, string fileType, DateTime sTFDate)
        {
            Command = DB.GetStoredProcCommand("Settlement_ERR_Detail_Update");

            DB.AddInParameter(Command, "DisputeTransactionFlag", DbType.String, GetNull(disputeTransactionFlag));
            DB.AddInParameter(Command, "AcquiringInstitutionID", DbType.Decimal, GetNull(acquiringInstitutionID));
            DB.AddInParameter(Command, "ForwardingInstitutionID", DbType.Decimal, GetNull(forwardingInstitutionID));
            DB.AddInParameter(Command, "SystemTraceNumber", DbType.Decimal, GetNull(systemTraceNumber));
            DB.AddInParameter(Command, "TransmissionDateTime", DbType.Decimal, GetNull(transmissionDateTime));
            DB.AddInParameter(Command, "PAN", DbType.Decimal, GetNull(pAN));
            DB.AddInParameter(Command, "TransactionAmount", DbType.Decimal, GetNull(transactionAmount));
            DB.AddInParameter(Command, "MessageType", DbType.Decimal, GetNull(messageType));
            DB.AddInParameter(Command, "ProcessingCode", DbType.Decimal, GetNull(processingCode));
            DB.AddInParameter(Command, "MerchantType", DbType.Decimal, GetNull(merchantType));
            DB.AddInParameter(Command, "CardAcceptorTerminalId", DbType.String, GetNull(cardAcceptorTerminalID));
            DB.AddInParameter(Command, "OriginalTransactionRetrievalRefNo", DbType.String, GetNull(originalTransactionRetrievalRefNo));
            DB.AddInParameter(Command, "PoitOfServiceCondition", DbType.Decimal, GetNull(poitOfServiceCondition));
            DB.AddInParameter(Command, "AuthorizationIDResponse", DbType.String, GetNull(authorizationIDResponse));
            DB.AddInParameter(Command, "ReceivingInstitutionID", DbType.Decimal, GetNull(receivingInstitutionID));
            DB.AddInParameter(Command, "CardIssBankID", DbType.Decimal, GetNull(cardIssBankID));
            DB.AddInParameter(Command, "OriginalTranSystemTraceNo", DbType.Decimal, GetNull(originalTranSystemTraceNo));
            DB.AddInParameter(Command, "ResponseCode", DbType.String, GetNull(responseCode));
            DB.AddInParameter(Command, "PointOfServiceEntryModeCode", DbType.Decimal, GetNull(pointOfServiceEntryModeCode));
            DB.AddInParameter(Command, "FeeCharged", DbType.Decimal, GetNull(feeCharged));
            DB.AddInParameter(Command, "FeePaid", DbType.Decimal, GetNull(feePaid));
            DB.AddInParameter(Command, "InterchangeServiceFee", DbType.Decimal, GetNull(interchangeServiceFee));
            DB.AddInParameter(Command, "CardHolderTransFee", DbType.Decimal, GetNull(cardHolderTransFee));
            DB.AddInParameter(Command, "CommissionReceivable", DbType.Decimal, GetNull(commissionReceivable));
            DB.AddInParameter(Command, "DisputeReason", DbType.Decimal, GetNull(disputeReason));
            DB.AddInParameter(Command, "ReservedforUse", DbType.String, GetNull(reservedforUse));
            DB.AddInParameter(Command, "CreateDate", DbType.DateTime, GetNull(createDate));
            DB.AddInParameter(Command, "BathNo", DbType.Decimal, GetNull(bathNo));
            DB.AddInParameter(Command, "FileName", DbType.String, GetNull(fileName));
            DB.AddInParameter(Command, "FileType", DbType.String, GetNull(fileType));
            DB.AddInParameter(Command, "STFDate", DbType.DateTime, GetNull(sTFDate));

            if (UseTransaction)
                DB.ExecuteNonQuery(Command, Transaction);
            else
                DB.ExecuteNonQuery(Command);

        }
        #endregion

        #region Delete Methods

        public void DeleteByDisputeTransactionFlag(string disputeTransactionFlag)
        {
            Command = DB.GetStoredProcCommand("Settlement_ERR_Detail_DeleteByDisputeTransactionFlag");

            DB.AddInParameter(Command, "DisputeTransactionFlag", DbType.String, GetNull(disputeTransactionFlag));

            if (UseTransaction)
                DB.ExecuteNonQuery(Command, Transaction);
            else
                DB.ExecuteNonQuery(Command);

        }

        #endregion


        #endregion

        #region Customized Methods
        #endregion
    }
}



