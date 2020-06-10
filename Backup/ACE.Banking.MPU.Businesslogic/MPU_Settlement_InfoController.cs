using System;
using System.Collections.Generic;
using System.Text;

using ACE.Banking.MPU.CollectionSuit;
using ACE.Banking.MPU.DataAccess;
using System.Data;
namespace ACE.Banking.MPU.Businesslogic
{


    /// <summary>
    /// MPU_Settlement_Info Controller
    /// </summary>
    public class MPU_Settlement_InfoController
    {

        private MPU_Settlement_InfoDataController DataController;
        private int _recordCount;

        #region "Constructor"
        public MPU_Settlement_InfoController()
        {
            DataController = new MPU_Settlement_InfoDataController();
        }
        #endregion

        #region "Helper Methods"
        private void Fill(IDataReader dataReader, MPU_Settlement_InfoInfo mPU_Settlement_InfoInfo)
        {
            if (!(dataReader["MPU_CODE"] is DBNull))
            {
                mPU_Settlement_InfoInfo.MPU_CODE = Convert.ToString(dataReader["MPU_CODE"]);
            }

            if (!(dataReader["OUTGOINGAMOUNT"] is DBNull))
            {
                mPU_Settlement_InfoInfo.OUTGOINGAMOUNT = Convert.ToDecimal(dataReader["OUTGOINGAMOUNT"]);
            }

            if (!(dataReader["OUTGOINGFEE"] is DBNull))
            {
                mPU_Settlement_InfoInfo.OUTGOINGFEE = Convert.ToDecimal(dataReader["OUTGOINGFEE"]);
            }


            if (!(dataReader["OUTGOINGMPUFEE"] is DBNull))
            {
                mPU_Settlement_InfoInfo.OUTGOINGMPUFEE = Convert.ToDecimal(dataReader["OUTGOINGMPUFEE"]);
            }

            if (!(dataReader["ATMOUTGOINGAMOUNT"] is DBNull))
            {
                mPU_Settlement_InfoInfo.ATMOUTGOINGAMOUNT = Convert.ToDecimal(dataReader["ATMOUTGOINGAMOUNT"]);
            }


            if (!(dataReader["ATMOUTGOINGFEE"] is DBNull))
            {
                mPU_Settlement_InfoInfo.ATMOUTGOINGFEE = Convert.ToDecimal(dataReader["ATMOUTGOINGFEE"]);
            }


            if (!(dataReader["ATMOUTGOINGMPUFEE"] is DBNull))
            {
                mPU_Settlement_InfoInfo.ATMOUTGOINGMPUFEE = Convert.ToDecimal(dataReader["ATMOUTGOINGMPUFEE"]);
            }


            if (!(dataReader["POSOUTGOINGAMOUNT"] is DBNull))
            {
                mPU_Settlement_InfoInfo.POSOUTGOINGAMOUNT = Convert.ToDecimal(dataReader["POSOUTGOINGAMOUNT"]);
            }

            if (!(dataReader["POSOUTGOINGFEE"] is DBNull))
            {
                mPU_Settlement_InfoInfo.POSOUTGOINGFEE = Convert.ToDecimal(dataReader["POSOUTGOINGFEE"]);
            }


            if (!(dataReader["POSOUTGOINGMPUFEE"] is DBNull))
            {
                mPU_Settlement_InfoInfo.POSOUTGOINGMPUFEE = Convert.ToDecimal(dataReader["POSOUTGOINGMPUFEE"]);
            }

            if (!(dataReader["INCOMINGAMOUNT"] is DBNull))
            {
                mPU_Settlement_InfoInfo.INCOMINGAMOUNT = Convert.ToDecimal(dataReader["INCOMINGAMOUNT"]);
            }

            if (!(dataReader["INCOMINGFEE"] is DBNull))
            {
                mPU_Settlement_InfoInfo.INCOMINGFEE = Convert.ToDecimal(dataReader["INCOMINGFEE"]);
            }

            if (!(dataReader["INCOMINGMPUFEE"] is DBNull))
            {
                mPU_Settlement_InfoInfo.INCOMINGMPUFEE = Convert.ToDecimal(dataReader["INCOMINGMPUFEE"]);
            }

            if (!(dataReader["ATMINCOMINGAMOUNT"] is DBNull))
            {
                mPU_Settlement_InfoInfo.ATMINCOMINGAMOUNT = Convert.ToDecimal(dataReader["ATMINCOMINGAMOUNT"]);
            }


            if (!(dataReader["ATMINCOMINGFEE"] is DBNull))
            {
                mPU_Settlement_InfoInfo.ATMINCOMINGFEE = Convert.ToDecimal(dataReader["ATMINCOMINGFEE"]);
            }


            if (!(dataReader["ATMINCOMINGMPUFEE"] is DBNull))
            {
                mPU_Settlement_InfoInfo.ATMINCOMINGMPUFEE = Convert.ToDecimal(dataReader["ATMINCOMINGMPUFEE"]);
            }

            if (!(dataReader["POSINCOMINGAMOUNT"] is DBNull))
            {
                mPU_Settlement_InfoInfo.POSINCOMINGAMOUNT = Convert.ToDecimal(dataReader["POSINCOMINGAMOUNT"]);
            }

            if (!(dataReader["POSINCOMINGFEE"] is DBNull))
            {
                mPU_Settlement_InfoInfo.POSINCOMINGFEE = Convert.ToDecimal(dataReader["POSINCOMINGFEE"]);
            }


            if (!(dataReader["POSINCOMINGMPUFEE"] is DBNull))
            {
                mPU_Settlement_InfoInfo.POSINCOMINGMPUFEE = Convert.ToDecimal(dataReader["POSINCOMINGMPUFEE"]);
            }


            if (!(dataReader["STFAMOUNT"] is DBNull))
            {
                mPU_Settlement_InfoInfo.STFAMOUNT = Convert.ToDecimal(dataReader["STFAMOUNT"]);
            }


            if (!(dataReader["STFFEE"] is DBNull))
            {
                mPU_Settlement_InfoInfo.STFFEE = Convert.ToDecimal(dataReader["STFFEE"]);
            }
            else
            {
                mPU_Settlement_InfoInfo.STFFEE = Decimal.MinValue;
            }

            if (!(dataReader["OUTGOINGSUMMARY"] is DBNull))
            {
                mPU_Settlement_InfoInfo.OUTGOINGSUMMARY = Convert.ToDecimal(dataReader["OUTGOINGSUMMARY"]);
            }


            if (!(dataReader["INCOMINGSUMMARY"] is DBNull))
            {
                mPU_Settlement_InfoInfo.INCOMINGSUMMARY = Convert.ToDecimal(dataReader["INCOMINGSUMMARY"]);
            }

            if (!(dataReader["MPUSTARTDATE"] is DBNull))
            {
                mPU_Settlement_InfoInfo.MPUSTARTDATE = Convert.ToDateTime(dataReader["MPUSTARTDATE"]);
            }

            if (!(dataReader["MPUENDDATE"] is DBNull))
            {
                mPU_Settlement_InfoInfo.MPUENDDATE = Convert.ToDateTime(dataReader["MPUENDDATE"]);
            }

        }
        #endregion

