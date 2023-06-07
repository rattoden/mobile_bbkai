using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace mobile.Models
{
    public class Vidi
    {
        [PrimaryKey, AutoIncrement]
        public int id_v { get; set; }

        public string name_v { get; set; }
    }
}
