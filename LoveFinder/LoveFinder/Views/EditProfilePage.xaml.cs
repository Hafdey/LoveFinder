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
        public EditProfilePage(UserController usercontroller)
        {
            InitializeComponent();
            user = usercontroller;
            Firstname.Text = user.user.firstname;
            Lastname.Text = user.user.lastname;
            Bio.Text = user.user.bio;
            Age.Text = user.user.age.ToString();
        }

        private void Save_Clicked(object sender, EventArgs e)
        {
            user.EditUser(user.user, Bio.Text, Age.Text);
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
            user.DeleteAccount(user.user);
            user.user.age = 0;
            user.user.bio = "";
            user.user.firstname = "";
            user.user.lastname = "";
            user.user.location = "";
            user.user.password = "";
            user.user.sexualOrientation = "";
            user.user.mail = "";
            user.user.gender = "";
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