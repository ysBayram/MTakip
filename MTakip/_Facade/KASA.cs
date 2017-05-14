using System;
using System.Collections.Generic;
using System.Text;
using MTakip.Entity;
using MTakip.Provider;
using System.Data;
using System.Data.SQLite;

namespace MTakip.Facade
{
    public class KASACRUD
    {
        public static void Kaydet(KASA p)
        {
            SQLiteCommand cm = DBCon.KomutOlustur("insert into KASA(ID,TUR,MIKTAR,ACIKLA,TAR,A_ID)values (@ID,@TUR,@MIKTAR,@ACIKLA,@TAR,@A_ID)");
            cm.Parameters.AddWithValue("@ID", null);
            cm.Parameters.AddWithValue("@TUR", p.TUR);
            cm.Parameters.AddWithValue("@MIKTAR", p.MIKTAR);
            cm.Parameters.AddWithValue("@ACIKLA", p.ACIKLA);
            cm.Parameters.AddWithValue("@TAR", p.TAR);
            cm.Parameters.AddWithValue("@A_ID", p.A_ID);
            cm.Connection.Open();
            cm.ExecuteNonQuery();
            cm.Connection.Close();
        }


        public static void Guncelle(KASA p)
        {
            SQLiteCommand cm = DBCon.KomutOlustur("update KASA set TUR=@TUR,MIKTAR=@MIKTAR,ACIKLA=@ACIKLA,TAR=@TAR,A_ID=@A_ID where ID=@ID");
            cm.Parameters.AddWithValue("@TUR", p.TUR);
            cm.Parameters.AddWithValue("@MIKTAR", p.MIKTAR);
            cm.Parameters.AddWithValue("@ACIKLA", p.ACIKLA);
            cm.Parameters.AddWithValue("@TAR", p.TAR);
            cm.Parameters.AddWithValue("@A_ID", p.A_ID);
            cm.Parameters.AddWithValue("@ID", p.ID);
            cm.Connection.Open();
            cm.ExecuteNonQuery();
            cm.Connection.Close();
        }


        public static void Sil(int ID)
        {
            SQLiteCommand cm = DBCon.KomutOlustur("delete from KASA where ID=@ID");
            cm.Parameters.AddWithValue("@ID", ID);
            cm.Connection.Open();
            cm.ExecuteNonQuery();
            cm.Connection.Close();
        }


        public static KASA IdyeGoreKASAGetir(int ID)
        {
            SQLiteDataAdapter da = new SQLiteDataAdapter("select * from KASA where ID=@ID", DBCon.BaglantiYap());
            da.SelectCommand.Parameters.AddWithValue("@ID", ID);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count != 0)
            {
                KASA k = new KASA();
                k.ID = Convert.ToInt32(dt.Rows[0]["ID"]);
                k.TUR = Convert.ToString(dt.Rows[0]["TUR"]);
                k.MIKTAR = Convert.ToInt32(dt.Rows[0]["MIKTAR"]);
                k.ACIKLA = Convert.ToString(dt.Rows[0]["ACIKLA"]);
                k.TAR = Convert.ToString(dt.Rows[0]["TAR"]);
                k.A_ID = Convert.ToInt32(dt.Rows[0]["A_ID"]);
                return k;
            }
            else { return null; }
        }


        public static DataTable TumunuGetirDataTable()
        {
            SQLiteDataAdapter da = new SQLiteDataAdapter("select * from KASA", DBCon.BaglantiYap());
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

        public static int KasaSay(string sql)
        { 
            SQLiteDataAdapter da = new SQLiteDataAdapter(sql,DBCon.BaglantiYap());
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count != 0)
            {
                int deger = 0;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    deger += Convert.ToInt32(dt.Rows[i][0]);
                }
                return deger;
            }
            else { return 0; }
        }

    }
}
