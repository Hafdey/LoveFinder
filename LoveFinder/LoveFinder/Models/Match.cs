using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoveFinder.Models
{
   public class Match
    {
        [PrimaryKey, AutoIncrement]
        public int matchID { get; set; }
        public string firstname { get; set; }
        public string lastname { get; set; }
        public int age { get; set; }
        public string location { get; set; }
        public string gender { get; set; }
        public string sexualOrientation { get; set; }
        public string bio { get; set; }
    }
}
