using LoveFinder.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoveFinder.Controllers
{
    public class LoggedInUserController
    {
        public User currentuser { get; set; }
        public void LoginUser()
        {
            using (SQLiteConnection sql = new SQLiteConnection(App.DatabaseLocation))
            {
                LoggedInUser loggedInUser = new LoggedInUser();
                loggedInUser.firstname = currentuser.firstname;
                loggedInUser.lastname = currentuser.lastname;
                loggedInUser.userID = currentuser.userID;
                loggedInUser.age = currentuser.age;
                loggedInUser.bio = currentuser.bio;
                loggedInUser.gender = currentuser.gender;
                loggedInUser.location = currentuser.location;
                loggedInUser.mail = currentuser.mail;
                loggedInUser.password = currentuser.password;
                loggedInUser.sexualOrientation = currentuser.sexualOrientation;
                sql.Insert(loggedInUser);
            }
        }
        public void LogoutUser()
        {
            using(SQLiteConnection sql = new SQLiteConnection(App.DatabaseLocation))
            {
                var user = sql.Table<LoggedInUser>().First();
                sql.Delete(user);
            }
        }
    }
}
