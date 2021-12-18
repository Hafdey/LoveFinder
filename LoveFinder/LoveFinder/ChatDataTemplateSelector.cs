using LoveFinder.Controllers;
using LoveFinder.Models;
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
        public UserController user { get; set; }

        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            return ((Message)item).senderID.Equals(user.currentUser.userID) ? fromTemplate : toTemplate;
        }
    }
}
