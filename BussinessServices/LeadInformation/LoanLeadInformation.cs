using BussinessServices.Interface;
using System;
using DataModel.UnitOfWork;
using InvestmentDataModel.DataModel;
using InvestmentDTO.LoanDTO;

namespace BussinessServices.LeadInformation
{
    public class LoanLeadsInformation : ILoanLeadInformation
    {
        private UnitOfWork unitOfWork;
        public LoanLeadsInformation()
        {
            unitOfWork = new UnitOfWork();
        }

        public LoanLeadInformationDTO GetLeadInformations(DateTime FromDate, DateTime ToDate)
        {
            throw new NotImplementedException();
        }

        public int InsertLead(LoanLeadInformationDTO entity)
        {
            var leadInformation = new LoanLeadInformation
            {
                EmailId = entity.EmailId,
                LeadDescription = entity.LeadDescription,
                DateOfLeadCreation = DateTime.Now,
                MobileNumber = entity.MobileNumber,
                LoanTypeId = entity.LoanTypeId
            };
            unitOfWork.LoanLeadInformation.Insert(leadInformation);
            var id= unitOfWork.Complete();
            unitOfWork.Dispose();
            return id;
        }
    }
}
