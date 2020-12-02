using Project_Dashboard.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project_Dashboard.Controllers
{
    public class HomeController : Controller
    {
        ProjectDB db = new ProjectDB();
        // GET: Home
        public ActionResult Index()
        {
            List<Department> departments = db.Departments.ToList();
            ViewBag.depts = departments;
            return View();
        }

    }
}