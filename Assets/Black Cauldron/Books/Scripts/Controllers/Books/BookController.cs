using Ginox.BlackCauldron.Alchemy.Models;
using System.Collections.Generic;

namespace Ginox.BlackCauldron.Books.Controllers.Books
{
    public abstract class ABookController
    {
        public List<Recipe> Recipes { get; private set; } = new();

        public void RegisterRecipe(Recipe recipe)
            => Recipes.Add(recipe);
    }
}
