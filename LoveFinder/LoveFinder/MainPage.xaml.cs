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
        public MainPage()
        {
            InitializeComponent();
        }

        private void Loginbtn_Clicked(object sender, EventArgs e)
        {
            LikePage likePage = new LikePage();
            Navigation.PushAsync(likePage);
        }

        private void Registerbtn_Clicked(object sender, EventArgs e)
        {
            RegisterPage registerPage = new RegisterPage();
            Navigation.PushAsync(registerPage);
        }
    }
}
