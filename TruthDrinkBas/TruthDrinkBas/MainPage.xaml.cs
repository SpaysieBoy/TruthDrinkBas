using SQLite;
using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TruthDrinkBas.Model;
using TruthDrinkBas.Views;
using Xamarin.Forms;
using System.Xml.Linq;

namespace TruthDrinkBas
{
    public partial class MainPage : ContentPage
    {
        User user = new User();

        public MainPage()
        {
            InitializeComponent();
            Image.Source = ImageSource.FromResource("TruthDrinkBas.Pictures.Truthordrink.png");
        }
        private void LoginButton_Clicked(object sender, EventArgs e)
        {
            var dbpath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Test_db_sqlite");
            var db = new SQLiteConnection(dbpath);
            var myquery = db.Table<User>().Where(u=>u.UserName.Equals(UsernameEntry.Text) && u.Password.Equals(PasswordEntry.Text)).FirstOrDefault();

            if (myquery != null)
            {
                App.Current.MainPage = new NavigationPage(new HomePage());
                
            }
            else
            {
                _ = DisplayAlert("Ai", "Wrong Username or Password", "Ok");
            }

            
        }
        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            Navigation.PushAsync(new RegisterPage());
        }

        private void TapGestureRecognizer_Tapped_1(object sender, EventArgs e)
        {
            Navigation.PushAsync(new RegisterPage());
        }


    }
}
