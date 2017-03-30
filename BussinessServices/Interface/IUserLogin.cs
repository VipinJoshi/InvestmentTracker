using BussinessEntities;

namespace BussinessServices.Interface
{
    public interface IUserLogin
    {
        bool Login(UserLoginEntity loginEntity);

        string ForgetPassword(string email);


    }
}
