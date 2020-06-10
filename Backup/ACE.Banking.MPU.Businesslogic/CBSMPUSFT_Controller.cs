using System;
using System.Collections.Generic;
using System.Text;

using System.Data;
using ACE.Banking.MPU.DataAccess;

namespace ACE.Banking.MPU.Businesslogic
{
    public class CBSMPUSFT_Controller
    {
        public string CBSMPUSettlementFileGeneration(DateTime MPUSTFStartDate, DateTime MPUSTFEndDate)
        {
            CBSMPUSFT_DataController CBSMPUSTFCtrl = new CBSMPUSFT_DataController();
            string _return = string.Empty;
            try
            {
                CBSMPUSTFCtrl.StartTransaction();
                _return = CBSMPUSTFCtrl.CBSSettlementFileGenerate(MPUSTFStartDate, MPUSTFEndDate);
                CBSMPUSTFCtrl.CommitTransaction();
            }
            catch (Exception ex)
            {
                CBSMPUSTFCtrl.RollbackTransaction();
            }
            return _return;
        }
    }
}
