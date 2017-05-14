using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MTakip.Entity;
using MTakip.Facade;

namespace MTakip
{
    public partial class admin : System.Web.UI.Page
    {
        int AddEdit = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (ADMINCRUD.IdyeGoreADMINGetir(Convert.ToInt32(Session["admin"])).YET != "1")
            {
                Response.Redirect("Anasayfa");
            }

            if (!String.IsNullOrEmpty(Request.QueryString["id"]))
            {
                AddEdit = Convert.ToInt32(Request.QueryString["id"]);
            }
            else
            {
                AddEdit = 0;
            }

            if (!Page.IsPostBack)
            {
                if (AddEdit != 0)
                {
                    btnKaydet.Text = "Düzenle";
                    ADMIN mst = ADMINCRUD.IdyeGoreADMINGetir(AddEdit);
                    tbK_Ad.Text = mst.K_AD;
                    tbPass.Text = mst.SFR;
                    tbMail.Text = mst.MAIL;
                    rbtnYetki.SelectedValue = mst.YET;
                }
                ADMGetir();
            }
        }

        protected void btnKaydet_Click(object sender, EventArgs e)
        {
            try
            {
                ADMIN mn = new ADMIN();
                mn.K_AD = tbK_Ad.Text;
                mn.SFR = tbPass.Text;
                mn.MAIL = tbMail.Text;
                mn.YET = rbtnYetki.SelectedValue;
                if (AddEdit == 0)
                {
                    ADMINCRUD.Kaydet(mn);
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "bilgi", "$.jGrowl('" + "Kaydetme Başarılı" + "', { header: 'Sonuç' });", true);
                }
                else
                {
                    mn.SON_GRS = DateTime.Now.ToShortDateString().ToString() + " - " + DateTime.Now.ToShortTimeString().ToString();
                    mn.ID = AddEdit;
                    ADMINCRUD.Guncelle(mn);
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "bilgi", "$.jGrowl('" + "Güncelleme Başarılı" + "', { header: 'Sonuç' });", true);
                }
                ADMGetir();
            }
            catch 
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "bilgi", "$.jGrowl('" + "İşleminizde Hata Oluştu Lütfen Kontrol Ediniz!" + "', { header: 'Sonuç' });", true);
            }            

        }

        protected void ADMGetir()
        {
            Tools.rptDoldur("SELECT * FROM ADMIN", rptAdmin);
        }

        protected void rptAdmin_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Sil") { ADMINCRUD.Sil(Convert.ToInt32(e.CommandArgument)); ADMGetir(); }
            if (e.CommandName == "Edit") { Response.Redirect("Admin?id=" + e.CommandArgument); }
        }


    }
}