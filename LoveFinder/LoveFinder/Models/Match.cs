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
        public int userID { get; set; }
        public int targetID { get; set; }
    }
}
