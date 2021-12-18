using LoveFinder.Controllers;
using LoveFinder.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LoveFinder.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WriteMessagePage : ContentPage
    {
        public UserController user { get; set; }
        MessageController msgctor = new MessageController();
        User targetuser = new User();
        public int userID { get; set; }
        public WriteMessagePage(int _userID)
        {
            InitializeComponent();
            userID = _userID;
        }
        protected override void OnAppearing()
        {
            targetuser = user.GetSpecificUser(userID);
            var msglist = msgctor.GetAllMessages(user.currentUser.userID, targetuser.userID);
            listMessages.ItemsSource = msglist;
        }

        private void sendbtn_Clicked(object sender, EventArgs e)
        {
            msgctor.SendMessage(user.currentUser.userID, targetuser.userID, text.Text);
            text.Text = null;
        }
    }
}