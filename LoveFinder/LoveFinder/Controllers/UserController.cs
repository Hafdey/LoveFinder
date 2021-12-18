using LoveFinder.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
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
                currentUser = user;
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
        public void EditUser(User edituser, string newbio, string newage)
        {
            using (SQLiteConnection sQLiteconnection = new SQLiteConnection(App.DatabaseLocation))
            {
                var getuser = sQLiteconnection.Table<User>().First(x => x.mail == edituser.mail && x.password == edituser.password);
                getuser.bio = newbio;
                getuser.age = Int32.Parse(newage);
                currentUser = getuser;
                sQLiteconnection.Update(getuser);
                sQLiteconnection.Close();
            }
        }
        public void RemoveUser(User remuser)
        {
            using (SQLiteConnection sQLiteconnection = new SQLiteConnection(App.DatabaseLocation))
            {
                sQLiteconnection.Delete(remuser);
                sQLiteconnection.Close();
            }
        }
        public User GetSpecificUser(int uID)
        {
            using (SQLiteConnection sQLiteconnection = new SQLiteConnection(App.DatabaseLocation))
            {
                var foundusr = sQLiteconnection.Table<User>().First(x => x.userID == uID);
                sQLiteconnection.Close();
                return foundusr;
            }
        }
        public User GetSpecificUserByMail(string mail)
        {
            using (SQLiteConnection sQLiteconnection = new SQLiteConnection(App.DatabaseLocation))
            {
                var foundusr = sQLiteconnection.Table<User>().First(x => x.mail == mail);
                sQLiteconnection.Close();
                return foundusr;
            }
        }
        public User getUser()
        {
            using (SQLiteConnection sQLiteconnection = new SQLiteConnection(App.DatabaseLocation))
            {
                if (currentUser.sexualOrientation == "Hetero")
                {
                    if (currentUser.gender == "Man")
                    {

                        var possiblematch = sQLiteconnection.Table<User>().Where(x => x.sexualOrientation == "Hetero" && x.gender == "Vrouw").ToList();
                        var likes = sQLiteconnection.Table<Liked>().Where(x => x.userID == currentUser.userID).ToList();
                        var matches = sQLiteconnection.Table<Match>().Where(x => x.userID == currentUser.userID).ToList();
                        Liked liked = new Liked();
                        Match match = new Match();
                        likes.Add(liked);
                        matches.Add(match);
                        foreach (var possible in possiblematch)
                        {
                            bool check = true;
                            if (matches.Any(x => x.targetID == possible.userID))
                            {
                                check = false;
                            }
                            if (check)
                            {
                                if (likes.Any(x => x.likedID == possible.userID))
                                {
                                    check = false;
                                }
                            }
                            if(check)
                            {
                                return possible;
                            }
                        }
                    }
                    if (currentUser.gender == "Vrouw")
                    {
                        //Alleen mannen
                        var possiblematch = sQLiteconnection.Table<User>().Where(x => x.sexualOrientation == "Hetero" && x.gender == "Man").ToList();
                        var likes = sQLiteconnection.Table<Liked>().Where(x => x.userID == currentUser.userID).ToList();
                        var matches = sQLiteconnection.Table<Match>().Where(x => x.userID == currentUser.userID).ToList();
                        Liked liked = new Liked();
                        Match match = new Match();
                        likes.Add(liked);
                        matches.Add(match);
                        foreach (var possible in possiblematch)
                        {
                            bool check = true;
                            if (matches.Any(x => x.targetID == possible.userID))
                            {
                                check = false;
                            }
                            if (check)
                            {
                                if (likes.Any(x => x.likedID == possible.userID))
                                {
                                    check = false;
                                }
                            }
                            if (check)
                            {
                                return possible;
                            }
                        }
                    }
                    else
                    {
                        //Alleen anders
                        var possiblematch = sQLiteconnection.Table<User>().Where(x => x.sexualOrientation == "Hetero" && x.gender == "Anders").ToList();
                        var likes = sQLiteconnection.Table<Liked>().Where(x => x.userID == currentUser.userID).ToList();
                        var matches = sQLiteconnection.Table<Match>().Where(x => x.userID == currentUser.userID).ToList();
                        Liked liked = new Liked();
                        Match match = new Match();
                        likes.Add(liked);
                        matches.Add(match);
                        foreach (var possible in possiblematch)
                        {
                            bool check = true;
                            if (matches.Any(x => x.targetID == possible.userID))
                            {
                                check = false;
                            }
                            if (check)
                            {
                                if (likes.Any(x => x.likedID == possible.userID))
                                {
                                    check = false;
                                }
                            }
                            if (check)
                            {
                                return possible;
                            }
                        }
                    }
                }
                if (currentUser.sexualOrientation == "Homo" || currentUser.sexualOrientation == "Lesbisch")
                {
                    if (currentUser.gender == "Man")
                    {
                        //Alleen mannen
                        var possiblematch = sQLiteconnection.Table<User>().Where(x => x.sexualOrientation == "Homo" && x.gender == "Man").ToList();
                        var likes = sQLiteconnection.Table<Liked>().Where(x => x.userID == currentUser.userID).ToList();
                        var matches = sQLiteconnection.Table<Match>().Where(x => x.userID == currentUser.userID).ToList();
                        Liked liked = new Liked();
                        Match match = new Match();
                        likes.Add(liked);
                        matches.Add(match);
                        foreach (var possible in possiblematch)
                        {
                            bool check = true;
                            if (matches.Any(x => x.targetID == possible.userID))
                            {
                                check = false;
                            }
                            if (check)
                            {
                                if (likes.Any(x => x.likedID == possible.userID))
                                {
                                    check = false;
                                }
                            }
                            if (check)
                            {
                                return possible;
                            }
                        }
                    }
                    if (currentUser.gender == "Vrouw")
                    {
                        //Alleen vrouwen
                        var possiblematch = sQLiteconnection.Table<User>().Where(x => x.sexualOrientation == "Lesbisch" || x.sexualOrientation == "Homo" && x.gender == "Vrouw").ToList();
                        var likes = sQLiteconnection.Table<Liked>().Where(x => x.userID == currentUser.userID).ToList();
                        var matches = sQLiteconnection.Table<Match>().Where(x => x.userID == currentUser.userID).ToList();
                        Liked liked = new Liked();
                        Match match = new Match();
                        likes.Add(liked);
                        matches.Add(match);
                        foreach (var possible in possiblematch)
                        {
                            bool check = true;
                            if (matches.Any(x => x.targetID == possible.userID))
                            {
                                check = false;
                            }
                            if (check)
                            {
                                if (likes.Any(x => x.likedID == possible.userID))
                                {
                                    check = false;
                                }
                            }
                            if (check)
                            {
                                return possible;
                            }
                        }
                    }
                    else
                    {
                        //Alleen anders
                        var possiblematch = sQLiteconnection.Table<User>().Where(x => x.sexualOrientation == "Lesbisch" || x.sexualOrientation == "Homo" && x.gender == "Anders").ToList();
                        var likes = sQLiteconnection.Table<Liked>().Where(x => x.userID == currentUser.userID).ToList();
                        var matches = sQLiteconnection.Table<Match>().Where(x => x.userID == currentUser.userID).ToList();
                        Liked liked = new Liked();
                        Match match = new Match();
                        likes.Add(liked);
                        matches.Add(match);
                        foreach (var possible in possiblematch)
                        {
                            bool check = true;
                            if (matches.Any(x => x.targetID == possible.userID))
                            {
                                check = false;
                            }
                            if (check)
                            {
                                if (likes.Any(x => x.likedID == possible.userID))
                                {
                                    check = false;
                                }
                            }
                            if (check)
                            {
                                return possible;
                            }
                        }
                    }
                    if (currentUser.sexualOrientation == "Bi")
                    {
                        //Alles
                        var possiblematch = sQLiteconnection.Table<User>().Where(x => x.sexualOrientation == "Bi").ToList();
                        var likes = sQLiteconnection.Table<Liked>().Where(x => x.userID == currentUser.userID).ToList();
                        var matches = sQLiteconnection.Table<Match>().Where(x => x.userID == currentUser.userID).ToList();
                        Liked liked = new Liked();
                        Match match = new Match();
                        likes.Add(liked);
                        matches.Add(match);
                        foreach (var possible in possiblematch)
                        {
                            bool check = true;
                            if (matches.Any(x => x.targetID == possible.userID))
                            {
                                check = false;
                            }
                            if (check)
                            {
                                if (likes.Any(x => x.likedID == possible.userID))
                                {
                                    check = false;
                                }
                            }
                            if (check)
                            {
                                return possible;
                            }
                        }
                    }
                    if (currentUser.sexualOrientation == "Anders")
                    {
                        //Alles
                        var possiblematch = sQLiteconnection.Table<User>().Where(x => x.sexualOrientation == "Anders" && x.gender == "Anders").ToList();
                        var likes = sQLiteconnection.Table<Liked>().Where(x => x.userID == currentUser.userID).ToList();
                        var matches = sQLiteconnection.Table<Match>().Where(x => x.userID == currentUser.userID).ToList();
                        Liked liked = new Liked();
                        Match match = new Match();
                        likes.Add(liked);
                        matches.Add(match);
                        foreach (var possible in possiblematch)
                        {
                            bool check = true;
                            if (matches.Any(x => x.targetID == possible.userID))
                            {
                                check = false;
                            }
                            if (check)
                            {
                                if (likes.Any(x => x.likedID == possible.userID))
                                {
                                    check = false;
                                }
                            }
                            if (check)
                            {
                                return possible;
                            }
                        }
                    }
                }
                return currentUser;
            }
        }
    }
}