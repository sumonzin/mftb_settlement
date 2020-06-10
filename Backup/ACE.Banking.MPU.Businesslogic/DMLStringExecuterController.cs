using System;
using System.Collections.Generic;
using System.Text;

using System.Data;
using ACE.Banking.MPU.DataAccess;
namespace ACE.Banking.MPU.Businesslogic
{
    public class DMLStringExecuterController
    {
        public DataTable DMLStringExecuter(string DMLString)
        {
            DMLStringExecuterDataController DMLCtrl = new DMLStringExecuterDataController();
            DataTable DT = new DataTable();
            try
            {
                DMLCtrl.StartTransaction();
                DT = DMLCtrl.DMLExecuter(DMLString);
                DMLCtrl.CommitTransaction();
                return DT;
            }
            catch (Exception ex)
            {
                DMLCtrl.RollbackTransaction();
                return DT;
            }            
        }
    }
}
