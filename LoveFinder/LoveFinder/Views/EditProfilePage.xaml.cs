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
        public EditProfilePage()
        {
            InitializeComponent();
        }

        private void Save_Clicked(object sender, EventArgs e)
        {
            LikePage likePage = new LikePage();
            Navigation.PushAsync(likePage);
        }

        private void Signout_Clicked(object sender, EventArgs e)
        {
            MainPage mainPage = new MainPage();
            Navigation.PushAsync(mainPage);
        }

        private void Remove_Clicked(object sender, EventArgs e)
        {
            MainPage mainPage = new MainPage();
            Navigation.PushAsync(mainPage);
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            EditPicturePage editPicturePage = new EditPicturePage();
            Navigation.PushAsync(editPicturePage);
        }
    }
}