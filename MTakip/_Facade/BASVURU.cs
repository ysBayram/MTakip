using System;
using System.Collections.Generic;
using System.Text;
using MTakip.Entity;
using MTakip.Provider;
using System.Data;
using System.Data.SQLite;

namespace MTakip.Facade
{
    public class BASVURUCRUD
    {
        public static void Kaydet(BASVURU p)
        {
            SQLiteCommand cm = DBCon.KomutOlustur("insert into BASVURU(ID,AD,ADRES,CEP_TEL,TEL,TARIFE,A_ID,TAR,ONAY)values (@ID,@AD,@ADRES,@CEP_TEL,@TEL,@TARIFE,@A_ID,@TAR,@ONAY)");
            cm.Parameters.AddWithValue("@ID", null);
            cm.Parameters.AddWithValue("@AD", p.AD);
            cm.Parameters.AddWithValue("@ADRES", p.ADRES);
            cm.Parameters.AddWithValue("@CEP_TEL", p.CEP_TEL);
            cm.Parameters.AddWithValue("@TEL", p.TEL);
            cm.Parameters.AddWithValue("@TARIFE", p.TARIFE);
            cm.Parameters.AddWithValue("@A_ID", p.A_ID);
            cm.Parameters.AddWithValue("@TAR", p.TAR);
            cm.Parameters.AddWithValue("@ONAY", p.ONAY);
            cm.Connection.Open();
            cm.ExecuteNonQuery();
            cm.Connection.Close();
        }


        public static void Guncelle(BASVURU p)
        {
            SQLiteCommand cm = DBCon.KomutOlustur("update BASVURU set AD=@AD,ADRES=@ADRES,CEP_TEL=@CEP_TEL,TEL=@TEL,TARIFE=@TARIFE,A_ID=@A_ID,TAR=@TAR,ONAY=@ONAY where ID=@ID");
            cm.Parameters.AddWithValue("@AD", p.AD);
            cm.Parameters.AddWithValue("@ADRES", p.ADRES);
            cm.Parameters.AddWithValue("@CEP_TEL", p.CEP_TEL);
            cm.Parameters.AddWithValue("@TEL", p.TEL);
            cm.Parameters.AddWithValue("@TARIFE", p.TARIFE);
            cm.Parameters.AddWithValue("@A_ID", p.A_ID);
            cm.Parameters.AddWithValue("@TAR", p.TAR);
            cm.Parameters.AddWithValue("@ONAY", p.ONAY);
            cm.Parameters.AddWithValue("@ID", p.ID);
            cm.Connection.Open();
            cm.ExecuteNonQuery();
            cm.Connection.Close();
        }


        public static void Sil(int ID)
        {
            SQLiteCommand cm = DBCon.KomutOlustur("delete from BASVURU where ID=@ID");
            cm.Parameters.AddWithValue("@ID", ID);
            cm.Connection.Open();
            cm.ExecuteNonQuery();
            cm.Connection.Close();
        }


        public static BASVURU IdyeGoreBASVURUGetir(int ID)
        {
            SQLiteDataAdapter da = new SQLiteDataAdapter("select * from BASVURU where ID=@ID", DBCon.BaglantiYap());
            da.SelectCommand.Parameters.AddWithValue("@ID", ID);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count != 0)
            {
                BASVURU b = new BASVURU();
                b.ID = Convert.ToInt32(dt.Rows[0]["ID"]);
                b.AD = Convert.ToString(dt.Rows[0]["AD"]);
                b.ADRES = Convert.ToString(dt.Rows[0]["ADRES"]);
                b.CEP_TEL = Convert.ToString(dt.Rows[0]["CEP_TEL"]);
                b.TEL = Convert.ToString(dt.Rows[0]["TEL"]);
                b.TARIFE = Convert.ToString(dt.Rows[0]["TARIFE"]);
                b.A_ID = Convert.ToInt32(dt.Rows[0]["A_ID"]);
                b.TAR = Convert.ToString(dt.Rows[0]["TAR"]);
                b.ONAY = Convert.ToString(dt.Rows[0]["ONAY"]);
                return b;
            }
            else { return null; }
        }


        public static DataTable TumunuGetirDataTable()
        {
            SQLiteDataAdapter da = new SQLiteDataAdapter("select * from BASVURU", DBCon.BaglantiYap());
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count != 0)
            {
                return dt;
            }
            else { return null; }
        }


        public static DataTable KayitKumesiGetir(string sql)
        {
            SQLiteDataAdapter da = new SQLiteDataAdapter(sql, DBCon.BaglantiYap());
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count != 0)
            {
                return dt;
            }
            else { return null; }
        }


        public static object TekDegerGetir(string sql)
        {
            SQLiteDataAdapter da = new SQLiteDataAdapter(sql, DBCon.BaglantiYap());
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count != 0)
            {
                return (object)dt.Rows[0][0];
            }
            else { return null; }
        }

    }
}
