using BussinessServices.Interface;
using BussinessServices.Users;
using InvestmentDTO.UserDTO;
using Microsoft.Owin.Security.OAuth;
using System.Security.Claims;
using System.Threading.Tasks;

namespace InvestmentTrackerApi.HelperClass.AuthProviders
{
    public class AuthServerProvider: OAuthAuthorizationServerProvider
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
                UserName = context.UserName,
                Password = PassWordEncryption.EncryptPassword(context.Password),
                Active = true,
                Locked = false,
            };
            
             var user = userRegistration.AuthorisedUser(register);
             
            if (user == null)
            {
                context.SetError("invalid_grant", "The user name or password is incorrect.");
                return;
            }
        //using (AuthRepository _repo = new AuthRepository())
        //{
        //    IdentityUser user = await _repo.FindUser(context.UserName, context.Password);

        //    if (user == null)
        //    {
        //        context.SetError("invalid_grant", "The user name or password is incorrect.");
        //        return;
        //    }
        //}

        var identity = new ClaimsIdentity(context.Options.AuthenticationType);
            identity.AddClaim(new Claim("sub", context.UserName));
            identity.AddClaim(new Claim("role", "user"));//set user role later

            context.Validated(identity);

        }
    }
}