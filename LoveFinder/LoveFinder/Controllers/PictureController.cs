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
        public void AddPicture(Picture pic)
        {
            using (SQLiteConnection sQLiteconnection = new SQLiteConnection(App.DatabaseLocation))
            {
                sQLiteconnection.CreateTable<Picture>();
                sQLiteconnection.Insert(pic);
                var test = sQLiteconnection.Table<Picture>().ToList();
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
                sQLiteconnection.Close();
            }
            foreach(Picture pic in pics)
            {
                var stream = new MemoryStream(pic.picByte);
                streampic.Add(stream);
            }
            return streampic;
        }
    }
}
