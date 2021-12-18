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
                var matchcheck = sQLiteconnection.Table<Match>().Where(x => x.userID == uID && x.targetID == likedID).ToList();
                var likecheck = sQLiteconnection.Table<Liked>().Where(x => x.userID == uID && x.likedID == likedID).ToList();
                if(matchcheck.Count == 0)
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
}
