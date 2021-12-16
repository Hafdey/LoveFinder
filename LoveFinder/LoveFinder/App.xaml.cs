using LoveFinder.Controllers;
using LoveFinder.Models;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LoveFinder
{
    public partial class App : Application
    {
        public static string DatabaseLocation = string.Empty;
        public App()
        {
           // UserController user = new UserController();
           // User testuser = new User("test", "test", "Jan", "Wimpel", 20, "Male", "Hetero");
           // testuser.bio = "Dit is een testbio";
           // user.CreateAccount(testuser);
            InitializeComponent();
            MainPage page = new MainPage();
            //page.user = user;
            MainPage = new NavigationPage(page);
        }
        public App(string databaseLocation)
        {
            InitializeComponent();
            DatabaseLocation = databaseLocation;
            MainPage page = new MainPage();
            ///page.user = user;
            MainPage = new NavigationPage(page);
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
