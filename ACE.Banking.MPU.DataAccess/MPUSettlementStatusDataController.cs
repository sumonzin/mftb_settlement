
using System;
using System.Data;
using ACE.Banking.MPU.CollectionSuit;

namespace ACE.Banking.MPU.DataAccess
{
    public class MPUSettlementStatusDataController : DataControllerBase
    {
        #region Generated Methods
        #region Select Methods
        public IDataReader Select()
        {
            Command = DB.GetStoredProcCommand("MPUSettlementStatus_SelectList");
            return DB.ExecuteReader(Command);
        }

        #endregion

        #region Insert Methods

        public bool Insert(string MPUSettlementID,decimal mPUIncomingAmount, decimal mPUOutgoingAmount, decimal mPUIncomingFee, decimal mPUOutgoingFee, decimal cBSIncomingAmount, decimal cBSOutgoingAmount, decimal cBSIncomingFee, decimal cBSOutgoingFee, string transactionNo, DateTime transactionDate, DateTime settlementDate, DateTime createdDate, DateTime uPdatedDate, string sTATUS)
        {
            Command = DB.GetStoredProcCommand("MPUSettlementStatus_Insert");

            DB.AddInParameter(Command, "MPUSettlementID", DbType.String, MPUSettlementID);
            DB.AddInParameter(Command, "MPUIncomingAmount", DbType.Decimal, GetNull(mPUIncomingAmount));
            DB.AddInParameter(Command, "MPUOutgoingAmount", DbType.Decimal, GetNull(mPUOutgoingAmount));
            DB.AddInParameter(Command, "MPUIncomingFee", DbType.Decimal, GetNull(mPUIncomingFee));
            DB.AddInParameter(Command, "MPUOutgoingFee", DbType.Decimal, GetNull(mPUOutgoingFee));
            DB.AddInParameter(Command, "CBSIncomingAmount", DbType.Decimal, GetNull(cBSIncomingAmount));
            DB.AddInParameter(Command, "CBSOutgoingAmount", DbType.Decimal, GetNull(cBSOutgoingAmount));
            DB.AddInParameter(Command, "CBSIncomingFee", DbType.Decimal, GetNull(cBSIncomingFee));
            DB.AddInParameter(Command, "CBSOutgoingFee", DbType.Decimal, GetNull(cBSOutgoingFee));
            DB.AddInParameter(Command, "TransactionNo", DbType.String, GetNull(transactionNo));
            DB.AddInParameter(Command, "TransactionDate", DbType.DateTime, GetNull(transactionDate));
            DB.AddInParameter(Command, "SettlementDate", DbType.DateTime, GetNull(settlementDate));
            DB.AddInParameter(Command, "CreatedDate", DbType.DateTime, GetNull(DateTime.Now));
            DB.AddInParameter(Command, "STATUS", DbType.String, GetNull(sTATUS));
            DB.ExecuteNonQuery(Command);
          
            return true;
        }

        #endregion

        #region Update Methods
        public void Update(string transactionNo, DateTime transactionDate, DateTime settlementDate, DateTime uPdatedDate, string sTATUS)
        {
            Command = DB.GetStoredProcCommand("MPUSettlementStatus_UpdateBySettlementDate");

           
            DB.AddInParameter(Command, "TransactionNo", DbType.String, GetNull(transactionNo));
            DB.AddInParameter(Command, "TransactionDate", DbType.DateTime, GetNull(transactionDate));
            DB.AddInParameter(Command, "SettlementDate", DbType.DateTime, GetNull(settlementDate));
            DB.AddInParameter(Command, "UPdatedDate", DbType.DateTime, GetNull(uPdatedDate));
            DB.AddInParameter(Command, "STATUS", DbType.String, GetNull(sTATUS));

            if (UseTransaction)
                DB.ExecuteNonQuery(Command, Transaction);
            else
                DB.ExecuteNonQuery(Command);

        }
        #endregion

        #region Delete Methods

        public void DeleteByMPUSettlementID(string mPUSettlementID)
        {
            Command = DB.GetStoredProcCommand("MPUSettlementStatus_DeleteByMPUSettlementID");

            DB.AddInParameter(Command, "MPUSettlementID", DbType.String, GetNull(mPUSettlementID));

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



