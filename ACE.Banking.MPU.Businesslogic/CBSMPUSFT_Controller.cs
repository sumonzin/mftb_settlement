using System;
using System.Collections.Generic;
using System.Text;
using ACE.Banking.MPU.CollectionSuit;
using System.Data;
using ACE.Banking.MPU.DataAccess;

namespace ACE.Banking.MPU.Businesslogic
{
    public class CBSMPUSFT_Controller
    {
        public string CBSMPUSettlementFileGeneration(DateTime MPUSTFStartDate, DateTime MPUSTFEndDate)
        {
            CBSMPUSFT_DataController CBSMPUSTFCtrl = new CBSMPUSFT_DataController();
            MPUSettlementINfo CutofData = new MPUSettlementINfo();

            string _return = string.Empty;
            try
            {
                //CBSMPUSTFCtrl.StartTransaction();
                //_return = CBSMPUSTFCtrl.CBSSettlementFileGenerate(MPUSTFStartDate, MPUSTFEndDate);
                //CBSMPUSTFCtrl.CommitTransaction();

                //Select ATM Settlement Data from Infosys Core Banking ........
                var CutOffData = CBSMPUSTFCtrl.CBSSettlementFileGenerate(MPUSTFStartDate, MPUSTFEndDate);

                //Insert into MPU_Settlement_Info (Combie DB)......
                if (CutOffData != null)
                {
                    try
                    {

                        CBSMPUSTFCtrl.Insert_MPU_SettlementInfo(
                                                                CutOffData.INID,
                                                                CutOffData.OUtAMT,
                                                                CutOffData.OutFee,
                                                                CutOffData.OutMPUAmt,
                                                                CutOffData.OutMPUFee,
                                                                CutOffData.ATMOutAmt,
                                                                CutOffData.ATMOutFee,
                                                                CutOffData.ATMOutMPUAmt,
                                                                CutOffData.ATMOutMPUFee,
                                                                CutOffData.POSOutAmt,
                                                                CutOffData.POSOutFee,
                                                                CutOffData.POSOutMPUAmt,
                                                                CutOffData.POSOutMPUFee,
                                                                CutOffData.InAmt,
                                                                CutOffData.InFee,
                                                                CutOffData.InMPUAmt,
                                                                CutOffData.InMPUFee,
                                                                CutOffData.ATMInAmt,
                                                                CutOffData.ATMInFee,
                                                                CutOffData.ATMInMPUAmt,
                                                                CutOffData.ATMInMPUFee,
                                                                CutOffData.POSInAmt,
                                                                CutOffData.POSInFee,
                                                                CutOffData.POSInMPUAmt,
                                                                CutOffData.POSInMPUFee,
                                                                CutOffData.STFAmt,
                                                                CutOffData.STFFee,
                                                                CutOffData.STFMPUAmt,
                                                                CutOffData.STFMPUFee,
                                                                CutOffData.OutSummary,
                                                                CutOffData.InSummary,
                                                                MPUSTFStartDate,
                                                                MPUSTFEndDate,
                                                                CutOffData.EcomOutAmt,
                                                                CutOffData.EcomOutFee,
                                                                CutOffData.EcomOutMPUAmt,
                                                                CutOffData.EcomOutMPUFee,
                                                                CutOffData.EcomInAmt,
                                                                CutOffData.EcomInFee,
                                                                CutOffData.EcomInMPUAmt,
                                                                CutOffData.EcomInMPUFee
                                                               
                            //CutofData.MPUStartDate,           
                            //CutofData.MPUEndDate                                                         
                                                                );
                        _return = "00";
                    }
                    catch(Exception ex)
                    {
                        throw ex;
                    }
                }

                return _return;

            }
            catch (Exception ex)
            {
                CBSMPUSTFCtrl.RollbackTransaction();
            }

            return _return;
            
        }
    }
}
