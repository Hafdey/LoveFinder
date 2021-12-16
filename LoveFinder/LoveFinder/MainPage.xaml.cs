using LoveFinder.Controllers;
using LoveFinder.Models;
using LoveFinder.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace LoveFinder
{
    public partial class MainPage : ContentPage
    {
        public UserController user = new UserController();
        public MainPage()
        {
            InitializeComponent();
        }
        protected override bool OnBackButtonPressed()
        {
            return true;
        }
        private void Loginbtn_Clicked(object sender, EventArgs e)
        {
            if(Mail.Text != null && Password.Text != null)
            {
                if(user.Login(Mail.Text, Password.Text))
                {
                    EditProfilePage editProfilePage = new EditProfilePage();
                    editProfilePage.user = user;
                    Navigation.PushAsync(editProfilePage);
                }
                else
                {
                    DisplayAlert("Foutieve gegevens", "De ingevoerde gegevens zijn niet correct", "Oke");
                }
            }
            else
            {
                DisplayAlert("Niet alle gegevens ingevuld", "Vul a.u.b. alle gevraagde velden in", "Oke");
            }
        }

        private void Registerbtn_Clicked(object sender, EventArgs e)
        {
            RegisterPage registerPage = new RegisterPage();
            registerPage.user = user;
            Navigation.PushAsync(registerPage);
        }
    }
}
