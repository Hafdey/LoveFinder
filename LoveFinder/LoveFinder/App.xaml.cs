using LoveFinder.Controllers;
using LoveFinder.Models;
using SQLite;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LoveFinder
{
    public partial class App : Application
    {
        public static string DatabaseLocation = string.Empty;
        public App(string databaseLocation)
        {
            InitializeComponent();
            DatabaseLocation = databaseLocation;
            using (SQLiteConnection sQLiteconnection = new SQLiteConnection(DatabaseLocation))
            {
                //   var test1 = sQLiteconnection.Table<Liked>().ToList();
                //   var test2 = sQLiteconnection.Table<Match>().ToList();
                //   var test3 = sQLiteconnection.Table<User>().ToList();
                //   var test4 = sQLiteconnection.Table<Picture>().ToList();
                //   var test5 = sQLiteconnection.Table<Message>().ToList();
                //   var test6 = sQLiteconnection.Table<MessageList>().ToList();
                //
                // sQLiteconnection.DeleteAll<Liked>();
                // sQLiteconnection.DeleteAll<Match>();
                // sQLiteconnection.DeleteAll<User>();
                // sQLiteconnection.DeleteAll<Picture>();
                // sQLiteconnection.DeleteAll<Message>();
                // sQLiteconnection.DeleteAll<MessageList>();

                sQLiteconnection.CreateTable<LoggedInUser>();
                sQLiteconnection.DeleteAll<LoggedInUser>();
                //var pics = sQLiteconnection.Table<Picture>().ToList();

                sQLiteconnection.CreateTable<Liked>();
                sQLiteconnection.CreateTable<Match>();
                sQLiteconnection.CreateTable<User>();
                sQLiteconnection.CreateTable<Picture>();
                sQLiteconnection.CreateTable<Message>();
                sQLiteconnection.CreateTable<MessageList>();
                sQLiteconnection.CreateTable<LoggedInUser>();

             //   test1 = sQLiteconnection.Table<Liked>().ToList();
             //   test2 = sQLiteconnection.Table<Match>().ToList();
             //   test3 = sQLiteconnection.Table<User>().ToList();
             //   test4 = sQLiteconnection.Table<Picture>().ToList();
             //   test5 = sQLiteconnection.Table<Message>().ToList();
             //   test6 = sQLiteconnection.Table<MessageList>().ToList();
            }
            MainPage page = new MainPage();
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
