using LoveFinder.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoveFinder.Controllers
{
    public class MatchController
    {
        private List<Liked> userlikedlist { get; set; }
        MessageListController messagelistcontroller = new MessageListController();
        public int matches { get; set; }
        public int matchUser(int uID)
        {
            Match match = new Match();
            using (SQLiteConnection sQLiteconnection = new SQLiteConnection(App.DatabaseLocation))
            {
                sQLiteconnection.CreateTable<Match>();
                try
                {
                    var likedlist = sQLiteconnection.Table<Liked>().Where(x => x.likedID == uID).ToList();
                    userlikedlist = sQLiteconnection.Table<Liked>().Where(x => x.userID == uID).ToList();
                    foreach(var like in likedlist)
                    {
                        foreach(var userlike in userlikedlist)
                        {
                            if(userlike.likedID == like.userID)
                            {
                                match.userID = uID;
                                match.targetID = userlike.likedID;
                                sQLiteconnection.Insert(match);
                                var dellike = sQLiteconnection.Table<Liked>().First(x => x.userID == uID && x.likedID == userlike.likedID);
                                sQLiteconnection.Delete(dellike);
                                messagelistcontroller.CreateNewMessageList(userlike.userID, userlike.likedID);
                                matches++;
                            }
                        }
                    }
                    return matches;
                }
                catch (Exception)
                {
                    
                }
                sQLiteconnection.Close();
                return -1;
            }
        }
        public void MatchSwitch(int uID)
        {
            using(SQLiteConnection sql = new SQLiteConnection(App.DatabaseLocation))
            {
                var matches = sql.Table<Match>().Where(x => x.targetID == uID);
                foreach(var match in matches)
                {
                    int tmp = 0;
                    tmp = match.userID;
                    match.userID = uID;
                    match.targetID = tmp;
                    sql.Update(match);
                }
            }
        }
    }
}
