using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using ACE.Banking.MPU.DataAccess;

namespace ACE.Banking.MPU.Businesslogic
{
    public class CutOffDateEntryController
    {
        Settlement_InfoDataController Datacontroller;
        
        #region "Constructor"

        public CutOffDateEntryController()
        {
            Datacontroller = new Settlement_InfoDataController();
        }

        #endregion

        #region Methods

        public void InsertintoCutoffdetail_Info(DateTime Startdate, DateTime EndDate,DateTime TranDate)
        {
            Datacontroller.InsertCutOffStartandEndDate(Startdate, EndDate, TranDate);
        }

        #endregion

    }
}
