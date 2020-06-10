
using System;
using System.Data;
using System.Collections.ObjectModel;

using ACE.Banking.MPU.CollectionSuit;
using ACE.Banking.MPU.DataAccess;

/// <summary>
/// Settlement_ERR_Detail Entity
/// </summary>
namespace ACE.Banking.MPU.Businesslogic
{

	
/// <summary>
/// Settlement_ERR_Detail Controller
/// </summary>
public class Settlement_ERR_DetailController 
    {

	private Settlement_ERR_DetailDataController DataController;
    private int _recordCount;
	
	#region "Constructor"
	public Settlement_ERR_DetailController()
	{
            DataController = new Settlement_ERR_DetailDataController();
	}
	#endregion
	
	#region "Helper Methods"
	private void Fill(IDataReader dataReader,Settlement_ERR_DetailInfo settlement_ERR_DetailInfo)
	{
	if (!( dataReader["DisputeTransactionFlag"] is DBNull))
	{
		settlement_ERR_DetailInfo.DisputeTransactionFlag = Convert.ToString(dataReader["DisputeTransactionFlag"]);
	}
	
	if (!( dataReader["AcquiringInstitutionID"] is DBNull))
	{
		settlement_ERR_DetailInfo.AcquiringInstitutionID = Convert.ToDecimal(dataReader["AcquiringInstitutionID"]) ;
	}
	else
	{
		settlement_ERR_DetailInfo.AcquiringInstitutionID = Decimal.MinValue ;
	}
	
	if (!( dataReader["ForwardingInstitutionID"] is DBNull))
	{
		settlement_ERR_DetailInfo.ForwardingInstitutionID = Convert.ToDecimal(dataReader["ForwardingInstitutionID"]) ;
	}
	else
	{
		settlement_ERR_DetailInfo.ForwardingInstitutionID = Decimal.MinValue ;
	}
	
	if (!( dataReader["SystemTraceNumber"] is DBNull))
	{
		settlement_ERR_DetailInfo.SystemTraceNumber = Convert.ToDecimal(dataReader["SystemTraceNumber"]) ;
	}
	else
	{
		settlement_ERR_DetailInfo.SystemTraceNumber = Decimal.MinValue ;
	}
	
	if (!( dataReader["TransmissionDateTime"] is DBNull))
	{
		settlement_ERR_DetailInfo.TransmissionDateTime = Convert.ToDecimal(dataReader["TransmissionDateTime"]) ;
	}
	else
	{
		settlement_ERR_DetailInfo.TransmissionDateTime = Decimal.MinValue ;
	}
	
	if (!( dataReader["PAN"] is DBNull))
	{
		settlement_ERR_DetailInfo.PAN = Convert.ToDecimal(dataReader["PAN"]) ;
	}
	else
	{
		settlement_ERR_DetailInfo.PAN = Decimal.MinValue ;
	}
	
	if (!( dataReader["TransactionAmount"] is DBNull))
	{
		settlement_ERR_DetailInfo.TransactionAmount = Convert.ToDecimal(dataReader["TransactionAmount"]) ;
	}
	else
	{
		settlement_ERR_DetailInfo.TransactionAmount = Decimal.MinValue ;
	}
	
	if (!( dataReader["MessageType"] is DBNull))
	{
		settlement_ERR_DetailInfo.MessageType = Convert.ToDecimal(dataReader["MessageType"]) ;
	}
	else
	{
		settlement_ERR_DetailInfo.MessageType = Decimal.MinValue ;
	}
	
	if (!( dataReader["ProcessingCode"] is DBNull))
	{
		settlement_ERR_DetailInfo.ProcessingCode = Convert.ToDecimal(dataReader["ProcessingCode"]) ;
	}
	else
	{
		settlement_ERR_DetailInfo.ProcessingCode = Decimal.MinValue ;
	}
	
	if (!( dataReader["MerchantType"] is DBNull))
	{
		settlement_ERR_DetailInfo.MerchantType = Convert.ToDecimal(dataReader["MerchantType"]) ;
	}
	else
	{
		settlement_ERR_DetailInfo.MerchantType = Decimal.MinValue ;
	}
	
	if (!( dataReader["CardAcceptorTerminalId"] is DBNull))
	{
		settlement_ERR_DetailInfo.CardAcceptorTerminalId = Convert.ToString(dataReader["CardAcceptorTerminalId"]);
	}
	
	if (!( dataReader["OriginalTransactionRetrievalRefNo"] is DBNull))
	{
		settlement_ERR_DetailInfo.OriginalTransactionRetrievalRefNo = Convert.ToString(dataReader["OriginalTransactionRetrievalRefNo"]);
	}
	
	if (!( dataReader["PoitOfServiceCondition"] is DBNull))
	{
		settlement_ERR_DetailInfo.PoitOfServiceCondition = Convert.ToDecimal(dataReader["PoitOfServiceCondition"]) ;
	}
	else
	{
		settlement_ERR_DetailInfo.PoitOfServiceCondition = Decimal.MinValue ;
	}
	
	if (!( dataReader["AuthorizationIDResponse"] is DBNull))
	{
		settlement_ERR_DetailInfo.AuthorizationIDResponse = Convert.ToString(dataReader["AuthorizationIDResponse"]);
	}
	
	if (!( dataReader["ReceivingInstitutionID"] is DBNull))
	{
		settlement_ERR_DetailInfo.ReceivingInstitutionID = Convert.ToDecimal(dataReader["ReceivingInstitutionID"]) ;
	}
	else
	{
		settlement_ERR_DetailInfo.ReceivingInstitutionID = Decimal.MinValue ;
	}
	
	if (!( dataReader["CardIssBankID"] is DBNull))
	{
		settlement_ERR_DetailInfo.CardIssBankID = Convert.ToDecimal(dataReader["CardIssBankID"]) ;
	}
	else
	{
		settlement_ERR_DetailInfo.CardIssBankID = Decimal.MinValue ;
	}
	
	if (!( dataReader["OriginalTranSystemTraceNo"] is DBNull))
	{
		settlement_ERR_DetailInfo.OriginalTranSystemTraceNo = Convert.ToDecimal(dataReader["OriginalTranSystemTraceNo"]) ;
	}
	else
	{
		settlement_ERR_DetailInfo.OriginalTranSystemTraceNo = Decimal.MinValue ;
	}
	
	if (!( dataReader["ResponseCode"] is DBNull))
	{
		settlement_ERR_DetailInfo.ResponseCode = Convert.ToString(dataReader["ResponseCode"]);
	}
	
	if (!( dataReader["PointOfServiceEntryModeCode"] is DBNull))
	{
		settlement_ERR_DetailInfo.PointOfServiceEntryModeCode = Convert.ToDecimal(dataReader["PointOfServiceEntryModeCode"]) ;
	}
	else
	{
		settlement_ERR_DetailInfo.PointOfServiceEntryModeCode = Decimal.MinValue ;
	}
	
	if (!( dataReader["FeeCharged"] is DBNull))
	{
		settlement_ERR_DetailInfo.FeeCharged = Convert.ToDecimal(dataReader["FeeCharged"]) ;
	}
	else
	{
		settlement_ERR_DetailInfo.FeeCharged = Decimal.MinValue ;
	}
	
	if (!( dataReader["FeePaid"] is DBNull))
	{
		settlement_ERR_DetailInfo.FeePaid = Convert.ToDecimal(dataReader["FeePaid"]) ;
	}
	else
	{
		settlement_ERR_DetailInfo.FeePaid = Decimal.MinValue ;
	}
	
	if (!( dataReader["InterchangeServiceFee"] is DBNull))
	{
		settlement_ERR_DetailInfo.InterchangeServiceFee = Convert.ToDecimal(dataReader["InterchangeServiceFee"]) ;
	}
	else
	{
		settlement_ERR_DetailInfo.InterchangeServiceFee = Decimal.MinValue ;
	}
	
	if (!( dataReader["CardHolderTransFee"] is DBNull))
	{
		settlement_ERR_DetailInfo.CardHolderTransFee = Convert.ToDecimal(dataReader["CardHolderTransFee"]) ;
	}
	else
	{
		settlement_ERR_DetailInfo.CardHolderTransFee = Decimal.MinValue ;
	}
	
	if (!( dataReader["CommissionReceivable"] is DBNull))
	{
		settlement_ERR_DetailInfo.CommissionReceivable = Convert.ToDecimal(dataReader["CommissionReceivable"]) ;
	}
	else
	{
		settlement_ERR_DetailInfo.CommissionReceivable = Decimal.MinValue ;
	}
	
	if (!( dataReader["DisputeReason"] is DBNull))
	{
		settlement_ERR_DetailInfo.DisputeReason = Convert.ToDecimal(dataReader["DisputeReason"]) ;
	}
	else
	{
		settlement_ERR_DetailInfo.DisputeReason = Decimal.MinValue ;
	}
	
	if (!( dataReader["ReservedforUse"] is DBNull))
	{
		settlement_ERR_DetailInfo.ReservedforUse = Convert.ToString(dataReader["ReservedforUse"]);
	}
	
	if (!( dataReader["CreateDate"] is DBNull))
	{
		settlement_ERR_DetailInfo.CreateDate = Convert.ToDateTime(dataReader["CreateDate"]);
	}
	
	if (!( dataReader["BathNo"] is DBNull))
	{
		settlement_ERR_DetailInfo.BathNo = Convert.ToDecimal(dataReader["BathNo"]) ;
	}
	else
	{
		settlement_ERR_DetailInfo.BathNo = Decimal.MinValue ;
	}
	
	if (!( dataReader["FileName"] is DBNull))
	{
		settlement_ERR_DetailInfo.FileName = Convert.ToString(dataReader["FileName"]);
	}
	
	if (!( dataReader["FileType"] is DBNull))
	{
		settlement_ERR_DetailInfo.FileType = Convert.ToString(dataReader["FileType"]);
	}
	
	if (!( dataReader["STFDate"] is DBNull))
	{
		settlement_ERR_DetailInfo.STFDate = Convert.ToDateTime(dataReader["STFDate"]);
	}
	
	}
	#endregion
	
