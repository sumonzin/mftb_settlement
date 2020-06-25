using System;
using System.Data;
using ACE.Banking.MPU.CollectionSuit;
using ACE.Banking.MPU.DataAccess;
namespace ACE.Banking.MPU.Businesslogic
{
    /// <summary>
    /// MemberBankDetailTransactionInfo Controller
    /// </summary>
    public class MemberBankDetailTransactionInfoController 
    {

        private MemberBankDetailTransactionInfoDataController DataController;

        #region "Constructor"
        public MemberBankDetailTransactionInfoController()
        {
            DataController = new MemberBankDetailTransactionInfoDataController();
        }
        #endregion

        #region "Helper Methods"
        private void Fill(IDataReader dataReader, MemberBankDetailTransactionInfoInfo memberBankDetailTransactionInfoInfo)
        {
            if (!(dataReader["AcquireInstitutionID"] is DBNull))
                memberBankDetailTransactionInfoInfo.AcquringInstitutionID = Convert.ToString(dataReader["AcquireInstitutionID"]);

            if (!(dataReader["ForwardInstitutionID"] is DBNull))
                memberBankDetailTransactionInfoInfo.ForwardInstitutionID = Convert.ToString(dataReader["ForwardInstitutionID"]);

            if (!(dataReader["SystemTraceNo"] is DBNull))
                memberBankDetailTransactionInfoInfo.SystemTraceNo = Convert.ToString(dataReader["SystemTraceNo"]);

            if (!(dataReader["TransDateTime"] is DBNull))
                memberBankDetailTransactionInfoInfo.TransDateTime = Convert.ToString(dataReader["TransDateTime"]);

            if (!(dataReader["PAN"] is DBNull))
                memberBankDetailTransactionInfoInfo.PAN = Convert.ToString(dataReader["PAN"]);

            if (!(dataReader["transAmount"] is DBNull))
                memberBankDetailTransactionInfoInfo.transAmount = Convert.ToDecimal(dataReader["transAmount"]);

            if (!(dataReader["AcceptanceAmount"] is DBNull))
                memberBankDetailTransactionInfoInfo.AcceptanceAmount = Convert.ToDecimal(dataReader["AcceptanceAmount"]);

            if (!(dataReader["CardHolderTransFee"] is DBNull))
                memberBankDetailTransactionInfoInfo.CardHolderTransFee = Convert.ToDecimal(dataReader["CardHolderTransFee"]);

            if (!(dataReader["MessageType"] is DBNull))
                memberBankDetailTransactionInfoInfo.MessageType = Convert.ToString(dataReader["MessageType"]);

            if (!(dataReader["ProcessingCode"] is DBNull))
                memberBankDetailTransactionInfoInfo.ProcessingCode = Convert.ToString(dataReader["ProcessingCode"]);

            if (!(dataReader["MerchantType"] is DBNull))
                memberBankDetailTransactionInfoInfo.MerchantType = Convert.ToString(dataReader["MerchantType"]);

            if (!(dataReader["TerminalNo"] is DBNull))
                memberBankDetailTransactionInfoInfo.TerminalNo = Convert.ToString(dataReader["TerminalNo"]);

            if (!(dataReader["CardAcceptorIDCode"] is DBNull))
                memberBankDetailTransactionInfoInfo.CardAcceptorIDCode = Convert.ToString(dataReader["CardAcceptorIDCode"]);

            if (!(dataReader["RetrievalRefNo"] is DBNull))
                memberBankDetailTransactionInfoInfo.RetrievalRefNo = Convert.ToString(dataReader["RetrievalRefNo"]);

            if (!(dataReader["POSConditionCode"] is DBNull))
                memberBankDetailTransactionInfoInfo.POSConditionCode = Convert.ToString(dataReader["POSConditionCode"]);

            if (!(dataReader["AuthResponseCode"] is DBNull))
                memberBankDetailTransactionInfoInfo.AuthResponseCode = Convert.ToString(dataReader["AuthResponseCode"]);

            if (!(dataReader["RecInstitutionID"] is DBNull))
                memberBankDetailTransactionInfoInfo.RecInstitutionID = Convert.ToString(dataReader["RecInstitutionID"]);

            if (!(dataReader["OrgSystemTraceNo"] is DBNull))
                memberBankDetailTransactionInfoInfo.OrgSystemTraceNo = Convert.ToString(dataReader["OrgSystemTraceNo"]);

            if (!(dataReader["ResponseCode"] is DBNull))
                memberBankDetailTransactionInfoInfo.ResponseCode = Convert.ToString(dataReader["ResponseCode"]);

            if (!(dataReader["POSEntryMode"] is DBNull))
                memberBankDetailTransactionInfoInfo.POSEntryMode = Convert.ToString(dataReader["POSEntryMode"]);

            if (!(dataReader["ServiceFeeReceive"] is DBNull))
                memberBankDetailTransactionInfoInfo.ServiceFeeReceive = Convert.ToDecimal(dataReader["ServiceFeeReceive"]);

            if (!(dataReader["ServiceFeePayable"] is DBNull))
                memberBankDetailTransactionInfoInfo.ServiceFeePayable = Convert.ToDecimal(dataReader["ServiceFeePayable"]);

            if (!(dataReader["InterChangeServiceFee"] is DBNull))
                memberBankDetailTransactionInfoInfo.InterChangeServiceFee = Convert.ToDecimal(dataReader["InterChangeServiceFee"]);

            if (!(dataReader["SAndDSwitchFlag"] is DBNull))
                memberBankDetailTransactionInfoInfo.SAndDSwitchFlag = Convert.ToString(dataReader["SAndDSwitchFlag"]);

            if (!(dataReader["ReservedForUse"] is DBNull))
                memberBankDetailTransactionInfoInfo.ReservedForUse = Convert.ToString(dataReader["ReservedForUse"]);

            if (!(dataReader["CreatedDate"] is DBNull))
                memberBankDetailTransactionInfoInfo.CreatedDate = Convert.ToDateTime(dataReader["CreatedDate"]);

            if (!(dataReader["BatchNo"] is DBNull))
                memberBankDetailTransactionInfoInfo.BatchNo = Convert.ToDecimal(dataReader["BatchNo"]);

            if (!(dataReader["FILENAME"] is DBNull))
                memberBankDetailTransactionInfoInfo.FILENAME = Convert.ToString(dataReader["FILENAME"]);

            if (!(dataReader["FileType"] is DBNull))
                memberBankDetailTransactionInfoInfo.FileType = Convert.ToString(dataReader["FileType"]);

            if (!(dataReader["SETTLEMENTDATE"] is DBNull))
                memberBankDetailTransactionInfoInfo.SETTLEMENTDATE = Convert.ToDateTime(dataReader["SETTLEMENTDATE"]);

        }
        #endregion

