using System;
using System.Collections.Generic;
using System.Text;

namespace MTakip.Entity
{
    public class BASVURU
    {
        public Int32 ID { get; set; }
        public String AD { get; set; }
        public String ADRES { get; set; }
        public String CEP_TEL { get; set; }
        public String TEL { get; set; }
        public String TARIFE { get; set; }
        public Int32 A_ID { get; set; }
        public String TAR { get; set; }
        public String ONAY { get; set; }

        public static string[] CName = { "AD", "ADRES", "CEP_TEL", "TEL", "TARIFE", "A_ID", "TAR", "ONAY" };
    }
}
