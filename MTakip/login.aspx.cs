using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MTakip.Facade;
using MTakip.Entity;

namespace MTakip
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["exit"] == "1")
            {
                Session.Abandon();
            }
            Page.Form.DefaultButton = btnGiris.UniqueID;
        }

        protected void btnGiris_Click(object sender, EventArgs e)
        {
            int adminsay = Convert.ToInt32(ADMINCRUD.TekDegerGetir("SELECT COUNT(*) FROM ADMIN"));
            for (int i = 1; i <= adminsay; i++)
            {
                ADMIN admin = ADMINCRUD.IdyeGoreADMINGetir(i);

                if (tbK_Ad.Text == admin.K_AD && tbPass.Text == admin.SFR)
                {
                    Session["anahtar"] = "acik";
                    Session["admin"] = admin.ID.ToString();
                    admin.SON_GRS = DateTime.Now.ToShortDateString().ToString() +" - "+DateTime.Now.ToShortTimeString().ToString();
                    admin.MAIL = admin.MAIL;
                    admin.ID = admin.ID;
                    ADMINCRUD.Guncelle(admin);
                    Response.Redirect("Anasayfa");
                }
                else
                {
                    divSonuc.Visible = true;
                }
            }            
        }
    }
}