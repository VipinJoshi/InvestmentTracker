using BussinessServices.DtoMapper;
using InvestmentTrackerApi.HelperClass.AuthProviders;
using Microsoft.Owin;
using Microsoft.Owin.Security.OAuth;
using Owin;
using System;
using System.Web.Http;

[assembly: OwinStartup(typeof(InvestmentTrackerApi.App_Start.StartUp))]
namespace InvestmentTrackerApi.App_Start
{
    public class StartUp
    {
        public void Configuration(IAppBuilder app)
        {
            HttpConfiguration config = new HttpConfiguration();
            ConfigOAuth(app);
            WebApiConfig.Register(config);
            //app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);
            //app.UseWebApi(config);
            AutoMapperConfig.RegisterMappping();
        }

        public void ConfigOAuth(IAppBuilder app)
        {
            OAuthAuthorizationServerOptions oAuth = new OAuthAuthorizationServerOptions
            {
                AllowInsecureHttp = true,
                TokenEndpointPath = new PathString("/token"),
                AccessTokenExpireTimeSpan = TimeSpan.FromMinutes(20),
                Provider = new AuthServerProvider(),
                
            };
            app.UseOAuthAuthorizationServer(oAuth);
            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());
        }
    }
}