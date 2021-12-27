using LoveFinder.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoveFinder.Controllers
{
    public class MessageListController
    {
        public void CreateNewMessageList(int uID, int targetID)
        {
            using (SQLiteConnection sQLiteconnection = new SQLiteConnection(App.DatabaseLocation))
            {
                MessageList messageList = new MessageList();
                messageList.userID = uID;
                messageList.targetID = targetID;
                sQLiteconnection.Insert(messageList);
            }
        }
        public List<MessageList> GetAllMessageLists(int uID)
        {
            using (SQLiteConnection sQLiteconnection = new SQLiteConnection(App.DatabaseLocation))
            {
                var msglist = sQLiteconnection.Table<MessageList>().Where(x => x.userID == uID).ToList();
                return msglist;
            }
        }
        public void MessageListSwitch(int uID)
        {
            using (SQLiteConnection sQLiteconnection = new SQLiteConnection(App.DatabaseLocation))
            {
                var msglist = sQLiteconnection.Table<MessageList>().Where(x => x.targetID == uID).ToList();
                foreach(var msg in msglist)
                {
                    int tmp = 0;
                    tmp = msg.userID;
                    msg.userID = msg.targetID;
                    msg.targetID = tmp;
                    sQLiteconnection.Update(msg);
                }
            }
        }
    }
}
