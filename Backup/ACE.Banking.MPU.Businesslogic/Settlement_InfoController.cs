using System;
using System.Data;

using ACE.Banking.MPU.CollectionSuit;
using ACE.Banking.MPU.DataAccess;

namespace ACE.Banking.MPU.Businesslogic
{
    /// <summary>
    /// Settlement_Info Controller
    /// </summary>
    public class Settlement_InfoController 
    {
        private Settlement_InfoDataController DataController;
        private int _recordCount;

        #region "Constructor"
        public Settlement_InfoController()
        {
            DataController = new Settlement_InfoDataController();
        }
        #endregion
        #region "Helper Methods"
        private void Fill(IDataReader dataReader, Settlement_InfoInfo settlement_InfoInfo)
        {
            if (!(dataReader["MPUDfCode"] is DBNull))
            {
                settlement_InfoInfo.MPUDfCode = Convert.ToString(dataReader["MPUDfCode"]);
            }

            if (!(dataReader["OutgoingAmoutSign"] is DBNull))
            {
                settlement_InfoInfo.OutgoingAmoutSign = Convert.ToString(dataReader["OutgoingAmoutSign"]);
            }

            if (!(dataReader["OutgoingAmount"] is DBNull))
            {
                settlement_InfoInfo.OutgoingAmount = Convert.ToDecimal(dataReader["OutgoingAmount"]);
            }

            if (!(dataReader["OutgoingFeeSign"] is DBNull))
            {
                settlement_InfoInfo.OutgoingFeeSign = Convert.ToString(dataReader["OutgoingFeeSign"]);
            }

            if (!(dataReader["OutgoingFee"] is DBNull))
            {
                settlement_InfoInfo.OutgoingFee = Convert.ToDecimal(dataReader["OutgoingFee"]);
            }

            if (!(dataReader["IncomingAmountSign"] is DBNull))
            {
                settlement_InfoInfo.IncomingAmountSign = Convert.ToString(dataReader["IncomingAmountSign"]);
            }

            if (!(dataReader["IncomingAmount"] is DBNull))
            {
                settlement_InfoInfo.IncomingAmount = Convert.ToDecimal(dataReader["IncomingAmount"]);
            }

            if (!(dataReader["IncomingFeeSign"] is DBNull))
            {
                settlement_InfoInfo.IncomingFeeSign = Convert.ToString(dataReader["IncomingFeeSign"]);
            }

            if (!(dataReader["IncomingFee"] is DBNull))
            {
                settlement_InfoInfo.IncomingFee = Convert.ToDecimal(dataReader["IncomingFee"]);
            }

            if (!(dataReader["STFAmountSign"] is DBNull))
            {
                settlement_InfoInfo.STFAmountSign = Convert.ToString(dataReader["STFAmountSign"]);
            }

            if (!(dataReader["STFAmount"] is DBNull))
            {
                settlement_InfoInfo.STFAmount = Convert.ToDecimal(dataReader["STFAmount"]);
            }

            if (!(dataReader["STFFeeSign"] is DBNull))
            {
                settlement_InfoInfo.STFFeeSign = Convert.ToString(dataReader["STFFeeSign"]);
            }

            if (!(dataReader["STFFee"] is DBNull))
            {
                settlement_InfoInfo.STFFee = Convert.ToDecimal(dataReader["STFFee"]);
            }

            if (!(dataReader["OutgoingSummary"] is DBNull))
            {
                settlement_InfoInfo.OutgoingSummary = Convert.ToDecimal(dataReader["OutgoingSummary"]);
            }

            if (!(dataReader["IncomingSummary"] is DBNull))
            {
                settlement_InfoInfo.IncomingSummary = Convert.ToDecimal(dataReader["IncomingSummary"]);
            }

            if (!(dataReader["SettlementCurrency"] is DBNull))
            {
                settlement_InfoInfo.SettlementCurrency = Convert.ToString(dataReader["SettlementCurrency"]);
            }

            if (!(dataReader["Reserved"] is DBNull))
            {
                settlement_InfoInfo.Reserved = Convert.ToString(dataReader["Reserved"]);
            }

            if (!(dataReader["CreatedDate"] is DBNull))
            {
                settlement_InfoInfo.CreatedDate = Convert.ToDateTime(dataReader["CreatedDate"]);
            }

            if (!(dataReader["UpdatedDate"] is DBNull))
            {
                settlement_InfoInfo.UpdatedDate = Convert.ToDateTime(dataReader["UpdatedDate"]);
            }

            if (!(dataReader["Status"] is DBNull))
            {
                settlement_InfoInfo.Status = Convert.ToString(dataReader["Status"]);
            }

            if (!(dataReader["ApproveBy"] is DBNull))
            {
                settlement_InfoInfo.ApproveBy = Convert.ToString(dataReader["ApproveBy"]);
            }

            if (!(dataReader["ApproveFrom"] is DBNull))
            {
                settlement_InfoInfo.ApproveFrom = Convert.ToString(dataReader["ApproveFrom"]);
            }
            if (!(dataReader["RejectBy"] is DBNull))
            {
                settlement_InfoInfo.RejectBy = Convert.ToString(dataReader["RejectBy"]);
            }

            if (!(dataReader["RejectFrom"] is DBNull))
            {
                settlement_InfoInfo.RejectFrom = Convert.ToString(dataReader["RejectFrom"]);
            }

            if (!(dataReader["ProcessBy"] is DBNull))
            {
                settlement_InfoInfo.ProcessBy = Convert.ToString(dataReader["ProcessBy"]);
            }

            if (!(dataReader["ProcessFrom"] is DBNull))
            {
                settlement_InfoInfo.ProcessFrom = Convert.ToString(dataReader["ProcessFrom"]);
            }

            if (!(dataReader["FileType"] is DBNull))
            {
                settlement_InfoInfo.FileType = Convert.ToString(dataReader["FileType"]);
            }

            if (!(dataReader["MerchantCode"] is DBNull))
            {
                settlement_InfoInfo.MerchantCode = Convert.ToString(dataReader["MerchantCode"]);
            }

            if (!(dataReader["TotalSettlementAmtSign"] is DBNull))
            {
                settlement_InfoInfo.TotalSettlementAmtSign = Convert.ToString(dataReader["TotalSettlementAmtSign"]);
            }

            if (!(dataReader["TotalSettlementAmt"] is DBNull))
            {
                settlement_InfoInfo.TotalSettlementAmt = Convert.ToDecimal(dataReader["TotalSettlementAmt"]);
            }

            if (!(dataReader["MerchantSettlementAccount"] is DBNull))
            {
                settlement_InfoInfo.MerchantSettlementAccount = Convert.ToString(dataReader["MerchantSettlementAccount"]);
            }

            if (!(dataReader["STFFileName"] is DBNull))
            {
                settlement_InfoInfo.SettlementFileName = Convert.ToString(dataReader["STFFileName"]);
            }
            if (!(dataReader["STFDate"] is DBNull))
            {
                settlement_InfoInfo.SettlementDate = Convert.ToDateTime(dataReader["STFDate"]);
            }

           
        }
        #endregion
        #region "Select Methods"
        public Settlement_InfoCollections Select()
        {
            IDataReader dataReader = DataController.Select();
            Settlement_InfoCollections settlement_InfoCollections = new Settlement_InfoCollections();

            while (dataReader.Read())
            {
                Settlement_InfoInfo settlement_InfoInfo = new Settlement_InfoInfo();
                Fill(dataReader, settlement_InfoInfo);
                settlement_InfoCollections.Add(settlement_InfoInfo);
            }
            return settlement_InfoCollections;

        }
        public Settlement_InfoCollections SelectByStatus(string status)
        {
            IDataReader dataReader = DataController.SelectByStatus(status);
            Settlement_InfoCollections settlement_InfoCollections = new Settlement_InfoCollections();

            while (dataReader.Read())
            {
                Settlement_InfoInfo settlement_InfoInfo = new Settlement_InfoInfo();
                Fill(dataReader, settlement_InfoInfo);
                settlement_InfoCollections.Add(settlement_InfoInfo);
            }
            return settlement_InfoCollections;

        }
        public Settlement_InfoCollections SelectBy(Settlement_InfoInfo settlement_InfoInfo)
        {
            IDataReader dataReader = DataController.FindBy(settlement_InfoInfo.MPUDfCode, settlement_InfoInfo.OutgoingAmoutSign, settlement_InfoInfo.OutgoingAmount, settlement_InfoInfo.OutgoingFeeSign, settlement_InfoInfo.OutgoingFee, settlement_InfoInfo.IncomingAmountSign, settlement_InfoInfo.IncomingAmount, settlement_InfoInfo.IncomingFeeSign, settlement_InfoInfo.IncomingFee, settlement_InfoInfo.STFAmountSign, settlement_InfoInfo.STFAmount, settlement_InfoInfo.STFFeeSign, settlement_InfoInfo.STFFee, settlement_InfoInfo.OutgoingSummary, settlement_InfoInfo.IncomingSummary, settlement_InfoInfo.SettlementCurrency, settlement_InfoInfo.Reserved, settlement_InfoInfo.CreatedDate, settlement_InfoInfo.UpdatedDate, settlement_InfoInfo.Status, settlement_InfoInfo.ApproveBy, settlement_InfoInfo.ApproveFrom,settlement_InfoInfo.RejectBy,settlement_InfoInfo.RejectFrom, settlement_InfoInfo.ProcessBy, settlement_InfoInfo.ProcessFrom, settlement_InfoInfo.FileType, settlement_InfoInfo.MerchantCode, settlement_InfoInfo.TotalSettlementAmtSign, settlement_InfoInfo.TotalSettlementAmt, settlement_InfoInfo.MerchantSettlementAccount);
            Settlement_InfoCollections settlement_InfoCollections = new Settlement_InfoCollections();

            while (dataReader.Read())
            {
                settlement_InfoInfo = new Settlement_InfoInfo();
                Fill(dataReader, settlement_InfoInfo);
                settlement_InfoCollections.Add(settlement_InfoInfo);
            }
            return settlement_InfoCollections;

        }
        #endregion
        #region "Add Methods"
        public bool Add(Settlement_InfoInfo settlement_InfoInfo)
        {
            Settlement_InfoCollections settlement_InfoCollections = new Settlement_InfoCollections();
            settlement_InfoCollections.Add(settlement_InfoInfo);

            return Add(settlement_InfoCollections);
        }

