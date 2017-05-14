using System;
using System.Collections.Generic;
using System.Text;
using MTakip.Entity;
using MTakip.Provider;
using System.Data;
using System.Data.SQLite;

namespace MTakip.Facade
{
    public class ARIZACRUD
    {
        public static void Kaydet(ARIZA p)
        {
            SQLiteCommand cm = DBCon.KomutOlustur("insert into ARIZA(ID,M_ID,A_ID,TAR,ONAY,MSJ)values (@ID,@M_ID,@A_ID,@TAR,@ONAY,@MSJ)");
            cm.Parameters.AddWithValue("@ID", null);
            cm.Parameters.AddWithValue("@M_ID", p.M_ID);
            cm.Parameters.AddWithValue("@A_ID", p.A_ID);
            cm.Parameters.AddWithValue("@TAR", p.TAR);
            cm.Parameters.AddWithValue("@ONAY", p.ONAY);
            cm.Parameters.AddWithValue("@MSJ", p.MSJ);
            cm.Connection.Open();
            cm.ExecuteNonQuery();
            cm.Connection.Close();
        }


        public static void Guncelle(ARIZA p)
        {
            SQLiteCommand cm = DBCon.KomutOlustur("update ARIZA set M_ID=@M_ID,A_ID=@A_ID,TAR=@TAR,ONAY=@ONAY,MSJ=@MSJ where ID=@ID");
            cm.Parameters.AddWithValue("@M_ID", p.M_ID);
            cm.Parameters.AddWithValue("@A_ID", p.A_ID);
            cm.Parameters.AddWithValue("@TAR", p.TAR);
            cm.Parameters.AddWithValue("@ONAY", p.ONAY);
            cm.Parameters.AddWithValue("@MSJ", p.MSJ);
            cm.Parameters.AddWithValue("@ID", p.ID);
            cm.Connection.Open();
            cm.ExecuteNonQuery();
            cm.Connection.Close();
        }


        public static void Sil(int ID)
        {
            SQLiteCommand cm = DBCon.KomutOlustur("delete from ARIZA where ID=@ID");
            cm.Parameters.AddWithValue("@ID", ID);
            cm.Connection.Open();
            cm.ExecuteNonQuery();
            cm.Connection.Close();
        }


        public static ARIZA IdyeGoreARIZAGetir(int ID)
        {
            SQLiteDataAdapter da = new SQLiteDataAdapter("select * from ARIZA where ID=@ID", DBCon.BaglantiYap());
            da.SelectCommand.Parameters.AddWithValue("@ID", ID);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count != 0)
            {
                ARIZA a = new ARIZA();
                a.ID = Convert.ToInt32(dt.Rows[0]["ID"]);
                a.M_ID = Convert.ToInt32(dt.Rows[0]["M_ID"]);
                a.A_ID = Convert.ToInt32(dt.Rows[0]["A_ID"]);
                a.TAR = Convert.ToString(dt.Rows[0]["TAR"]);
                a.ONAY = Convert.ToString(dt.Rows[0]["ONAY"]);
                a.MSJ = Convert.ToString(dt.Rows[0]["MSJ"]);
                return a;
            }
            else { return null; }
        }


        public static DataTable TumunuGetirDataTable()
        {
            SQLiteDataAdapter da = new SQLiteDataAdapter("select * from ARIZA", DBCon.BaglantiYap());
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