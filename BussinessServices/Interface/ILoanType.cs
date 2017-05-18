using InvestmentDTO.LoanDTO;
using System.Collections.Generic;

namespace BussinessServices.Interface
{
    public interface ILoanType
    {
        IEnumerable<LoanTypeDTO> GetLoanType(); 
    }
}
