﻿using BussinessServices.Interface;
using BussinessServices.Users;
using InvestmentDTO.UserDTO;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OAuth;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace InvestmentTrackerApi.HelperClass.AuthProviders
{
    public class AuthServerProvider : OAuthAuthorizationServerProvider
    {
        private readonly IRegisterUser userRegistration = null;
        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
        }

        public AuthServerProvider()
        {
            userRegistration = new Register();
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {

            context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { "*" });
            var register = new UserLoginDTO()
            {
                Email = context.UserName,
                Password = PassWordEncryption.EncryptPassword(context.Password),
                Active = true,
                Locked = false,
            };

            var user = userRegistration.AuthorisedUser(register);

            if (user == null || string.IsNullOrWhiteSpace(user.UserName))
            {
                context.SetError("invalid_grant", "The user name or password is incorrect.");
                return;
            }

            var identity = new ClaimsIdentity(context.Options.AuthenticationType);
            identity.AddClaim(new Claim(ClaimTypes.Role, user.RolesCollection));
             
            var props = new AuthenticationProperties(new Dictionary<string, string>
                {
                    { "LoginUserName", user.UserName },
                    { "Role", user.RolesCollection },
                    { "UserId", user.UserId.ToString() }
                });
            var ticket = new AuthenticationTicket(identity, props);
            context.Validated(ticket);

        }

        /// <summary>
        /// this is for the extra information apart token
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override Task TokenEndpoint(OAuthTokenEndpointContext context)
        {
            foreach (KeyValuePair<string, string> property in context.Properties.Dictionary)
            {
                context.AdditionalResponseParameters.Add(property.Key, property.Value);
            }
            return Task.FromResult<object>(null);
        }

        
    }
}