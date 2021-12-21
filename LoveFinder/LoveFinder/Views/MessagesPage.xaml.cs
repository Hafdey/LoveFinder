using LoveFinder.Controllers;
using LoveFinder.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LoveFinder.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MessagesPage : ContentPage
    {
        public UserController user { get; set; }
        MessageListController msgl = new MessageListController();
        PictureController pcontroller = new PictureController(); 
        List<MessageList> msglist = new List<MessageList>();
        public User target { get; set; }

        public MessagesPage()
        {
            InitializeComponent();
        }
        protected override void OnAppearing()
        {
            List<Chat> chats = new List<Chat>();
            msglist = msgl.GetAllMessageLists(user.currentUser.userID);
            foreach(var msg in msglist)
            {
                Chat chat = new Chat();
                target = user.GetSpecificUser(msg.targetID);
                var targetpf = pcontroller.GetProfilePic(msg.targetID);
                var stream = new MemoryStream(targetpf.picByte);
                var profilepic = ImageSource.FromStream(() => stream);
                var firstname = target.firstname;
                chat.name = target.firstname;
                chat.profilepic = profilepic;
                chat.message = "TEST";
                chat.userID = target.userID;
                chats.Add(chat);
            }
            messagelist.ItemsSource = chats;
        }

        private void messagelist_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var userinfo = messagelist.SelectedItem;
            var userinfoID = userinfo.GetType().GetProperty("userID");
            var userID = userinfoID.GetValue(userinfo, null);
            WriteMessagePage writeMessagePage = new WriteMessagePage((int)userID);
            writeMessagePage.user = user;
            Navigation.PushAsync(writeMessagePage);
        }
    }
}