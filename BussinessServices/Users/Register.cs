/* 
 * Register class contains all the bussiness logic related to Registration process
 */
using System;
using BussinessServices.Interface;
using DataModel.UnitOfWork;
using InvestmentDataModel.DataModel;
using InvestmentDTO.UserDTO;
using System.Data.Entity;
using System.Linq;
using BussinessServices.HelperClass;

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

        public UserTokenDTO AuthorisedUser(UserLoginDTO register)
        {
            var userLogin = new UserLogin
            {
                Email = register.Email,
                Password = register.Password
            };
            
            var user = unitOfWork.UsersLogin.GetWithIncludes(
                  p => p.Email.Equals(register.Email, StringComparison.OrdinalIgnoreCase)
                  && p.Password == (register.Password) && p.Active == true &&p.Locked==false).Include(p=>p.UserRoles.Select(k=>k.Role));

            var query = user.Select(emp => new UserRoles{ UserName= emp.UserName,Roles= emp.UserRoles.Select(u=>u.Role.RoleName) });

            UserTokenDTO token = new UserTokenDTO();
            var userList = query.ToList();
            if (userList == null)
            {
                return token;
            }
            token.UserName = userList[0].UserName;
            var roles = string.Empty;

            // string.Join("|", userList[0].Roles.Select();  try that when get time
            foreach (var item in userList[0].Roles)
            {
                if (!string.IsNullOrWhiteSpace(item))
                {
                    roles += item + ",";
                }
            }
            token.RolesCollection = roles.TrimEnd(',');

            return token;
        }


    }
}
