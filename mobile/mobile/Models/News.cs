using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace mobile.Models
{
    public class News
    {
        [PrimaryKey, AutoIncrement]
        public int id { get; set; }

        public string img { get; set; }

        public string zag { get; set; }

        public string txt { get; set; }

        public string date_n { get; set; }

        public string txt1 { get; set; }
    }
}
