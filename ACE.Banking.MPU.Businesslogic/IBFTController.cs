using System;
using ACE.Banking.MPU.CollectionSuit;
using System.Linq;

namespace ACE.Banking.MPU.Businesslogic
{
    public class IBFTController
    {
        #region Variable
        //private MemberBankDetailTransactionInfoDataController DataController;
        private MemberBankDetailTransactionInfoController MemberBankDetailController;

        #endregion

        #region Constructor
        public IBFTController()
        {
            //DataController = new MemberBankDetailTransactionInfoDataController();
            MemberBankDetailController = new MemberBankDetailTransactionInfoController();


        }
        #endregion


        #region Methods
        public void Option1()
        {
           



            //var ace = "9504035459183552".Substring(0, 6);

            Option1BankAsAcquirer();
            Option2BankAsBeneficiaryAndIssuer();
        }

        public void Option2()
        {

        }

        private void Option1BankAsAcquirer()
        {
            MemberBankDetailTransactionInfoCollections memberBankDetailTransactionInfoInfosCol = MemberBankDetailController.Select();
            var memberBankDetailTransactionInfosList = memberBankDetailTransactionInfoInfosCol.Cast<MemberBankDetailTransactionInfoInfo>().ToList();

            var option1List = memberBankDetailTransactionInfosList.Where(
                x =>
                (
                x.ProcessingCode.Substring(0, 2) == "40" ||
                x.ProcessingCode.Substring(0, 2) == "42"   ||
                x.ProcessingCode.Substring(0, 2) == "48" ) &&
                x.TranRespCode == "500" &&
                x.PAN.Substring(0, 6) != "950502" &&
                x.FILENAME.Contains("ACOM")).ToList();

            //int i = option1List.Count;

            decimal transTotalAmout = 0;
            foreach (var item in option1List)
            {
                transTotalAmout += (item.ServiceFeeReceive / 100); //  * 0.0005M + 100;
            }

            transTotalAmout = Math.Round(transTotalAmout, 2);

            var option1BIList = memberBankDetailTransactionInfosList.Where(
                x =>
                (
                x.ProcessingCode.Substring(0, 2) == "40" ||
                x.ProcessingCode.Substring(0, 2) == "42" ||
                x.ProcessingCode.Substring(0, 2) == "48") &&
                (x.TranRespCode == "500" || x.TranRespCode == "100") &&
                 x.PAN.Substring(0, 6) != "950502"  &&
                 x.FILENAME.Contains("ICOM") &&
                 x.IssuerBankCode == "00290001" 
                )
                .ToList();


            int i = option1BIList.Count;


        }

        private void Option2BankAsBeneficiaryAndIssuer()
        {

        }
        #endregion
    }
}
