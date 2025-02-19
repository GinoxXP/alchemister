namespace Ginox.BlackCauldron.Alchemy.Models
{
    public class IngredientTransformation
    {
        public IngredientTransformation(
            AIngredient inputIngredient,
            AIngredient outputIngregient)
        {
            InputIngredient = inputIngredient;
            OutputIngregient = outputIngregient;
        }

        public AIngredient InputIngredient { get; private set; }

        public AIngredient OutputIngregient { get; private set; }
    }
}
