using System;
using System.Collections.ObjectModel;

namespace ACE.Banking.MPU.CollectionSuit
{
    public class MemberBankDetailTransactionInfoInfo
    {
        private string _RefundStatus;

        public string RefundStatus
        {
            get { return _RefundStatus; }
            set { _RefundStatus = value; }
        }

        public int RefundStatusLength
        {
            get { return 5; }
        }

        private string _acquireInstitutionID;

        public string AcquringInstitutionID
        {
            get { return _acquireInstitutionID; }
            set { _acquireInstitutionID = value; }
        }
	
        public int AcquireInstitutionIDLength
        {
            get { return 11; }
        }

        private string _AuthDate;

        public string AuthDate
        {
            get { return _AuthDate; }
            set { _AuthDate = value; }
        }

        public int AuthDateLength
        {
            get { return 4; }
        }


        private string _IssuerBankCode;

        public string IssuerBankCode
        {
            get { return _IssuerBankCode; }
            set { _IssuerBankCode = value; }
        }

        public int IssuerBankcodeLength
        {
            get { return 11; }
        }

        private string _BeneficiaryBankCode;

        public string BeneficiaryBankCode
        {
            get { return _BeneficiaryBankCode; }
            set { _BeneficiaryBankCode = value; }
        }

        public int BeneficiaryBankcodeLength
        {
            get { return 11; }
        }

        private String _forwardInstitutionID;
        /// <summary>
        /// ForwardInstitutionID 
        /// </summary> 
        public String ForwardInstitutionID
        {
            get { return _forwardInstitutionID; }
            set { _forwardInstitutionID = value; }
        }
        public int ForwardInstitutionIDLength
        {
            get { return 11; }
        }
        private String _systemTraceNo;
        /// <summary>
        /// SystemTraceNo 
        /// </summary> 
        public String SystemTraceNo
        {
            get { return _systemTraceNo; }
            set { _systemTraceNo = value; }
        }
        public int SystemTraceNoLength
        {
            get { return 6; }
        }
        private string _transDateTime;
        /// <summary>
        /// TransDateTime 
        /// </summary> 
        public string TransDateTime
        {
            get { return _transDateTime; }
            set { _transDateTime = value; }
        }
        public int TransDateTimeLength
        {
            get { return 10; }
        }
        private String _pAN;
        /// <summary>
        /// PAN 
        /// </summary> 
        public String PAN
        {
            get { return _pAN; }
            set { _pAN = value; }
        }
        public int PANLength
        {
            get { return 19; }
        }

        private String _TranRespCOde;
        /// <summary>
        /// PAN 
        /// </summary> 
        public String TranRespCode
        {
            get { return _TranRespCOde; }
            set { _TranRespCOde = value; }
        }
        public int TranRespCodeLength
        {
            get { return 3; }
        }

        private string _SetConservationRate;
        /// <summary>
        /// transAmount 
        /// </summary> 

        public string SetConservationRate
        {
            get { return _SetConservationRate; }
            set { _SetConservationRate = value; }
        }
        public int SetConservationRateLength
            {
            get { return 8; }
        }


        private Decimal _SettlementAmount;
        /// <summary>
        /// transAmount 
        /// </summary> 

        public Decimal settlementAmount
        {
            get { return _SettlementAmount; }
            set { _SettlementAmount = value; }
        }
        public int SettlementAmountLength
        {
            get { return 12; }
        }



        private Decimal _transAmount;
        /// <summary>
        /// transAmount 
        /// </summary> 
       
        public Decimal transAmount
        {
            get { return _transAmount; }
            set { _transAmount = value; }
        }
        public int TransAmountLength
        {
            get { return 12; }
        }

        private Decimal _acceptanceAmount;
        /// <summary>
        /// AcceptanceAmount 
        /// </summary> 
        public Decimal AcceptanceAmount
        {
            get { return _acceptanceAmount; }
            set { _acceptanceAmount = value; }
        }
        public int AcceptanceAmountLength
        {
            get { return 12; }
        }

        public String CardHolderTransType { get; set; }

        private int cardHolderTransTypeLenght;

