using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using ACE.Banking.MPU.CollectionSuit;
using ACE.Banking.MPU.DataAccess;
namespace ACE.Banking.MPU.Businesslogic
{
    /// <summary>
    /// MerchantDetailTransaction_Info Controller
    /// </summary>
    public class MerchantDetailTransaction_InfoController 
    {

        private MerchantDetailTransaction_InfoDataController DataController;
        

        #region "Constructor"
        public MerchantDetailTransaction_InfoController()
        {
            DataController = new MerchantDetailTransaction_InfoDataController();
        }
        #endregion

        #region "Helper Methods"
        private void Fill(IDataReader dataReader, MerchantDetailTransaction_InfoInfo merchantDetailTransaction_InfoInfo)
            {
            if (!(dataReader["AcquireInstitutionID"] is DBNull))
                merchantDetailTransaction_InfoInfo.AcquireInstitutionID = Convert.ToDecimal(dataReader["AcquireInstitutionID"]);

            if (!(dataReader["ForwardingInstitutionID"] is DBNull))
                merchantDetailTransaction_InfoInfo.ForwardingInstitutionID = Convert.ToDecimal(dataReader["ForwardingInstitutionID"]);

            if (!(dataReader["SystemTraceNo"] is DBNull))
                merchantDetailTransaction_InfoInfo.SystemTraceNo = Convert.ToDecimal(dataReader["SystemTraceNo"]);

            if (!(dataReader["TranDateTime"] is DBNull))
                merchantDetailTransaction_InfoInfo.TranDateTime = Convert.ToDecimal(dataReader["TranDateTime"]);

            if (!(dataReader["PAN"] is DBNull))
                merchantDetailTransaction_InfoInfo.PAN = Convert.ToDecimal(dataReader["PAN"]);

            if (!(dataReader["TransactionAmount"] is DBNull))
                merchantDetailTransaction_InfoInfo.TransactionAmount = Convert.ToDecimal(dataReader["TransactionAmount"]);

            if (!(dataReader["AccptAmount"] is DBNull))
                merchantDetailTransaction_InfoInfo.AccptAmount = Convert.ToDecimal(dataReader["AccptAmount"]);

            if (!(dataReader["MerchantTranFee"] is DBNull))
                merchantDetailTransaction_InfoInfo.MerchantTranFee = Convert.ToDecimal(dataReader["MerchantTranFee"]);

            if (!(dataReader["MessageType"] is DBNull))
                merchantDetailTransaction_InfoInfo.MessageType = Convert.ToDecimal(dataReader["MessageType"]);

            if (!(dataReader["ProcessingCode"] is DBNull))
                merchantDetailTransaction_InfoInfo.ProcessingCode = Convert.ToDecimal(dataReader["ProcessingCode"]);

            if (!(dataReader["MerchantType"] is DBNull))
                merchantDetailTransaction_InfoInfo.MerchantType = Convert.ToDecimal(dataReader["MerchantType"]);

            if (!(dataReader["AcceptorTerminalID"] is DBNull))
                merchantDetailTransaction_InfoInfo.AcceptorTerminalID = Convert.ToString(dataReader["AcceptorTerminalID"]);

            if (!(dataReader["AcceptorID"] is DBNull))
                merchantDetailTransaction_InfoInfo.AcceptorID = Convert.ToString(dataReader["AcceptorID"]);

            if (!(dataReader["RetrievalReferenceNo"] is DBNull))
                merchantDetailTransaction_InfoInfo.RetrievalReferenceNo = Convert.ToString(dataReader["RetrievalReferenceNo"]);

            if (!(dataReader["POSConditionCode"] is DBNull))
                merchantDetailTransaction_InfoInfo.POSConditionCode = Convert.ToDecimal(dataReader["POSConditionCode"]);

            if (!(dataReader["AuthorizeResponseCode"] is DBNull))
                merchantDetailTransaction_InfoInfo.AuthorizeResponseCode = Convert.ToString(dataReader["AuthorizeResponseCode"]);

            if (!(dataReader["InstitutionCode"] is DBNull))
                merchantDetailTransaction_InfoInfo.InstitutionCode = Convert.ToDecimal(dataReader["InstitutionCode"]);

            if (!(dataReader["OrgTraceNo"] is DBNull))
                merchantDetailTransaction_InfoInfo.OrgTraceNo = Convert.ToDecimal(dataReader["OrgTraceNo"]);

            if (!(dataReader["ResponseCode"] is DBNull))
                merchantDetailTransaction_InfoInfo.ResponseCode = Convert.ToString(dataReader["ResponseCode"]);

            if (!(dataReader["POSEntryMode"] is DBNull))
                merchantDetailTransaction_InfoInfo.POSEntryMode = Convert.ToDecimal(dataReader["POSEntryMode"]);

            if (!(dataReader["SvcFeeRec"] is DBNull))
                merchantDetailTransaction_InfoInfo.SvcFeeRec = Convert.ToDecimal(dataReader["SvcFeeRec"]);

            if (!(dataReader["SvcFeePayable"] is DBNull))
                merchantDetailTransaction_InfoInfo.SvcFeePayable = Convert.ToDecimal(dataReader["SvcFeePayable"]);

            if (!(dataReader["InterchangeSvcFee"] is DBNull))
                merchantDetailTransaction_InfoInfo.InterchangeSvcFee = Convert.ToDecimal(dataReader["InterchangeSvcFee"]);

            if (!(dataReader["SwitchFlag"] is DBNull))
                merchantDetailTransaction_InfoInfo.SwitchFlag = Convert.ToDecimal(dataReader["SwitchFlag"]);

            if (!(dataReader["ReservedForUse"] is DBNull))
                merchantDetailTransaction_InfoInfo.ReservedForUse = Convert.ToString(dataReader["ReservedForUse"]);

            if (!(dataReader["CreatedDate"] is DBNull))
                merchantDetailTransaction_InfoInfo.CreatedDate = Convert.ToDateTime(dataReader["CreatedDate"]);

            if (!(dataReader["BatchNo"] is DBNull))
                merchantDetailTransaction_InfoInfo.BatchNo = Convert.ToDecimal(dataReader["BatchNo"]);
            
            if (!(dataReader["FileName"] is DBNull))
                merchantDetailTransaction_InfoInfo.FileName = Convert.ToString(dataReader["FileName"]);

            if (!(dataReader["STFDate"] is DBNull))
                merchantDetailTransaction_InfoInfo.STFDate = Convert.ToDateTime(dataReader["STFDate"]);

        }
        #endregion