        #region "Select Methods"

        public MemberBankDetailTransactionInfoCollections Select()
        {
            IDataReader dataReader = DataController.Select();
            MemberBankDetailTransactionInfoCollections memberBankDetailTransactionInfoCollections = new MemberBankDetailTransactionInfoCollections();

            while (dataReader.Read())
            {
                MemberBankDetailTransactionInfoInfo memberBankDetailTransactionInfoInfo = new MemberBankDetailTransactionInfoInfo();
                Fill(dataReader, memberBankDetailTransactionInfoInfo);
                memberBankDetailTransactionInfoCollections.Add(memberBankDetailTransactionInfoInfo);
            }
            return memberBankDetailTransactionInfoCollections;

        }
        public DataSet SelectByBankCode(string BankCode,DateTime STFDate)
        {
            return DataController.SelectByBankID(BankCode, STFDate);
        }
        #endregion

        #region "Add Methods"
        public bool Add(MemberBankDetailTransactionInfoInfo memberBankDetailTransactionInfoInfo)
        {
            MemberBankDetailTransactionInfoCollections memberBankDetailTransactionInfoCollections = new MemberBankDetailTransactionInfoCollections();
            memberBankDetailTransactionInfoCollections.Add(memberBankDetailTransactionInfoInfo);

            return Add(memberBankDetailTransactionInfoCollections);
        }

