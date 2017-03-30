using BussinessEntities;
using System.Linq;

namespace BussinessServices.Interface
{
    interface IEarningSlab
    {
        int CreateEarningSlab(EarningSlabEntity earningSlab);

        bool UpdateEarningSlab(int earningSlabId, EarningSlabEntity earningSlab);

        EarningSlabEntity GetEarningSlabById(int earningSlabId);

        IQueryable<EarningSlabEntity> GetAllEarningSlab();

        bool Delete(int earningSlabId);

    }
}
