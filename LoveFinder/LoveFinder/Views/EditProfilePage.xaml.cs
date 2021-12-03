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
    public partial class EditProfilePage : ContentPage
    {
        public UserController user { get; set; }
        public EditProfilePage()
        {
            InitializeComponent();
        }

        private void Save_Clicked(object sender, EventArgs e)
        {
            LikePage likePage = new LikePage();
            likePage.user = user;
            Navigation.PushAsync(likePage);
        }

        private void Signout_Clicked(object sender, EventArgs e)
        {
            MainPage mainPage = new MainPage();
            mainPage.user = user;
            Navigation.PushAsync(mainPage);
        }

        private void Remove_Clicked(object sender, EventArgs e)
        {
            MainPage mainPage = new MainPage();
            mainPage.user = user;
            Navigation.PushAsync(mainPage);
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            EditPicturePage editPicturePage = new EditPicturePage();
            Navigation.PushAsync(editPicturePage);
        }
    }
}