        #region "Select Methods"

        public MPU_Settlement_InfoCollections Select()
        {
            IDataReader dataReader = DataController.Select();
            MPU_Settlement_InfoCollections mPU_Settlement_InfoCollections = new MPU_Settlement_InfoCollections();

            while (dataReader.Read())
            {
                MPU_Settlement_InfoInfo mPU_Settlement_InfoInfo = new MPU_Settlement_InfoInfo();
                Fill(dataReader, mPU_Settlement_InfoInfo);
                mPU_Settlement_InfoCollections.Add(mPU_Settlement_InfoInfo);
            }
            return mPU_Settlement_InfoCollections;
        }
        public MPU_Settlement_InfoCollections SelectBySettlementDate(string SettlementDate)
        {
            IDataReader dataReader = DataController.SelectBySTFDate(SettlementDate);
            MPU_Settlement_InfoCollections mPU_Settlement_InfoCollections = new MPU_Settlement_InfoCollections();

            while (dataReader.Read())
            {
                MPU_Settlement_InfoInfo mPU_Settlement_InfoInfo = new MPU_Settlement_InfoInfo();
                Fill(dataReader, mPU_Settlement_InfoInfo);
                mPU_Settlement_InfoCollections.Add(mPU_Settlement_InfoInfo);
            }
            return mPU_Settlement_InfoCollections;

        }

        #endregion

        #region "Add Methods"
        public bool Add(MPU_Settlement_InfoInfo mPU_Settlement_InfoInfo)
        {
            MPU_Settlement_InfoCollections mPU_Settlement_InfoCollections = new MPU_Settlement_InfoCollections();
            mPU_Settlement_InfoCollections.Add(mPU_Settlement_InfoInfo);

            return Add(mPU_Settlement_InfoCollections);
        }

