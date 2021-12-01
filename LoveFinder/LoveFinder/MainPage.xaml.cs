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
        public UserController user { get; set; }
        public MainPage()
        {
            InitializeComponent();
        }

        private void Loginbtn_Clicked(object sender, EventArgs e)
        {
            if(Mail.Text != null && Password.Text != null)
            {
                bool next = user.Login(Mail.Text, Password.Text);
                if (next)
                {
                    LikePage likePage = new LikePage();
                    Navigation.PushAsync(likePage);
                }
                else
                {
                    DisplayAlert("Geen correcte gegevens", "Ingevoerde gegevens zijn niet correct", "Oke");
                }
            }
            else
            {
                Mail.Text = null;
                Password.Text = null;
                DisplayAlert("Missende velden", "Graag alle velden invullen a.u.b.", "Oke");
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
