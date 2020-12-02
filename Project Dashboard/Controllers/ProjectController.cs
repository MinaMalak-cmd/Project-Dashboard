using Project_Dashboard.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
namespace Project_Dashboard.Controllers
{
    public class ProjectController : Controller
    {
        ProjectDB db = new ProjectDB();        
        // GET: Project        
        public ActionResult Index()
        {
            List<Project> p = db.Projects.ToList();
            return View(p);
        }
        public ActionResult addProject()
        {
            List<Department> departments = db.Departments.ToList();
            ViewBag.depts = departments;
            return View();
        }
        [HttpPost]
        public ActionResult addProject(Project p)
        {
            db.Projects.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult editProject(int id)
        {
            List<Department> departments = db.Departments.ToList();
            ViewBag.depts = departments;
            Project p = db.Projects.Where(n => n.id == id).FirstOrDefault();
            return View(p);
        }
        [HttpPost]
        public ActionResult editProject(Project c)
        {
            db.Entry(c).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult deleteProject(int id)
        {
            Project s = db.Projects.Where(n => n.id == id).FirstOrDefault();
            db.Entry(s).State = EntityState.Deleted;
            //db.Projects.Remove(s);
            db.SaveChanges();
            return RedirectToAction("index");            
        }
    }
}