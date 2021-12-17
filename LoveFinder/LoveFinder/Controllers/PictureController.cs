using LoveFinder.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace LoveFinder.Controllers
{
    public class PictureController
    {
        public int picID { get; set; }
        public void AddPicture(Picture pic)
        {
            var pics = new List<Picture>();
            bool success = false;
            using (SQLiteConnection sQLiteconnection = new SQLiteConnection(App.DatabaseLocation))
            {
                sQLiteconnection.CreateTable<Picture>();
                pics = sQLiteconnection.Table<Picture>().Where(x => x.userID == pic.userID).ToList();
                try
                {
                    int newprofilepic = pics.Count - picID;
                    sQLiteconnection.Delete(pics[newprofilepic]);
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
        public List<Stream> GetPicture(int uID)
        {
            var pics = new List<Picture>();
            var streampic = new List<Stream>();
            using (SQLiteConnection sQLiteconnection = new SQLiteConnection(App.DatabaseLocation))
            {
                pics = sQLiteconnection.Table<Picture>().Where(x => x.userID == uID).ToList();
                var doublepic = pics.Find(x => x.isProfilePic == true);
                pics.Remove(doublepic);
                try
                {
                    var profilepic = sQLiteconnection.Table<Picture>().First(x => x.isProfilePic == true && x.userID == uID);
                    pics.Add(profilepic);
                }
                catch (Exception)
                {

                }
                sQLiteconnection.Close();
            }
            foreach(Picture pic in pics)
            {
                var stream = new MemoryStream(pic.picByte);
                streampic.Add(stream);
            }
            return streampic;
        }
        public void SetProfilePic(int uID)
        {
            using (SQLiteConnection sQLiteconnection = new SQLiteConnection(App.DatabaseLocation))
            {
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
                var newprofilepic = pics[pics.Count - picID];
                newprofilepic.isProfilePic = true;
                sQLiteconnection.Update(newprofilepic);
                sQLiteconnection.Close();
            }
        }
        public void RemovePic(int uID)
        {
            var pics = new List<Picture>();
            using (SQLiteConnection sQLiteconnection = new SQLiteConnection(App.DatabaseLocation))
            {
                pics = sQLiteconnection.Table<Picture>().Where(x => x.userID == uID).ToList();
                int delpic = pics.Count - picID;
                sQLiteconnection.Delete(pics[delpic]);
                sQLiteconnection.Close();
            }
        }
        public Stream GetProfilePic(int uID)
        {
            MemoryStream stream = null;
            bool success = false;
            using (SQLiteConnection sQLiteconnection = new SQLiteConnection(App.DatabaseLocation))
            {
                try
                {
                    var bytePic = sQLiteconnection.Table<Picture>().First(x => x.userID == uID && x.isProfilePic == true);
                    stream = new MemoryStream(bytePic.picByte);
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
                return stream;
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
