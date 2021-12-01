using LoveFinder.Controllers;
using LoveFinder.Models;
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
        public UserController user { get; set; }
        public RegisterPage()
        {
            InitializeComponent();
        }

        private void Savebtn_Clicked(object sender, EventArgs e)
        {
            if (Firstname.Text != null && Lastname.Text != null && Birthday.Text != null && Gender.Text != null && SexualOrientation.Text != null && Mail.Text != null && Password1.Text != null && Password2.Text != null)
            {
                if(Password1.Text == Password2.Text)
                {
                    User newuser = new User(Mail.Text,Password1.Text,Firstname.Text,Lastname.Text,Int32.Parse(Birthday.Text),Gender.Text,SexualOrientation.Text);
                    user.CreateAccount(newuser);
                }
                else
                {
                    DisplayAlert("Fout wachtwoorden", "Wachtwoorden komen niet overeen", "Oke");
                    Password1.Text = null;
                    Password2.Text = null;
                }
            }
            else
            {
                DisplayAlert("Fout vulden", "Niet alle velden zijn ingevuld", "Oke");
            }
            EditProfilePage editProfilePage = new EditProfilePage();
            editProfilePage.user = user;
            Navigation.PushAsync(editProfilePage);
        }

        private void Backbtn_Clicked(object sender, EventArgs e)
        {
            
        }
    }
}