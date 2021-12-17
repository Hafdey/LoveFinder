using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoveFinder.Models
{
    public class Liked
    {
        [PrimaryKey, AutoIncrement]
        public int likeID { get; set; }
        public int userID { get; set; }
        public int likedID { get; set; }
    }
}
