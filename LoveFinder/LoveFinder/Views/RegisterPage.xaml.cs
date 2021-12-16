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
            UserController userController = new UserController();
            User user = new User();
            user.firstname = Firstname.Text;
            user.lastname = Lastname.Text;
            user.age = Int32.Parse(Birthday.Text);
            user.gender = Gender.SelectedItem.ToString();
            user.sexualOrientation = SexualOrientation.SelectedItem.ToString();
            user.mail = Mail.Text;
            user.location = "";
            user.bio = "";
            if(Password1.Text == Password2.Text)
            {
                user.password = Password1.Text;
            }
            else
            {
                DisplayAlert("Wachtwoorden niet juist", "De ingegeven wachtwoorden komen niet overeen", "Oke");
            }

            bool success = userController.CreateUser(user);

            if (success)
            {
                DisplayAlert("Gelukt!", "Je account is succesvol aangemaakt", "Oke");
                EditProfilePage editProfilePage = new EditProfilePage();
                editProfilePage.user = userController;
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