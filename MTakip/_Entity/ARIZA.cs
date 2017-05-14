using System;
using System.Collections.Generic;
using System.Text;

namespace MTakip.Entity
{
    public class ARIZA
    {
        public Int32 ID { get; set; }
        public Int32 M_ID { get; set; }
        public Int32 A_ID { get; set; }
        public String TAR { get; set; }
        public String ONAY { get; set; }
        public String MSJ { get; set; }

        public static string[] CName = { "M_ID", "A_ID", "TAR", "ONAY", "MSJ" };
    }
}
