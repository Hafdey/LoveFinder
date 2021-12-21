using LoveFinder.Controllers;
using LoveFinder.Models;
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
    public partial class LikePage : ContentPage
    {
        public UserController user { get; set; }
        public LikeController like = new LikeController();
        public PictureController pic = new PictureController();
        public MatchController matchcontroller = new MatchController();
        public User possiblematch = new User();
        public LikePage()
        {
            InitializeComponent();
        }
        protected override void OnAppearing()
        {
            int matches = matchcontroller.matchUser(user.currentUser.userID);
            if(matches > 0)
            {
                DisplayAlert("Match!", "Je hebt een match, check je berichten!", "Oke");
            }
            possiblematch = user.getUser();
            TargetText.Text = possiblematch.bio;
            if (possiblematch.bio == "")
            {
                TargetText.Text = "Deze gebruiker heeft geen bio -_-";
            }
            try
            {
                var matchprofilepic = pic.GetProfilePic(possiblematch.userID);
                var stream = new MemoryStream(matchprofilepic.picByte);
                headpic.Source = ImageSource.FromStream(() => stream);
            }
            catch (Exception)
            {

            }
            try
            {
                var restpics = pic.PossibleMatchPics(possiblematch.userID);
                pic1.Source = ImageSource.FromStream(() => restpics[0]);
                pic2.Source = ImageSource.FromStream(() => restpics[1]);
                pic3.Source = ImageSource.FromStream(() => restpics[2]);
            }
            catch (Exception)
            {

            }
            if(possiblematch.userID == user.currentUser.userID)
            {
                DisplayAlert("Geen gebruikers meer", "Er zijn geen gebruikers meer in het systeem die je kunt liken", "Oke :(");
            }
        }

        private void Message_Clicked(object sender, EventArgs e)
        {
            MessagesPage messagesPage = new MessagesPage();
            messagesPage.user = user;
            Navigation.PushAsync(messagesPage);
        }

        private void Profile_Clicked(object sender, EventArgs e)
        {
            EditProfilePage editProfilePage = new EditProfilePage();
            editProfilePage.user = user;
            Navigation.PushAsync(editProfilePage);
        }

        private void Like_Clicked(object sender, EventArgs e)
        {
            like.LikePerson(user.currentUser.userID, possiblematch.userID);
            possiblematch = user.getUser();
            var matchprofilepic = pic.GetProfilePic(possiblematch.userID);
            var stream = new MemoryStream(matchprofilepic.picByte);
            var restpics = pic.PossibleMatchPics(possiblematch.userID);
            TargetText.Text = possiblematch.bio;
            if(possiblematch.bio == null)
            {
                TargetText.Text = "Deze gebruiker heeft geen bio -_-";
            }
            try
            {
                headpic.Source = ImageSource.FromStream(() => stream);
                pic1.Source = ImageSource.FromStream(() => restpics[restpics.Count - 1]);
                pic2.Source = ImageSource.FromStream(() => restpics[restpics.Count - 2]);
                pic3.Source = ImageSource.FromStream(() => restpics[restpics.Count - 3]);
            }
            catch (Exception)
            {

            }
            if (possiblematch.userID == user.currentUser.userID)
            {
                DisplayAlert("Geen gebruikers meer", "Er zijn geen gebruikers meer in het systeem die je kunt liken", "Oke :(");
            }
        }

        private void Dislike_Clicked(object sender, EventArgs e)
        {
            possiblematch = user.getUser();
            TargetText.Text = possiblematch.bio;
            if (possiblematch.bio == null)
            {
                TargetText.Text = "Deze gebruiker heeft geen bio -_-";
            }
            var matchprofilepic = pic.GetProfilePic(possiblematch.userID);
            var stream = new MemoryStream(matchprofilepic.picByte);
            var restpics = pic.PossibleMatchPics(possiblematch.userID);
            try
            {
                headpic.Source = ImageSource.FromStream(() => stream);
                pic1.Source = ImageSource.FromStream(() => restpics[restpics.Count - 1]);
                pic2.Source = ImageSource.FromStream(() => restpics[restpics.Count - 2]);
                pic3.Source = ImageSource.FromStream(() => restpics[restpics.Count - 3]);
            }
            catch (Exception)
            {

            }
            if (possiblematch.userID == user.currentUser.userID)
            {
                DisplayAlert("Geen gebruikers meer", "Er zijn geen gebruikers meer in het systeem die je kunt liken", "Oke :(");
            }
        }
    }
}