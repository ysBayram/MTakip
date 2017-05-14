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
    public partial class basvuru : System.Web.UI.Page
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
                    BASVURU mst = BASVURUCRUD.IdyeGoreBASVURUGetir(AddEdit);
                    tbAd.Text = mst.AD;
                    tbCep.Text = mst.CEP_TEL;
                    tbTel.Text = mst.TEL;
                    tbTar.Text = mst.TARIFE;
                    tbAdres.Text = mst.ADRES;
                    tbTarih.Text = mst.TAR;
                    ddlAdmin.SelectedValue = mst.A_ID.ToString();
                    cbOnay.Checked = Convert.ToBoolean(mst.ONAY);
                }
                BASGetir();
            }
        }

        protected void rptBasvuru_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Sil") { BASVURUCRUD.Sil(Convert.ToInt32(e.CommandArgument)); Temizle(); BASGetir(); }
            if (e.CommandName == "Edit") { Response.Redirect("Basvuru?id=" + e.CommandArgument); }           
        }

        protected void BASGetir()
        {
            Tools.rptDoldur("SELECT * FROM BASVURU", rptBasvuru);
            Tools.ddlDoldur("SELECT * FROM ADMIN", ddlAdmin, "K_AD", "ID");
            if (AddEdit == 0) { ddlAdmin.Items.Insert(0, new ListItem("Lütfen Sorumlu Kişi Seçiniz", "0")); } else { ddlAdmin.SelectedIndex = BASVURUCRUD.IdyeGoreBASVURUGetir(AddEdit).A_ID; }            
        }

        protected void Temizle()
        {
            tbTar.Text = String.Empty;
            tbAd.Text = String.Empty;
            tbCep.Text = String.Empty;
            tbTel.Text = String.Empty;
            tbAdres.Text = String.Empty;
            tbTarih.Text = String.Empty;
            ddlAdmin.SelectedIndex = 0;
        }

        protected void btnKaydet_Click(object sender, EventArgs e)
        {
            try
            {
                BASVURU mn = new BASVURU();
                mn.TARIFE = tbTar.Text;
                mn.AD = tbAd.Text;
                mn.CEP_TEL = tbCep.Text;
                mn.TEL = tbTel.Text;
                mn.ADRES = tbAdres.Text;
                mn.TAR = tbTarih.Text;                
                mn.ONAY = cbOnay.Checked.ToString();
                mn.A_ID = Convert.ToInt32(ddlAdmin.SelectedValue);
                string sonuc = String.Empty;
                if (AddEdit == 0)
                {
                    BASVURUCRUD.Kaydet(mn);
                    sonuc = "Kaydetme";
                    Temizle();
                }
                else
                {     
                    mn.ID = AddEdit;
                    BASVURUCRUD.Guncelle(mn);
                    sonuc = "Güncelleme";
                }
                Page.ClientScript.RegisterStartupScript(this.GetType(), "bilgi", "$.jGrowl('" + sonuc + " Başarılı" + "', { header: 'Sonuç' });", true);
                BASGetir();
            }
            catch
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "bilgi", "$.jGrowl('" + "İşleminizde Hata Oluştu Lütfen Kontrol Ediniz!" + "', { header: 'Sonuç' });", true);
            }
        }



    }
}