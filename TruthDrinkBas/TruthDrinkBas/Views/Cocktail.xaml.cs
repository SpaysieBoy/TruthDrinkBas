using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TruthDrinkBas.Model;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Newtonsoft.Json;

namespace TruthDrinkBas.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Cocktail : ContentPage
    {
        public Cocktail()
        {
            InitializeComponent();
        }

        private async void ZoekCocktailNameButton_Clicked(object sender, EventArgs e)
        {
            var cocktails = await CocktailLogic.GetCocktailsByName(CocktailnameEntry.Text);
            CocktailListView.ItemsSource = cocktails;
        }

        private void CocktailListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var selectedDrink = CocktailListView.SelectedItem as Drink;
            if (selectedDrink != null)
            {
                Navigation.PushAsync(new ReceptCocktail(selectedDrink));
            }
        }
    }
}