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
    public partial class EditPersonInGame : ContentPage
    {
        NumberOfUsers numberOfUsers;
        public EditPersonInGame(NumberOfUsers selectedUser)
        {
            InitializeComponent();
            numberOfUsers = selectedUser;

            IdLabel.Text = numberOfUsers.IdNumberOfUsers.ToString();
            UserNameBodyEntry.Text = numberOfUsers.totalNumbers;
        }

        private async void UpdateUserButton_Clicked(object sender, EventArgs e)
        {
            int updateRows;
            numberOfUsers.totalNumbers = UserNameBodyEntry.Text;


            using (SQLiteConnection sQLiteConnection = new SQLiteConnection(App.DatabaseLocation))
            {
                sQLiteConnection.CreateTable<NumberOfUsers>();
                updateRows = sQLiteConnection.Update(numberOfUsers);
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
            numberOfUsers.totalNumbers = UserNameBodyEntry.Text;

            using (SQLiteConnection sQLiteConnection = new SQLiteConnection(App.DatabaseLocation))
            {
                sQLiteConnection.CreateTable<NumberOfUsers>();
                deleteRows = sQLiteConnection.Delete(numberOfUsers);
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