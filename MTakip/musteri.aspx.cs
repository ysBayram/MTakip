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
    public partial class musteri : System.Web.UI.Page
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
                if (AddEdit != 0)
                {
                    btnKaydet.Text = "Düzenle";
                    MUSTERI mst = MUSTERICRUD.IdyeGoreMUSTERIGetir(AddEdit);
                    tbK_Ad.Text = mst.K_AD;
                    tbAd.Text = mst.AD;
                    tbCep.Text = mst.CEP_TEL;
                    tbTel.Text = mst.TEL;
                    tbAdres.Text = mst.ADRES;
                }
                MUSGetir();
            }
        }

        protected void btnKaydet_Click(object sender, EventArgs e)
        {
            try
            {
                MUSTERI mn = new MUSTERI();
                mn.K_AD = tbK_Ad.Text;
                mn.AD = tbAd.Text;
                mn.CEP_TEL = tbCep.Text;
                mn.TEL = tbTel.Text;
                mn.ADRES = tbAdres.Text;
                string sonuc = String.Empty;
                if (AddEdit == 0)
                {
                    MUSTERICRUD.Kaydet(mn);
                    sonuc = "Kaydetme";
                    Temizle();
                }
                else
                {
                    mn.ID = AddEdit;
                    MUSTERICRUD.Guncelle(mn);
                    sonuc = "Güncelleme";
                }                
                Page.ClientScript.RegisterStartupScript(this.GetType(), "bilgi", "$.jGrowl('" + sonuc +" Başarılı" + "', { header: 'Sonuç' });", true);
                MUSGetir();
            }
            catch
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "bilgi", "$.jGrowl('" + "İşleminizde Hata Oluştu Lütfen Kontrol Ediniz!" + "', { header: 'Sonuç' });", true);
            }
        }

        protected void MUSGetir()
        {
            Tools.rptDoldur("SELECT * FROM MUSTERI", rptMusteri);
        }

        protected void rptMusteri_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Sil") { MUSTERICRUD.Sil(Convert.ToInt32(e.CommandArgument)); MUSGetir(); Temizle(); }
            if (e.CommandName == "Edit") { Response.Redirect("Musteri?id=" + e.CommandArgument); }
        }

        protected void Temizle()
        {
            tbK_Ad.Text = String.Empty;
            tbAd.Text = String.Empty;
            tbCep.Text = String.Empty;
            tbTel.Text = String.Empty;
            tbAdres.Text = String.Empty;
        }
    }
}