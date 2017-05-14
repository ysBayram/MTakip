using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Drawing.Imaging;
using System.Net.Mail;
using System.Text.RegularExpressions;
using MTakip.Facade;
using MTakip.Entity;

namespace MTakip.Facade
{
    public class Tools
    {
        public static string change(string dosyaAdi)
        {
            //Bu metodumuzlada Türkçe karakterleri temizleyip ingilizceye uyarlıyoruz
            string Temp = dosyaAdi.ToLower();

            Temp = Temp.Replace("-", "").ToString();
            Temp = Temp.Replace(" ", "-").ToString();
            Temp = Temp.Replace("ç", "c").ToString(); Temp = Temp.Replace("ğ", "g").ToString();
            Temp = Temp.Replace("ı", "i").ToString(); Temp = Temp.Replace("ö", "o").ToString();
            Temp = Temp.Replace("ş", "s").ToString(); Temp = Temp.Replace("ü", "u").ToString();
            Temp = Temp.Replace("\"", "").ToString(); Temp = Temp.Replace("/", "").ToString();
            Temp = Temp.Replace("(", "").ToString(); Temp = Temp.Replace(")", "").ToString();
            Temp = Temp.Replace("{", "").ToString(); Temp = Temp.Replace("}", "").ToString();
            Temp = Temp.Replace("%", "").ToString(); Temp = Temp.Replace("&", "").ToString();
            Temp = Temp.Replace("+", "").ToString(); Temp = Temp.Replace(",", "").ToString();
            Temp = Temp.Replace("?", "").ToString(); Temp = Temp.Replace(".", "_").ToString();
            Temp = Temp.Replace("ı", "i").ToString();
            Temp = Temp.Replace("!", "").ToString();
            Temp = Temp.Replace("#", "").ToString();
            Temp = Temp.Replace("$", "").ToString();
            Temp = Temp.Replace("Ğ", "G").ToString();
            Temp = Temp.Replace("Ç", "C").ToString();
            Temp = Temp.Replace("İ", "I").ToString();
            Temp = Temp.Replace("Ş", "S").ToString();
            Temp = Temp.Replace("Ü", "U").ToString();
            Temp = Temp.Replace("Ö", "O").ToString();
            Temp = Temp.Replace(":", "-").ToString();
            return Temp;
        }

        public static string ControlLength(string word, int length)
        {
            if (word.Length > length)
            {
                return word.Substring(0, length - 3);
            }
            else
            {
                return word;
            }
        }

        public static void MessageBox(string msg, Control cntrl, Type type)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("alert('");
            sb.Append(msg.Replace("\n", "\\n").Replace("\r", "").Replace("'", "\\'"));
            sb.Append("');");
            ScriptManager.RegisterStartupScript(cntrl, type, "showalert", sb.ToString(), true);
        }

        public static void rptDoldur(string sql, Repeater rpt)
        {
            DataTable dt = ADMINCRUD.KayitKumesiGetir(sql);
            if (dt != null) { rpt.DataSource = dt.DefaultView; rpt.DataBind(); }
            else { rpt.DataSource = null; rpt.DataBind(); }
        }

        public static void gwDoldur(string sql, GridView gv)
        {
            DataTable dt = ADMINCRUD.KayitKumesiGetir(sql);
            if (dt != null) { gv.DataSource = dt.DefaultView; gv.DataBind(); }
            else { gv.DataSource = null; gv.DataBind(); }
        }

        public static void ddlDoldur(string sql, DropDownList ddl, string displayMember, string valueMember)
        {
            DataTable dt = ADMINCRUD.KayitKumesiGetir(sql);
            if (dt != null) { ddl.DataSource = dt.DefaultView; ddl.DataTextField = displayMember; ddl.DataValueField = valueMember; ddl.DataBind(); }
            else { ddl.DataSource = null; ddl.DataBind(); }
        }

        public static string GaleriUpload(FileUpload fu, string konum)
        {
            string dosya = string.Empty;
            if (fu.HasFile)
            {
                string ext = System.IO.Path.GetExtension(fu.FileName).ToLower();
                if (ext == ".jpg" || ext == ".gif" || ext == ".png")
                {
                    string rs = Tools.change(System.IO.Path.GetFileNameWithoutExtension(fu.FileName) + DateTime.Now.ToString()) + ext;
                    fu.SaveAs(HttpContext.Current.Server.MapPath("../images/WebPortal/res/" + konum + "\\" + rs));
                    dosya = "../images/WebPortal/res/" + konum + "/" + rs;
                }

                if (ext == ".avi" || ext == ".mpg" || ext == ".wmv" || ext == ".mp4")
                {
                    string rs = Tools.change(System.IO.Path.GetFileNameWithoutExtension(fu.FileName) + DateTime.Now.ToString()) + ext;
                    fu.SaveAs(HttpContext.Current.Server.MapPath("../images/WebPortal/vid/" + konum + "\\" + rs));
                    dosya = "../images/WebPortal/vid/" + konum + "/" + rs;
                }
            }
            return dosya;
        }
        
