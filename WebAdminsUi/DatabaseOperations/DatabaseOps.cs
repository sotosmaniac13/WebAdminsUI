using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAdminsUi.Models;

namespace WebAdminsUi.DatabaseOperations
{
    public class DatabaseOps
    {
        public bool CheckUserStatusIfActive(LoginViewModel model)
        {
            using (var db = new ApplicationDbContext())
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

            using (var db = new ApplicationDbContext())
            {
                var users = db.Users.Where(u => u.Status == UserStatus.Pending);

                foreach (var user in users)
                {
                    pendingUsers.Add(user);
                }
            }

            return pendingUsers;
        }
    }
}