using InvestmentDataModel.DataModel;
using InvestmentDataModel.IRepository;

namespace InvestmentDataModel.Interface
{
    interface IUnitOfWork
    {
        IGenericRepository<UserLogin> UsersLogin { get; }
        IGenericRepository<UserAccountDetail> UsersAccountDetail { get; }
        IGenericRepository<LoanLeadInformation> LoanLeadInformation { get; }
        IGenericRepository<LoanType> LoanType { get; }
        int Complete();
    }
}
