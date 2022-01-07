using LoveFinder.Controllers;
using LoveFinder.Models;
using Plugin.Media;
using Plugin.Media.Abstractions;
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
    public partial class ChangePicturePage : ContentPage
    {
        public UserController user { get; set; }
        PictureController PictureController = new PictureController();
        private List<System.IO.Stream> pictures { get; set; }
        public int picID { get; set; }
        public ChangePicturePage(int _picID)
        {
            InitializeComponent();
            picID = _picID;
        }
        protected override void OnAppearing()
        {
            if(picID >= 0)
            {
                var pic = PictureController.GetPictureByID(picID);
                var picsource = new MemoryStream(pic.picByte);
                Picture.Source = ImageSource.FromStream(() => picsource);
            }
        }
        private void SetAsProfilePic_Clicked(object sender, EventArgs e)
        {
            PictureController.SetProfilePic(user.currentUser.userID, picID);
            Navigation.PopAsync();
        }

        private void DeletePic_Clicked(object sender, EventArgs e)
        {
            PictureController.RemovePic(picID);
            Navigation.PopAsync();
        }

        async private void ReplacePic_Clicked(object sender, EventArgs e)
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
            Picture.Source = ImageSource.FromStream(() => picStream);

            picStream.CopyTo(ms);
            var byteArray = ms.ToArray();
            picture.isProfilePic = false;
            picture.picByte = byteArray;
            picture.userID = user.currentUser.userID;
            PictureController.AddPicture(picture, picID);
        }
    }
}