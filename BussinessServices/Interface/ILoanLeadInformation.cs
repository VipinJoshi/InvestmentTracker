using InvestmentDTO.LoanDTO;
using System;

namespace BussinessServices.Interface
{
    public interface ILoanLeadInformation
    {
       int InsertLead(LoanLeadInformationDTO leadInformation);

        LoanLeadInformationDTO GetLeadInformations(DateTime FromDate, DateTime ToDate);
    }
}
