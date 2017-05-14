using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SQLite;

namespace MTakip.Provider
{
    public class DBCon
    {
        public static SQLiteConnection BaglantiYap()
        {
            return new SQLiteConnection(@"Data Source=|DataDirectory|\MtakipDB.db");
        }
        public static SQLiteCommand KomutOlustur(string cmd)
        {
            return string.IsNullOrEmpty(cmd) ? null : new SQLiteCommand(cmd, BaglantiYap());
        }
    }
}
