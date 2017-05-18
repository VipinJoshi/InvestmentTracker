using AutoMapper;
using BussinessServices.DtoMapper.Profiles;

namespace BussinessServices.DtoMapper
{
    public class AutoMapperConfig
    {
        public static IMapper mapper;
        public static void RegisterMappping()
        {
            var config = new MapperConfiguration(cnfg =>
            {
                cnfg.AddProfile(new LoanLeadMappingProfile());
            });
            mapper = config.CreateMapper();
            config.AssertConfigurationIsValid();
        }
    }
}
