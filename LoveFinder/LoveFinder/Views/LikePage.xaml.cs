using LoveFinder.Controllers;
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
    public partial class LikePage : ContentPage
    {
        public UserController user { get; set; }
        public LikePage()
        {
            InitializeComponent();
        }

        private void Message_Clicked(object sender, EventArgs e)
        {
            MessagesPage messagesPage = new MessagesPage();
            messagesPage.user = user;
            Navigation.PushAsync(messagesPage);
        }

        private void Profile_Clicked(object sender, EventArgs e)
        {
            EditProfilePage editProfilePage = new EditProfilePage(user);
            Navigation.PushAsync(editProfilePage);
        }

        private void Like_Clicked(object sender, EventArgs e)
        {
            
        }

        private void Dislike_Clicked(object sender, EventArgs e)
        {
           
        }
    }
}