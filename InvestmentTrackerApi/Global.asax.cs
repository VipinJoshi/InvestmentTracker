using InvestmentDataModel;
using InvestmentTrackerApi.App_Start;
using System;
using System.Data.Entity;
using System.Web.Http;

namespace InvestmentTrackerApi
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            Database.SetInitializer<DataBaseContext>(null);
            //GlobalConfiguration.Configuration.Routes.Add("default", new HttpRoute("{Controller}/{action}/{Id}"));
            GlobalConfiguration.Configure(WebApiConfig.Register);

        }

       
    }
}