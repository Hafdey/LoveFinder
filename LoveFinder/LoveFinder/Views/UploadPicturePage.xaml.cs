using LoveFinder.Controllers;
using LoveFinder.Models;
using Plugin.Media;
using Plugin.Media.Abstractions;
using SQLite;
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
    public partial class UploadPicturePage : ContentPage
    {
        public UserController user { get; set; }
        public PictureController pictureController { get; set; }
        public UploadPicturePage()
        {
            InitializeComponent();
        }

        async private void Upload_Clicked(object sender, EventArgs e)
        {
            await CrossMedia.Current.Initialize();
            Picture picture = new Picture();
            MemoryStream ms = new MemoryStream();
            var mediaOptions = new PickMediaOptions()
            {
                PhotoSize = PhotoSize.Medium
            };
            var selectedImageFile = await CrossMedia.Current.PickPhotoAsync(mediaOptions);
            var picStream = selectedImageFile.GetStream();

            picStream.CopyTo(ms);
            var byteArray = ms.ToArray();
            picture.isProfilePic = false;
            picture.picByte = byteArray;
            picture.userID = user.currentUser.userID;
            pictureController.AddPicture(picture);
            Navigation.PopAsync();
        }

        private void Back_Clicked(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }
    }
}