using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TruthDrinkBas.Model;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration.AndroidSpecific;
using Xamarin.Forms.Xaml;

namespace TruthDrinkBas.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegisterPage : ContentPage
    {
        public RegisterPage()
        {
            InitializeComponent();
        }

        private async void AddUserButton_Clicked(object sender, EventArgs e)
        {
            User user = new User();
            user.UserName = UserNameEntry.Text;
            user.Password = PassWordEntry.Text;
            user.MailAdres = MailAdresEntry.Text;

            SQLiteConnection sQLiteConnection = new SQLiteConnection(App.DatabaseLocation);
            sQLiteConnection.CreateTable<User>();
            int insertRows = sQLiteConnection.Insert(user);
            sQLiteConnection.Close();

            if(insertRows > 0)
            {
                _ = DisplayAlert("Done it!", "New User has been added!", "Ok");
            }
            else
            {
                _ = DisplayAlert("Ah, jammer", "Er is iets fout gegaan! Probeer het later nog een keer opnieuw", "Ok");
            }

            await Navigation.PopAsync();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            SQLiteConnection sQLiteConnection = new SQLiteConnection(App.DatabaseLocation);
            sQLiteConnection.CreateTable<User>();

            var users = sQLiteConnection.Table<User>().ToList();
            sQLiteConnection.Close();
            UserListView.ItemsSource = users;
        }

        private void UserListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var selectedUser = UserListView.SelectedItem as User;
            if(selectedUser != null)
            {
                Navigation.PushAsync(new ChangeUserPage(selectedUser));
            }
        }

    }
}