
using System;
using System.Data;
using System.Collections.ObjectModel;

/// <summary>
/// MPUSettlementStatus Entity
/// </summary>
namespace ACE.Banking.MPU.CollectionSuit
{
    public class MPUSettlementStatusInfo
    {
        private String _mPUSettlementID;
        /// <summary>
        /// MPUSettlementID 
        /// </summary> 
        public String MPUSettlementID
        {
            get { return _mPUSettlementID; }
            set { _mPUSettlementID = value; }
        }
        private Decimal _mPUIncomingAmount;
        /// <summary>
        /// MPUIncomingAmount 
        /// </summary> 
        public Decimal MPUIncomingAmount
        {
            get { return _mPUIncomingAmount; }
            set { _mPUIncomingAmount = value; }
        }
        private Decimal _mPUOutgoingAmount;
        /// <summary>
        /// MPUOutgoingAmount 
        /// </summary> 
        public Decimal MPUOutgoingAmount
        {
            get { return _mPUOutgoingAmount; }
            set { _mPUOutgoingAmount = value; }
        }
        private Decimal _mPUIncomingFee;
        /// <summary>
        /// MPUIncomingFee 
        /// </summary> 
        public Decimal MPUIncomingFee
        {
            get { return _mPUIncomingFee; }
            set { _mPUIncomingFee = value; }
        }
        private Decimal _mPUOutgoingFee;
        /// <summary>
        /// MPUOutgoingFee 
        /// </summary> 
        public Decimal MPUOutgoingFee
        {
            get { return _mPUOutgoingFee; }
            set { _mPUOutgoingFee = value; }
        }
        private Decimal _cBSIncomingAmount;
        /// <summary>
        /// CBSIncomingAmount 
        /// </summary> 
        public Decimal CBSIncomingAmount
        {
            get { return _cBSIncomingAmount; }
            set { _cBSIncomingAmount = value; }
        }
        private Decimal _cBSOutgoingAmount;
        /// <summary>
        /// CBSOutgoingAmount 
        /// </summary> 
        public Decimal CBSOutgoingAmount
        {
            get { return _cBSOutgoingAmount; }
            set { _cBSOutgoingAmount = value; }
        }
        private Decimal _cBSIncomingFee;
        /// <summary>
        /// CBSIncomingFee 
        /// </summary> 
        public Decimal CBSIncomingFee
        {
            get { return _cBSIncomingFee; }
            set { _cBSIncomingFee = value; }
        }
        private Decimal _cBSOutgoingFee;
        /// <summary>
        /// CBSOutgoingFee 
        /// </summary> 
        public Decimal CBSOutgoingFee
        {
            get { return _cBSOutgoingFee; }
            set { _cBSOutgoingFee = value; }
        }
        private String _transactionNo;
        /// <summary>
        /// TransactionNo 
        /// </summary> 
        public String TransactionNo
        {
            get { return _transactionNo; }
            set { _transactionNo = value; }
        }
        private DateTime _transactionDate;
        /// <summary>
        /// TransactionDate 
        /// </summary> 
        public DateTime TransactionDate
        {
            get { return _transactionDate; }
            set { _transactionDate = value; }
        }
        private DateTime _settlementDate;
        /// <summary>
        /// SettlementDate 
        /// </summary> 
        public DateTime SettlementDate
        {
            get { return _settlementDate; }
            set { _settlementDate = value; }
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
        private DateTime _uPdatedDate;
        /// <summary>
        /// UPdatedDate 
        /// </summary> 
        public DateTime UPdatedDate
        {
            get { return _uPdatedDate; }
            set { _uPdatedDate = value; }
        }
        private String _sTATUS;
        /// <summary>
        /// STATUS 
        /// </summary> 
        public String STATUS
        {
            get { return _sTATUS; }
            set { _sTATUS = value; }
        }
    }

    /// <summary>
    /// MPUSettlementStatus Entity Collections
    /// </summary>
    public class MPUSettlementStatusCollections : Collection<MPUSettlementStatusInfo> { }
}










