/*
 * This controller is used to handle User registration request
 */

using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Web.Http;
using BussinessServices.Interface;
using BussinessServices.Users;
using InvestmentTrackerApi.HelperClass;
using InvestmentTrackerDTO;
using System.Threading.Tasks;
using InvestmentDTO.UserDTO;

namespace InvestmentTrackerApi.Controller
{
    [RoutePrefix("api/User")]
    public class RegisterController : ApiController
    {
        private readonly IRegisterUser userRegistration = null;

        public RegisterController()
        {
            userRegistration = new Register();
        }



        [HttpPost]
        [ActionName("Registration")]
        [Route("Register")]
        public async Task<IHttpActionResult> UserRegistration(UserRegistration registration)
        {
            HttpResponseMessage response = null;

            if (registration != null && ModelState.IsValid)
            {
                var register = new UserLoginDTO()
                {
                    UserName = registration.UserName,
                    Email = registration.Email,
                    Password = PassWordEncryption.EncryptPassword(registration.password),
                    Active = true,
                    Locked = false,
                    DateOfAccountCreation = DateTime.Now



                };

                // Register user
                userRegistration.RegisterUser(register);

                return Ok(registration);// Request.CreateResponse(HttpStatusCode.OK, registration); 
            }
            else
            {
                return BadRequest(ModelState);
             //   response = Request.CreateResponse(HttpStatusCode.NotAcceptable, registration);
            }
           // return response;

        }

        [HttpGet]
        //[ActionName("CheckUserName")]
        [Route("{userName}")]
        public UserAvailability GetUserNameAvailability(string userName)
        {
            var isAvailable = userRegistration.UserNameAvailability(userName);
            List<string> availableName = null;

            if (!isAvailable)
            {
                var name = string.Format(userName + "77");
                var name2 = string.Format(userName + DateTime.Now.ToString("ddyyyy"));
                availableName = new List<string> { name, name2 };
            }

            UserAvailability user = new UserAvailability
            {
                UserNameAvailable = isAvailable,
                SuggestedUserName = availableName

            };

            return user;
        }

    }
}