        public bool Add(MemberBankDetailTransactionInfoCollections memberBankDetailTransactionInfoCollections)
        {
            string uniqueKey = "";
            try
            {
                DataController.StartTransaction();
                foreach (MemberBankDetailTransactionInfoInfo memberBankDetailTransactionInfoInfo in memberBankDetailTransactionInfoCollections)
                {
                    uniqueKey = memberBankDetailTransactionInfoInfo.AcquringInstitutionID;

                    memberBankDetailTransactionInfoInfo.AcquringInstitutionID =
                        DataController.Insert(
                        memberBankDetailTransactionInfoInfo.PAN, 
                        memberBankDetailTransactionInfoInfo.ProcessingCode, 
                        memberBankDetailTransactionInfoInfo.transAmount, 
                        memberBankDetailTransactionInfoInfo.settlementAmount,
                        memberBankDetailTransactionInfoInfo.SetConservationRate,
                        memberBankDetailTransactionInfoInfo.SystemTraceNo, 
                        memberBankDetailTransactionInfoInfo.TransDateTime,
                        memberBankDetailTransactionInfoInfo.SETTLEMENTDATE,
                        memberBankDetailTransactionInfoInfo.MerchantType,
                        memberBankDetailTransactionInfoInfo.TerminalNo,
                        memberBankDetailTransactionInfoInfo.AcquringInstitutionID, 
                        memberBankDetailTransactionInfoInfo.IssuerBankCode, 
                        memberBankDetailTransactionInfoInfo.BeneficiaryBankCode,
                        memberBankDetailTransactionInfoInfo.ForwardInstitutionID, 
                        memberBankDetailTransactionInfoInfo.AuthResponseCode,
                        memberBankDetailTransactionInfoInfo.RetrievalRefNo, 
                        memberBankDetailTransactionInfoInfo.CardAcceptorTerminalNo,
                        memberBankDetailTransactionInfoInfo.TransactionCurCode, 
                        memberBankDetailTransactionInfoInfo.SettlementCurcode,
                        memberBankDetailTransactionInfoInfo.FromAccount, 
                        memberBankDetailTransactionInfoInfo.ToAccount, 
                        memberBankDetailTransactionInfoInfo.MessageType, 
                        memberBankDetailTransactionInfoInfo.CardAcceptorIDCode,
                        memberBankDetailTransactionInfoInfo.ResponseCode, 
                        memberBankDetailTransactionInfoInfo.ServiceFeeReceive,
                        memberBankDetailTransactionInfoInfo.ServiceFeePayable,
                        memberBankDetailTransactionInfoInfo.InterChangeServiceFee, 
                        memberBankDetailTransactionInfoInfo.POSEntryMode, 
                        memberBankDetailTransactionInfoInfo.OrgSystemTraceNo,
                        memberBankDetailTransactionInfoInfo.POSConditionCode,
                        memberBankDetailTransactionInfoInfo.AcceptanceAmount,
                        memberBankDetailTransactionInfoInfo.CardHolderTransType,
                        memberBankDetailTransactionInfoInfo.CardHolderTransFee,
                        memberBankDetailTransactionInfoInfo.TranTranmissionDate,
                        memberBankDetailTransactionInfoInfo.ReservedForUse,
                        memberBankDetailTransactionInfoInfo.CreatedDate,
                        memberBankDetailTransactionInfoInfo.BatchNo,
                        memberBankDetailTransactionInfoInfo.FILENAME, 
                        memberBankDetailTransactionInfoInfo.FileType, 
                        memberBankDetailTransactionInfoInfo.TranRespCode,
                        memberBankDetailTransactionInfoInfo.RefundStatus);
                }
                DataController.CommitTransaction();
            }
            catch (Exception ex)
            {
                DataController.RollbackTransaction();
                return false;
            }
            return true;
        }
        #endregion

