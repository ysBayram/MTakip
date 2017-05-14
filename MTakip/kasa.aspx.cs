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
    public partial class kasa : System.Web.UI.Page
    {
        int AddEdit = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
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
                G_Gider.InnerText = KASACRUD.KasaSay("SELECT MIKTAR FROM KASA WHERE TUR == 'Gider' AND TAR == '" + DateTime.Now.ToString("dd'/'MM'/'yyyy") + "'").ToString();
                G_Gelir.InnerText = KASACRUD.KasaSay("SELECT MIKTAR FROM KASA WHERE TUR == 'Gelir' AND TAR == '" + DateTime.Now.ToString("dd'/'MM'/'yyyy") + "'").ToString();
                T_Gelir.InnerText = KASACRUD.KasaSay("SELECT MIKTAR FROM KASA WHERE TUR == 'Gelir'").ToString();
                T_Gider.InnerText = KASACRUD.KasaSay("SELECT MIKTAR FROM KASA WHERE TUR == 'Gider'").ToString();

                string qs = Request.QueryString["tb"];

                if (!String.IsNullOrEmpty(qs))
                {
                    if (qs == "G_Gelir")
                    {
                        Tools.rptDoldur("Select * from KASA where TUR == 'Gelir' AND TAR == '" + DateTime.Now.ToString("dd'/'MM'/'yyyy") + "'", rptKasa);
                    }
                    else if (qs == "G_Gider")
                    {
                        Tools.rptDoldur("Select * from KASA where TUR == 'Gider' AND TAR == '" + DateTime.Now.ToString("dd'/'MM'/'yyyy") + "'", rptKasa);
                    }
                    else if (qs == "T_Gelir")
                    {
                        Tools.rptDoldur("Select * from KASA where TUR == 'Gelir'", rptKasa);
                    }
                    else if (qs == "T_Gider")
                    {
                        Tools.rptDoldur("Select * from KASA where TUR == 'Gider'", rptKasa);
                    }

                    Tools.ddlDoldur("SELECT * FROM ADMIN", ddlAdmin, "K_AD", "ID");
                    ddlAdmin.Items.Insert(0, new ListItem("Lütfen Sorumlu Kişi Seçiniz", "0"));

                }
                else
                {
                    KASAGetir();
                }

                if (AddEdit != 0)
                {
                    btnKaydet.Text = "Düzenle";
                    KASA mst = KASACRUD.IdyeGoreKASAGetir(AddEdit);
                    ddlTur.SelectedValue = mst.TUR;
                    ddlAdmin.SelectedValue = mst.A_ID.ToString();
                    tbAcikla.Text = mst.ACIKLA.ToString();
                    tbTarih.Text = mst.TAR;
                    tbMiktar.Text = mst.MIKTAR.ToString();
                }
                
            }
        }

        protected void btnKaydet_Click(object sender, EventArgs e)
        {
            try
            {
                KASA mn = new KASA();
                mn.A_ID = Convert.ToInt32(ddlAdmin.SelectedValue);
                mn.TUR = ddlTur.SelectedValue;
                mn.TAR = tbTarih.Text;
                mn.MIKTAR = Convert.ToInt32(tbMiktar.Text);
                mn.ACIKLA = tbAcikla.Text;
                string sonuc = String.Empty;
                if (AddEdit == 0)
                {
                    KASACRUD.Kaydet(mn);
                    sonuc = "Kaydetme";
                    Temizle();
                }
                else
                {
                    mn.ID = AddEdit;
                    KASACRUD.Guncelle(mn);
                    sonuc = "Güncelleme";
                }
                Page.ClientScript.RegisterStartupScript(this.GetType(), "bilgi", "$.jGrowl('" + sonuc + " Başarılı" + "', { header: 'Sonuç' });", true);
                KASAGetir();
            }
            catch
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "bilgi", "$.jGrowl('" + "İşleminizde Hata Oluştu Lütfen Kontrol Ediniz!" + "', { header: 'Sonuç' });", true);
            }
        }

        protected void KASAGetir()
        {
            Tools.rptDoldur("SELECT * FROM KASA", rptKasa);
            Tools.ddlDoldur("SELECT * FROM ADMIN", ddlAdmin, "K_AD", "ID");
            ddlAdmin.Items.Insert(0, new ListItem("Lütfen Sorumlu Kişi Seçiniz", "0"));

        }

        protected void Temizle()
        {
            tbAcikla.Text = String.Empty;
            tbMiktar.Text = String.Empty;
            tbTarih.Text = String.Empty;
            ddlAdmin.SelectedIndex = 0;
            ddlTur.SelectedValue = "Gider";
        }

        protected void rptKasa_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Sil") { KASACRUD.Sil(Convert.ToInt32(e.CommandArgument)); Temizle(); KASAGetir(); }
            if (e.CommandName == "Edit") { Response.Redirect("kasa?id=" + e.CommandArgument); }  
        }

        protected string rowStyle(string tip)
        {
            string tur = KASACRUD.IdyeGoreKASAGetir(Convert.ToInt32(tip)).TUR;
            if (tur == "Gider")
            { return "gradeX even"; }
            else { return "gradeC even"; }
        }

    }
}