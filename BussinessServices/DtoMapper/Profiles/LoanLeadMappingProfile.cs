using AutoMapper;
using InvestmentDataModel.DataModel;
using InvestmentDTO.LoanDTO;

namespace BussinessServices.DtoMapper.Profiles
{
    class LoanLeadMappingProfile:Profile
    {
        public override string ProfileName { get { return "LoanLeadMappingProfile"; } }

        public LoanLeadMappingProfile()
        {
            CreateMap<LoanType, LoanTypeDTO>();
            // CreateMap<Group, GroupDetailDTO>();
        }
    }
}