        public bool Add(MPU_Settlement_InfoCollections mPU_Settlement_InfoCollections)
        {
            string uniqueKey = "";
            try
            {
                DataController.StartTransaction();
                foreach (MPU_Settlement_InfoInfo mPU_Settlement_InfoInfo in mPU_Settlement_InfoCollections)
                {
                    uniqueKey = mPU_Settlement_InfoInfo.MPU_CODE;
                    mPU_Settlement_InfoInfo.MPU_CODE = DataController.Insert(mPU_Settlement_InfoInfo.MPU_CODE, mPU_Settlement_InfoInfo.OUTGOINGAMOUNT, mPU_Settlement_InfoInfo.OUTGOINGFEE, mPU_Settlement_InfoInfo.OUTGOINGMPUFEE, mPU_Settlement_InfoInfo.ATMOUTGOINGAMOUNT, mPU_Settlement_InfoInfo.ATMOUTGOINGFEE, mPU_Settlement_InfoInfo.ATMOUTGOINGMPUFEE, mPU_Settlement_InfoInfo.POSOUTGOINGAMOUNT, mPU_Settlement_InfoInfo.POSOUTGOINGFEE, mPU_Settlement_InfoInfo.POSOUTGOINGMPUFEE, mPU_Settlement_InfoInfo.INCOMINGAMOUNT, mPU_Settlement_InfoInfo.INCOMINGFEE, mPU_Settlement_InfoInfo.INCOMINGMPUFEE, mPU_Settlement_InfoInfo.ATMINCOMINGAMOUNT, mPU_Settlement_InfoInfo.ATMINCOMINGFEE, mPU_Settlement_InfoInfo.ATMINCOMINGMPUFEE, mPU_Settlement_InfoInfo.POSINCOMINGAMOUNT, mPU_Settlement_InfoInfo.POSINCOMINGFEE, mPU_Settlement_InfoInfo.POSINCOMINGMPUFEE, mPU_Settlement_InfoInfo.STFAMOUNT, mPU_Settlement_InfoInfo.STFFEE, mPU_Settlement_InfoInfo.OUTGOINGSUMMARY, mPU_Settlement_InfoInfo.INCOMINGSUMMARY, mPU_Settlement_InfoInfo.MPUSTARTDATE, mPU_Settlement_InfoInfo.MPUENDDATE);
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

        public bool Update(MPU_Settlement_InfoCollections mPU_Settlement_InfoCollections)
        {
            try
            {
                DataController.StartTransaction();
                foreach (MPU_Settlement_InfoInfo mPU_Settlement_InfoInfo in mPU_Settlement_InfoCollections)
                    DataController.Update(mPU_Settlement_InfoInfo.MPU_CODE, mPU_Settlement_InfoInfo.OUTGOINGAMOUNT, mPU_Settlement_InfoInfo.OUTGOINGFEE, mPU_Settlement_InfoInfo.OUTGOINGMPUFEE, mPU_Settlement_InfoInfo.ATMOUTGOINGAMOUNT, mPU_Settlement_InfoInfo.ATMOUTGOINGFEE, mPU_Settlement_InfoInfo.ATMOUTGOINGMPUFEE, mPU_Settlement_InfoInfo.POSOUTGOINGAMOUNT, mPU_Settlement_InfoInfo.POSOUTGOINGFEE, mPU_Settlement_InfoInfo.POSOUTGOINGMPUFEE, mPU_Settlement_InfoInfo.INCOMINGAMOUNT, mPU_Settlement_InfoInfo.INCOMINGFEE, mPU_Settlement_InfoInfo.INCOMINGMPUFEE, mPU_Settlement_InfoInfo.ATMINCOMINGAMOUNT, mPU_Settlement_InfoInfo.ATMINCOMINGFEE, mPU_Settlement_InfoInfo.ATMINCOMINGMPUFEE, mPU_Settlement_InfoInfo.POSINCOMINGAMOUNT, mPU_Settlement_InfoInfo.POSINCOMINGFEE, mPU_Settlement_InfoInfo.POSINCOMINGMPUFEE, mPU_Settlement_InfoInfo.STFAMOUNT, mPU_Settlement_InfoInfo.STFFEE, mPU_Settlement_InfoInfo.OUTGOINGSUMMARY, mPU_Settlement_InfoInfo.INCOMINGSUMMARY, mPU_Settlement_InfoInfo.MPUSTARTDATE, mPU_Settlement_InfoInfo.MPUENDDATE);

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
        public bool DeleteByMPU_CODE(MPU_Settlement_InfoInfo mPU_Settlement_InfoInfo)
        {
            MPU_Settlement_InfoCollections mPU_Settlement_InfoCollections = new MPU_Settlement_InfoCollections();
            mPU_Settlement_InfoCollections.Add(mPU_Settlement_InfoInfo);
            return DeleteByMPU_CODE(mPU_Settlement_InfoCollections);
        }

        public bool DeleteByMPU_CODE(MPU_Settlement_InfoCollections mPU_Settlement_InfoCollections)
        {
            string uniqueKey = "";
            try
            {
                DataController.StartTransaction();
                foreach (MPU_Settlement_InfoInfo mPU_Settlement_InfoInfo in mPU_Settlement_InfoCollections)
                {
                    uniqueKey = mPU_Settlement_InfoInfo.MPU_CODE;
                    DataController.DeleteByMPU_CODE(mPU_Settlement_InfoInfo.MPU_CODE);
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








