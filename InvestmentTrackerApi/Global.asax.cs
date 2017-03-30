using InvestmentDataModel;
using InvestmentTrackerApi.App_Start;
using System;
using System.Web.Http;

namespace InvestmentTrackerApi
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
           // Database.SetInitializer<DataBaseContext>(null);//todo: I might need this
            GlobalConfiguration.Configure(WebApiConfig.Register);

        }

       
    }
}