        public bool Add(Settlement_InfoCollections settlement_InfoCollections)
        {
            string uniqueKey = "";
            try
            {
                DataController.StartTransaction();
                foreach (Settlement_InfoInfo settlement_InfoInfo in settlement_InfoCollections)
                {
                    uniqueKey = settlement_InfoInfo.MPUDfCode;
                    settlement_InfoInfo.MPUDfCode = DataController.Insert(settlement_InfoInfo.MPUDfCode, settlement_InfoInfo.OutgoingAmoutSign, settlement_InfoInfo.OutgoingAmount, settlement_InfoInfo.OutgoingFeeSign, settlement_InfoInfo.OutgoingFee, settlement_InfoInfo.IncomingAmountSign, settlement_InfoInfo.IncomingAmount, settlement_InfoInfo.IncomingFeeSign, settlement_InfoInfo.IncomingFee, settlement_InfoInfo.STFAmountSign, settlement_InfoInfo.STFAmount, settlement_InfoInfo.STFFeeSign, settlement_InfoInfo.STFFee, settlement_InfoInfo.OutgoingSummary, settlement_InfoInfo.IncomingSummary, settlement_InfoInfo.SettlementCurrency, settlement_InfoInfo.Reserved, settlement_InfoInfo.CreatedDate, settlement_InfoInfo.UpdatedDate, settlement_InfoInfo.Status, settlement_InfoInfo.ApproveBy, settlement_InfoInfo.ApproveFrom, settlement_InfoInfo.RejectBy, settlement_InfoInfo.RejectFrom, settlement_InfoInfo.ProcessBy, settlement_InfoInfo.ProcessFrom, settlement_InfoInfo.FileType, settlement_InfoInfo.MerchantCode, settlement_InfoInfo.TotalSettlementAmtSign, settlement_InfoInfo.TotalSettlementAmt, settlement_InfoInfo.MerchantSettlementAccount, settlement_InfoInfo.SettlementFileName,settlement_InfoInfo.SettlementDate);
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
        public bool SettlementProcessForMerchant(string accountno, char amountsign, decimal amount,char feesign,decimal feeamount, string datetime, string currency, string eno, string terminalNo, out string refEno, out string ResponseCode)
        {
            try
            {
                DataController.StartTransaction();
                if (DataController.SettlementProcess(accountno, amountsign, amount, datetime, currency, eno, terminalNo, out refEno, out ResponseCode))
                {
                    if (ResponseCode == "00")
                    {
                        eno = refEno;
                        if (DataController.SettlementProcess(accountno, feesign, feeamount, datetime, currency, eno, terminalNo, out refEno, out ResponseCode))
                        {
                            if (ResponseCode == "00")
                                DataController.CommitTransaction();
                            else
                                throw new Exception("Error");
                        }
                    }                    
                }                    
                else
                    throw new Exception("Error.");
                refEno = eno;
                return true;
            }
            catch (Exception ex)
            {
                ResponseCode = "06";
                refEno = string.Empty;
                DataController.RollbackTransaction();
                return false;
            }
        }

        public bool SettlementProcessForMemberBank(Settlement_InfoInfo stfmbinfo,string channel,out string ENO,out string RCODE)
        {
            try
            {
                DataController.StartTransaction();

                if (DataController.MemberBankSettlementProcess(stfmbinfo.MPUDfCode, stfmbinfo.OutgoingAmount, stfmbinfo.OutgoingAmoutSign,stfmbinfo.OutgoingFee,stfmbinfo.OutgoingFeeSign, stfmbinfo.IncomingAmount, stfmbinfo.IncomingAmountSign, stfmbinfo.IncomingFee,stfmbinfo.IncomingFeeSign,stfmbinfo.SettlementCurrency, channel,stfmbinfo.SettlementDate, out ENO, out RCODE))
                {
                    if (RCODE == "00")
                        DataController.CommitTransaction();
                    else
                        
                        throw new Exception("Error");
                    
                }
                else
                    throw new Exception("Error");
                
                return true;

            }
            catch (Exception ex)
            {

                DataController.RollbackTransaction();
                ENO = string.Empty;
                RCODE = "06";
                return false;
            }
        }

        #endregion
        #region "Update Methods"

        public bool UpdateByMemberCode(Settlement_InfoCollections settlement_InfoCollections)
        {
            try
            {
                DataController.StartTransaction();
                foreach (Settlement_InfoInfo settlement_InfoInfo in settlement_InfoCollections)
                    DataController.UpdateByMemberCode(settlement_InfoInfo.MPUDfCode, settlement_InfoInfo.Status, settlement_InfoInfo.ApproveBy, settlement_InfoInfo.ApproveFrom,settlement_InfoInfo.RejectBy,settlement_InfoInfo.RejectFrom, settlement_InfoInfo.ProcessBy, settlement_InfoInfo.ProcessFrom,settlement_InfoInfo.FileType,settlement_InfoInfo.SettlementDate);

                DataController.CommitTransaction();
            }
            catch (Exception ex)
            {
                DataController.RollbackTransaction();
                return false;
            }
            return true;
        }
        public bool UpdateByMemberCode(Settlement_InfoInfo settlement_InfoInfo)
        {
            try
            {
                DataController.StartTransaction();
                DataController.UpdateByMemberCode(settlement_InfoInfo.MPUDfCode, settlement_InfoInfo.Status, settlement_InfoInfo.ApproveBy, settlement_InfoInfo.ApproveFrom, settlement_InfoInfo.RejectBy, settlement_InfoInfo.RejectFrom, settlement_InfoInfo.ProcessBy, settlement_InfoInfo.ProcessFrom,settlement_InfoInfo.FileType,settlement_InfoInfo.SettlementDate);
                DataController.CommitTransaction();
            }
            catch (Exception ex)
            {
                DataController.RollbackTransaction();
                return false;
            }
            return true;
        }
        public bool UpdateByMerchantCode(Settlement_InfoCollections settlement_InfoCollections)
        {
            try
            {
                DataController.StartTransaction();
                foreach (Settlement_InfoInfo settlement_InfoInfo in settlement_InfoCollections)
                    DataController.UpdateByMerchantCode(settlement_InfoInfo.Status, settlement_InfoInfo.ApproveBy, settlement_InfoInfo.ApproveFrom,settlement_InfoInfo.RejectBy,settlement_InfoInfo.RejectFrom, settlement_InfoInfo.ProcessBy, settlement_InfoInfo.ProcessFrom,settlement_InfoInfo.MerchantCode,settlement_InfoInfo.UpdatedDate,settlement_InfoInfo.FileType,settlement_InfoInfo.SettlementDate);

                DataController.CommitTransaction();
            }
            catch (Exception ex)
            {
                DataController.RollbackTransaction();
                return false;
            }
            return true;
        }
        public bool UpdateByMerchantCode(Settlement_InfoInfo settlement_InfoInfo)
        {
            try
            {
                DataController.StartTransaction();
                DataController.UpdateByMerchantCode(settlement_InfoInfo.Status, settlement_InfoInfo.ApproveBy, settlement_InfoInfo.ApproveFrom, settlement_InfoInfo.RejectBy, settlement_InfoInfo.RejectFrom, settlement_InfoInfo.ProcessBy, settlement_InfoInfo.ProcessFrom, settlement_InfoInfo.MerchantCode, settlement_InfoInfo.UpdatedDate,settlement_InfoInfo.FileType,settlement_InfoInfo.SettlementDate);
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
        public bool DeleteByMPUDfCode(Settlement_InfoInfo settlement_InfoInfo)
        {
            Settlement_InfoCollections settlement_InfoCollections = new Settlement_InfoCollections();
            settlement_InfoCollections.Add(settlement_InfoInfo);
            return DeleteByMPUDfCode(settlement_InfoCollections);
        }

        public bool DeleteByMPUDfCode(Settlement_InfoCollections settlement_InfoCollections)
        {
            string uniqueKey = "";
            try
            {
                DataController.StartTransaction();
                foreach (Settlement_InfoInfo settlement_InfoInfo in settlement_InfoCollections)
                {
                    uniqueKey = settlement_InfoInfo.MPUDfCode;
                    DataController.DeleteByMPUDfCode(settlement_InfoInfo.MPUDfCode);
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
        public bool DeleteBySTFFileName(string SettlementFileName)
        {
            string uniqueKey = "";
            try
            {
                DataController.StartTransaction();
                DataController.DeleteByFileName(SettlementFileName);
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