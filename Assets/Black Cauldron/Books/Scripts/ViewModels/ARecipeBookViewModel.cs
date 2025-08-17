using Ginox.BlackCauldron.Alchemy.Models;
using System.Collections.Generic;
using Ginox.BlackCauldron.Books.Models;

namespace Ginox.BlackCauldron.Books.ViewModels
{
    public abstract class ARecipeBookViewModel : ABookViewModel
    {
        public ARecipeBook Model { get; protected set; }
        
        public List<Recipe> Recipes => Model.Recipes;

        public void RegisterRecipe(Recipe recipe)
            => Recipes.Add(recipe);
    }
}