using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAdminsUi.DatabaseOperations;
using WebAdminsUi.Models;

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
            var dbOps = new DatabaseOps();
            var pendingUsers = dbOps.GetPendingUsers();

            return View(pendingUsers);
        }

        public ActionResult ApproveNewUser(string id)
        {
            using (var db = new ApplicationDbContext())
            {
                var user = db.Users.Where(u => u.Id == id).SingleOrDefault();
                user.Status = UserStatus.Active;

                db.Users.Attach(user);
                db.Entry(user).Property(u => u.Status).IsModified = true;
                db.SaveChanges();

                return RedirectToAction("ManagersDashboard");
            }
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