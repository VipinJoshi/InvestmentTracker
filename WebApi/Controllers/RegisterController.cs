using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BussinessEntities;
using BussinessServices.Interface;
using BussinessServices.Users;

namespace WebApi.Controllers
{
    public class RegisterController : ApiController
    {
        private readonly IRegisterUser registerService;

        public RegisterController()
        {
            registerService = new Register();
        }

        // POST api/product
        [HttpPost]
        public long Post([FromBody] UserLoginEntity usersEntity)
        {
            return registerService.RegisterUser(usersEntity);
        }

        [HttpGet]
        public bool UserNameAvailability(string userName)
        {
            return registerService.UserNameAvailability(userName);
        }
    }
}
