using SQLite;
using SQLiteNetExtensions.Attributes;
using System.Data;

namespace mobile.Models
{
    public class Users
    {
        [PrimaryKey, AutoIncrement]
        public int id_u { get; set; }

        public string login_u { get; set; }

        public string pass_u { get; set; }

        public int role_u { get; set; }

        public string fio_u { get; set; }

        public int? group_s { get; set; }

        [Ignore]
        public string name_r { get; set; }
        [Ignore]
        public string? num_g { get; set; }
    }
}
