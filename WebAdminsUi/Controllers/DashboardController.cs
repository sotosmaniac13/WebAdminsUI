using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebAdminsUi.Controllers
{
    public class DashboardController : Controller
    {
        // GET: Dashboard
        public ActionResult Index()
        {
            return View();
        }
        
        [Authorize(Roles ="Manager")]
        public ActionResult ManagersDashboard()
        {
            return View();
        }

        [Authorize(Roles = "Analyst")]
        public ActionResult AnalystsDashboard()
        {
            return View();
        }

        [Authorize(Roles = "Architect")]
        public ActionResult ArchitectsDashboard()
        {
            return View();
        }

        [Authorize(Roles = "Programmer")]
        public ActionResult ProgrammersDashboard()
        {
            return View();
        }

        [Authorize(Roles = "Tester")]
        public ActionResult TestersDashboard()
        {
            return View();
        }
    }
}