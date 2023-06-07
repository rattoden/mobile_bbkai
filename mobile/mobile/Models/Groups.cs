using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace mobile.Models
{
    public class Groups
    {
        [PrimaryKey, AutoIncrement]
        public int id_g { get; set; }

        public string num_g { get; set; }
    }
}