        #region "Select Methods"

        public MerchantDetailTransaction_InfoCollections Select()
        {
            IDataReader dataReader = DataController.Select();
            MerchantDetailTransaction_InfoCollections merchantDetailTransaction_InfoCollections = new MerchantDetailTransaction_InfoCollections();

            while (dataReader.Read())
            {
                MerchantDetailTransaction_InfoInfo merchantDetailTransaction_InfoInfo = new MerchantDetailTransaction_InfoInfo();
                Fill(dataReader, merchantDetailTransaction_InfoInfo);
                merchantDetailTransaction_InfoCollections.Add(merchantDetailTransaction_InfoInfo);
            }
            return merchantDetailTransaction_InfoCollections;

        }

        public DataSet SelectByMerchantCode(string MerchantCode,DateTime STFDate)
        {
            return DataController.SelectByMerchantCode(MerchantCode, STFDate);
        }

        #endregion

        #region "Add Methods"
        public bool Add(MerchantDetailTransaction_InfoInfo merchantDetailTransaction_InfoInfo)
        {
            MerchantDetailTransaction_InfoCollections merchantDetailTransaction_InfoCollections = new MerchantDetailTransaction_InfoCollections();
            merchantDetailTransaction_InfoCollections.Add(merchantDetailTransaction_InfoInfo);

            return Add(merchantDetailTransaction_InfoCollections);
        }

