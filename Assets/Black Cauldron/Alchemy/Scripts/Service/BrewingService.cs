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
                ingredient.Destroy();

                return;
            }

            ingredient.Destroy();

            recipeIterator++;
        }

        public APotion FinishBrew()
        {
            var potion = CheckPotion();
            StartNewBrew();
            if (potion == null)
            {
                /// TODO: Restart brewing process
            }
            else
            {
                return potion;
            }

            return null;
        }

        public APotion CheckPotion()
        {
            Recipe compleatedRecipe = null;
            foreach (var recipe in suitableRecipes)
            {
                if (recipe.Ingredients.Count == recipeIterator)
                {
                    compleatedRecipe = recipe;
                    break;
                }
            }

            if (compleatedRecipe != null)
            {
                return compleatedRecipe.Potion;
            }

            return null;
        }

        private void StartNewBrew()
        {
            recipeIterator = 0;
            suitableRecipes.Clear();

            foreach (var recipe in Recipes)
                suitableRecipes.Add(recipe);
        }
    }
}
