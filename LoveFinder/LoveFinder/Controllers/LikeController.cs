using LoveFinder.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoveFinder.Controllers
{
    public class LikeController
    {
        public void LikePerson(int uID, int likedID)
        {
            using (SQLiteConnection sQLiteconnection = new SQLiteConnection(App.DatabaseLocation))
            {
                Liked liked = new Liked();
                sQLiteconnection.CreateTable<Liked>();
                liked.userID = uID;
                liked.likedID = likedID;
                sQLiteconnection.Insert(liked);
                sQLiteconnection.Close();
            }
        }
    }
}
