
using System;
using System.Data;
using System.Collections.ObjectModel;

/// <summary>
/// Settlement_ERR_Detail Entity
/// </summary>
namespace ACE.Banking.MPU.CollectionSuit
{
    public class Settlement_ERR_DetailInfo
    {
        private String _disputeTransactionFlag;
        /// <summary>
        /// DisputeTransactionFlag 
        /// </summary> 
        public String DisputeTransactionFlag
        {
            get { return _disputeTransactionFlag; }
            set { _disputeTransactionFlag = value; }
        }
        private Decimal _acquiringInstitutionID;
        /// <summary>
        /// AcquiringInstitutionID 
        /// </summary> 
        public Decimal AcquiringInstitutionID
        {
            get { return _acquiringInstitutionID; }
            set { _acquiringInstitutionID = value; }
        }
        private Decimal _forwardingInstitutionID;
        /// <summary>
        /// ForwardingInstitutionID 
        /// </summary> 
        public Decimal ForwardingInstitutionID
        {
            get { return _forwardingInstitutionID; }
            set { _forwardingInstitutionID = value; }
        }
        private Decimal _systemTraceNumber;
        /// <summary>
        /// SystemTraceNumber 
        /// </summary> 
        public Decimal SystemTraceNumber
        {
            get { return _systemTraceNumber; }
            set { _systemTraceNumber = value; }
        }
        private Decimal _transmissionDateTime;
        /// <summary>
        /// TransmissionDateTime 
        /// </summary> 
        public Decimal TransmissionDateTime
        {
            get { return _transmissionDateTime; }
            set { _transmissionDateTime = value; }
        }
        private Decimal _pAN;
        /// <summary>
        /// PAN 
        /// </summary> 
        public Decimal PAN
        {
            get { return _pAN; }
            set { _pAN = value; }
        }
        private Decimal _transactionAmount;
        /// <summary>
        /// TransactionAmount 
        /// </summary> 
        public Decimal TransactionAmount
        {
            get { return _transactionAmount; }
            set { _transactionAmount = value; }
        }
        private Decimal _messageType;
        /// <summary>
        /// MessageType 
        /// </summary> 
        public Decimal MessageType
        {
            get { return _messageType; }
            set { _messageType = value; }
        }
        private Decimal _processingCode;
        /// <summary>
        /// ProcessingCode 
        /// </summary> 
        public Decimal ProcessingCode
        {
            get { return _processingCode; }
            set { _processingCode = value; }
        }
        private Decimal _merchantType;
        /// <summary>
        /// MerchantType 
        /// </summary> 
        public Decimal MerchantType
        {
            get { return _merchantType; }
            set { _merchantType = value; }
        }
        private String _cardAcceptorTerminalId;
        /// <summary>
        /// CardAcceptorTerminalId 
        /// </summary> 
        public String CardAcceptorTerminalId
        {
            get { return _cardAcceptorTerminalId; }
            set { _cardAcceptorTerminalId = value; }
        }
        private String _originalTransactionRetrievalRefNo;
        /// <summary>
        /// OriginalTransactionRetrievalRefNo 
        /// </summary> 
        public String OriginalTransactionRetrievalRefNo
        {
            get { return _originalTransactionRetrievalRefNo; }
            set { _originalTransactionRetrievalRefNo = value; }
        }
        private Decimal _poitOfServiceCondition;
        /// <summary>
        /// PoitOfServiceCondition 
        /// </summary> 
        public Decimal PoitOfServiceCondition
        {
            get { return _poitOfServiceCondition; }
            set { _poitOfServiceCondition = value; }
        }
        private String _authorizationIDResponse;
        /// <summary>
        /// AuthorizationIDResponse 
        /// </summary> 
        public String AuthorizationIDResponse
        {
            get { return _authorizationIDResponse; }
            set { _authorizationIDResponse = value; }
        }
        private Decimal _receivingInstitutionID;
        /// <summary>
        /// ReceivingInstitutionID 
        /// </summary> 
        public Decimal ReceivingInstitutionID
        {
            get { return _receivingInstitutionID; }
            set { _receivingInstitutionID = value; }
        }
        private Decimal _cardIssBankID;
        /// <summary>
        /// CardIssBankID 
        /// </summary> 
        public Decimal CardIssBankID
        {
            get { return _cardIssBankID; }
            set { _cardIssBankID = value; }
        }
        private Decimal _originalTranSystemTraceNo;
        /// <summary>
        /// OriginalTranSystemTraceNo 
        /// </summary> 
        public Decimal OriginalTranSystemTraceNo
        {
            get { return _originalTranSystemTraceNo; }
            set { _originalTranSystemTraceNo = value; }
        }
        private String _responseCode;
        /// <summary>
        /// ResponseCode 
        /// </summary> 
        public String ResponseCode
        {
            get { return _responseCode; }
            set { _responseCode = value; }
        }
        private Decimal _pointOfServiceEntryModeCode;
        /// <summary>
        /// PointOfServiceEntryModeCode 
        /// </summary> 
        public Decimal PointOfServiceEntryModeCode
        {
            get { return _pointOfServiceEntryModeCode; }
            set { _pointOfServiceEntryModeCode = value; }
        }
        private Decimal _feeCharged;
        /// <summary>
        /// FeeCharged 
        /// </summary> 
        public Decimal FeeCharged
        {
            get { return _feeCharged; }
            set { _feeCharged = value; }
        }
        private Decimal _feePaid;
        /// <summary>
        /// FeePaid 
        /// </summary> 
        public Decimal FeePaid
        {
            get { return _feePaid; }
            set { _feePaid = value; }
        }
        private Decimal _interchangeServiceFee;
        /// <summary>
        /// InterchangeServiceFee 
        /// </summary> 
        public Decimal InterchangeServiceFee
        {
            get { return _interchangeServiceFee; }
            set { _interchangeServiceFee = value; }
        }
        private Decimal _cardHolderTransFee;
        /// <summary>
        /// CardHolderTransFee 
        /// </summary> 
        public Decimal CardHolderTransFee
        {
            get { return _cardHolderTransFee; }
            set { _cardHolderTransFee = value; }
        }
        private Decimal _commissionReceivable;
        /// <summary>
        /// CommissionReceivable 
        /// </summary> 
        public Decimal CommissionReceivable
        {
            get { return _commissionReceivable; }
            set { _commissionReceivable = value; }
        }
        private Decimal _disputeReason;
        /// <summary>
        /// DisputeReason 
        /// </summary> 
        public Decimal DisputeReason
        {
            get { return _disputeReason; }
            set { _disputeReason = value; }
        }
        private String _reservedforUse;
        /// <summary>
        /// ReservedforUse 
        /// </summary> 
        public String ReservedforUse
        {
            get { return _reservedforUse; }
            set { _reservedforUse = value; }
        }
        private DateTime _createDate;
        /// <summary>
        /// CreateDate 
        /// </summary> 
        public DateTime CreateDate
        {
            get { return _createDate; }
            set { _createDate = value; }
        }
        private Decimal _bathNo;
        /// <summary>
        /// BathNo 
        /// </summary> 
        public Decimal BathNo
        {
            get { return _bathNo; }
            set { _bathNo = value; }
        }
        private String _fileName;
        /// <summary>
        /// FileName 
        /// </summary> 
        public String FileName
        {
            get { return _fileName; }
            set { _fileName = value; }
        }
        private String _fileType;
        /// <summary>
        /// FileType 
        /// </summary> 
        public String FileType
        {
            get { return _fileType; }
            set { _fileType = value; }
        }
        private DateTime _sTFDate;
        /// <summary>
        /// STFDate 
        /// </summary> 
        public DateTime STFDate
        {
            get { return _sTFDate; }
            set { _sTFDate = value; }
        }
    }

    /// <summary>
    /// Settlement_ERR_Detail Entity Collections
    /// </summary>
    public class Settlement_ERR_DetailCollections : Collection<Settlement_ERR_DetailInfo> { }
}










