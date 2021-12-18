using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoveFinder.Models
{
    public class Message
    {
        [PrimaryKey, AutoIncrement]
        public int messageID { get; set; }
        public int senderID { get; set; }
        public int messageListID { get; set; }
        public string message { get; set; }
        public DateTime sendDate { get; set; }
    }
}
