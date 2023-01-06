using System;
using System.Collections.Generic;
using System.Text;

namespace TruthDrinkBas.Model
{
    public class Constants
    {
        public const string COCKTAIL_BY_NAME = "http://www.thecocktaildb.com/api/json/v1/1/search.php?s={0}";
        public const string COCKTAIL_BY_RANDOM = "http://www.thecocktaildb.com/api/json/v1/1/random.php";
        public const string COCKTAIL_BY_LETTER = "http://www.thecocktaildb.com/api/json/v1/1/search.php?f={0}";
        public const string INGREDIENT_BY_ID = "http://www.thecocktaildb.com/api/json/v1/1/lookup.php?iid={0}";
        public const string INGREDIENT_BY_NAME = "http://www.thecocktaildb.com/api/json/v1/1/search.php?i{0}";
        public const string COCKTAIL_DETAILS_BY = "http://www.thecocktaildb.com/api/json/v1/1/lookup.php?i={0}";
    }
}
