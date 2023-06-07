using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace mobile.Models
{
    public class Chet
    {
        [PrimaryKey, AutoIncrement]
        public int id_c { get; set; }

        public string name_c { get; set; }
    }
}
