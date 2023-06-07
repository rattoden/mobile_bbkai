using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace mobile.Models
{
    public class Doki
    {
        [PrimaryKey, AutoIncrement]
        public int id_d { get; set; }

        public int id_u { get; set; }

        public int id_v { get; set; }

        public string name_d { get; set; }

        public string ssilka_d { get; set; }

        public int flag_d { get; set; }

        public int id_di { get; set; }

        [Ignore]
        public string name_di { get; set;}
        [Ignore]
        public string name_v { get; set; }
    }
}
