using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace ACE.Banking.MPU.DataAccess
{
    public class CBSMPUSFT_DataController : DataControllerBase
    {
        public string CBSSettlementFileGenerate(DateTime MPUStartdate, DateTime MPUEndDate)
        {
            Command = DB.GetStoredProcCommand("SP_MPU_SETTLEMENT_INFO_CUTOFF");
            DB.AddInParameter(Command, "MPUSTARTDATE", DbType.DateTime, MPUStartdate);
            DB.AddInParameter(Command, "MPUENDDATE", DbType.DateTime, MPUEndDate);
            DB.AddOutParameter(Command, "RCODE", DbType.String, 2);

            DB.ExecuteNonQuery(Command);
            return Convert.ToString(DB.GetParameterValue(Command, "RCODE"));
        }
    }
}
