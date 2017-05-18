using System;

namespace InvestmentDTO.LoanDTO
{
    public class LoanLeadInformationDTO
    {
        public int LeadId { get; set; }
        public string LeadDescription { get; set; }
        public string EmailId { get; set; }
        public string MobileNumber { get; set; }
        public DateTime? DateOfLeadCreation { get; set; }
        // public virtual LaonTypeDTO LoanType { get; set; }//todo check the effect
        public string Name { get; set; }
        public string City { get; set; }
        public int LoanTypeId { get; set; }

    }
}
