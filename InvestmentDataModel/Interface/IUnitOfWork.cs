using InvestmentDataModel.DataModel;
using InvestmentDataModel.IRepository;

namespace InvestmentDataModel.Interface
{
    interface IUnitOfWork
    {
        IGenericRepository<UserLogin> UsersLogin { get; }
        IGenericRepository<UserAccountDetail> UsersAccountDetail { get; }

        int Complete();
    }
}
