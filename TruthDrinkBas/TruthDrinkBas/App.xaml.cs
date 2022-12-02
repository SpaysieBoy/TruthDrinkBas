using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TruthDrinkBas
{
    public partial class App : Application
    {
        public static string DatabaseLocation = string.Empty;
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage());
        }

        public App(string databaselocation)
        {
            InitializeComponent();
            DatabaseLocation = databaselocation;
            MainPage = new NavigationPage(new MainPage());
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
