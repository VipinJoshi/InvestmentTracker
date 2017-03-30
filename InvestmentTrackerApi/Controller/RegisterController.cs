/*
 * This controller is used to handle User registration request
 */ 
using System;
using System.Collections.Generic;
using System.Web.Http;
using BussinessServices.Users;
using BussinessServices.Interface;
using InvestmentTrackerApi.DTO;
using BussinessEntities;
using System.Net.Http;
using System.Net;
using InvestmentTrackerApi.HelperClass;

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

        public string Get()
        {
            return string.Format("Hello Vipin its {0} so make it quick", DateTime.Now);
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