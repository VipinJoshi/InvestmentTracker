using InvestmentDTO.UserDTO;

namespace BussinessServices.Interface
{
    public interface IUserLogin
    {
        bool Login(UserLoginDTO loginEntity);

        string ForgetPassword(string email);


    }
}
