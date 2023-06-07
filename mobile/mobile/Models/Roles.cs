using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace mobile.Models
{
    public class Roles
    {
        [PrimaryKey, AutoIncrement]
        public int id_r { get; set; }

        public string name_r { get; set; }
    }
}
