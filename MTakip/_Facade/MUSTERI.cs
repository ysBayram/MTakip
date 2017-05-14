using System;
using System.Collections.Generic;
using System.Text;
using MTakip.Entity;
using MTakip.Provider;
using System.Data;
using System.Data.SQLite;

namespace MTakip.Facade
{
    public class MUSTERICRUD
    {
        public static void Kaydet(MUSTERI p)
        {
            SQLiteCommand cm = DBCon.KomutOlustur("insert into MUSTERI(ID,K_AD,AD,ADRES,CEP_TEL,TEL)values (@ID,@K_AD,@AD,@ADRES,@CEP_TEL,@TEL)");
            cm.Parameters.AddWithValue("@ID", null);
            cm.Parameters.AddWithValue("@K_AD", p.K_AD);
            cm.Parameters.AddWithValue("@AD", p.AD);
            cm.Parameters.AddWithValue("@ADRES", p.ADRES);
            cm.Parameters.AddWithValue("@CEP_TEL", p.CEP_TEL);
            cm.Parameters.AddWithValue("@TEL", p.TEL);
            cm.Connection.Open();
            cm.ExecuteNonQuery();
            cm.Connection.Close();
        }


        public static void Guncelle(MUSTERI p)
        {
            SQLiteCommand cm = DBCon.KomutOlustur("update MUSTERI set K_AD=@K_AD,AD=@AD,ADRES=@ADRES,CEP_TEL=@CEP_TEL,TEL=@TEL where ID=@ID");
            cm.Parameters.AddWithValue("@K_AD", p.K_AD);
            cm.Parameters.AddWithValue("@AD", p.AD);
            cm.Parameters.AddWithValue("@ADRES", p.ADRES);
            cm.Parameters.AddWithValue("@CEP_TEL", p.CEP_TEL);
            cm.Parameters.AddWithValue("@TEL", p.TEL);
            cm.Parameters.AddWithValue("@ID", p.ID);
            cm.Connection.Open();
            cm.ExecuteNonQuery();
            cm.Connection.Close();
        }


        public static void Sil(int ID)
        {
            SQLiteCommand cm = DBCon.KomutOlustur("delete from MUSTERI where ID=@ID");
            cm.Parameters.AddWithValue("@ID", ID);
            cm.Connection.Open();
            cm.ExecuteNonQuery();
            cm.Connection.Close();
        }


        public static MUSTERI IdyeGoreMUSTERIGetir(int ID)
        {
            SQLiteDataAdapter da = new SQLiteDataAdapter("select * from MUSTERI where ID=@ID", DBCon.BaglantiYap());
            da.SelectCommand.Parameters.AddWithValue("@ID", ID);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count != 0)
            {
                MUSTERI m = new MUSTERI();
                m.ID = Convert.ToInt32(dt.Rows[0]["ID"]);
                m.K_AD = Convert.ToString(dt.Rows[0]["K_AD"]);
                m.AD = Convert.ToString(dt.Rows[0]["AD"]);
                m.ADRES = Convert.ToString(dt.Rows[0]["ADRES"]);
                m.CEP_TEL = Convert.ToString(dt.Rows[0]["CEP_TEL"]);
                m.TEL = Convert.ToString(dt.Rows[0]["TEL"]);
                return m;
            }
            else { return null; }
        }


        public static DataTable TumunuGetirDataTable()
        {
            SQLiteDataAdapter da = new SQLiteDataAdapter("select * from MUSTERI", DBCon.BaglantiYap());
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
