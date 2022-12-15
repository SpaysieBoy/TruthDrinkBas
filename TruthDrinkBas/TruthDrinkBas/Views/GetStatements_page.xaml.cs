using SQLite;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TruthDrinkBas.Model;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using static System.Net.Mime.MediaTypeNames;

namespace TruthDrinkBas.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GetStatements_page : ContentPage
    {

        public GetStatements_page()
        {
            InitializeComponent();


        }

        private void Button_Clicked_1(object sender, EventArgs e)
        {
            var dbpath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Test_db_sqlite");
            var db = new SQLiteConnection(dbpath);
            var myquery = db.Table<Question>().ToList();

            var r = new Random();
           
            int index = r.Next(myquery.Count);
            var q = myquery[index];
            QuestionBodyEntry.Text = (q.QuestionBody);



            var DbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Test_db_sqlite");
            var Db = new SQLiteConnection(DbPath);
            var myquery1 = Db.Table<NumberOfUsers>().ToList();

            var S = new Random();

            int index1 = r.Next(myquery1.Count);
            var W = myquery1[index1];
            PeopleInGameEntry.Text = (W.totalNumbers);

        }
        private void Button_Clicked_2(object sender, EventArgs e)
        {
            var dbpath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Test_db_sqlite");
            var db = new SQLiteConnection(dbpath);
            var myquery = db.Table<Question>().ToList();

            var r = new Random();

            int index = r.Next(myquery.Count);
            var q = myquery[index];
            QuestionBodyEntry.Text = (q.QuestionBody);

            var DbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Test_db_sqlite");
            var Db = new SQLiteConnection(DbPath);
            var myquery1 = Db.Table<NumberOfUsers>().ToList();

            var S = new Random();

            int index1 = r.Next(myquery1.Count);
            var W = myquery1[index1];
            PeopleInGameEntry.Text = (W.totalNumbers);


        }

        private void StatementListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
        }
    }
}