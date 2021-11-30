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
        public LikePage()
        {
            InitializeComponent();
        }

        private void Message_Clicked(object sender, EventArgs e)
        {
            MessagesPage messagesPage = new MessagesPage();
            Navigation.PushAsync(messagesPage);
        }

        private void Profile_Clicked(object sender, EventArgs e)
        {
            EditProfilePage editProfilePage = new EditProfilePage();
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