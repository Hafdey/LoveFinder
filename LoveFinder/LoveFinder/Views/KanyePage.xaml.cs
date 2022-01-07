using LoveFinder.Controllers;
using LoveFinder.Logic;
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
    public partial class KanyePage : ContentPage
    {
        public UserController user = new UserController();
        public KanyePage()
        {
            InitializeComponent();
        }
        protected override void OnAppearing()
        {
            var data = KanyeLogic.GetRandomQuote();
            Quote.Text = data.quote;
        }

        private void refresh_Clicked(object sender, EventArgs e)
        {
             var data = KanyeLogic.GetRandomQuote();
             Quote.Text = data.quote;
        }
    }
}