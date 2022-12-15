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
    public partial class PeopleInGame : ContentPage
    {
        public PeopleInGame()
        {
            InitializeComponent();
        }

        private void PersonButton_Clicked(object sender, EventArgs e)
        {
            NumberOfUsers numberOfUsers = new NumberOfUsers();
            numberOfUsers.totalNumbers = ManyPeopleGameEntry.Text;

            SQLiteConnection sQLiteConnection = new SQLiteConnection(App.DatabaseLocation);
            sQLiteConnection.CreateTable<NumberOfUsers>();
            int insertedRows = sQLiteConnection.Insert(numberOfUsers);
            sQLiteConnection.Close();

            if (insertedRows > 0)
            {
                _ = DisplayAlert("Gelukt", "Je persoon is toegevoegd aan de database", "Ok");
                Navigation.PushAsync(new PeopleInGame());
            }
            else
            {
                _ = DisplayAlert("Ah, jammer", "er ging iets fout! Probeer het opnieuw", "Ok");
            }

            
        }

        private void PersoninGameListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var selectedUser = PersoninGameListView.SelectedItem as NumberOfUsers;
            if (selectedUser != null)
            {
                Navigation.PushAsync(new EditPersonInGame(selectedUser));
            }

        }

        private void GameButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new GetStatements_page());
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            SQLiteConnection sQLiteConnection = new SQLiteConnection(App.DatabaseLocation);
            sQLiteConnection.CreateTable<NumberOfUsers>();

            var numberOfUser = sQLiteConnection.Table<NumberOfUsers>().ToList();
            sQLiteConnection.Close();
            PersoninGameListView.ItemsSource = numberOfUser;
        }


    }
}