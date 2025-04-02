using Ginox.BlackCauldron.Alchemy.Views.Ingredients;

namespace Ginox.BlackCauldron.Alchemy.Models.Tools
{
    public class Mortar
    {
        public readonly int PERFORM_MAX_RANDOM_RANGE = 5;

        public bool IsReadyForAddIngredient { get; set; } = true;

        public AIngredientView HangedIngredient { get; set; }

        public AIngredient PerformedIngredient { get; set; }
    }
}
