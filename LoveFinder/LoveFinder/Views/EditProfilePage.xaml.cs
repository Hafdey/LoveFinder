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
    public partial class EditProfilePage : ContentPage
    {
        public UserController user { get; set; }

        public EditProfilePage()
        {
            InitializeComponent();
        }
        protected override void OnAppearing()
        {
            Firstname.Text = user.currentUser.firstname;
            Lastname.Text = user.currentUser.lastname;
            Age.Text = user.currentUser.age.ToString();
            Bio.Text = user.currentUser.bio;
        }

        private void Save_Clicked(object sender, EventArgs e)
        {

        }

        private void Signout_Clicked(object sender, EventArgs e)
        {
            
        }

        private void Remove_Clicked(object sender, EventArgs e)
        {

        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            EditPicturePage editPicturePage = new EditPicturePage();
            Navigation.PushAsync(editPicturePage);
        }
    }
}