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
    public partial class ariza : System.Web.UI.Page
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
                    ARIZA mst = ARIZACRUD.IdyeGoreARIZAGetir(AddEdit);
                    ddlMusteri.SelectedValue = mst.M_ID.ToString();
                    ddlAdmin.SelectedValue = mst.A_ID.ToString();
                    cbOnay.Checked = Convert.ToBoolean(mst.ONAY);
                    tbTarih.Text = mst.TAR;
                    tbNot.Text = mst.MSJ;
                }
                ARGetir();
            }
        }

        protected void btnKaydet_Click(object sender, EventArgs e)
        {
            try
            {
                ARIZA mn = new ARIZA();
                mn.A_ID = Convert.ToInt32(ddlAdmin.SelectedValue);
                mn.M_ID = Convert.ToInt32(ddlMusteri.SelectedValue);
                mn.ONAY = cbOnay.Checked.ToString();
                mn.TAR = tbTarih.Text;
                mn.MSJ = tbNot.Text;
                string sonuc = String.Empty;
                if (AddEdit == 0)
                {
                    ARIZACRUD.Kaydet(mn);
                    sonuc = "Kaydetme";
                    Temizle();
                }
                else
                {
                    mn.ID = AddEdit;
                    ARIZACRUD.Guncelle(mn);
                    sonuc = "Güncelleme";
                }
                Page.ClientScript.RegisterStartupScript(this.GetType(), "bilgi", "$.jGrowl('" + sonuc + " Başarılı" + "', { header: 'Sonuç' });", true);
                ARGetir();
            }
            catch
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "bilgi", "$.jGrowl('" + "İşleminizde Hata Oluştu Lütfen Kontrol Ediniz!" + "', { header: 'Sonuç' });", true);
            }
        }

        protected void ARGetir()
        {
            Tools.rptDoldur("SELECT * FROM ARIZA", rptAriza);
            Tools.ddlDoldur("SELECT * FROM ADMIN", ddlAdmin, "K_AD", "ID");
            Tools.ddlDoldur("SELECT * FROM MUSTERI", ddlMusteri, "AD", "ID");
            if (AddEdit == 0)
            {
                ddlAdmin.Items.Insert(0, new ListItem("Lütfen Sorumlu Kişi Seçiniz", "0"));
                ddlMusteri.Items.Insert(0, new ListItem("Lütfen Arıza Sahibi Müşteriyi Seçiniz", "0"));
            }
            else
            {
                ddlAdmin.SelectedIndex = ARIZACRUD.IdyeGoreARIZAGetir(AddEdit).A_ID;
                ddlMusteri.SelectedIndex = ARIZACRUD.IdyeGoreARIZAGetir(AddEdit).M_ID;
            }
            
        }

        protected void Temizle()
        {
            cbOnay.Checked = false;
            tbNot.Text = String.Empty;
            tbTarih.Text = String.Empty;
            ddlMusteri.SelectedIndex = 0;
            ddlAdmin.SelectedIndex = 0;
        }

        protected void rptAriza_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Sil") { ARIZACRUD.Sil(Convert.ToInt32(e.CommandArgument)); Temizle(); ARGetir(); }
            if (e.CommandName == "Edit") { Response.Redirect("Ariza?id=" + e.CommandArgument); }         
        }

    }
}