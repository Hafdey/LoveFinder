using LoveFinder.Controllers;
using LoveFinder.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace LoveFinder
{
   public class ChatDataTemplateSelector : DataTemplateSelector
    {
        public DataTemplate fromTemplate { get; set; }
        public DataTemplate toTemplate { get; set; }

        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            using(SQLiteConnection sql = new SQLiteConnection(App.DatabaseLocation))
            {
                var user = sql.Table<LoggedInUser>().ToList();
                return ((Message)item).senderID.Equals(user[0].userID) ? fromTemplate : toTemplate;
            }
        }
    }
}
