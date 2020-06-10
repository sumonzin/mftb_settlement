using System;
using System.Collections.Generic;
using System.Text;

using ACE.Banking.MPU.CollectionSuit;
using ACE.Banking.MPU.DataAccess;

namespace ACE.Banking.MPU.Businesslogic
{
    public class MPUSettlementStatusController
    {
        private MPUSettlementStatusDataController DataController;

        public MPUSettlementStatusController()
        {
            DataController = new MPUSettlementStatusDataController();
        }


        #region "Add Methods"
        public bool Add(MPUSettlementStatusInfo mPUSettlementStatusInfo)
        {
            MPUSettlementStatusCollections mPUSettlementStatusCollections = new MPUSettlementStatusCollections();
            mPUSettlementStatusCollections.Add(mPUSettlementStatusInfo);

            return Add(mPUSettlementStatusCollections);
        }

        public bool Add(MPUSettlementStatusCollections mPUSettlementStatusCollections)
        {
            string uniqueKey = "";
            bool _return = false;
            try
            {
                DataController.StartTransaction();
                foreach (MPUSettlementStatusInfo mPUSettlementStatusInfo in mPUSettlementStatusCollections)
                {
                    uniqueKey = mPUSettlementStatusInfo.MPUSettlementID;
                    _return = DataController.Insert(mPUSettlementStatusInfo.MPUSettlementID, mPUSettlementStatusInfo.MPUIncomingAmount, mPUSettlementStatusInfo.MPUOutgoingAmount, mPUSettlementStatusInfo.MPUIncomingFee, mPUSettlementStatusInfo.MPUOutgoingFee, mPUSettlementStatusInfo.CBSIncomingAmount, mPUSettlementStatusInfo.CBSOutgoingAmount, mPUSettlementStatusInfo.CBSIncomingFee, mPUSettlementStatusInfo.CBSOutgoingFee, mPUSettlementStatusInfo.TransactionNo, mPUSettlementStatusInfo.TransactionDate, mPUSettlementStatusInfo.SettlementDate, mPUSettlementStatusInfo.CreatedDate, mPUSettlementStatusInfo.UPdatedDate, mPUSettlementStatusInfo.STATUS);
                }
                DataController.CommitTransaction();
            }
            catch (Exception ex)
            {
                
                DataController.RollbackTransaction();
                return _return;
            }
            return _return;
        }
        #endregion

        #region "Update Method"
        public bool UpdatebySTFdate(MPUSettlementStatusInfo mPUSettlementStatusInfo)
        {
            try
            {
                DataController.StartTransaction();
                //foreach (MPUSettlementStatusInfo mPUSettlementStatusInfo in mPUSettlementStatusCollections)
                    DataController.Update(mPUSettlementStatusInfo.TransactionNo, mPUSettlementStatusInfo.TransactionDate, mPUSettlementStatusInfo.SettlementDate, mPUSettlementStatusInfo.UPdatedDate, mPUSettlementStatusInfo.STATUS);

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
