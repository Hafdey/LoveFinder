using LoveFinder.Controllers;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoveFinder.Models
{
    public class User
    {
        [PrimaryKey, AutoIncrement]
        public int userID { get; set; }
        public string mail { get; set; }
        public string password { get; set; }
        public string firstname { get; set; }
        public string lastname { get; set; }
        public int age { get; set; }
        public string location { get; set; }
        public string gender { get; set; }
        public string sexualOrientation { get; set; }
        public string bio { get; set; }
    }
}
