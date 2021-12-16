using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoveFinder.Models
{
    public class Picture
    {
        [PrimaryKey, AutoIncrement]
        public int picID { get; set; }
        public int userID { get; set; }
        public string picURL { get; set; }
        public bool isProfilePic { get; set; }
    }
}
