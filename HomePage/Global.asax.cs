using System.Net;
using System.Timers;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace HomePage
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            Timer t;
            t = new Timer(60000);
            t.Elapsed += T_Elapsed;
            t.Start();
        }

        private void T_Elapsed(object sender, ElapsedEventArgs e)
        {
            using (WebClient wb = new WebClient())
            {
                wb.DownloadString("http://chenzhitong.azurewebsites.net/");
            }
        }
    }
}
