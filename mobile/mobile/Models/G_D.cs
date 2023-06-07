using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace mobile.Models
{
    public class G_D
    {
        [PrimaryKey, AutoIncrement]
        public int id_g_d { get; set; }

        public int id_g { get; set; }

        public int id_d { get; set; }

        [Ignore]
        public string name_d { get; set; }
        [Ignore]
        public string num_g { get; set; }
    }
}
