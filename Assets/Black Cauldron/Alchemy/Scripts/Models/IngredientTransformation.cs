namespace Ginox.BlackCauldron.Alchemy.Models
{
    public class IngredientTransformation
    {
        public AIngredient InputIngredient { get; private set; }

        public AIngredient OutputIngregient { get; private set; }

        public IngredientTransformation(AIngredient inputIngredient, AIngredient outputIngregient)
        {
            InputIngredient = inputIngredient;
            OutputIngregient = outputIngregient;
        }
    }
}
