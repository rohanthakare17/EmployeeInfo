using System;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;

namespace EmployeeInfo
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            RegisterRoutes(RouteTable.Routes);
        }
        private void RegisterRoutes(RouteCollection routes)
        {
            routes.MapPageRoute("",
                "",
                "~/WebForms/Login.aspx"
            );
        }
    }
}