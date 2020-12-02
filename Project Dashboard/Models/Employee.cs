using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Project_Dashboard.Models
{
    public class Employee
    {
        [Key]
        public int empId { get; set; }
        public string name { get; set; }
        public DateTime hiredate { get; set; }
        public string address { get; set; }
        public int salary { get; set; }
        [ForeignKey("department")]
        public int deptId { get; set; }
        public virtual Department department { get; set; }
        
    }
}