using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAdminsUi.Models;

namespace WebAdminsUi.DatabaseOperations
{
    public class DatabaseOps
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        //This method is used during Logging In to check if a new user has been approved by a Manager
        public bool CheckUserStatusIfActive(LoginViewModel model)
        {
            using (db)
            {
                var userStatus = db.Users.First(u => u.UserName == model.Username).Status;
                
                if (userStatus == UserStatus.Active)
                    return true;
                else
                    return false;
            }
        }


        //This method will return a list of users waiting to be approved to the Manager
        public List<ApplicationUser> GetPendingUsers()
        {
            var pendingUsers = new List<ApplicationUser>();

            using (db)
            {
                var users = db.Users.Where(u => u.Status == UserStatus.Pending);

                foreach (var user in users)
                {
                    pendingUsers.Add(user);
                }
            }
            return pendingUsers;
        }


        public List<Document> AnalystsDocs()
        {
            return db.Documents.Where(d => d.CompletedByAnalyst == false && d.CompletedByArchitect == false && d.CompletedByProgrammer == false && d.CompletedByTester == false).ToList();
        }

        public List<Document> ArchitectsDocs()
        {
            return db.Documents.Where(d => d.CompletedByAnalyst == true && d.CompletedByArchitect == false && d.CompletedByProgrammer == false && d.CompletedByTester == false).ToList();
        }

        public List<Document> ProgrammersDocs()
        {
            return db.Documents.Where(d => d.CompletedByAnalyst == true && d.CompletedByArchitect == true && d.CompletedByProgrammer == false && d.CompletedByTester == false).ToList();
        }

        public List<Document> TestersDocs()
        {
            return db.Documents.Where(d => d.CompletedByAnalyst == true && d.CompletedByArchitect == true && d.CompletedByProgrammer == true && d.CompletedByTester == false).ToList();
        }
    }
}