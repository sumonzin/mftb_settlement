using System;
using System.Data;
using System.Text;

namespace ACE.Banking.MPU.DataAccess
{
    public class MPU_Settlement_InfoDataController : DataControllerBase
    {
        #region Generated Methods

        #region Select Methods

        public IDataReader Select()
        {
            Command = DB.GetStoredProcCommand("MPU_Settlement_Info_SelectList");
            return DB.ExecuteReader(Command);
        }

        public IDataReader SelectBySTFDate(string SettlementDate)
        {
            //String StartDate = "2018-07-23 23:34:06.000";
            //String EndDate = "2018-07-24 23:34:07.000";
            //DateTime startdate = Convert.ToDateTime(StartDate);
            //DateTime enddate = Convert.ToDateTime(EndDate);
            try
            {
                Command = DB.GetStoredProcCommand("MPU_Settlement_Info_SelectListSettlementDate");
                DB.AddInParameter(Command, "FileSTFDate", DbType.String, SettlementDate);

                //DB.AddInParameter(Command, "MPUStartDate", DbType.DateTime, startdate);
                //DB.AddInParameter(Command, "MPUEndDate", DbType.DateTime, enddate);

                return DB.ExecuteReader(Command);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IDataReader SelectCore_EcomandPOSACQ(string SettlementDate)
        {
            try
            {
                Command = DB.GetStoredProcCommand("SP_SelectCore_EcomandPOSACQ");
                DB.AddInParameter(Command, "FileSTFDate", DbType.String, SettlementDate);

                return DB.ExecuteReader(Command);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IDataReader SelectCore_EcomandPOSISS(string SettlementDate)
        {
            try
            {
                Command = DB.GetStoredProcCommand("SP_SelectCore_EcomandPOSISS");
                DB.AddInParameter(Command, "FileSTFDate", DbType.String, SettlementDate);

                return DB.ExecuteReader(Command);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IDataReader SelectCore_ATMACQandISS(string SettlementDate)
        {
            try
            {
                Command = DB.GetStoredProcCommand("SP_SelectCore_ATMACQandISS");
                DB.AddInParameter(Command, "FileSTFDate", DbType.String, SettlementDate);

                return DB.ExecuteReader(Command);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion Select Methods

        #region Insert Methods

        public string Insert(string mPU_CODE, decimal oUTGOINGAMOUNT, decimal oUTGOINGFEE, decimal oUTGOINGMPUFEE, decimal aTMOUTGOINGAMOUNT, decimal aTMOUTGOINGFEE, decimal aTMOUTGOINGMPUFEE, decimal pOSOUTGOINGAMOUNT, decimal pOSOUTGOINGFEE, decimal pOSOUTGOINGMPUFEE, decimal iNCOMINGAMOUNT, decimal iNCOMINGFEE, decimal iNCOMINGMPUFEE, decimal aTMINCOMINGAMOUNT, decimal aTMINCOMINGFEE, decimal aTMINCOMINGMPUFEE, decimal pOSINCOMINGAMOUNT, decimal pOSINCOMINGFEE, decimal pOSINCOMINGMPUFEE, decimal sTFAMOUNT, decimal sTFFEE, decimal oUTGOINGSUMMARY, decimal iNCOMINGSUMMARY, DateTime mPUSTARTDATE, DateTime mPUENDDATE)
        {
            Command = DB.GetStoredProcCommand("MPU_Settlement_Info_Insert");

            DB.AddOutParameter(Command, "MPU_CODE", DbType.String, 36);
            DB.AddInParameter(Command, "OUTGOINGAMOUNT", DbType.Decimal, GetNull(oUTGOINGAMOUNT));
            DB.AddInParameter(Command, "OUTGOINGFEE", DbType.Decimal, GetNull(oUTGOINGFEE));
            DB.AddInParameter(Command, "OUTGOINGMPUFEE", DbType.Decimal, GetNull(oUTGOINGMPUFEE));
            DB.AddInParameter(Command, "ATMOUTGOINGAMOUNT", DbType.Decimal, GetNull(aTMOUTGOINGAMOUNT));
            DB.AddInParameter(Command, "ATMOUTGOINGFEE", DbType.Decimal, GetNull(aTMOUTGOINGFEE));
            DB.AddInParameter(Command, "ATMOUTGOINGMPUFEE", DbType.Decimal, GetNull(aTMOUTGOINGMPUFEE));
            DB.AddInParameter(Command, "POSOUTGOINGAMOUNT", DbType.Decimal, GetNull(pOSOUTGOINGAMOUNT));
            DB.AddInParameter(Command, "POSOUTGOINGFEE", DbType.Decimal, GetNull(pOSOUTGOINGFEE));
            DB.AddInParameter(Command, "POSOUTGOINGMPUFEE", DbType.Decimal, GetNull(pOSOUTGOINGMPUFEE));
            DB.AddInParameter(Command, "INCOMINGAMOUNT", DbType.Decimal, GetNull(iNCOMINGAMOUNT));
            DB.AddInParameter(Command, "INCOMINGFEE", DbType.Decimal, GetNull(iNCOMINGFEE));
            DB.AddInParameter(Command, "INCOMINGMPUFEE", DbType.Decimal, GetNull(iNCOMINGMPUFEE));
            DB.AddInParameter(Command, "ATMINCOMINGAMOUNT", DbType.Decimal, GetNull(aTMINCOMINGAMOUNT));
            DB.AddInParameter(Command, "ATMINCOMINGFEE", DbType.Decimal, GetNull(aTMINCOMINGFEE));
            DB.AddInParameter(Command, "ATMINCOMINGMPUFEE", DbType.Decimal, GetNull(aTMINCOMINGMPUFEE));
            DB.AddInParameter(Command, "POSINCOMINGAMOUNT", DbType.Decimal, GetNull(pOSINCOMINGAMOUNT));
            DB.AddInParameter(Command, "POSINCOMINGFEE", DbType.Decimal, GetNull(pOSINCOMINGFEE));
            DB.AddInParameter(Command, "POSINCOMINGMPUFEE", DbType.Decimal, GetNull(pOSINCOMINGMPUFEE));
            DB.AddInParameter(Command, "STFAMOUNT", DbType.Decimal, GetNull(sTFAMOUNT));
            DB.AddInParameter(Command, "STFFEE", DbType.Decimal, GetNull(sTFFEE));
            DB.AddInParameter(Command, "OUTGOINGSUMMARY", DbType.Decimal, GetNull(oUTGOINGSUMMARY));
            DB.AddInParameter(Command, "INCOMINGSUMMARY", DbType.Decimal, GetNull(iNCOMINGSUMMARY));
            DB.AddInParameter(Command, "MPUSTARTDATE", DbType.DateTime, GetNull(mPUSTARTDATE));
            DB.AddInParameter(Command, "MPUENDDATE", DbType.DateTime, GetNull(mPUENDDATE));

            if (UseTransaction)
                DB.ExecuteNonQuery(Command, Transaction);
            else
                DB.ExecuteNonQuery(Command);

            return DB.GetParameterValue(Command, "MPU_CODE").ToString();
        }

        #endregion Insert Methods

        #region Update Methods

        public void Update(string mPU_CODE, decimal oUTGOINGAMOUNT, decimal oUTGOINGFEE, decimal oUTGOINGMPUFEE, decimal aTMOUTGOINGAMOUNT, decimal aTMOUTGOINGFEE, decimal aTMOUTGOINGMPUFEE, decimal pOSOUTGOINGAMOUNT, decimal pOSOUTGOINGFEE, decimal pOSOUTGOINGMPUFEE, decimal iNCOMINGAMOUNT, decimal iNCOMINGFEE, decimal iNCOMINGMPUFEE, decimal aTMINCOMINGAMOUNT, decimal aTMINCOMINGFEE, decimal aTMINCOMINGMPUFEE, decimal pOSINCOMINGAMOUNT, decimal pOSINCOMINGFEE, decimal pOSINCOMINGMPUFEE, decimal sTFAMOUNT, decimal sTFFEE, decimal oUTGOINGSUMMARY, decimal iNCOMINGSUMMARY, DateTime mPUSTARTDATE, DateTime mPUENDDATE)
        {
            Command = DB.GetStoredProcCommand("MPU_Settlement_Info_Update");

            DB.AddInParameter(Command, "MPU_CODE", DbType.String, GetNull(mPU_CODE));
            DB.AddInParameter(Command, "OUTGOINGAMOUNT", DbType.Decimal, GetNull(oUTGOINGAMOUNT));
            DB.AddInParameter(Command, "OUTGOINGFEE", DbType.Decimal, GetNull(oUTGOINGFEE));
            DB.AddInParameter(Command, "OUTGOINGMPUFEE", DbType.Decimal, GetNull(oUTGOINGMPUFEE));
            DB.AddInParameter(Command, "ATMOUTGOINGAMOUNT", DbType.Decimal, GetNull(aTMOUTGOINGAMOUNT));
            DB.AddInParameter(Command, "ATMOUTGOINGFEE", DbType.Decimal, GetNull(aTMOUTGOINGFEE));
            DB.AddInParameter(Command, "ATMOUTGOINGMPUFEE", DbType.Decimal, GetNull(aTMOUTGOINGMPUFEE));
            DB.AddInParameter(Command, "POSOUTGOINGAMOUNT", DbType.Decimal, GetNull(pOSOUTGOINGAMOUNT));
            DB.AddInParameter(Command, "POSOUTGOINGFEE", DbType.Decimal, GetNull(pOSOUTGOINGFEE));
            DB.AddInParameter(Command, "POSOUTGOINGMPUFEE", DbType.Decimal, GetNull(pOSOUTGOINGMPUFEE));
            DB.AddInParameter(Command, "INCOMINGAMOUNT", DbType.Decimal, GetNull(iNCOMINGAMOUNT));
            DB.AddInParameter(Command, "INCOMINGFEE", DbType.Decimal, GetNull(iNCOMINGFEE));
            DB.AddInParameter(Command, "INCOMINGMPUFEE", DbType.Decimal, GetNull(iNCOMINGMPUFEE));
            DB.AddInParameter(Command, "ATMINCOMINGAMOUNT", DbType.Decimal, GetNull(aTMINCOMINGAMOUNT));
            DB.AddInParameter(Command, "ATMINCOMINGFEE", DbType.Decimal, GetNull(aTMINCOMINGFEE));
            DB.AddInParameter(Command, "ATMINCOMINGMPUFEE", DbType.Decimal, GetNull(aTMINCOMINGMPUFEE));
            DB.AddInParameter(Command, "POSINCOMINGAMOUNT", DbType.Decimal, GetNull(pOSINCOMINGAMOUNT));
            DB.AddInParameter(Command, "POSINCOMINGFEE", DbType.Decimal, GetNull(pOSINCOMINGFEE));
            DB.AddInParameter(Command, "POSINCOMINGMPUFEE", DbType.Decimal, GetNull(pOSINCOMINGMPUFEE));
            DB.AddInParameter(Command, "STFAMOUNT", DbType.Decimal, GetNull(sTFAMOUNT));
            DB.AddInParameter(Command, "STFFEE", DbType.Decimal, GetNull(sTFFEE));
            DB.AddInParameter(Command, "OUTGOINGSUMMARY", DbType.Decimal, GetNull(oUTGOINGSUMMARY));
            DB.AddInParameter(Command, "INCOMINGSUMMARY", DbType.Decimal, GetNull(iNCOMINGSUMMARY));
            DB.AddInParameter(Command, "MPUSTARTDATE", DbType.DateTime, GetNull(mPUSTARTDATE));
            DB.AddInParameter(Command, "MPUENDDATE", DbType.DateTime, GetNull(mPUENDDATE));

            if (UseTransaction)
                DB.ExecuteNonQuery(Command, Transaction);
            else
                DB.ExecuteNonQuery(Command);
        }

        #endregion Update Methods

        #region Delete Methods

        public void DeleteByMPU_CODE(string mPU_CODE)
        {
            Command = DB.GetStoredProcCommand("MPU_Settlement_Info_DeleteByMPU_CODE");

            DB.AddInParameter(Command, "MPU_CODE", DbType.String, GetNull(mPU_CODE));

            if (UseTransaction)
                DB.ExecuteNonQuery(Command, Transaction);
            else
                DB.ExecuteNonQuery(Command);
        }

        #endregion Delete Methods

        #endregion Generated Methods
    }
}