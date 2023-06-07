using SQLite;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace mobile.Models
{
#nullable enable
    public class Raspis
    {
        [PrimaryKey, AutoIncrement]
        public int id_r { get; set; }

        public int id_g { get; set; }

        public int id_c { get; set; }

        public int id_n { get; set; }

        public int id_t { get; set; }

        public string? date_r { get; set; }

        public int id_d { get; set; }

        public int id_v { get; set; }

        public string? aud_r { get; set; }

        public int zd_r { get; set; }

        public int? id_u { get; set; }

        [Ignore]
        public string name_t { get; set; }

        [Ignore]
        public string name_d { get; set; }

        [Ignore]
        public string name_v { get; set; }

        [Ignore]
        public string fio_u { get; set; }
    }
}
