using LoveFinder.Controllers;
using LoveFinder.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
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
        PictureController PictureController = new PictureController();

        public EditProfilePage()
        {
            InitializeComponent();
        }
        protected override void OnAppearing()
        {
            var pic = PictureController.GetProfilePic(user.currentUser.userID);
            try
            {
                if (pic != null)
                {
                    var stream = new MemoryStream(pic.picByte);
                    profilepic.Source = ImageSource.FromStream(() => stream);
                }
                else
                {
                    Firstname.Margin = new Thickness(0, 10, 0, 0);
                }
            }
            catch (Exception)
            {

            }

            Firstname.Text = user.currentUser.firstname;
            Lastname.Text = user.currentUser.lastname;
            Age.Text = user.currentUser.age.ToString();
            Bio.Text = user.currentUser.bio;
            
        }

        private void Save_Clicked(object sender, EventArgs e)
        {
            if(Bio.Text != null && Age.Text != null)
            {
                if(Int32.Parse(Age.Text) > 18)
                {
                    user.EditUser(user.currentUser, Bio.Text, Age.Text);
                    LikePage likePage = new LikePage();
                    likePage.user = user;
                    Navigation.PushAsync(likePage);
                }
                else
                {
                    DisplayAlert("Ingevoerde leeftijd niet correct", "De ingevoerde leeftijd is niet voldoende om verder te gaan met het gebruik van deze applicatie", "Oke");
                }
            }
            else
            {
                DisplayAlert("Vul alle velden in", "Vul a.u.b. alle velden in", "Oke");
            }
        }

        private void Signout_Clicked(object sender, EventArgs e)
        {
            LoggedInUserController loggedInUserController = new LoggedInUserController();
            loggedInUserController.currentuser = user.currentUser;
            loggedInUserController.LogoutUser();
            Navigation.PopToRootAsync();
        }

        private void Remove_Clicked(object sender, EventArgs e)
        {
            Navigation.PopToRootAsync();
            user.RemoveUser(user.currentUser);
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            EditPicturePage editPicturePage = new EditPicturePage();
            editPicturePage.user = user;
            Navigation.PushAsync(editPicturePage);
        }
    }
}