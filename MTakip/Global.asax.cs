using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using System.Web.Routing;

namespace MTakip
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            RouteTable.Routes.MapPageRoute("anasayfa", "Anasayfa", "~/default.aspx");
            RouteTable.Routes.MapPageRoute("admin", "Admin", "~/admin.aspx");
            RouteTable.Routes.MapPageRoute("musteri", "Musteri", "~/musteri.aspx");
            RouteTable.Routes.MapPageRoute("ariza", "Ariza", "~/ariza.aspx");
            RouteTable.Routes.MapPageRoute("basvuru", "Basvuru", "~/basvuru.aspx");
            RouteTable.Routes.MapPageRoute("kasa", "Kasa", "~/kasa.aspx");
        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {
           
        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}