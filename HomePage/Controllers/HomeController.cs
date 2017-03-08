using System;
using System.Net;
using System.Text;
using System.Timers;
using System.Web.Mvc;
using System.Xml;

namespace HomePage.Controllers
{
    static class CViewBag
    {
        public static string url;
        public static string copyright;
        public static string copyrightlink;
    }

    public class HomeController : Controller
    {
        Timer t = new Timer(3600000);

        public ActionResult Index()
        {
            if (CViewBag.url == null)
            {
                t.Elapsed += T_Elapsed;
                t.Start();
                T_Elapsed(null, null);
            }
            ViewBag.url = CViewBag.url;
            ViewBag.copyright = CViewBag.copyright;
            ViewBag.copyrightlink = CViewBag.copyrightlink;
            return View();
        }

        private void T_Elapsed(object sender, ElapsedEventArgs e)
        {
            XmlDocument doc = new XmlDocument();
            using (WebClient wc = new WebClient())
            {
                wc.Encoding = Encoding.UTF8;
                string xml = "";
                try
                {
                    xml = wc.DownloadString("http://www.bing.com/HPImageArchive.aspx?format=xml&idx=0&n=1&mkt=zh-cn");
                    doc.LoadXml(xml);
                    CViewBag.url = "http://cn.bing.com" + doc.GetElementsByTagName("url")[0].InnerText;
                    CViewBag.copyright = doc.GetElementsByTagName("copyright")[0].InnerText;
                    CViewBag.copyrightlink = doc.GetElementsByTagName("copyrightlink")[0].InnerText;
                }
                catch (Exception)
                {
                    ViewBag.url = "";
                    ViewBag.copyright = "";
                    ViewBag.copyrightlink = "javascript:";
                }
            }
        }
    }
}