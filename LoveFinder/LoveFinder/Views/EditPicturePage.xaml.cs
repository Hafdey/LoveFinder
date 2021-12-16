using LoveFinder.Controllers;
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
    public partial class EditPicturePage : ContentPage
    {
        public UserController user { get; set; }
        PictureController PictureController = new PictureController();
        public EditPicturePage()
        {
            InitializeComponent();
        }
        protected override void OnAppearing()
        {
            var test = PictureController.GetPicture(user.currentUser.userID);
            if(test.Count != 0)
            {
                pic1.Source = ImageSource.FromStream(() => test[0]);
            }
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            ChangePicturePage changePicturePage = new ChangePicturePage();
            changePicturePage.user = user;
            Navigation.PushAsync(changePicturePage);
        }

        private void Save_Clicked(object sender, EventArgs e)
        {
            EditProfilePage editProfilePage = new EditProfilePage();
            editProfilePage.user = user;
            Navigation.PushAsync(editProfilePage);
        }
       
        private void Back_Clicked(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }
    }
}