using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace mobile.Models
{
    public class U_D
    {
        [PrimaryKey, AutoIncrement]
        public int id_u_d { get; set; }

        public int id_u { get; set; }

        public int id_d { get; set; }

        [Ignore]
        public string name_d { get; set; }
        [Ignore]
        public string fio_u { get; set; }
    }
}
