using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace TruthDrinkBas.Model
{
    public class Cocktail
    {
        public static string GenerateURLName(string name)
        {
            return string.Format(Constants.COCKTAIL_BY_NAME, name);
        }
        public static string GenerateURLLetter(string letter)
        {
            return string.Format(Constants.COCKTAIL_BY_LETTER, letter);
        }
        public static string GenerateURLRandom()
        {
            return Constants.COCKTAIL_BY_RANDOM;
        }
        public static string GenerateURLById(string name)
        {
            return string.Format(Constants.COCKTAIL_BY_NAME, name);
        }
    }
}
