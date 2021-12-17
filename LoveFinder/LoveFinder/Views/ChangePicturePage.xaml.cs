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
    public partial class ChangePicturePage : ContentPage
    {
        public UserController user { get; set; }
        PictureController PictureController = new PictureController();
        public ChangePicturePage(int _id)
        {
            InitializeComponent();
            PictureController.picID = _id;
        }
        protected override void OnAppearing()
        {
            var pictures = PictureController.GetPicture(user.currentUser.userID);
            if (pictures != null)
            {
                picture.Source = ImageSource.FromStream(() => pictures[pictures.Count - PictureController.picID]);
            }
        }

        private void SetAsProfilePic_Clicked(object sender, EventArgs e)
        {
            PictureController.SetProfilePic(user.currentUser.userID);
            Navigation.PopAsync();
        }

        private void DeletePic_Clicked(object sender, EventArgs e)
        {
            PictureController.RemovePic(user.currentUser.userID);
            Navigation.PopAsync();
        }

        private void ReplacePic_Clicked(object sender, EventArgs e)
        {
            UploadPicturePage uploadPicturePage = new UploadPicturePage();
            uploadPicturePage.user = user;
            uploadPicturePage.pictureController = PictureController;
            Navigation.PushAsync(uploadPicturePage);
        }

        private void Back_Clicked(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }
    }
}