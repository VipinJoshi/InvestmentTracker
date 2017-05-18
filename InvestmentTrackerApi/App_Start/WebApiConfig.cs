/*
 * Api config file
 */
using System.Web.Http;
using System.Web.Http.ExceptionHandling;

namespace InvestmentTrackerApi.App_Start
{
    public class WebApiConfig
    {
        //todo: move these logic in seperate files like routingconfig and error logging config
        public static void Register(HttpConfiguration config)
        {
            // TODO: Add any additional configuration code.

            RoutingConfiguration(config);

            //register error log in api config
            ErrorHandlingConfiguration(config);
        }

        private static void RoutingConfiguration(HttpConfiguration config)
        {
            // Web API routes
            config.MapHttpAttributeRoutes();

            //config.Routes.MapHttpRoute(
            //    name: "Register",
            //    routeTemplate: "api/{Controller}/{Action}",
            //    defaults: new { controller = "Register", Action = "UserRegistration" }
            //    );

            //config.Routes.MapHttpRoute(
            //    name: "ApiRoot",
            //    routeTemplate: "api/{Action}/{userName}",
            //    defaults: new { controller = "Register", Action = "", id = RouteParameter.Optional }
            //    );

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "{controller}/{action}/{id}",
                 defaults: new {Controller="LoanLead", action = "getloantype", id = RouteParameter.Optional }
            );
        }

        private static void ErrorHandlingConfiguration(HttpConfiguration config)
        {
            config.Services.Replace(typeof(IExceptionLogger), new HelperClass.ApiErrorLoger());
            config.Services.Replace(typeof(IExceptionHandler), new HelperClass.ApiExceptionHandler());
        }
    }
}