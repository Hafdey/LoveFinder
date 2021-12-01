using LoveFinder.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoveFinder.Controllers
{
    class UserController
    {
        public User user = new User("","","","",0,"","");
        public void CreateAccount(User newuser)
        {
            user.CreateAccount(newuser);
        }
        public void DeleteAccount(User deluser)
        {
            user.DeleteAccount(deluser);
        }
        public bool Login(string mail, string password)
        {
            return user.Login(mail, password);
        }
    }
}