        public bool Add(MerchantDetailTransaction_InfoCollections merchantDetailTransaction_InfoCollections)
        {
            try
            {
                DataController.StartTransaction();
                foreach (MerchantDetailTransaction_InfoInfo merchantDetailTransaction_InfoInfo in merchantDetailTransaction_InfoCollections)
                {
                     DataController.Insert(merchantDetailTransaction_InfoInfo.AcquireInstitutionID, merchantDetailTransaction_InfoInfo.ForwardingInstitutionID,
                         merchantDetailTransaction_InfoInfo.SystemTraceNo, merchantDetailTransaction_InfoInfo.TranDateTime, 
                         merchantDetailTransaction_InfoInfo.PAN, merchantDetailTransaction_InfoInfo.TransactionAmount, 
                         merchantDetailTransaction_InfoInfo.AccptAmount, merchantDetailTransaction_InfoInfo.MerchantTranFee,
                         merchantDetailTransaction_InfoInfo.MessageType, merchantDetailTransaction_InfoInfo.ProcessingCode, 
                         merchantDetailTransaction_InfoInfo.MerchantType, merchantDetailTransaction_InfoInfo.AcceptorTerminalID, 
                         merchantDetailTransaction_InfoInfo.AcceptorID, merchantDetailTransaction_InfoInfo.RetrievalReferenceNo, 
                         merchantDetailTransaction_InfoInfo.POSConditionCode, merchantDetailTransaction_InfoInfo.AuthorizeResponseCode,
                         merchantDetailTransaction_InfoInfo.InstitutionCode, merchantDetailTransaction_InfoInfo.OrgTraceNo, 
                         merchantDetailTransaction_InfoInfo.ResponseCode, merchantDetailTransaction_InfoInfo.POSEntryMode,
                         merchantDetailTransaction_InfoInfo.SvcFeeRec, merchantDetailTransaction_InfoInfo.SvcFeePayable,
                         merchantDetailTransaction_InfoInfo.InterchangeSvcFee, merchantDetailTransaction_InfoInfo.SwitchFlag,
                         merchantDetailTransaction_InfoInfo.ReservedForUse, merchantDetailTransaction_InfoInfo.CreatedDate,
                         merchantDetailTransaction_InfoInfo.BatchNo,merchantDetailTransaction_InfoInfo.FileName,merchantDetailTransaction_InfoInfo.STFDate);
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

        public bool Update(MerchantDetailTransaction_InfoCollections merchantDetailTransaction_InfoCollections)
        {
            try
            {
                DataController.StartTransaction();
                foreach (MerchantDetailTransaction_InfoInfo merchantDetailTransaction_InfoInfo in merchantDetailTransaction_InfoCollections)
                    DataController.Update(merchantDetailTransaction_InfoInfo.AcquireInstitutionID, merchantDetailTransaction_InfoInfo.ForwardingInstitutionID,
                        merchantDetailTransaction_InfoInfo.SystemTraceNo, merchantDetailTransaction_InfoInfo.TranDateTime, 
                        merchantDetailTransaction_InfoInfo.PAN, merchantDetailTransaction_InfoInfo.TransactionAmount, 
                        merchantDetailTransaction_InfoInfo.AccptAmount, merchantDetailTransaction_InfoInfo.MerchantTranFee, 
                        merchantDetailTransaction_InfoInfo.MessageType, merchantDetailTransaction_InfoInfo.ProcessingCode, 
                        merchantDetailTransaction_InfoInfo.MerchantType, merchantDetailTransaction_InfoInfo.AcceptorTerminalID, 
                        merchantDetailTransaction_InfoInfo.AcceptorID, merchantDetailTransaction_InfoInfo.RetrievalReferenceNo,
                        merchantDetailTransaction_InfoInfo.POSConditionCode, merchantDetailTransaction_InfoInfo.AuthorizeResponseCode,
                        merchantDetailTransaction_InfoInfo.InstitutionCode, merchantDetailTransaction_InfoInfo.OrgTraceNo, 
                        merchantDetailTransaction_InfoInfo.ResponseCode, merchantDetailTransaction_InfoInfo.POSEntryMode,
                        merchantDetailTransaction_InfoInfo.SvcFeeRec, merchantDetailTransaction_InfoInfo.SvcFeePayable, 
                        merchantDetailTransaction_InfoInfo.InterchangeSvcFee, merchantDetailTransaction_InfoInfo.SwitchFlag,
                        merchantDetailTransaction_InfoInfo.ReservedForUse, merchantDetailTransaction_InfoInfo.CreatedDate, 
                        merchantDetailTransaction_InfoInfo.BatchNo, merchantDetailTransaction_InfoInfo.FileName,
                        merchantDetailTransaction_InfoInfo.STFDate);

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
        public bool DeleteByAcquireInstitutionID(MerchantDetailTransaction_InfoInfo merchantDetailTransaction_InfoInfo)
        {
            MerchantDetailTransaction_InfoCollections merchantDetailTransaction_InfoCollections = new MerchantDetailTransaction_InfoCollections();
            merchantDetailTransaction_InfoCollections.Add(merchantDetailTransaction_InfoInfo);
            return DeleteByAcquireInstitutionID(merchantDetailTransaction_InfoCollections);
        }

        public bool DeleteByAcquireInstitutionID(MerchantDetailTransaction_InfoCollections merchantDetailTransaction_InfoCollections)
        {
            try
            {
                DataController.StartTransaction();
                foreach (MerchantDetailTransaction_InfoInfo merchantDetailTransaction_InfoInfo in merchantDetailTransaction_InfoCollections)
                {                    
                    DataController.DeleteByAcquireInstitutionID(merchantDetailTransaction_InfoInfo.AcquireInstitutionID);
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
