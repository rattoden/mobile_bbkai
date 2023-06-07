using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace mobile.Models
{
    public class Times
    {
        [PrimaryKey, AutoIncrement]
        public int id_t { get; set; }

        public string name_t { get; set; }
    }
}
