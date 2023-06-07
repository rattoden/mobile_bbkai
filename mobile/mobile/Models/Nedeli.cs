using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace mobile.Models
{
    public class Nedeli
    {
        [PrimaryKey, AutoIncrement]
        public int id_n { get; set; }

        public string name_n { get; set; }
    }
}