	#region "Select Methods"	
	
	public Settlement_ERR_DetailCollections Select() 
	{
		IDataReader dataReader = DataController.Select();
		Settlement_ERR_DetailCollections settlement_ERR_DetailCollections = new Settlement_ERR_DetailCollections();
	
		while(dataReader.Read())
		{
			Settlement_ERR_DetailInfo settlement_ERR_DetailInfo = new Settlement_ERR_DetailInfo();
			Fill(dataReader, settlement_ERR_DetailInfo);
			settlement_ERR_DetailCollections.Add(settlement_ERR_DetailInfo);
		}
		return settlement_ERR_DetailCollections;
		
	}
	
	#endregion
	
	#region "Add Methods"
	public bool Add(Settlement_ERR_DetailInfo settlement_ERR_DetailInfo ) 
	{
		Settlement_ERR_DetailCollections settlement_ERR_DetailCollections = new Settlement_ERR_DetailCollections();
		settlement_ERR_DetailCollections.Add(settlement_ERR_DetailInfo);
	
		return Add(settlement_ERR_DetailCollections);
	}
	
	public bool Add(Settlement_ERR_DetailCollections settlement_ERR_DetailCollections) 
	{
		string uniqueKey  = "";
		try
		{
			DataController.StartTransaction();
			foreach(Settlement_ERR_DetailInfo settlement_ERR_DetailInfo in settlement_ERR_DetailCollections)
			{
				uniqueKey = settlement_ERR_DetailInfo.DisputeTransactionFlag;
				settlement_ERR_DetailInfo.DisputeTransactionFlag = DataController.Insert(settlement_ERR_DetailInfo.DisputeTransactionFlag , settlement_ERR_DetailInfo.AcquiringInstitutionID , settlement_ERR_DetailInfo.ForwardingInstitutionID , settlement_ERR_DetailInfo.SystemTraceNumber , settlement_ERR_DetailInfo.TransmissionDateTime , settlement_ERR_DetailInfo.PAN , settlement_ERR_DetailInfo.TransactionAmount , settlement_ERR_DetailInfo.MessageType , settlement_ERR_DetailInfo.ProcessingCode , settlement_ERR_DetailInfo.MerchantType , settlement_ERR_DetailInfo.CardAcceptorTerminalId , settlement_ERR_DetailInfo.OriginalTransactionRetrievalRefNo , settlement_ERR_DetailInfo.PoitOfServiceCondition , settlement_ERR_DetailInfo.AuthorizationIDResponse , settlement_ERR_DetailInfo.ReceivingInstitutionID , settlement_ERR_DetailInfo.CardIssBankID , settlement_ERR_DetailInfo.OriginalTranSystemTraceNo , settlement_ERR_DetailInfo.ResponseCode , settlement_ERR_DetailInfo.PointOfServiceEntryModeCode , settlement_ERR_DetailInfo.FeeCharged , settlement_ERR_DetailInfo.FeePaid , settlement_ERR_DetailInfo.InterchangeServiceFee , settlement_ERR_DetailInfo.CardHolderTransFee , settlement_ERR_DetailInfo.CommissionReceivable , settlement_ERR_DetailInfo.DisputeReason , settlement_ERR_DetailInfo.ReservedforUse , settlement_ERR_DetailInfo.CreateDate , settlement_ERR_DetailInfo.BathNo , settlement_ERR_DetailInfo.FileName , settlement_ERR_DetailInfo.FileType , settlement_ERR_DetailInfo.STFDate);
			}				
			DataController.CommitTransaction();
		}	
        catch(Exception ex)
		{
			
			DataController.RollbackTransaction();
			return false;
		}
		return true;
	}
	#endregion
	
