/*
 * Exception handler class to handle exceptions
 */ 
using System.Net;
using System.Net.Http;
using System.Web.Http.ExceptionHandling;

namespace InvestmentTrackerApi.HelperClass
{
    public class ApiExceptionHandler:ExceptionHandler
    {
        public override void Handle(ExceptionHandlerContext context)
        {
            var result = new HttpResponseMessage(HttpStatusCode.InternalServerError)
            {
                Content = new StringContent("Some Error"),
                ReasonPhrase = "Internal Server Error "
            };

            context.Result = new ApiExceptionResult(context.Request, result);
           // base.Handle(context);
        }

    }
}