/* 
 * Register class contains all the bussiness logic related to Registration process
 */
using System;
using BussinessServices.Interface;
using DataModel.UnitOfWork;
using InvestmentDataModel.DataModel;
using InvestmentDTO.UserDTO;

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

            var result = unitOfWork.UsersLogin.Get(p => string.Equals(p.UserName, userName, StringComparison.OrdinalIgnoreCase)) ?? new UserLogin();

            return !(result.UserId > 0);
        }

        /// <summary>
        /// this file is used to register new user
        /// </summary>
        /// <param name="register"></param>
        /// <returns></returns>
        public long RegisterUser(UserLoginDTO register)
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

            var userRole = new UserRole
            {
                RoleId = register.RoleId,
                UserLogin = userLogin
               ,
                Active = true
            };

            unitOfWork.UserRole.Insert(userRole);

            unitOfWork.Complete();
            unitOfWork.Dispose();
            return userLogin.UserId;

        }

        public UserLogin AuthorisedUser(UserLoginDTO register)
        {
            var userLogin = new UserLogin
            {
                Email = register.Email,
                Password = register.Password
            };
            UserLogin user = unitOfWork.UsersLogin.Get(
                  p => p.Email.Equals(register.Email, StringComparison.OrdinalIgnoreCase)
                  && p.Password == (register.Password) && p.Active == true);
            return user;

        }


    }
}
