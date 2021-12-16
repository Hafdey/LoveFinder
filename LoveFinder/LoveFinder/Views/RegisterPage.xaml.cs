using LoveFinder.Controllers;
using LoveFinder.Models;
using SQLite;
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
            User newuser = new User();
            newuser.firstname = Firstname.Text;
            newuser.lastname = Lastname.Text;
            newuser.age = Int32.Parse(Birthday.Text);
            newuser.gender = Gender.SelectedItem.ToString();
            newuser.sexualOrientation = SexualOrientation.SelectedItem.ToString();
            newuser.mail = Mail.Text;
            newuser.location = "";
            newuser.bio = "";
            if(Password1.Text == Password2.Text)
            {
                newuser.password = Password1.Text;
            }
            else
            {
                DisplayAlert("Wachtwoorden niet juist", "De ingegeven wachtwoorden komen niet overeen", "Oke");
            }

            bool success = user.CreateUser(newuser);

            if (success)
            {
                DisplayAlert("Gelukt!", "Je account is succesvol aangemaakt", "Oke");
                EditProfilePage editProfilePage = new EditProfilePage();
                editProfilePage.user = user;
                Navigation.PushAsync(editProfilePage);
            }
            else
            {
                DisplayAlert("Fout", "Dit account bestaat al", "Oke");
            }
        }

        private void Backbtn_Clicked(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }
    }
}