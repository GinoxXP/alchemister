using Ginox.BlackCauldron.Alchemy.Models;
using Ginox.BlackCauldron.Books.Models;
using Ginox.BlackCauldron.Core;
using System.Collections.Generic;

namespace Ginox.BlackCauldron.Books.ViewModels
{
    public abstract class ABookViewModel : ViewModel
    {
        public ABook Model { get; protected set; }

        public List<Recipe> Recipes => Model.Recipes;

        public void RegisterRecipe(Recipe recipe)
            => Recipes.Add(recipe);
    }
}
