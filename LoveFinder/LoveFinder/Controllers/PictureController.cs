using LoveFinder.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Xamarin.Forms;

namespace LoveFinder.Controllers
{
    public class PictureController
    {
        public int picID { get; set; }
        public void AddPicture(Picture pic, int picID)
        {
            bool success = false;
            using (SQLiteConnection sQLiteconnection = new SQLiteConnection(App.DatabaseLocation))
            {
                sQLiteconnection.CreateTable<Picture>();
                try
                {
                    var oldpic = sQLiteconnection.Table<Picture>().Where(x => x.picID == picID);
                    sQLiteconnection.Delete(oldpic);
                    sQLiteconnection.Insert(pic);
                    success = true;
                }
                catch (Exception)
                {

                }
                if (!success)
                {
                    sQLiteconnection.Insert(pic);
                }
                sQLiteconnection.Close();
            }

        }
        public List<Picture> GetPicture(int uID)
        {
            var pics = new List<Picture>();
            var streampic = new List<Stream>();
            using (SQLiteConnection sQLiteconnection = new SQLiteConnection(App.DatabaseLocation))
            {
                pics = sQLiteconnection.Table<Picture>().Where(x => x.userID == uID).ToList();
                try
                {
                    var doublepic = pics.Find(x => x.isProfilePic == true);
                    pics.Remove(doublepic);
                }
                catch (Exception)
                {

                }
                sQLiteconnection.Close();
                return pics;
            }

        }
        public Picture GetPictureByID(int picID)
        {
            using(SQLiteConnection sql = new SQLiteConnection(App.DatabaseLocation))
            {
                Picture pic = new Picture();
                try
                {
                     pic = sql.Table<Picture>().First(x => x.picID == picID);
                }
                catch (Exception)
                {

                }
                return pic;
            }
        }
        public void SetProfilePic(int uID, int picID)
        {
            if(picID >= 0)
            {
                using (SQLiteConnection sQLiteconnection = new SQLiteConnection(App.DatabaseLocation))
                {
                    var newprofile = sQLiteconnection.Table<Picture>().Where(x => x.picID == picID).ToList();
                    var pics = sQLiteconnection.Table<Picture>().Where(x => x.userID == uID).ToList();
                    try
                    {
                        var profilepic = pics.Find(x => x.isProfilePic == true);
                        profilepic.isProfilePic = false;
                        sQLiteconnection.Update(profilepic);
                    }
                    catch (Exception)
                    {

                    }
                    newprofile[0].isProfilePic = true;
                    sQLiteconnection.Update(newprofile[0]);
                    sQLiteconnection.Close();
                }
            }
        }
        public void RemovePic(int picID)
        {
            if(picID >= 0)
            {
                using (SQLiteConnection sQLiteconnection = new SQLiteConnection(App.DatabaseLocation))
                {
                    var pics = sQLiteconnection.Table<Picture>().Where(x => x.picID == picID).ToList();
                    sQLiteconnection.Delete(pics[0]);
                    sQLiteconnection.Close();
                }
            }
        }
        public Picture GetProfilePic(int uID)
        {
            bool success = false;
            Picture pic = new Picture();
            using (SQLiteConnection sQLiteconnection = new SQLiteConnection(App.DatabaseLocation))
            {
                try
                {
                    pic = sQLiteconnection.Table<Picture>().First(x => x.userID == uID && x.isProfilePic == true);
                    sQLiteconnection.Close();
                    success = true;
                }
                catch (Exception)
                {

                }
                if (!success)
                {
                    return null;
                }
                return pic;
            }
        }
        public List<Stream> PossibleMatchPics(int uID)
        {
            var pics = new List<Picture>();
            var streampic = new List<Stream>();
            using (SQLiteConnection sQLiteconnection = new SQLiteConnection(App.DatabaseLocation))
            {
                pics = sQLiteconnection.Table<Picture>().Where(x => x.userID == uID).ToList();
                var doublepic = pics.Find(x => x.isProfilePic == true);
                pics.Remove(doublepic);
                sQLiteconnection.Close();
            }
            foreach (Picture pic in pics)
            {
                var stream = new MemoryStream(pic.picByte);
                streampic.Add(stream);
            }
            return streampic;
        }
    }
}
