using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAdminsUi.DatabaseOperations;
using WebAdminsUi.Models;

namespace WebAdminsUi.Controllers
{
    [Authorize(Roles = "Manager, Analyst, Architect, Programmer, Tester")]
    public class DashboardController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        DatabaseOps dbOps = new DatabaseOps();


        // GET: Dashboard
        //public ActionResult Index()
        //{
        //    return View();
        //}
        

        [Authorize(Roles ="Manager")]
        public ActionResult ManagersDashboard()
        {
            var pendingUsers = dbOps.GetPendingUsers();

            return View(pendingUsers);
        }
        [Authorize(Roles = "Manager")]
        public ActionResult ApproveNewUser(string id)
        {
            using (db)
            {
                var user = db.Users.Where(u => u.Id == id).SingleOrDefault();
                user.Status = UserStatus.Active;

                db.Users.Attach(user);
                db.Entry(user).Property(u => u.Status).IsModified = true;
                db.SaveChanges();

                return RedirectToAction("ManagersDashboard");
            }
        }


        //[Authorize(Roles = "Analyst")]
        //public ActionResult AnalystsDashboard()
        //{
            
        //}

        //[Authorize(Roles = "Architect")]
        //public ActionResult ArchitectsDashboard()
        //{
        //    return View("Index", dbOps.ArchitectsDocs());
        //}

        //[Authorize(Roles = "Programmer")]
        //public ActionResult ProgrammersDashboard()
        //{
        //    return View("Index", dbOps.ProgrammersDocs());
        //}

        //[Authorize(Roles = "Tester")]
        //public ActionResult TestersDashboard()
        //{
        //    return View("Index", dbOps.TestersDocs());
        //}
    }
}