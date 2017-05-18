using InvestmentDataModel.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessEntities
{
    public class LoanLeadInformationEntity
    {
        public int LeadId { get; set; }
        public string LeadDescription { get; set; }
        public string EmailId { get; set; }
        public string MobileNumber { get; set; }
        public DateTime? DateOfLeadCreation { get; set; }
        public virtual LoanType LoanType { get; set; }
        
        public int LoanTypeId { get; set; }

    }
}
