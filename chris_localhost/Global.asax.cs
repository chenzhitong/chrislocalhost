using System.Net;
using System.Timers;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace chris_localhost
{
    public class MvcApplication : HttpApplication
    {
        Timer t;
        protected void Application_Start()
        {
            RouteConfig.RegisterRoutes(RouteTable.Routes);
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
