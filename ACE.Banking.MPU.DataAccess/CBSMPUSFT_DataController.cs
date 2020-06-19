using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Configuration;

//using System.Data.OracleClient;
using Oracle.DataAccess.Client;
using ACE.Banking.MPU.DataAccess;
using ACE.Banking.MPU.CollectionSuit;

namespace ACE.Banking.MPU.DataAccess
{
    public class CBSMPUSFT_DataController : DataControllerBase
    {
        
        public MPUSettlementINfo CBSSettlementFileGenerate(DateTime MPUStartdate, DateTime MPUEndDate)
        {
            
            String Startdate = MPUStartdate.ToString("dd-MM-yyyy");
            String EndDate = MPUEndDate.ToString("dd-MM-yyyy");

            var ConnectionString = ConfigurationManager.AppSettings["OrclConnection"];
            try
            {
                using (OracleConnection conn = new OracleConnection(ConnectionString))
                {
                    conn.Open();

                    OracleDataAdapter da = new OracleDataAdapter();
                    OracleCommand cmd = new OracleCommand();
                    cmd.Connection = conn;
                    cmd.CommandText = "custom.SP_MPU_SETTLEMENT_INFO_CUTOFF";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("MPUSTARTDATE", OracleDbType.Varchar2).Value = Startdate;
                    cmd.Parameters.Add("MPUENDDATE", OracleDbType.Varchar2).Value = EndDate;

              
                    cmd.Parameters.Add("CV_1", OracleDbType.RefCursor).Direction = ParameterDirection.Output;

                    MPUSettlementINfo SelectedData = new MPUSettlementINfo();
                    using (OracleDataReader rdr = cmd.ExecuteReader()) // execute the oracle sql and start reading it
                    {
                        while (rdr.Read())//loop through each row from oracle
                        {
                            if (!rdr.IsDBNull(0))
                            {
                                SelectedData.INID = rdr.GetString(0);
                            }
                            if (!rdr.IsDBNull(1))
                            {
                                SelectedData.OUtAMT = rdr.GetDecimal(1);
                            }
                            if (!rdr.IsDBNull(2))
                            {
                                SelectedData.OutFee = rdr.GetDecimal(2);
                            }
                            if (!rdr.IsDBNull(3))
                            {
                                SelectedData.OutMPUAmt = rdr.GetDecimal(3);
                            }
                            if (!rdr.IsDBNull(4))
                            {
                                SelectedData.OutMPUFee = rdr.GetDecimal(4);
                            }
                            if (!rdr.IsDBNull(5))
                            {
                                SelectedData.ATMOutAmt = rdr.GetDecimal(5);
                            }
                            if (!rdr.IsDBNull(6))
                            {
                                SelectedData.ATMOutFee = rdr.GetDecimal(6);
                            }
                            if (!rdr.IsDBNull(7))
                            {
                                SelectedData.ATMOutMPUAmt = rdr.GetDecimal(7);
                            }
                            if (!rdr.IsDBNull(8))
                            {
                                SelectedData.ATMOutMPUFee = rdr.GetDecimal(8);
                            }
                            if (!rdr.IsDBNull(9))
                            {
                                SelectedData.POSOutAmt = rdr.GetDecimal(9);
                            }
                            if (!rdr.IsDBNull(10))
                            {
                                SelectedData.POSOutFee = rdr.GetDecimal(10);
                            }
                            if (!rdr.IsDBNull(11))
                            {
                                SelectedData.POSOutMPUAmt = rdr.GetDecimal(11);
                            }
                            if (!rdr.IsDBNull(12))
                            {
                                SelectedData.POSOutMPUFee = rdr.GetDecimal(12);
                            }

                            //Ecom Out amt
                            if (!rdr.IsDBNull(13))
                            {
                                SelectedData.EcomOutAmt = rdr.GetDecimal(13);
                            }
                            if (!rdr.IsDBNull(14))
                            {
                                SelectedData.EcomOutFee = rdr.GetDecimal(14);
                            }
                            if (!rdr.IsDBNull(15))
                            {
                                SelectedData.EcomOutMPUAmt = rdr.GetDecimal(15);
                            }
                            if (!rdr.IsDBNull(16))
                            {
                                SelectedData.EcomOutMPUFee = rdr.GetDecimal(16);
                            }
                            //end of ecom out amt

                            if (!rdr.IsDBNull(17))
                            {
                                SelectedData.InAmt = rdr.GetDecimal(17);
                            }
                            if (!rdr.IsDBNull(18))
                            {
                                SelectedData.InFee = rdr.GetDecimal(18);
                            }
                            if (!rdr.IsDBNull(19))
                            {
                                SelectedData.InMPUAmt = rdr.GetDecimal(19);
                            }
                            if (!rdr.IsDBNull(20))
                            {
                                SelectedData.InMPUFee = rdr.GetDecimal(20);
                            }
                            if (!rdr.IsDBNull(21))
                            {
                                SelectedData.ATMInAmt = rdr.GetDecimal(21);
                            }
                            if (!rdr.IsDBNull(22))
                            {
                                SelectedData.ATMInFee = rdr.GetDecimal(22);
                            }
                            if (!rdr.IsDBNull(23))
                            {
                                SelectedData.ATMInMPUAmt = rdr.GetDecimal(23);
                            }
                            if (!rdr.IsDBNull(24))
                            {
                                SelectedData.ATMInMPUFee = rdr.GetDecimal(24);
                            }
                            if (!rdr.IsDBNull(25))
                            {
                                SelectedData.POSInAmt = rdr.GetDecimal(25);
                            }
                            if (!rdr.IsDBNull(26))
                            {
                                SelectedData.POSInFee = rdr.GetDecimal(26);
                            }
                            if (!rdr.IsDBNull(27))
                            {
                                SelectedData.POSInMPUAmt = rdr.GetDecimal(27);
                            }
                            if (!rdr.IsDBNull(28))
                            {
                                SelectedData.POSInMPUFee = rdr.GetDecimal(28);
                            }

                            //Ecom In amt
                            if (!rdr.IsDBNull(29))
                            {
                                SelectedData.EcomInAmt = rdr.GetDecimal(29);
                            }
                            if (!rdr.IsDBNull(30))
                            {
                                SelectedData.EcomInFee = rdr.GetDecimal(30);
                            }
                            if (!rdr.IsDBNull(31))
                            {
                                SelectedData.EcomInMPUAmt = rdr.GetDecimal(31);
                            }
                            if (!rdr.IsDBNull(32))
                            {
                                SelectedData.EcomInMPUFee = rdr.GetDecimal(32);
                            }
                            //
                            if (!rdr.IsDBNull(33))
                            {
                                SelectedData.STFAmt = rdr.GetDecimal(33);
                            }
                            if (!rdr.IsDBNull(34))
                            {
                                SelectedData.STFFee = rdr.GetDecimal(34);
                            }
                            if (!rdr.IsDBNull(35))
                            {
                                SelectedData.STFMPUAmt = rdr.GetDecimal(35);
                            }
                            if (!rdr.IsDBNull(36))
                            {
                                SelectedData.STFMPUFee = rdr.GetDecimal(36);
                            }
                            if (!rdr.IsDBNull(37))
                            {
                                SelectedData.OutSummary = rdr.GetDecimal(37);
                            }
                            if (!rdr.IsDBNull(38))
                            {
                                SelectedData.InSummary = rdr.GetDecimal(38);
                            }
                            
                        }
                        rdr.Close();
                    }

                    conn.Close();

                    return SelectedData;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //Insert into MPU_Settlement_info Table (Combie Db)
        public void Insert_MPU_SettlementInfo(string Inid, decimal outamt, decimal outfee, decimal outmpuamt, decimal outmpufee, decimal atmoutamt, decimal atmoutfee, decimal atmoutmpuamt, decimal atmoutmpufee, decimal posoutamt,
            decimal posoutfee, decimal posoutmpuamt, decimal posoutmpufee, decimal inamt, decimal infee, decimal inmpuamt, decimal inmpufee, decimal atminamt, decimal atminfee, decimal atminmpuamt, decimal atminmpufee, decimal posinamt, decimal posinfee,
            decimal posinmpuamt, decimal posinmpufee, decimal stfamt, decimal stffee, decimal stfmpuamt, decimal stfmpufee, decimal outSum, decimal inSum, DateTime MpuStartDate, DateTime MPUendDate,
            decimal ecomoutamt, decimal ecomoutfee, decimal ecommpuoutamt, decimal ecommpuoutfee, decimal ecominamt, decimal ecominfee, decimal ecominmpuamt, decimal ecominmpufee)
        {
            try
            {
                Command = DB.GetStoredProcCommand("Insert_MPUSettlement_Info");

                DB.AddInParameter(Command, "MPU_CODE", DbType.String, Inid);
                DB.AddInParameter(Command, "OUTGOINGAMOUNT", DbType.Decimal, GetNull(outamt));
                DB.AddInParameter(Command, "OUTGOINGFEE", DbType.Decimal, GetNull(outfee));
                DB.AddInParameter(Command, "OUTGOINGMPUAMT", DbType.Decimal, GetNull(outmpuamt));
                DB.AddInParameter(Command, "OUTGOINGMPUFEE", DbType.Decimal, GetNull(outmpufee));
                DB.AddInParameter(Command, "ATMOUTGOINGAMOUNT", DbType.Decimal, GetNull(atmoutamt));
                DB.AddInParameter(Command, "ATMOUTGOINGFEE", DbType.Decimal, GetNull(atmoutfee));
                DB.AddInParameter(Command, "ATMOUTGOINGMPUAMT", DbType.Decimal, GetNull(atmoutmpuamt));
                DB.AddInParameter(Command, "ATMOUTGOINGMPUFEE", DbType.Decimal, GetNull(atmoutmpufee));
                DB.AddInParameter(Command, "POSOUTGOINGAMOUNT", DbType.Decimal, GetNull(posoutamt));
                DB.AddInParameter(Command, "POSOUTGOINGFEE", DbType.Decimal, GetNull(posoutfee));
                DB.AddInParameter(Command, "POSOUTGOINGMPUAMT", DbType.Decimal, GetNull(posoutmpuamt));
                DB.AddInParameter(Command, "POSOUTGOINGMPUFEE", DbType.Decimal, GetNull(posoutmpufee));
                DB.AddInParameter(Command, "INCOMINGAMOUNT", DbType.Decimal, GetNull(inamt));
                DB.AddInParameter(Command, "INCOMINGFEE", DbType.Decimal, GetNull(infee));
                DB.AddInParameter(Command, "INCOMINGMPUAMT", DbType.Decimal, GetNull(inmpuamt));
                DB.AddInParameter(Command, "INCOMINGMPUFEE", DbType.Decimal, GetNull(inmpufee));
                DB.AddInParameter(Command, "ATMINCOMINGAMOUNT", DbType.Decimal, GetNull(atminamt));
                DB.AddInParameter(Command, "ATMINCOMINGFEE", DbType.Decimal, GetNull(atminfee));
                DB.AddInParameter(Command, "ATMINCOMINGMPUAMT", DbType.Decimal, GetNull(atminmpuamt));
                DB.AddInParameter(Command, "ATMINCOMINGMPUFEE", DbType.Decimal, GetNull(atminmpufee));
                DB.AddInParameter(Command, "POSINCOMINGAMOUNT", DbType.Decimal, GetNull(posinamt));
                DB.AddInParameter(Command, "POSINCOMINGFEE", DbType.Decimal, GetNull(posinfee));
                DB.AddInParameter(Command, "POSINCOMINGMPUAMT", DbType.Decimal, GetNull(posinmpuamt));
                DB.AddInParameter(Command, "POSINCOMINGMPUFEE", DbType.Decimal, GetNull(posinmpufee));
                DB.AddInParameter(Command, "STFAMOUNT", DbType.Decimal, GetNull(stfamt));
                DB.AddInParameter(Command, "STFFEE", DbType.Decimal, GetNull(stffee));
                DB.AddInParameter(Command, "STFMPUAMT", DbType.Decimal, GetNull(stfmpuamt));
                DB.AddInParameter(Command, "STFMPUFEE", DbType.Decimal, GetNull(stfmpufee));
                DB.AddInParameter(Command, "OUTGOINGSUMMARY", DbType.Decimal, GetNull(outSum));
                DB.AddInParameter(Command, "INCOMINGSUMMARY", DbType.Decimal, GetNull(inSum));

                //Ecom Out amt
                DB.AddInParameter(Command, "ECOMOUTAMOUNT", DbType.Decimal, GetNull(ecomoutamt));
                DB.AddInParameter(Command, "ECOMOUTFEE", DbType.Decimal, GetNull(ecomoutfee));
                DB.AddInParameter(Command, "ECOMOUTMPUAMT", DbType.Decimal, GetNull(ecommpuoutamt));
                DB.AddInParameter(Command, "ECOMOUTMPUFEE", DbType.Decimal, GetNull(ecommpuoutfee));
                //Ecom In Amt
                DB.AddInParameter(Command, "ECOMINCOMINGAMOUNT", DbType.Decimal, GetNull(ecominamt));
                DB.AddInParameter(Command, "ECOMINCOMINGFEE", DbType.Decimal, GetNull(ecominfee));
                DB.AddInParameter(Command, "ECOMINCOMINGMPUAMT", DbType.Decimal, GetNull(ecominmpuamt));
                DB.AddInParameter(Command, "ECOMINCOMINGMPUFEE", DbType.Decimal, GetNull(ecominmpufee));

                DB.AddInParameter(Command, "MPUSTARTDATE", DbType.DateTime, MpuStartDate);
                DB.AddInParameter(Command, "MPUENDDATE", DbType.DateTime, MPUendDate);

                DB.ExecuteNonQuery(Command);

                return;
            }
            catch (Exception ex)
            {
                return;
            }
        }
    }
}