	#region "Update Methods"
	
	public bool Update(Settlement_ERR_DetailCollections settlement_ERR_DetailCollections )
	{
        try
		{
            DataController.StartTransaction();
            foreach(Settlement_ERR_DetailInfo settlement_ERR_DetailInfo in settlement_ERR_DetailCollections)
                DataController.Update(settlement_ERR_DetailInfo.DisputeTransactionFlag , settlement_ERR_DetailInfo.AcquiringInstitutionID , settlement_ERR_DetailInfo.ForwardingInstitutionID , settlement_ERR_DetailInfo.SystemTraceNumber , settlement_ERR_DetailInfo.TransmissionDateTime , settlement_ERR_DetailInfo.PAN , settlement_ERR_DetailInfo.TransactionAmount , settlement_ERR_DetailInfo.MessageType , settlement_ERR_DetailInfo.ProcessingCode , settlement_ERR_DetailInfo.MerchantType , settlement_ERR_DetailInfo.CardAcceptorTerminalId , settlement_ERR_DetailInfo.OriginalTransactionRetrievalRefNo , settlement_ERR_DetailInfo.PoitOfServiceCondition , settlement_ERR_DetailInfo.AuthorizationIDResponse , settlement_ERR_DetailInfo.ReceivingInstitutionID , settlement_ERR_DetailInfo.CardIssBankID , settlement_ERR_DetailInfo.OriginalTranSystemTraceNo , settlement_ERR_DetailInfo.ResponseCode , settlement_ERR_DetailInfo.PointOfServiceEntryModeCode , settlement_ERR_DetailInfo.FeeCharged , settlement_ERR_DetailInfo.FeePaid , settlement_ERR_DetailInfo.InterchangeServiceFee , settlement_ERR_DetailInfo.CardHolderTransFee , settlement_ERR_DetailInfo.CommissionReceivable , settlement_ERR_DetailInfo.DisputeReason , settlement_ERR_DetailInfo.ReservedforUse , settlement_ERR_DetailInfo.CreateDate , settlement_ERR_DetailInfo.BathNo , settlement_ERR_DetailInfo.FileName , settlement_ERR_DetailInfo.FileType , settlement_ERR_DetailInfo.STFDate);
            
            DataController.CommitTransaction();
		}
        catch(Exception ex)
		{
            
            DataController.RollbackTransaction();
            return false;
        }
        return true;
    }
	#endregion
	
