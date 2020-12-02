using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Project_Dashboard.Models
{
    public class Project
    {
        [Key]
        public int id { get; set; }
        [Required]
        public string name { get; set; }
        [MaxLength(20)]
        public string location { get; set; }
        public string description { get; set; }
        [ForeignKey("department")]
        public int deptId { get; set; }
        //id ,name,location,description,deptid
        public virtual Department department { get; set; }
    }
}