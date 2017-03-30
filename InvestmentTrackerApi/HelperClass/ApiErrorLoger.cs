/*
 * this class file is a used to log the error 
 * note error loging is not implemented as its not required at this time but we can do in future by writting logic in Log methods
 */
using System.Web.Http.ExceptionHandling;

namespace InvestmentTrackerApi.HelperClass
{
    public class ApiErrorLoger:ExceptionLogger
    {
        public override void Log(ExceptionLoggerContext context)
        {
            //todo:implement the  logging later 
            base.Log(context);

        }
    }
}