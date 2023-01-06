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
    public partial class ReceptCocktail : ContentPage
    {
        Drink drink;
        public ReceptCocktail(Drink selectedDrink)
        {
            InitializeComponent();
            drink = selectedDrink;

            ImageBox.Source = drink.strDrinkThumb;
            strDrink.Text = drink.strDrink;
            strCategory.Text = drink.strCategory;
            strAlcoholic.Text = drink.strAlcoholic;
            strGlas.Text = drink.strGlass;
            strIngredient1.Text = drink.strIngredient1;
            strIngredient2.Text = drink.strIngredient2;
            strIngredient3.Text = drink.strIngredient3;
            strIngredient4.Text = drink.strIngredient4;
            strIngredient5.Text = drink.strIngredient5;
            strIngredient6.Text = drink.strIngredient6;
            strIngredient7.Text = drink.strIngredient7;
            
        }
    }
}