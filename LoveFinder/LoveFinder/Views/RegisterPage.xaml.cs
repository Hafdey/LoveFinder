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
    public partial class RegisterPage : ContentPage
    {
        public RegisterPage()
        {
            InitializeComponent();
        }

        private void Savebtn_Clicked(object sender, EventArgs e)
        {
            EditProfilePage editProfilePage = new EditProfilePage();
            Navigation.PushAsync(editProfilePage);
        }

        private void Backbtn_Clicked(object sender, EventArgs e)
        {

        }
    }
}