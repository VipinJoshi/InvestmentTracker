using BussinessServices.Interface;
using BussinessServices.LeadInformation;
using InvestmentDTO.LoanDTO;
using System.Collections.Generic;
using System.Web.Http;

namespace InvestmentTrackerApi.Controller
{
    [RoutePrefix("api/LoanLeads")]
    public class LoanLeadController : ApiController
    {
        private readonly ILoanLeadInformation leadInformation = null;
        private readonly ILoanType loanType = null;

        public LoanLeadController()
        {
            loanType = new LoanTypeService();
            leadInformation = new LoanLeadsInformation();
        }
        [HttpGet]
        [Route("{GetLoanType}")]
        public IEnumerable<LoanTypeDTO> GetLoanType()
        {
            return loanType.GetLoanType();
        }

        [HttpPost]
        [Route("{SaveLoanLead}")]
        public IHttpActionResult SaveLoanLead()
        {
            return Ok();
        }
    }

    
}
