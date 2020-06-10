using System;
using System.Collections.Generic;
using System.Text;

using System.Data;

namespace ACE.Banking.MPU.DataAccess
{
   public class DMLStringExecuterDataController : DataControllerBase
    {
       public DataTable DMLExecuter(string DMLString)
       {
           Command = DB.GetSqlStringCommand(DMLString);
           return DB.ExecuteDataSet(Command).Tables[0];
       }
    }
}
