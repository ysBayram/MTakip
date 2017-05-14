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
    public partial class _default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                T_Ariza.InnerText = ARIZACRUD.TekDegerGetir("SELECT COUNT(*) FROM ARIZA WHERE ONAY == 'True'").ToString();
                B_Ariza.InnerText = ARIZACRUD.TekDegerGetir("SELECT COUNT(*) FROM ARIZA WHERE ONAY == 'False'").ToString();
                T_Basvuru.InnerText = BASVURUCRUD.TekDegerGetir("SELECT COUNT(*) FROM BASVURU WHERE ONAY == 'True'").ToString();
                B_Basvuru.InnerText = BASVURUCRUD.TekDegerGetir("SELECT COUNT(*) FROM BASVURU WHERE ONAY == 'False'").ToString();

                string qs = Request.QueryString["tb"];
                
                if (!String.IsNullOrEmpty(qs))
                {
                    if (qs == "T_Ariza" || qs == "B_Ariza")
                    {
                        Tablo_Ariza.Attributes.Add("style", "display:block;");
                        Tablo_Basvuru.Attributes.Add("style", "display:none;");
                        if (qs == "T_Ariza")
                        {
                            Tools.rptDoldur("Select * from ARIZA where ONAY like 'true'", rptAriza);
                        }
                        if (qs == "B_Ariza")
                        {
                            Tools.rptDoldur("Select * from ARIZA where ONAY like 'false'", rptAriza);
                        }
                    }
                    if (qs == "T_Basvuru" || qs == "B_Basvuru")
                    {
                        Tablo_Basvuru.Attributes.Add("style", "display:block;");
                        Tablo_Ariza.Attributes.Add("style", "display:none;");
                        if (qs =="T_Basvuru")
                        {
                            Tools.rptDoldur("Select * from BASVURU where ONAY like 'true'", rptBasvuru);
                        }
                        if (qs == "B_Basvuru")
                        {
                            Tools.rptDoldur("Select * from BASVURU where ONAY like 'false'", rptBasvuru);
                        }
                    }
                    AltLogo.Visible = false;
                }

            }
        }

    }
}