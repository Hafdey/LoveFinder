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
        public ChangePicturePage()
        {
            InitializeComponent();
        }

        private void SetAsProfilePic_Clicked(object sender, EventArgs e)
        {
            EditPicturePage editPicturePage = new EditPicturePage();
            editPicturePage.user = user;
            Navigation.PushAsync(editPicturePage);
        }

        private void DeletePic_Clicked(object sender, EventArgs e)
        {
            EditPicturePage editPicturePage = new EditPicturePage();
            editPicturePage.user = user;
            Navigation.PushAsync(editPicturePage);
        }

        private void ReplacePic_Clicked(object sender, EventArgs e)
        {
            UploadPicturePage uploadPicturePage = new UploadPicturePage();
            uploadPicturePage.user = user;
            Navigation.PushAsync(uploadPicturePage);
        }

        private void Back_Clicked(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }
    }
}