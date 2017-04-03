/*
 * This controller is used to handle User registration request
 */

using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BussinessEntities;
using BussinessServices.Interface;
using BussinessServices.Users;
using InvestmentTrackerApi.HelperClass;
using InvestmentTrackerDTO;

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
        public HttpResponseMessage UserRegistration(UserRegistration registration)
        {
            HttpResponseMessage response = null;

            if (registration != null && ModelState.IsValid)
            {
                var register = new UserLoginEntity()
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

                response = Request.CreateResponse(HttpStatusCode.OK, registration); 
            }
            else
            {
                response = Request.CreateResponse(HttpStatusCode.NotAcceptable, registration);
            }
            return response;

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