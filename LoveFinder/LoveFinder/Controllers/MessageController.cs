using LoveFinder.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoveFinder.Controllers
{
    public class MessageController
    {
        public void SendMessage(int uID, int targetid, string messagetext)
        {
            Message message = new Message();
            using (SQLiteConnection sql = new SQLiteConnection(App.DatabaseLocation))
            {
                var msglst = sql.Table<MessageList>().First(x => x.userID == uID && x.targetID == targetid);
                message.messageListID = msglst.messageListID;
                message.message = messagetext;
                message.sendDate = DateTime.Now;
                message.senderID = uID;
                sql.Insert(message);
            }
        }
        public List<Message> GetAllMessages(int uID, int targetID)
        {
            using (SQLiteConnection sql = new SQLiteConnection(App.DatabaseLocation))
            {
                var msglst = sql.Table<MessageList>().First(x => x.userID == uID && x.targetID == targetID);
                var messages = sql.Table<Message>().Where(x => x.messageListID == msglst.messageListID).ToList();
                sql.Close();
                return messages;
            }
        }
    }
}
