using System;
using System.ComponentModel.DataAnnotations;

namespace DotNetAppSqlDb.Models
{
    public class Student
    {
        public int id { get; set; }
        public string name { get; set; }
        public string carnet { get; set; }
        public string img { get; set; }
        public string cv { get; set; }
        public string id_carrer { get; set; }


        [Display(Name = "Created Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime in_date { get; set; }
    }
}