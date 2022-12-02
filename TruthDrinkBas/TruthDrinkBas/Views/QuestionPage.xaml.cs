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
    public partial class QuestionPage : ContentPage
    {
        Question question;
        public QuestionPage(Question selectedQuestion)
        {
            InitializeComponent();
            question = selectedQuestion;

            IdLabel.Text = question.Id.ToString();
            QuestionBodyEntry.Text = question.QuestionBody;
        }

        private async void UpdateButton_Clicked(object sender, EventArgs e)
        {
            int updateRows;
            question.QuestionBody = QuestionBodyEntry.Text;

            using (SQLiteConnection sQLiteConnection = new SQLiteConnection(App.DatabaseLocation))
            {
                sQLiteConnection.CreateTable<Question>();
                updateRows = sQLiteConnection.Update(question);
            }

            if(updateRows > 0)
            {
                _ = DisplayAlert("Gelukt!", "Je vraag is aangepast.", "Ok");
            }
            else
            {
                _ = DisplayAlert("Ah Jammer", "Het is niet gelukt", "Ok");
            }

            await Navigation.PopAsync();
        }

        private async void DeleteButton_Clicked(object sender, EventArgs e)
        {
            int deleteRows;
            question.QuestionBody = QuestionBodyEntry.Text;

            using (SQLiteConnection sQLiteConnection = new SQLiteConnection(App.DatabaseLocation))
            {
                sQLiteConnection.CreateTable<Question>();
                deleteRows = sQLiteConnection.Delete(question);
            }

            if (deleteRows > 0)
            {
                _ = DisplayAlert("Gelukt!", "Je vraag is verwijderd.", "Ok");
            }
            else
            {
                _ = DisplayAlert("Ah Jammer", "Het is niet gelukt om je vraag te verwijderen", "Ok");
            }
            await Navigation.PopAsync();
        }
    }
}