        public int CardHolderTransTypeLenght
        {
            get { return 1; }
            
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
        public int CardHolderTransFeeLength
        {
            get { return 11; }
        }

        private String _tranTranmissiondate;
        /// <summary>
        /// TranTranmissionDate 
        /// </summary> 
        public String TranTranmissionDate
        {
            get { return _tranTranmissiondate; }
            set { _tranTranmissiondate = value; }
        }
        public int TranTranmissionDateLength
        {
            get { return 10; }
        }
        private String _messageType;
        /// <summary>
        /// MessageType 
        /// </summary> 
        public String MessageType
        {
            get { return _messageType; }
            set { _messageType = value; }
        }
        public int MessageTypeLength
        {
            get { return 4; }
        }
        private String _processingCode;
        /// <summary>
        /// ProcessingCode 
        /// </summary> 
        public String ProcessingCode
        {
            get { return _processingCode; }
            set { _processingCode = value; }
        }
        public int ProcessingCodeLenth
        {
            get { return 6; }
        }
        private String _merchantType;
        /// <summary>
        /// MerchantType 
        /// </summary> 
        public String MerchantType
        {
            get { return _merchantType; }
            set { _merchantType = value; }
        }
        public int MerchantTypeLength
        {
            get { return 4; }
        }
        private String _terminalNo;
        /// <summary>
        /// TerminalNo 
        /// </summary> 
        public String TerminalNo
        {
            get { return _terminalNo; }
            set { _terminalNo = value; }
        }
        public int TerminalNoLength
        {
            get { return 11; }
        }

        private String _TransactionCurCode;
        /// <summary>
        /// CardAcceptorTerminal Tdentifiaction 
        /// </summary> 
        public String TransactionCurCode
        {
            get { return _TransactionCurCode; }
            set { _TransactionCurCode = value; }
        }
        public int TransactionCurcodelength
        {
            get { return 3; }
        }

        private String _SettlementCurCode;
        /// <summary>
        /// CardAcceptorTerminal Tdentifiaction 
        /// </summary> 
        public String SettlementCurcode
        {
            get { return _SettlementCurCode; }
            set { _SettlementCurCode = value; }
        }
        public int SettlementCurcodelength
        {
            get { return 3; }
        }

        private String _FromAccount;
        /// <summary>
        /// CardAcceptorTerminal Tdentifiaction 
        /// </summary> 
        public String FromAccount
        {
            get { return _FromAccount; }
            set { _FromAccount = value; }
        }
        public int FromAccountlength
        {
            get { return 28; }
        }

        private String _ToAccount;
        /// <summary>
        /// CardAcceptorTerminal Tdentifiaction 
        /// </summary> 
        public String ToAccount
        {
            get { return _ToAccount; }
            set { _ToAccount = value; }
        }
        public int ToAccountlength
        {
            get { return 28; }
        }

        private String _CardAcceptorTerminalNo;
        /// <summary>
        /// CardAcceptorTerminal Tdentifiaction 
        /// </summary> 
        public String CardAcceptorTerminalNo
        {
            get { return _CardAcceptorTerminalNo; }
            set { _CardAcceptorTerminalNo = value; }
        }
        public int CardAcceptorTerminalNoLength
        {
            get { return 8; }
        }


        private String _CardAcceptorIDCode;
        /// <summary>
        /// CardAcceptorTerminal Tdentifiaction 
        /// </summary> 
        public String CardAcceptorIDCode
        {
            get { return _CardAcceptorIDCode; }
            set { _CardAcceptorIDCode = value; }
        }
        public int CardAcceptorIDCodeLength
        {
            get { return 15; }
        }

        private String _CardAcceptorName;
        /// <summary>
        /// CardAcceptorTerminal Tdentifiaction 
        /// </summary> 
        public String CardAcceptorName
        {
            get { return _CardAcceptorName; }
            set { _CardAcceptorName = value; }
        }
        public int CardAcceptorNameLength
        {
            get { return 40; }
        }

        private String _OrgTranInformation;
        /// <summary>
        /// CardAcceptorIDCode 
        /// </summary> 
        public String OrgTranInformation
        {
            get { return _OrgTranInformation; }
            set { _OrgTranInformation = value; }
        }
        public int OrgTranInformationLength
        {
            get { return 23; }
        }

        private String _retrievalRefNo;
        /// <summary>
        /// RetrievalRefNo 
        /// </summary> 
        public String RetrievalRefNo
        {
            get { return _retrievalRefNo; }
            set { _retrievalRefNo = value; }
        }
        public int RetrievalRefNoLength
        {
            get { return 12; }
        }
        private String _pOSConditionCode;
        /// <summary>
        /// POSConditionCode 
        /// </summary> 
        public String POSConditionCode
        {
            get { return _pOSConditionCode; }
            set { _pOSConditionCode = value; }
        }
        public int POSConditionCodeLength
        {
            get { return 2; }
        }
        private String _authResponseCode;
        /// <summary>
        /// AuthResponseCode 
        /// </summary> 
        public String AuthResponseCode
        {
            get { return _authResponseCode; }
            set { _authResponseCode = value; }
        }
        public int AuthResponseCodeLength
        {
            get { return 6; }
        }
        private String _recInstitutionID;
        /// <summary>
        /// RecInstitutionID 
        /// </summary> 
        public String RecInstitutionID
        {
            get { return _recInstitutionID; }
            set { _recInstitutionID = value; }
        }
        public int RecInstitutionIDLength
        {
            get { return 11; }
        }

        private String _IssInstitutionID;
        /// <summary>
        /// RecInstitutionID 
        /// </summary> 
        public String IssInstitutionID
        {
            get { return _IssInstitutionID; }
            set { _IssInstitutionID = value; }
        }
        public int IssInstitutionIDLength
        {
            get { return 11; }
        }

        private String _TranFeatures;
        /// <summary>
        /// RecInstitutionID 
        /// </summary> 
        public String TranFeatures
        {
            get { return _TranFeatures; }
            set { _TranFeatures = value; }
        }
        public int TranFeaturesLength
        {
            get { return 1; }
        }

        private String _MerchantCountryCode;
        /// <summary>
        /// RecInstitutionID 
        /// </summary> 
        public String MerchantCountryCode
        {
            get { return _MerchantCountryCode; }
            set { _MerchantCountryCode = value; }
        }
        public int MerchantCountryCodeLength
        {
            get { return 3; }
        }

        private String _AuthType;
        /// <summary>
        /// RecInstitutionID 
        /// </summary> 
        public String AuthType
        {
            get { return _AuthType; }
            set { _AuthType = value; }
        }
        public int AuthTypeLength
        {
            get { return 3; }
        }


        private String _orgSystemTraceNo;
        /// <summary>
        /// OrgSystemTraceNo 
        /// </summary> 
        public String OrgSystemTraceNo
        {
            get { return _orgSystemTraceNo; }
            set { _orgSystemTraceNo = value; }
        }
        public int OrgSystemTraceNolength
        {
            get { return 6; }
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
        public int ResponseCodeLength
        {
            get { return 4; }
        }
        private String _pOSEntryMode;
        /// <summary>
        /// POSEntryMode 
        /// </summary> 
        public String POSEntryMode
        {
            get { return _pOSEntryMode; }
            set { _pOSEntryMode = value; }
        }
        public int POSEntryModeLength
        {
            get { return 3; }
        }
        private Decimal _serviceFeeReceive;
        /// <summary>
        /// ServiceFeeReceive 
        /// </summary> 
        public Decimal ServiceFeeReceive
        {
            get { return _serviceFeeReceive; }
            set { _serviceFeeReceive = value; }
        }
        public int ServiceFeeReceiveLength
        {
            get { return 12; }
        }
        private Decimal _serviceFeePayable;
        /// <summary>
        /// ServiceFeePayable 
        /// </summary> 
        public Decimal ServiceFeePayable
        {
            get { return _serviceFeePayable; }
            set { _serviceFeePayable = value; }
        }
        public int ServiceFeePayableLength
        {
            get { return 12; }
        }
        private Decimal _interChangeServiceFee;
        /// <summary>
        /// InterChangeServiceFee 
        /// </summary> 
        public Decimal InterChangeServiceFee
        {
            get { return _interChangeServiceFee; }
            set { _interChangeServiceFee = value; }
        }
        public int InterChangeServiceFeeLength
        {
            get { return 12; }
        }
        private string _sAndDSwitchFlag;
        /// <summary>
        /// SAndDSwitchFlag 
        /// </summary> 
        public string SAndDSwitchFlag
        {
            get { return _sAndDSwitchFlag; }
            set { _sAndDSwitchFlag = value; }
        }
        public int SAndDSwitchFlagLength
        {
            get { return 1; }
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
        public int ReservedForUseLength
        {
            get { return 66; }
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
        private String _fILENAME;
        /// <summary>
        /// FILENAME 
        /// </summary> 
        public String FILENAME
        {
            get { return _fILENAME; }
            set { _fILENAME = value; }
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
        private DateTime _sETTLEMENTDATE;
        /// <summary>
        /// SETTLEMENTDATE 
        /// </summary> 
        public DateTime SETTLEMENTDATE
        {
            get { return _sETTLEMENTDATE; }
            set { _sETTLEMENTDATE = value; }
        }

        public string strSettlementDatetime;
    }

    /// <summary>
    /// MemberBankDetailTransactionInfo Entity Collections
    /// </summary>
    public class MemberBankDetailTransactionInfoCollections : Collection<MemberBankDetailTransactionInfoInfo> { }
}