using LoveFinder.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoveFinder.Controllers
{
    public class UserController
    {
        public User currentUser = null;
        public UserController()
        {

        }
        public bool CreateUser(User user)
        {
            bool success = CheckUser(user);
            if (success)
            {
                SQLiteConnection sQLiteconnection = new SQLiteConnection(App.DatabaseLocation);
                sQLiteconnection.CreateTable<User>();
                int insertedRows = sQLiteconnection.Insert(user);
                sQLiteconnection.Table<User>().ToList();
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool CheckUser(User user)
        {
            User found = null;
            SQLiteConnection sQLiteconnection = new SQLiteConnection(App.DatabaseLocation);
            try
            {
                found = sQLiteconnection.Table<User>().First(x => x.mail == user.mail);
            }
            catch (Exception)
            {

            }
            if (found == null)
            {
                return true;
            }
            return false;
        }
        public bool Login(string mail, string password)
        {
            using (SQLiteConnection sQLiteconnection = new SQLiteConnection(App.DatabaseLocation))
            {
                try
                {
                    currentUser = sQLiteconnection.Table<User>().First(x => x.mail == mail && x.password == password);
                }
                catch (Exception)
                {

                }
            }
            if (currentUser != null)
            {
                return true;
            }
            return false;
        }
        public bool EditUser(User edituser, string newbio, string newage)
        {
            return true;
        }
    }
}
