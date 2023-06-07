using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace mobile.Models
{
    public class Otcheti
    {
        [PrimaryKey, AutoIncrement]
        public int id_o { get; set; }

        public int id_d { get; set; }

        public int id_u { get; set; }

        public string ssilka { get; set; }

        public string date_o { get; set; }
        
        [Ignore]
        public int id_di { get; set;}

        [Ignore]
        public int id_v { get; set;}

        [Ignore]
        public string fio_u { get; set; }
    }
}
