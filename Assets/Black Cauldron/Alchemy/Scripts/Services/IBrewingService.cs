using Ginox.BlackCauldron.Alchemy.Models;
using System.Collections.Generic;

namespace Ginox.BlackCauldron.Alchemy.Services
{
    public interface IBrewingService
    {
        /// <summary>
        /// Performed potion.
        /// </summary>
        public APotion CompleatedPotion { get; }

        /// <summary>
        /// List of recipe.
        /// </summary>
        public List<Recipe> Recipes { get; }

        /// <summary>
        /// Register recipe.
        /// </summary>
        /// <param name="recipe">Registred recipe.</param>
        public void RegisterRecipe(Recipe recipe);

        /// <summary>
        /// Get recipe of potion.
        /// </summary>
        /// <param name="potion">Potion.</param>
        /// <returns>Recipe of potion.</returns>
        public Recipe GetRecipe(APotion potion);

        /// <summary>
        /// Brew potion.
        /// </summary>
        /// <param name="ingredient">Add ingredient to brewing process.</param>
        public void Brew(AIngredient ingredient);

        /// <summary>
        /// Finish brewing process.
        /// </summary>
        public void FinishBrew();
    }
}
