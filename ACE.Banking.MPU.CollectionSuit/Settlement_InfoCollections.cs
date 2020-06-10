using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace ACE.Banking.MPU.CollectionSuit
{
    public class Settlement_InfoInfo
    {
        private String _ResCode;

        /// <summary>
        /// ResCode
        /// </summary>
        public String ResCode
        {
            get { return _ResCode; }
            set { _ResCode = value; }
        }

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

    public class Settlement_InfoCollections : Collection<Settlement_InfoInfo> { }

    public class Settlement_Upload
    {
        public string AccountNo { get; set; }

        public string CurrencyCode { get; set; }
        public string ServiceOutlet { get; set; }
        public string TranType { get; set; }

        public decimal TranAmount { get; set; }

        public string TranParticular { get; set; }

        public string AccountRespCode { get; set; }

        public string ReferenceNo { get; set; }

        public string InstrumentType { get; set; }

        // public DateTime InstrumentDate { get; set; }
        public string strInsdate { get; set; }

        public string InstrumentAlpha { get; set; }

        public string InstrumentNumber { get; set; }

        public string NavigationFlat { get; set; }

        public decimal ReferenceAmount { get; set; }

        public string RefCurCode { get; set; }

        public string RateCode { get; set; }
        public decimal Rate { get; set; }
        public string strRate { get; set; }

        public string strValuedate { get; set; }

        //  public DateTime ValueDate { get; set; }

        public string strGLDate { get; set; }

        // public DateTime GLDate { get; set; }

        public string CategoryCode { get; set; }

        public string ENo { get; set; }

        public string Acode { get; set; }

        public string Status { get; set; }

        public string Narration { get; set; }

        public string Desp { get; set; }
        public string Channel { get; set; }
    }

    public class Settlement_UploadCollections : Collection<Settlement_Upload> { }

    public class Select_serviceOutlet
    {
        public string Sol_ID { get; set; }
        public string accountNo { get; set; }
    }

    public class Select_ServiceOutletCollection : Collection<Select_serviceOutlet> { }

    public class MPUSettlementINfo
    {
        public string INID { get; set; }
        public decimal OUtAMT { get; set; }
        public decimal OutFee { get; set; }
        public decimal OutMPUAmt { get; set; }
        public decimal OutMPUFee { get; set; }
        public decimal ATMOutAmt { get; set; }
        public decimal ATMOutFee { get; set; }
        public decimal ATMOutMPUAmt { get; set; }
        public decimal ATMOutMPUFee { get; set; }
        public decimal POSOutAmt { get; set; }
        public decimal POSOutFee { get; set; }
        public decimal POSOutMPUAmt { get; set; }
        public decimal POSOutMPUFee { get; set; }
        public decimal EcomOutAmt { get; set; }
        public decimal EcomOutFee { get; set; }
        public decimal EcomOutMPUAmt { get; set; }
        public decimal EcomOutMPUFee { get; set; }
        public decimal InAmt { get; set; }
        public decimal InFee { get; set; }
        public decimal InMPUAmt { get; set; }
        public decimal InMPUFee { get; set; }
        public decimal ATMInAmt { get; set; }
        public decimal ATMInFee { get; set; }
        public decimal ATMInMPUAmt { get; set; }
        public decimal ATMInMPUFee { get; set; }
        public decimal POSInAmt { get; set; }
        public decimal POSInFee { get; set; }
        public decimal POSInMPUAmt { get; set; }
        public decimal POSInMPUFee { get; set; }
        public decimal EcomInAmt { get; set; }
        public decimal EcomInFee { get; set; }
        public decimal EcomInMPUAmt { get; set; }
        public decimal EcomInMPUFee { get; set; }
        public decimal STFAmt { get; set; }
        public decimal STFFee { get; set; }
        public decimal STFMPUAmt { get; set; }
        public decimal STFMPUFee { get; set; }
        public decimal OutSummary { get; set; }
        public decimal InSummary { get; set; }
        public DateTime MPUStartDate { get; set; }
        public string strMPUstartDate { get; set; }
        public string strMPUEndDate { get; set; }
        public DateTime MPUEndDate { get; set; }
    }

    public class OfficeACCfromInfosys
    {
        public string RecAccName { get; set; }
        public string ReceivableAcc { get; set; }

        public string IncomingAcc { get; set; }
        public string IncomAccName { get; set; }

        public string MPUSettlementAcc { get; set; }
        public string SetAccName { get; set; }

        public string PayableAcc { get; set; }
        public string PayableAccName { get; set; }

        public string ECOMPayableAcc { get; set; }
        public string ECOMPayAccName { get; set; }

        public string POSandEcomCrdPayAcc { get; set; }
        public string POSandEcomCrdAccName { get; set; }

        public string CommissiononPOs { get; set; }
        public string ComPOSName { get; set; }
        public string CommissiononEcom { get; set; }
        public string ComEcomName { get; set; }
        public string RecePOsCrdAcc { get; set; }
        public string RecePOSCrdAccName { get; set; }
        public string SundryAccComonATM { get; set; }
        public string SundryAccComonATMName { get; set; }
        public string SundryAccComonPOS { get; set; }
        public string SundryAccComonPOSName { get; set; }
        public string SundryAccComonEcom { get; set; }
        public string SundryAccComonEcomName { get; set; }
    }

    public class MemberBankDetailInfo
    {
        public string PAN { get; set; }
        public string ProcessingCode { get; set; }
        public string TranAmt { get; set; }
        public string SettlememtAmt { get; set; }
        public string MerchantType { get; set; }
        public string AcquireInstitutionID { get; set; }
        public  string MessageType { get; set; }
        public string ServiceFeeReceive { get; set; }
        public string ServiceFeePayable { get; set; }
        public string CardAcceptorIDCode { get; set; }
        public string FileName { get; set; }
        public string FileType { get; set; }
        public string TranResponseCode { get; set; }
        public string RefundStatus { get; set; }
            
    }

    public class DirPOSCollections : Collection<MemberBankDetailInfo> { }

    public class SelectDirPOSResponseModel
    {
        public Collection<MemberBankDetailInfo> lstMemberBank { get; set; }
    }

    public class MerchantRateDetail
    {
        public string MerchantID { get; set; }
        public string NewAccountNo { get; set; }
        public string Rate { get; set; }
        public string Name { get; set; }
          
    }

    public class DIR_POS_Record
    {
        public string MerchantID { get; set; }
        public decimal TranAmt { get; set; }
        public decimal ServiceFeeReceive { get; set; }
        public decimal ServiceFeePayable { get; set; }
        public decimal MerchantRate { get; set; }
        public string MerchantType { get; set; }
        public DateTime STFDate { get; set; }
        public decimal CashAdvReceive { get; set; }

    }

    public class DIR_POS_Record_Collection : Collection<DIR_POS_Record> { }

    public class MerchantRateCollections : Collection<MerchantRateDetail> { }

    public class sum_memB_record
    {
        public decimal DebitAmt { get; set; }
        public decimal Credit2Amt { get; set; }
        public decimal CreditAmt { get; set; }
    }

}