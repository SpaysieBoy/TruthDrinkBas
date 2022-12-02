using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TruthDrinkBas.Model;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TruthDrinkBas.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ChangeUserPage : ContentPage
    {
        User user;
        public ChangeUserPage(User selectedUser)
        {
            InitializeComponent();
            user = selectedUser;

            IdLabel.Text = user.Id.ToString();
            UserNameBodyEntry.Text = user.UserName;
            PassWordBodyEntry.Text = user.Password;
            MailAdresBodyEntry.Text = user.MailAdres;
        }

        private async void UpdateUserButton_Clicked(object sender, EventArgs e)
        {
            int updateRows;
            user.UserName = UserNameBodyEntry.Text;
            user.Password = PassWordBodyEntry.Text;
            user.MailAdres = MailAdresBodyEntry.Text;

            using (SQLiteConnection sQLiteConnection = new SQLiteConnection(App.DatabaseLocation))
            {
                sQLiteConnection.CreateTable<User>();
                updateRows = sQLiteConnection.Update(user);
            }

            if (updateRows > 0)
            {
                _ = DisplayAlert("Gelukt!", "De gebruiker is aangepast", "Ok");
            }
            else
            {
                _ = DisplayAlert("Ah Jammer", "Het is niet gelukt", "Ok");
            }

            await Navigation.PopAsync();
        }

        private async void DeleteUserButton_Clicked(object sender, EventArgs e)
        {
            int deleteRows;
            user.UserName = UserNameBodyEntry.Text;
            user.Password = PassWordBodyEntry.Text;
            user.MailAdres = MailAdresBodyEntry.Text;

            using (SQLiteConnection sQLiteConnection = new SQLiteConnection(App.DatabaseLocation))
            {
                sQLiteConnection.CreateTable<User>();
                deleteRows = sQLiteConnection.Delete(user);
            }

            if (deleteRows > 0)
            {
                _ = DisplayAlert("Gelukt!", "De gebruiker is verwijderd", "Ok");
            }
            else
            {
                _ = DisplayAlert("Ah Jammer", "Het is niet gelukt", "Ok");
            }

            await Navigation.PopAsync();
        }
    }
}