        #region "Update Methods"

        public bool Update(MemberBankDetailTransactionInfoCollections memberBankDetailTransactionInfoCollections)
        {
            try
            {
                DataController.StartTransaction();
                foreach (MemberBankDetailTransactionInfoInfo memberBankDetailTransactionInfoInfo in memberBankDetailTransactionInfoCollections)
                    DataController.Update(memberBankDetailTransactionInfoInfo.AcquringInstitutionID, memberBankDetailTransactionInfoInfo.ForwardInstitutionID, memberBankDetailTransactionInfoInfo.SystemTraceNo, memberBankDetailTransactionInfoInfo.TransDateTime, memberBankDetailTransactionInfoInfo.PAN, memberBankDetailTransactionInfoInfo.transAmount, memberBankDetailTransactionInfoInfo.AcceptanceAmount, memberBankDetailTransactionInfoInfo.CardHolderTransFee, memberBankDetailTransactionInfoInfo.MessageType, memberBankDetailTransactionInfoInfo.ProcessingCode, memberBankDetailTransactionInfoInfo.MerchantType, memberBankDetailTransactionInfoInfo.TerminalNo, memberBankDetailTransactionInfoInfo.CardAcceptorIDCode, memberBankDetailTransactionInfoInfo.RetrievalRefNo, memberBankDetailTransactionInfoInfo.POSConditionCode, memberBankDetailTransactionInfoInfo.AuthResponseCode, memberBankDetailTransactionInfoInfo.RecInstitutionID, memberBankDetailTransactionInfoInfo.OrgSystemTraceNo, memberBankDetailTransactionInfoInfo.ResponseCode, memberBankDetailTransactionInfoInfo.POSEntryMode, memberBankDetailTransactionInfoInfo.ServiceFeeReceive, memberBankDetailTransactionInfoInfo.ServiceFeePayable, memberBankDetailTransactionInfoInfo.InterChangeServiceFee, memberBankDetailTransactionInfoInfo.SAndDSwitchFlag, memberBankDetailTransactionInfoInfo.ReservedForUse, memberBankDetailTransactionInfoInfo.CreatedDate, memberBankDetailTransactionInfoInfo.BatchNo, memberBankDetailTransactionInfoInfo.FILENAME, memberBankDetailTransactionInfoInfo.FileType, memberBankDetailTransactionInfoInfo.SETTLEMENTDATE);

                DataController.CommitTransaction();
            }
            catch (Exception ex)
            {
                DataController.RollbackTransaction();
                return false;
            }
            return true;
        }
        #endregion

        #region "Delete Methods"
        public bool DeleteByAcquireInstitutionID(MemberBankDetailTransactionInfoInfo memberBankDetailTransactionInfoInfo)
        {
            MemberBankDetailTransactionInfoCollections memberBankDetailTransactionInfoCollections = new MemberBankDetailTransactionInfoCollections();
            memberBankDetailTransactionInfoCollections.Add(memberBankDetailTransactionInfoInfo);
            return DeleteByAcquireInstitutionID(memberBankDetailTransactionInfoCollections);
        }

        public bool DeleteByAcquireInstitutionID(MemberBankDetailTransactionInfoCollections memberBankDetailTransactionInfoCollections)
        {
            string uniqueKey = "";
            try
            {
                DataController.StartTransaction();
                foreach (MemberBankDetailTransactionInfoInfo memberBankDetailTransactionInfoInfo in memberBankDetailTransactionInfoCollections)
                {
                    uniqueKey = memberBankDetailTransactionInfoInfo.AcquringInstitutionID;
                    DataController.DeleteByAcquireInstitutionID(memberBankDetailTransactionInfoInfo.AcquringInstitutionID);
                }
                DataController.CommitTransaction();
            }
            catch (Exception ex)
            {
                DataController.RollbackTransaction();
                return false;
            }

            return true;
        }
        #endregion
    }

}
