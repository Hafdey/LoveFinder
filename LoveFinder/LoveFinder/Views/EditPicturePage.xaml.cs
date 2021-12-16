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
            var pictures = PictureController.GetPicture(user.currentUser.userID);
            if(pictures.Count >= 1)
            {
                pic1.Source = ImageSource.FromStream(() => pictures[pictures.Count - 1]);
                if(pictures.Count >= 2)
                {
                    pic2.Source = ImageSource.FromStream(() => pictures[pictures.Count - 2]);
                }
                if (pictures.Count >= 3)
                {
                    pic3.Source = ImageSource.FromStream(() => pictures[pictures.Count - 3]);
                }
                if (pictures.Count >= 4)
                {
                    pic4.Source = ImageSource.FromStream(() => pictures[pictures.Count - 4]);
                }
                if (pictures.Count >= 5)
                {
                    pic5.Source = ImageSource.FromStream(() => pictures[pictures.Count - 5]);
                }
            }
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

        private void TapGestureRecognizer_Tapped_1(object sender, EventArgs e)
        {
            ChangePicturePage changePicturePage = new ChangePicturePage(1);
            changePicturePage.user = user;
            Navigation.PushAsync(changePicturePage);
        }

        private void TapGestureRecognizer_Tapped_2(object sender, EventArgs e)
        {
            ChangePicturePage changePicturePage = new ChangePicturePage(2);
            changePicturePage.user = user;
            Navigation.PushAsync(changePicturePage);
        }

        private void TapGestureRecognizer_Tapped_3(object sender, EventArgs e)
        {
            ChangePicturePage changePicturePage = new ChangePicturePage(3);
            changePicturePage.user = user;
            Navigation.PushAsync(changePicturePage);
        }

        private void TapGestureRecognizer_Tapped_4(object sender, EventArgs e)
        {
            ChangePicturePage changePicturePage = new ChangePicturePage(4);
            changePicturePage.user = user;
            Navigation.PushAsync(changePicturePage);
        }

        private void TapGestureRecognizer_Tapped_5(object sender, EventArgs e)
        {
            ChangePicturePage changePicturePage = new ChangePicturePage(5);
            changePicturePage.user = user;
            Navigation.PushAsync(changePicturePage);
        }
    }
}