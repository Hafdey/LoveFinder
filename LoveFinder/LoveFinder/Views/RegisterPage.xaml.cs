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
            if (Firstname.Text != null && Lastname.Text != null && Birthday.Text != null && Gender.SelectedItem.ToString() != null && SexualOrientation.SelectedItem.ToString() != null && Mail.Text != null && Password1.Text != null && Password2.Text != null)
            {
                if(Password1.Text == Password2.Text)
                {
                    var next = user.FindUser(Mail.Text);
                    if (next != null)
                    {
                        DisplayAlert("Bestaand account", "Dit account bestaat al", "Oke");
                    }
                    else
                    {
                        user.user.firstname = Firstname.Text;
                        user.user.lastname = Lastname.Text;
                        user.user.age = 0;
                        user.user.bio = "";
                        user.user.gender = Gender.SelectedItem.ToString();
                        user.user.sexualOrientation = SexualOrientation.SelectedItem.ToString();
                        user.user.location = "";
                        user.user.password = Password1.Text;
                        user.user.mail = Mail.Text;
                        user.CreateAccount(user.user);
                        EditProfilePage editProfilePage = new EditProfilePage();
                        editProfilePage.user = user;
                        Navigation.PushAsync(editProfilePage);
                    }
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
        }

        private void Backbtn_Clicked(object sender, EventArgs e)
        {
            
        }
    }
}