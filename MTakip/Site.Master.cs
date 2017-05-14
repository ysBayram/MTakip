using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MTakip.Facade;

namespace MTakip
{
    public partial class Site : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((string)Session["anahtar"] == null || (string)Session["anahtar"] == "kapali")
            {
                Response.Redirect("login.aspx");
            }

            if (!Page.IsPostBack)
            {
                spanAdmin.InnerText = "Hoşgeldin " + ADMINCRUD.IdyeGoreADMINGetir(Convert.ToInt32(Session["admin"])).K_AD;
            }
        }
    }
}