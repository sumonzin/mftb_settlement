using System;
using System.Collections.ObjectModel;
using System.Text;

namespace ACE.Banking.MPU.CollectionSuit
{
    public class MPU_Settlement_InfoInfo
    {
        private String _mPU_CODE;
        /// <summary>
        /// MPU_CODE 
        /// </summary> 
        public String MPU_CODE
        {
            get { return _mPU_CODE; }
            set { _mPU_CODE = value; }
        }
        private Decimal _oUTGOINGAMOUNT;
        /// <summary>
        /// OUTGOINGAMOUNT 
        /// </summary> 
        public Decimal OUTGOINGAMOUNT
        {
            get { return _oUTGOINGAMOUNT; }
            set { _oUTGOINGAMOUNT = value; }
        }
        private Decimal _oUTGOINGFEE;
        /// <summary>
        /// OUTGOINGFEE 
        /// </summary> 
        public Decimal OUTGOINGFEE
        {
            get { return _oUTGOINGFEE; }
            set { _oUTGOINGFEE = value; }
        }
        private Decimal _oUTGOINGMPUFEE;
        /// <summary>
        /// OUTGOINGMPUFEE 
        /// </summary> 
        public Decimal OUTGOINGMPUFEE
        {
            get { return _oUTGOINGMPUFEE; }
            set { _oUTGOINGMPUFEE = value; }
        }
        private Decimal _aTMOUTGOINGAMOUNT;
        /// <summary>
        /// ATMOUTGOINGAMOUNT 
        /// </summary> 
        public Decimal ATMOUTGOINGAMOUNT
        {
            get { return _aTMOUTGOINGAMOUNT; }
            set { _aTMOUTGOINGAMOUNT = value; }
        }
        private Decimal _aTMOUTGOINGFEE;
        /// <summary>
        /// ATMOUTGOINGFEE 
        /// </summary> 
        public Decimal ATMOUTGOINGFEE
        {
            get { return _aTMOUTGOINGFEE; }
            set { _aTMOUTGOINGFEE = value; }
        }
        private Decimal _aTMOUTGOINGMPUFEE;
        /// <summary>
        /// ATMOUTGOINGMPUFEE 
        /// </summary> 
        public Decimal ATMOUTGOINGMPUFEE
        {
            get { return _aTMOUTGOINGMPUFEE; }
            set { _aTMOUTGOINGMPUFEE = value; }
        }
        private Decimal _pOSOUTGOINGAMOUNT;
        /// <summary>
        /// POSOUTGOINGAMOUNT 
        /// </summary> 
        public Decimal POSOUTGOINGAMOUNT
        {
            get { return _pOSOUTGOINGAMOUNT; }
            set { _pOSOUTGOINGAMOUNT = value; }
        }
        private Decimal _pOSOUTGOINGFEE;
        /// <summary>
        /// POSOUTGOINGFEE 
        /// </summary> 
        public Decimal POSOUTGOINGFEE
        {
            get { return _pOSOUTGOINGFEE; }
            set { _pOSOUTGOINGFEE = value; }
        }
        private Decimal _pOSOUTGOINGMPUFEE;
        /// <summary>
        /// POSOUTGOINGMPUFEE 
        /// </summary> 
        public Decimal POSOUTGOINGMPUFEE
        {
            get { return _pOSOUTGOINGMPUFEE; }
            set { _pOSOUTGOINGMPUFEE = value; }
        }
        private Decimal _iNCOMINGAMOUNT;
        /// <summary>
        /// INCOMINGAMOUNT 
        /// </summary> 
        public Decimal INCOMINGAMOUNT
        {
            get { return _iNCOMINGAMOUNT; }
            set { _iNCOMINGAMOUNT = value; }
        }
        private Decimal _iNCOMINGFEE;
        /// <summary>
        /// INCOMINGFEE 
        /// </summary> 
        public Decimal INCOMINGFEE
        {
            get { return _iNCOMINGFEE; }
            set { _iNCOMINGFEE = value; }
        }
        private Decimal _iNCOMINGMPUFEE;
        /// <summary>
        /// INCOMINGMPUFEE 
        /// </summary> 
        public Decimal INCOMINGMPUFEE
        {
            get { return _iNCOMINGMPUFEE; }
            set { _iNCOMINGMPUFEE = value; }
        }
        private Decimal _aTMINCOMINGAMOUNT;
        /// <summary>
        /// ATMINCOMINGAMOUNT 
        /// </summary> 
        public Decimal ATMINCOMINGAMOUNT
        {
            get { return _aTMINCOMINGAMOUNT; }
            set { _aTMINCOMINGAMOUNT = value; }
        }
        private Decimal _aTMINCOMINGFEE;
        /// <summary>
        /// ATMINCOMINGFEE 
        /// </summary> 
        public Decimal ATMINCOMINGFEE
        {
            get { return _aTMINCOMINGFEE; }
            set { _aTMINCOMINGFEE = value; }
        }
        private Decimal _aTMINCOMINGMPUFEE;
        /// <summary>
        /// ATMINCOMINGMPUFEE 
        /// </summary> 
        public Decimal ATMINCOMINGMPUFEE
        {
            get { return _aTMINCOMINGMPUFEE; }
            set { _aTMINCOMINGMPUFEE = value; }
        }
        private Decimal _pOSINCOMINGAMOUNT;
        /// <summary>
        /// POSINCOMINGAMOUNT 
        /// </summary> 
        public Decimal POSINCOMINGAMOUNT
        {
            get { return _pOSINCOMINGAMOUNT; }
            set { _pOSINCOMINGAMOUNT = value; }
        }
        private Decimal _pOSINCOMINGFEE;
        /// <summary>
        /// POSINCOMINGFEE 
        /// </summary> 
        public Decimal POSINCOMINGFEE
        {
            get { return _pOSINCOMINGFEE; }
            set { _pOSINCOMINGFEE = value; }
        }
        private Decimal _pOSINCOMINGMPUFEE;
        /// <summary>
        /// POSINCOMINGMPUFEE 
        /// </summary> 
        public Decimal POSINCOMINGMPUFEE
        {
            get { return _pOSINCOMINGMPUFEE; }
            set { _pOSINCOMINGMPUFEE = value; }
        }
        private Decimal _sTFAMOUNT;
        /// <summary>
        /// STFAMOUNT 
        /// </summary> 
        public Decimal STFAMOUNT
        {
            get { return _sTFAMOUNT; }
            set { _sTFAMOUNT = value; }
        }
        private Decimal _sTFFEE;
        /// <summary>
        /// STFFEE 
        /// </summary> 
        public Decimal STFFEE
        {
            get { return _sTFFEE; }
            set { _sTFFEE = value; }
        }
        private Decimal _oUTGOINGSUMMARY;
        /// <summary>
        /// OUTGOINGSUMMARY 
        /// </summary> 
        public Decimal OUTGOINGSUMMARY
        {
            get { return _oUTGOINGSUMMARY; }
            set { _oUTGOINGSUMMARY = value; }
        }
        private Decimal _iNCOMINGSUMMARY;
        /// <summary>
        /// INCOMINGSUMMARY 
        /// </summary> 
        public Decimal INCOMINGSUMMARY
        {
            get { return _iNCOMINGSUMMARY; }
            set { _iNCOMINGSUMMARY = value; }
        }
        private DateTime _mPUSTARTDATE;
        /// <summary>
        /// MPUSTARTDATE 
        /// </summary> 
        public DateTime MPUSTARTDATE
        {
            get { return _mPUSTARTDATE; }
            set { _mPUSTARTDATE = value; }
        }
        private DateTime _mPUENDDATE;
        /// <summary>
        /// MPUENDDATE 
        /// </summary> 
        public DateTime MPUENDDATE
        {
            get { return _mPUENDDATE; }
            set { _mPUENDDATE = value; }
        }

        public decimal Ecomoutamt { get; set; }
        public decimal Ecomoutfee { get; set; }
        public decimal Ecomoutmpuamt { get; set; }
        public decimal Ecomoutmpufee { get; set; }
        public decimal EcomInamt { get; set; }
        public decimal EcomInfee { get; set; }
        public decimal EcomInmpuamt { get; set; }
        public decimal EcomInmpufee { get; set; }
        
    }

    /// <summary>
    /// MPU_Settlement_Info Entity Collections
    /// </summary>
    public class MPU_Settlement_InfoCollections : Collection<MPU_Settlement_InfoInfo> { }
}