using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace mobile.Models
{
    public class Discs
    {
        [PrimaryKey, AutoIncrement]
        public int id_d { get; set; }

        public string name_d { get; set; }
    }
}
