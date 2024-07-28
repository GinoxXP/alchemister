using Ginox.BlackCauldron.Alchemy.Model;
using System.Collections.Generic;

namespace Ginox.BlackCauldron.Alchemy.Service
{
    public class BrewingService 
    {
        private int recipeIterator;
        private List<Recipe> suitableRecipes = new();

        public List<Recipe> Recipes { get; private set; } = new();

        public void RegisterRecipe(Recipe recipe)
            => Recipes.Add(recipe);


        public void Brew(AIngredient ingredient)
        {
            if (recipeIterator == 0)
                StartNewBrew();

            var newSuitableRecipes = new List<Recipe>();
            bool isAcceptedRecipe = false;
            foreach (var recipe in suitableRecipes)
            {
                if (recipe.Perform(ingredient, recipeIterator))
                {
                    newSuitableRecipes.Add(recipe);
                    isAcceptedRecipe = true;
                }
            }

            if (!isAcceptedRecipe)
            {
                /// TODO: Restart brewing process
                return;
            }

            recipeIterator++;
        }

        public void FinishBrew()
        {
            Recipe compleatedRecipe = null;
            foreach (var recipe in suitableRecipes)
            {
                if (recipe.Ingredients.Count == recipeIterator - 1)
                {
                    compleatedRecipe = recipe;
                    break;
                }
            }

            if (compleatedRecipe != null)
            {
                /// TODO: Give potion
            }
            else
            {
                /// TODO: Restart brewing process
            }

            recipeIterator = 0;
        }

        private void StartNewBrew()
        {
            suitableRecipes.Clear();

            foreach (var recipe in Recipes)
                suitableRecipes.Add(recipe);
        }
    }
}
