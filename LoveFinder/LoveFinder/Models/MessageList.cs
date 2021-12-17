using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoveFinder.Models
{
    public class MessageList
    {
        [PrimaryKey, AutoIncrement]
        public int messageListID { get; set; }
        public int userID { get; set; }
        public int targetID { get; set; }
    }
}
