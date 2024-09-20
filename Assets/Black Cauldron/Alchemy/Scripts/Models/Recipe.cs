using System.Collections.Generic;

namespace Ginox.BlackCauldron.Alchemy.Models
{
    public class Recipe
    {
        public APotion Potion { get; private set; }

        public List<AIngredient> Ingredients { get; private set; } = new();

        public Recipe(APotion potion)
        {
            Potion = potion;
        }

        public Recipe RegisterIngredient(AIngredient aIngredient)
        {
            Ingredients.Add(aIngredient);
            return this;
        }

        public bool Perform(AIngredient ingredient, int index)
            => ingredient.GetType() == Ingredients[index].GetType();
    }
}
