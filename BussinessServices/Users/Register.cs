/* 
 * Register class contains all the bussiness logic related to Registration process
 */ 
using System;
using BussinessEntities;
using BussinessServices.Interface;
using DataModel.UnitOfWork;
using InvestmentDataModel.DataModel;

namespace BussinessServices.Users
{
    public class Register : IRegisterUser

    {
        private readonly UnitOfWork unitOfWork;

        public Register()
        {
            unitOfWork = new UnitOfWork();
        }

        /// <summary>
        /// check user name availability
        /// </summary>
        public bool UserNameAvailability(string userName)
        {

            var userLogin = new UserLogin();
            var result = unitOfWork.UsersLogin.Get(p=>string.Equals(p.UserName,userName,StringComparison.OrdinalIgnoreCase)) ?? new UserLogin() ;

            return !(result.UserId>0);
        }

        /// <summary>
        /// this file is used to register new user
        /// </summary>
        /// <param name="register"></param>
        /// <returns></returns>
        public long RegisterUser(UserLoginEntity register)
        {

            var userLogin = new UserLogin
            {
                UserName = register.UserName,
                Email = register.Email,
                Password = register.Password,
                Active = register.Active,
                Locked = register.Locked,
                DateOfAccountCreation = register.DateOfAccountCreation
            };

            unitOfWork.UsersLogin.Insert(userLogin);
            unitOfWork.Complete();
            unitOfWork.Dispose();
            return userLogin.UserId;

        }

        
    }
}
