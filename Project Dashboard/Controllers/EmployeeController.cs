using Project_Dashboard.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Web.Mvc;

namespace Project_Dashboard.Controllers
{
    public class EmployeeController : Controller
    {
        ProjectDB db = new ProjectDB();
        // GET: Employee
        public ActionResult Index()
        {
            List<Employee> e = db.Employees.ToList();
            return View(e);
        }
        public ActionResult addEmployee()
        {
            List<Department> departments = db.Departments.ToList();
            ViewBag.depts = departments;
            return View();
            
        }
        [HttpPost]
        public ActionResult addEmployee(Employee e)
        {
            db.Employees.Add(e);
            db.SaveChanges();
            return RedirectToAction("Index");

        }
        public ActionResult editEmployee(int id)
        {
            List<Department> departments = db.Departments.ToList();
            ViewBag.depts = departments;
            Employee e = db.Employees.Where(n => n.empId == id).FirstOrDefault();
            return View(e);
        }
        [HttpPost]
        public ActionResult editEmployee(Employee d)
        {
            Employee e = db.Employees.Where(n => n.empId == d.empId).FirstOrDefault();
            //db.Entry(d).State = EntityState.Modified;
            //student st = db.Students.Where(n => n.id == s.id).FirstOrDefault();
            //st.name = s.name;
            //st.age = s.age;
            //st.address = s.address;
            //st.deptid = s.deptid;
            //db.SaveChanges();

            e.name = d.name;
            e.salary = d.salary;
            e.hiredate = d.hiredate;
            e.address = d.address;
            e.deptId = d.deptId;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult deleteEmployee(int id)
        {
            Employee em = db.Employees.Where(n => n.empId == id).FirstOrDefault();
            db.Entry(em).State = EntityState.Deleted;
            db.SaveChanges();
            return RedirectToAction("index");            
        }
    }
}