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
    public partial class EditPicturePage : ContentPage
    {
        public UserController user { get; set; }
        PictureController PictureController = new PictureController();
        public List<Picture> pics { get; set; }
        public Picture profpic { get; set; }
        public EditPicturePage()
        {
            InitializeComponent();
        }
        protected override void OnAppearing()
        {

            using (var ms = new MemoryStream())
            {
                pics = PictureController.GetPicture(user.currentUser.userID);
                List<Stream> pictures = new List<Stream>();
                profpic = PictureController.GetProfilePic(user.currentUser.userID);
                foreach(var pic in pics)
                {
                    var stream = new MemoryStream(pic.picByte);
                    pictures.Add(stream);
                }
                try
                {
                    var stream2 = new MemoryStream(profpic.picByte);
                    profilepic.Source = ImageSource.FromStream(() => stream2);
                }
                catch (Exception)
                {

                }
                try
                {
                    pic2.Source = ImageSource.FromStream(() => pictures[0]);
                    pic3.Source = ImageSource.FromStream(() => pictures[1]);
                    pic4.Source = ImageSource.FromStream(() => pictures[2]);
                    pic5.Source = ImageSource.FromStream(() => pictures[3]);
                }
                catch (Exception)
                {

                }
            }
        }
        private void Save_Clicked(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }
       
        private void Back_Clicked(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }
        private void profilepic_Clicked(object sender, EventArgs e)
        {
            ChangePicturePage changePicturePage = new ChangePicturePage(profpic.picID);
            changePicturePage.user = user;
            Navigation.PushAsync(changePicturePage);
        }
        private void pic2_Clicked(object sender, EventArgs e)
        {
            if(pics.Count > 1)
            {
                ChangePicturePage changePicturePage = new ChangePicturePage(pics[0].picID);
                changePicturePage.user = user;
                Navigation.PushAsync(changePicturePage);
            }
            else
            {
                ChangePicturePage changePicturePage = new ChangePicturePage(-1);
                changePicturePage.user = user;
                Navigation.PushAsync(changePicturePage);
            }

        }
        private void pic3_Clicked(object sender, EventArgs e)
        {
            if(pics.Count > 2)
            {
                ChangePicturePage changePicturePage = new ChangePicturePage(pics[1].picID);
                changePicturePage.user = user;
                Navigation.PushAsync(changePicturePage);
            }
            else
            {
                ChangePicturePage changePicturePage = new ChangePicturePage(-1);
                changePicturePage.user = user;
                Navigation.PushAsync(changePicturePage);
            }

        }
        private void pic4_Clicked(object sender, EventArgs e)
        {
            if(pics.Count > 3)
            {
                ChangePicturePage changePicturePage = new ChangePicturePage(pics[2].picID);
                changePicturePage.user = user;
                Navigation.PushAsync(changePicturePage);
            }
            else
            {
                ChangePicturePage changePicturePage = new ChangePicturePage(-1);
                changePicturePage.user = user;
                Navigation.PushAsync(changePicturePage);
            }
        }
        private void pic5_Clicked(object sender, EventArgs e)
        {
            if(pics.Count >= 4)
            {
                ChangePicturePage changePicturePage = new ChangePicturePage(pics[3].picID);
                changePicturePage.user = user;
                Navigation.PushAsync(changePicturePage);
            }
            else
            {
                ChangePicturePage changePicturePage = new ChangePicturePage(-1);
                changePicturePage.user = user;
                Navigation.PushAsync(changePicturePage);
            }
        }
    }
}