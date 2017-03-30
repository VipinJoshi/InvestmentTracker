using System.Web.Http.ExceptionHandling;

namespace InvestmentTrackerApi.HelperClass
{
    public class ApiErrorLoger:ExceptionLogger
    {
       /* private IErrorLog errorRepository; todo: implement ninject 
        public ApiErrorLoger(ExceptionLoggerContext e)
        {
            errorRepository = e;
        }
        */
        public override void Log(ExceptionLoggerContext context)
        {
            //todo:implement the  logging later 
            base.Log(context);

        }
    }
}