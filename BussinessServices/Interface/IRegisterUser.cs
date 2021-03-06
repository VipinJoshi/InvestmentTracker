﻿using InvestmentDataModel.DataModel;
using InvestmentDTO.UserDTO;

namespace BussinessServices.Interface
{
    public interface IRegisterUser
    {
        long RegisterUser(UserLoginDTO register);

        //bool UpdateOtherUserInformation(int userId, UserAccountDetailsEntity accountDetail);//Add information of user Account details

        //bool UpdateLoginInformation(int userId, UserLoginEntity loginInformation);

        //bool DeleteUser(int userId);

        bool UserNameAvailability(string userName);

        UserLogin AuthorisedUser(UserLoginDTO register);


    }
}
