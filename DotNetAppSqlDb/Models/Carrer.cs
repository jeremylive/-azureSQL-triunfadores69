using System;
using System.ComponentModel.DataAnnotations;

namespace DotNetAppSqlDb.Models
{
    public class Carrer
    {
        public int id { get; set; }
        public string name { get; set; }
        public string in_charge { get; set; }
        public string location { get; set; }
    }
}