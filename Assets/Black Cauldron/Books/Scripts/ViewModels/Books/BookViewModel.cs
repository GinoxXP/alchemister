using Ginox.BlackCauldron.Alchemy.Model;
using System.Collections.Generic;

namespace Ginox.BlackCauldron.Books.ViewModels.Books
{
    public abstract class ABookViewModel
    {
        public List<Recipe> Recipes { get; private set; } = new();

        public void RegisterRecipe(Recipe recipe)
            => Recipes.Add(recipe);
    }
}
