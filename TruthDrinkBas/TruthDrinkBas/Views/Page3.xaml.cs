using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TruthDrinkBas.Model;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TruthDrinkBas.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Page3 : ContentPage
    {
        public Page3()
        {
            InitializeComponent();
        }

        private void SaveButton_Clicked(object sender, EventArgs e)
        {
            Question question = new Question();
            question.QuestionBody = QuestionEntry.Text;

            SQLiteConnection sQLiteConnection = new SQLiteConnection(App.DatabaseLocation);
            sQLiteConnection.CreateTable<Question>();
            int insertedRows = sQLiteConnection.Insert(question);
            sQLiteConnection.Close();

            if(insertedRows > 0)
            {
                _ = DisplayAlert("Gelukt", "Je vraag is toegevoegd aan de Database", "Ok");
            }
            else
            {
                _ = DisplayAlert("Ah, jammer", "er ging iets fout! Probeer het opnieuw", "Ok");
            }

            //await Navigation.PopAsync();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            SQLiteConnection sQLiteConnection = new SQLiteConnection(App.DatabaseLocation);
            sQLiteConnection.CreateTable<Question>();

            var questions = sQLiteConnection.Table<Question>().ToList();
            sQLiteConnection.Close();
            QuestionListView.ItemsSource = questions;
        }

        private void QuestionListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var selectedQuestion = QuestionListView.SelectedItem as Question;
            if(selectedQuestion != null)
            {
                Navigation.PushAsync(new QuestionPage(selectedQuestion));
            }
        }
    }
}