using DataModel.IRepository;


namespace DataModel.Interface
{
    interface IUnitOfWork
    {
        IGenericRepository<userslogin> UserLogin { get; }
        IGenericRepository<useraccountdetail> UserAccountDetail { get; }

        int Complete();
    }
}
