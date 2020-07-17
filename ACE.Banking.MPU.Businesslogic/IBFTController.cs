using System;
using ACE.Banking.MPU.CollectionSuit;
using System.Linq;
using System.Collections.Generic;

namespace ACE.Banking.MPU.Businesslogic
{
    public class IBFTController
    {
        #region Variable
        //private MemberBankDetailTransactionInfoDataController DataController;
        private MemberBankDetailTransactionInfoController MemberBankDetailController;

        private MemberBankDetailTransactionInfoCollections memberBankDetailTransactionInfoInfosCol;
        #endregion

        #region Constructor
        public IBFTController()
        {
            //DataController = new MemberBankDetailTransactionInfoDataController();
            MemberBankDetailController = new MemberBankDetailTransactionInfoController();
            memberBankDetailTransactionInfoInfosCol = MemberBankDetailController.Select();

        }
        #endregion


        #region Methods
        public void BankAsAquirer()
        {

            
            var memberBankDetailTransactionInfosList = memberBankDetailTransactionInfoInfosCol.Cast<MemberBankDetailTransactionInfoInfo>().ToList();

            var option1List = memberBankDetailTransactionInfosList.Where(
                x =>
                (
                x.ProcessingCode.Substring(0, 2) == "40" ||
                x.ProcessingCode.Substring(0, 2) == "42" ||
                x.ProcessingCode.Substring(0, 2) == "48") &&
                x.TranRespCode == "500" &&
                x.PAN.Substring(0, 6) != "950502" &&
                x.FILENAME.Contains("ACOM")).ToList();


            decimal acqDebit = 0;
            foreach (var item in option1List)
            {
                acqDebit += (item.ServiceFeeReceive / 100); //  * 0.0005M + 100;
            }


            // Bank as Issuere and Beneficiary
            acqDebit = Math.Round(acqDebit, 2);

            var option1BIList = memberBankDetailTransactionInfosList.Where(
                x =>
                (
                x.ProcessingCode.Substring(0, 2) == "40" ||
                x.ProcessingCode.Substring(0, 2) == "42" ||
                x.ProcessingCode.Substring(0, 2) == "48") &&
                (x.TranRespCode == "500" || x.TranRespCode == "100") &&
                 x.PAN.Substring(0, 6) != "950502" &&
                 x.FILENAME.Contains("ICOM") &&
                 x.IssuerBankCode == "00290001" &&
                 x.BeneficiaryBankCode == "00290001" &&
                 x.AcquringInstitutionID != "00290001"
                )
                .ToList();

            decimal transTotalAmout1 = 0;
            decimal transTotalAmout2 = 0;
            decimal transTotalAmout3 = 0;
            
            foreach (var item in option1BIList)
            {
                transTotalAmout1 += Math.Round(item.ServiceFeePayable / 100, 2);

                transTotalAmout3 += Math.Round(((item.transAmount / 100) * 0.0005M) + 200, 2);
                var option1BBList = memberBankDetailTransactionInfosList.Where(
                x =>
                (
                x.ProcessingCode.Substring(0, 2) == "40" ||
                x.ProcessingCode.Substring(0, 2) == "42" ||
                x.ProcessingCode.Substring(0, 2) == "48") &&
                (x.TranRespCode == "500" || x.TranRespCode == "100") &&
                 x.PAN.Substring(0, 6) != "950502" &&
                 x.FILENAME.Contains("BCOM") &&
                 x.SystemTraceNo == item.SystemTraceNo &&
                 x.IssuerBankCode == "00290001" &&
                 x.BeneficiaryBankCode == "00290001" &&
                 x.AcquringInstitutionID != "00290001"
                ).Sum(
                    y =>
                    y.ServiceFeeReceive
                 );

                transTotalAmout2 += option1BBList / 100;
            }

            transTotalAmout1 = Math.Round(transTotalAmout1, 2);
            transTotalAmout2 = Math.Round(transTotalAmout2, 2);

            // decimal Iss_Credit2 = Math.Round(transTotalAmout1 + transTotalAmout2);
           
            decimal Iss_Debit = transTotalAmout3;
            decimal Iss_Credit2 = Math.Round((Iss_Debit - transTotalAmout1) + transTotalAmout2, 2);



        }

        public void BankAsIssuerOnly()
        {
            var memberBankDetailTransactionInfosList = memberBankDetailTransactionInfoInfosCol.Cast<MemberBankDetailTransactionInfoInfo>().ToList();
            var option3List = memberBankDetailTransactionInfosList.Where(
             x =>
             (
             x.ProcessingCode.Substring(0, 2) == "40" ||
             x.ProcessingCode.Substring(0, 2) == "42" ||
             x.ProcessingCode.Substring(0, 2) == "48") &&
             x.TranRespCode == "500" &&
             x.PAN.Substring(0, 6) != "950502" &&
             x.IssuerBankCode == "00290001" &&
             x.BeneficiaryBankCode != "00290001" &&
             x.AcquringInstitutionID != "00290001" &&
             x.FILENAME.Contains("ICOM")).ToList();

            decimal transTotalAmout1 = 0;
            decimal transTotalAmout2 = 0;
            foreach (var item in option3List)
            {
                transTotalAmout1 += Math.Round(((item.transAmount/100)+(item.transAmount / 100) * 0.0005M) + 200, 2);
                transTotalAmout2 += Math.Round((item.transAmount / 100)+(item.ServiceFeePayable / 100), 2);
            }
            
            decimal ISS_Debit = transTotalAmout1;
            decimal ISS_Credit= transTotalAmout2;
        }

        public void BankAsBefiniciaryOnly()
        {
           var memberBankDetailTransactionInfosList = memberBankDetailTransactionInfoInfosCol.Cast<MemberBankDetailTransactionInfoInfo>().ToList();
            var option2List = memberBankDetailTransactionInfosList.Where(
              x =>
              (
              x.ProcessingCode.Substring(0, 2) == "40" ||
              x.ProcessingCode.Substring(0, 2) == "42" ||
              x.ProcessingCode.Substring(0, 2) == "48") &&
              x.TranRespCode == "500" &&
              x.PAN.Substring(0, 6) != "950502" &&
              x.IssuerBankCode != "00290001" &&
              x.BeneficiaryBankCode == "00290001" &&
              x.AcquringInstitutionID != "00290001" &&
              x.FILENAME.Contains("BCOM")).ToList();

            decimal transTotalAmout1 = 0;
            decimal transTotalAmout2 = 0;
            foreach (var item in option2List)
            {
                transTotalAmout1 += Math.Round((item.transAmount/100) + (item.ServiceFeeReceive / 100),2);
                transTotalAmout2 += Math.Round(item.ServiceFeeReceive / 100,2);
            }

            decimal Bene_Debit = transTotalAmout1;
            decimal Bene_Credit = transTotalAmout2;

        }

       

        #endregion
    }
}