	#region "Delete Methods"
	public bool DeleteByDisputeTransactionFlag(Settlement_ERR_DetailInfo settlement_ERR_DetailInfo ) 
	{
        Settlement_ERR_DetailCollections settlement_ERR_DetailCollections = new Settlement_ERR_DetailCollections();
        settlement_ERR_DetailCollections.Add(settlement_ERR_DetailInfo);
        return DeleteByDisputeTransactionFlag(settlement_ERR_DetailCollections);
    }
	
	public bool DeleteByDisputeTransactionFlag(Settlement_ERR_DetailCollections settlement_ERR_DetailCollections) 
	{
		string uniqueKey = "";
        try
		{
            DataController.StartTransaction();
            foreach(Settlement_ERR_DetailInfo settlement_ERR_DetailInfo in settlement_ERR_DetailCollections)
			{
				uniqueKey = settlement_ERR_DetailInfo.DisputeTransactionFlag;
                DataController.DeleteByDisputeTransactionFlag(settlement_ERR_DetailInfo.DisputeTransactionFlag);
            }
            DataController.CommitTransaction();
		}
		catch(Exception ex)
		{
			
			DataController.RollbackTransaction();
			return false;
		}

        return true;
    }
	
	
	
	#endregion 
}
	
}		
		
		
		
		
		
		
		
		
		