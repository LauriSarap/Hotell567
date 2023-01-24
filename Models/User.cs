using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotell567.Models
{
    [Table("users")]
    public class User
    {
        [AutoIncrement, PrimaryKey]
        public int id { get; set; }
        public int type { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string email { get; set; }

        public int phone_number { get; set; }
        public string date_of_birth { get; set; }
        public string address_line_1 { get; set; }
        public string address_line_2 { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public int postal_code { get; set; }
        public string country { get; set; }
    }
}
