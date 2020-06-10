using System;
using System.Collections.ObjectModel;

namespace ACE.Banking.MPU.CollectionSuit
{
    public class Settlement_InfoInfo
    {
        private String _mPUDfCode;
        /// <summary>
        /// MPUDfCode 
        /// </summary> 
        public String MPUDfCode
        {
            get { return _mPUDfCode; }
            set { _mPUDfCode = value; }
        }
        private String _outgoingAmoutSign;
        /// <summary>
        /// OutgoingAmoutSign 
        /// </summary> 
        public String OutgoingAmoutSign
        {
            get { return _outgoingAmoutSign; }
            set { _outgoingAmoutSign = value; }
        }
        private Decimal _outgoingAmount;
        /// <summary>
        /// OutgoingAmount 
        /// </summary> 
        public Decimal OutgoingAmount
        {
            get { return _outgoingAmount; }
            set { _outgoingAmount = value; }
        }
        private String _outgoingFeeSign;
        /// <summary>
        /// OutgoingFeeSign 
        /// </summary> 
        public String OutgoingFeeSign
        {
            get { return _outgoingFeeSign; }
            set { _outgoingFeeSign = value; }
        }
        private Decimal _outgoingFee;
        /// <summary>
        /// OutgoingFee 
        /// </summary> 
        public Decimal OutgoingFee
        {
            get { return _outgoingFee; }
            set { _outgoingFee = value; }
        }
        private String _incomingAmountSign;
        /// <summary>
        /// IncomingAmountSign 
        /// </summary> 
        public String IncomingAmountSign
        {
            get { return _incomingAmountSign; }
            set { _incomingAmountSign = value; }
        }
        private Decimal _incomingAmount;
        /// <summary>
        /// IncomingAmount 
        /// </summary> 
        public Decimal IncomingAmount
        {
            get { return _incomingAmount; }
            set { _incomingAmount = value; }
        }
        private String _incomingFeeSign;
        /// <summary>
        /// IncomingFeeSign 
        /// </summary> 
        public String IncomingFeeSign
        {
            get { return _incomingFeeSign; }
            set { _incomingFeeSign = value; }
        }
        private Decimal _incomingFee;
        /// <summary>
        /// IncomingFee 
        /// </summary> 
        public Decimal IncomingFee
        {
            get { return _incomingFee; }
            set { _incomingFee = value; }
        }
        private String _sTFAmountSign;
        /// <summary>
        /// STFAmountSign 
        /// </summary> 
        public String STFAmountSign
        {
            get { return _sTFAmountSign; }
            set { _sTFAmountSign = value; }
        }
        private Decimal _sTFAmount;
        /// <summary>
        /// STFAmount 
        /// </summary> 
        public Decimal STFAmount
        {
            get { return _sTFAmount; }
            set { _sTFAmount = value; }
        }
        private String _sTFFeeSign;
        /// <summary>
        /// STFFeeSign 
        /// </summary> 
        public String STFFeeSign
        {
            get { return _sTFFeeSign; }
            set { _sTFFeeSign = value; }
        }
        private Decimal _sTFFee;
        /// <summary>
        /// STFFee 
        /// </summary> 
        public Decimal STFFee
        {
            get { return _sTFFee; }
            set { _sTFFee = value; }
        }
        private Decimal _outgoingSummary;
        /// <summary>
        /// OutgoingSummary 
        /// </summary> 
        public Decimal OutgoingSummary
        {
            get { return _outgoingSummary; }
            set { _outgoingSummary = value; }
        }
        private Decimal _incomingSummary;
        /// <summary>
        /// IncomingSummary 
        /// </summary> 
        public Decimal IncomingSummary
        {
            get { return _incomingSummary; }
            set { _incomingSummary = value; }
        }
        private String _settlementCurrency;
        /// <summary>
        /// SettlementCurrency 
        /// </summary> 
        public String SettlementCurrency
        {
            get { return _settlementCurrency; }
            set { _settlementCurrency = value; }
        }
        private String _reserved;
        /// <summary>
        /// Reserved 
        /// </summary> 
        public String Reserved
        {
            get { return _reserved; }
            set { _reserved = value; }
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
        private DateTime _updatedDate;
        /// <summary>
        /// UpdatedDate 
        /// </summary> 
        public DateTime UpdatedDate
        {
            get { return _updatedDate; }
            set { _updatedDate = value; }
        }
        private String _status;
        /// <summary>
        /// Status 
        /// </summary> 
        public String Status
        {
            get { return _status; }
            set { _status = value; }
        }
        private String _approveBy;
        /// <summary>
        /// ApproveBy 
        /// </summary> 
        public String ApproveBy
        {
            get { return _approveBy; }
            set { _approveBy = value; }
        }
        private String _approveFrom;
        /// <summary>
        /// ApproveFrom 
        /// </summary> 
        public String ApproveFrom
        {
            get { return _approveFrom; }
            set { _approveFrom = value; }
        }
        private String _RejectBy;
        /// <summary>
        /// ApproveBy 
        /// </summary> 
        public String RejectBy
        {
            get { return _RejectBy; }
            set { _RejectBy = value; }
        }
        private String _RejecctFrom;
        /// <summary>
        /// ApproveFrom 
        /// </summary> 
        public String RejectFrom
        {
            get { return _RejecctFrom; }
            set { _RejecctFrom = value; }
        }
        private String _processBy;
        /// <summary>
        /// ProcessBy 
        /// </summary> 
        public String ProcessBy
        {
            get { return _processBy; }
            set { _processBy = value; }
        }
        private String _processFrom;
        /// <summary>
        /// ProcessFrom 
        /// </summary> 
        public String ProcessFrom
        {
            get { return _processFrom; }
            set { _processFrom = value; }
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
        private String _merchantCode;
        /// <summary>
        /// MerchantCode 
        /// </summary> 
        public String MerchantCode
        {
            get { return _merchantCode; }
            set { _merchantCode = value; }
        }
        private String _totalSettlementAmtSign;
        /// <summary>
        /// TotalSettlementAmtSign 
        /// </summary> 
        public String TotalSettlementAmtSign
        {
            get { return _totalSettlementAmtSign; }
            set { _totalSettlementAmtSign = value; }
        }
        private Decimal _totalSettlementAmt;
        /// <summary>
        /// TotalSettlementAmt 
        /// </summary> 
        public Decimal TotalSettlementAmt
        {
            get { return _totalSettlementAmt; }
            set { _totalSettlementAmt = value; }
        }
        private String _merchantSettlementAccount;
        /// <summary>
        /// MerchantSettlementAccount 
        /// </summary> 
        public String MerchantSettlementAccount
        {
            get { return _merchantSettlementAccount; }
            set { _merchantSettlementAccount = value; }
        }
        private string _STFFileName;
        public string SettlementFileName
        {
            get { return _STFFileName; }
            set { _STFFileName = value; }
        }
        private DateTime _STFDate;

        public DateTime SettlementDate
        {
            get { return _STFDate; }
            set { _STFDate = value; }
        }
	
    }

    /// <summary>
    /// Settlement_Info Entity Collections
    /// </summary>
    public class Settlement_InfoCollections : Collection<Settlement_InfoInfo> { }
}