        public static string fotoUpload(FileUpload fu, string konum, int boyutSiniri)
        {
            string foto = "";
            if (fu.HasFile)
            {
                string ext = System.IO.Path.GetExtension(fu.FileName).ToLower();
                if (ext == ".jpg" || ext == ".gif" || ext == ".png")
                {
                    string rs = Tools.change(System.IO.Path.GetFileNameWithoutExtension(fu.FileName) + DateTime.Now.ToString()) + ext;
                    fu.SaveAs(HttpContext.Current.Server.MapPath("../images/WebPortal/res/" + konum + "\\" + rs));
                    Bitmap OriginalBMb = new Bitmap(HttpContext.Current.Server.MapPath("../images/WebPortal/res/" + konum + "\\" + rs));
                    double ResimYukseklik = OriginalBMb.Height;// yüksekliği belirtiyoruz
                    double ResimUzunluk = OriginalBMb.Width;// genişliği belirtiyoruz
                    int sabit = boyutSiniri;
                    double oran = 0;
                    if (ResimUzunluk > ResimYukseklik && ResimUzunluk > sabit)
                    {
                        oran = ResimUzunluk / ResimYukseklik;
                        ResimUzunluk = sabit;
                        ResimYukseklik = sabit / oran;
                    }
                    else if (ResimYukseklik > ResimUzunluk && ResimYukseklik > sabit)
                    {
                        oran = ResimYukseklik / ResimUzunluk;
                        ResimYukseklik = sabit;
                        ResimUzunluk = sabit / oran;
                    }
                    Size newSizeb = new Size(Convert.ToInt32(ResimUzunluk), Convert.ToInt32(ResimYukseklik));
                    Bitmap Resizebmb = new Bitmap(OriginalBMb, newSizeb);
                    Graphics grPhoto = Graphics.FromImage(Resizebmb);
                    grPhoto.InterpolationMode = InterpolationMode.High; // resmin kalitesini ayarlıyoruz. Burada InterpolationMode özelliklerini bulabilirsini
                    Resizebmb.Save(HttpContext.Current.Server.MapPath("../images/WebPortal/" + konum + "\\" + rs), ImageFormat.Jpeg);
                    OriginalBMb.Dispose();
                    File.Delete(HttpContext.Current.Server.MapPath("../images/WebPortal/res/" + konum + "\\" + rs));//eski oluşturduğumuz resimi siliyoruz
                    foto = "../images/WebPortal/" + konum + "/" + rs;
                }
            }
            return foto;
        }

        public static void Dosya_Sil(string konum)
        {
            if (!string.IsNullOrEmpty(konum))
            {
                File.Delete(HttpContext.Current.Server.MapPath(konum));
            }
        }

        public static string Dosya_Upload(FileUpload fu)
        {
            string dosya = string.Empty;
            if (fu.HasFile)
            {
                string ext = System.IO.Path.GetExtension(fu.FileName).ToLower();
                string rs = Tools.change(System.IO.Path.GetFileNameWithoutExtension(fu.FileName) + DateTime.Now.ToString()) + ext;
                fu.SaveAs(HttpContext.Current.Server.MapPath("../images/WebPortal/dosya/" + rs));
                dosya = "../images/WebPortal/dosya/" + rs;
            }
            return dosya;
        }

        public static void sendMail(string name, string email, string subject, string message)
        {
            try
            {
                MailMessage mail = new MailMessage();
                mail.To.Add(ADMINCRUD.IdyeGoreADMINGetir(1).MAIL);
                mail.From = new MailAddress(email, name);
                mail.Subject = subject;
                mail.Body = message;
                SmtpClient smtp = new SmtpClient();
                smtp.Port = 587;
                smtp.Host = "smtp.gmail.com";
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.EnableSsl = true;
                smtp.UseDefaultCredentials = false;
                System.Net.NetworkCredential yetki = new System.Net.NetworkCredential("robotpoyraz@gmail.com", "00poyraz99");
                smtp.Credentials = yetki;
                smtp.Send(mail);
                HttpContext.Current.Response.Write("<script>alert('Mailiniz başarılı bir şekilde gönderilmiştir!')</script>");
            }
            catch (Exception e)
            {
                HttpContext.Current.Response.Write("<script>alert('" + e.Message + "')</script>");
            }

        }


    }
}