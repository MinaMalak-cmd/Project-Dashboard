using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace Project_Dashboard.Models
{
    public class Department
    {
        [Key]
        public int deptId { get; set; }
        [Required]
        public string name { get; set; }
        public string location { get; set; }
        public Department()
        {
            Employees = new List<Employee>();
            Projects = new List<Project>();
        }
        public virtual List<Employee> Employees { get; set; }
        public virtual List<Project> Projects { get; set; }
    }
}