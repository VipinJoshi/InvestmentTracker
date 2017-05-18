using BussinessServices.Interface;
using System.Collections.Generic;
using DataModel.UnitOfWork;
using InvestmentDTO.LoanDTO;
using BussinessServices.DtoMapper;
using InvestmentDataModel.DataModel;

namespace BussinessServices.LeadInformation
{
    public class LoanTypeService : ILoanType
    {
        private UnitOfWork unitOfWork;
        public LoanTypeService()
        {
            unitOfWork = new UnitOfWork();
        }

        public IEnumerable<LoanTypeDTO> GetLoanType()
        {
            //return
            var result= unitOfWork.LoanType.GetMany(p=>p.Active==true);
            
            //return ss;
            //   return 
            return AutoMapperConfig.mapper.Map<IEnumerable<LoanType>, IEnumerable<LoanTypeDTO>>(result);
                //AutoMapperConfig.Mapper.Map<IList<Receipt>, IList<ReceiptDTO>>(result);
        }
    }
}
