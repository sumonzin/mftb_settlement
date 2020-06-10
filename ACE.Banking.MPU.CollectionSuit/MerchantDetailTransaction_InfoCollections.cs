using System;
using System.Data;
using System.Collections.ObjectModel;

namespace ACE.Banking.MPU.CollectionSuit
{
    public class MerchantDetailTransaction_InfoInfo
    {
        private Decimal _acquireInstitutionID;
        /// <summary>
        /// AcquireInstitutionID 
        /// </summary> 
        public Decimal AcquireInstitutionID
        {
            get { return _acquireInstitutionID; }
            set { _acquireInstitutionID = value; }
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
        private Decimal _systemTraceNo;
        /// <summary>
        /// SystemTraceNo 
        /// </summary> 
        public Decimal SystemTraceNo
        {
            get { return _systemTraceNo; }
            set { _systemTraceNo = value; }
        }
        private Decimal _tranDateTime;
        /// <summary>
        /// TranDateTime 
        /// </summary> 
        public Decimal TranDateTime
        {
            get { return _tranDateTime; }
            set { _tranDateTime = value; }
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
        private Decimal _accptAmount;
        /// <summary>
        /// AccptAmount 
        /// </summary> 
        public Decimal AccptAmount
        {
            get { return _accptAmount; }
            set { _accptAmount = value; }
        }
        private Decimal _merchantTranFee;
        /// <summary>
        /// MerchantTranFee 
        /// </summary> 
        public Decimal MerchantTranFee
        {
            get { return _merchantTranFee; }
            set { _merchantTranFee = value; }
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
        private String _acceptorTerminalID;
        /// <summary>
        /// AcceptorTerminalID 
        /// </summary> 
        public String AcceptorTerminalID
        {
            get { return _acceptorTerminalID; }
            set { _acceptorTerminalID = value; }
        }
        private String _acceptorID;
        /// <summary>
        /// AcceptorID 
        /// </summary> 
        public String AcceptorID
        {
            get { return _acceptorID; }
            set { _acceptorID = value; }
        }
        private String _retrievalReferenceNo;
        /// <summary>
        /// RetrievalReferenceNo 
        /// </summary> 
        public String RetrievalReferenceNo
        {
            get { return _retrievalReferenceNo; }
            set { _retrievalReferenceNo = value; }
        }
        private Decimal _pOSConditionCode;
        /// <summary>
        /// POSConditionCode 
        /// </summary> 
        public Decimal POSConditionCode
        {
            get { return _pOSConditionCode; }
            set { _pOSConditionCode = value; }
        }
        private String _authorizeResponseCode;
        /// <summary>
        /// AuthorizeResponseCode 
        /// </summary> 
        public String AuthorizeResponseCode
        {
            get { return _authorizeResponseCode; }
            set { _authorizeResponseCode = value; }
        }
        private Decimal _institutionCode;
        /// <summary>
        /// InstitutionCode 
        /// </summary> 
        public Decimal InstitutionCode
        {
            get { return _institutionCode; }
            set { _institutionCode = value; }
        }
        private Decimal _orgTraceNo;
        /// <summary>
        /// OrgTraceNo 
        /// </summary> 
        public Decimal OrgTraceNo
        {
            get { return _orgTraceNo; }
            set { _orgTraceNo = value; }
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
        private Decimal _pOSEntryMode;
        /// <summary>
        /// POSEntryMode 
        /// </summary> 
        public Decimal POSEntryMode
        {
            get { return _pOSEntryMode; }
            set { _pOSEntryMode = value; }
        }
        private Decimal _svcFeeRec;
        /// <summary>
        /// SvcFeeRec 
        /// </summary> 
        public Decimal SvcFeeRec
        {
            get { return _svcFeeRec; }
            set { _svcFeeRec = value; }
        }
        private Decimal _svcFeePayable;
        /// <summary>
        /// SvcFeePayable 
        /// </summary> 
        public Decimal SvcFeePayable
        {
            get { return _svcFeePayable; }
            set { _svcFeePayable = value; }
        }
        private Decimal _interchangeSvcFee;
        /// <summary>
        /// InterchangeSvcFee 
        /// </summary> 
        public Decimal InterchangeSvcFee
        {
            get { return _interchangeSvcFee; }
            set { _interchangeSvcFee = value; }
        }
        private Decimal _switchFlag;
        /// <summary>
        /// SwitchFlag 
        /// </summary> 
        public Decimal SwitchFlag
        {
            get { return _switchFlag; }
            set { _switchFlag = value; }
        }
        private String _reservedForUse;
        /// <summary>
        /// ReservedForUse 
        /// </summary> 
        public String ReservedForUse
        {
            get { return _reservedForUse; }
            set { _reservedForUse = value; }
        }
        private DateTime _createdDate;
        /// <summary>
        /// CreatedDate 
        /// </summary> 
        public DateTime CreatedDate
        {
            get { return _createdDate; }
            set { _createdDate = value; }
        }
        private Decimal _batchNo;
        /// <summary>
        /// BatchNo 
        /// </summary> 
        public Decimal BatchNo
        {
            get { return _batchNo; }
            set { _batchNo = value; }
        }
        private string _STFFileName;
        public string FileName
        {
            get { return _STFFileName; }
            set { _STFFileName = value; }
        }
        private DateTime _STFDate;

        public DateTime STFDate
        {
            get { return _STFDate; }
            set { _STFDate = value; }
        }
	
    }
    /// <summary>
    /// MerchantDetailTransaction_Info Entity Collections
    /// </summary>
    public class MerchantDetailTransaction_InfoCollections : Collection<MerchantDetailTransaction_InfoInfo> { }
}