using Ginox.BlackCauldron.Alchemy.Models;
using System.Collections.Generic;

namespace Ginox.BlackCauldron.Alchemy.Services
{
    public class MortarService
    {
        public List<IngredientTransformation> Transformations { get; private set; } = new();

        public void RegisterTransformation(IngredientTransformation ingredientTransformation)
        {
            Transformations.Add(ingredientTransformation);
        }

        public AIngredient Transform(AIngredient inputIngreient)
        {
            AIngredient outputIngredient = null;

            foreach (var transformation in Transformations)
            {
                if (transformation.InputIngredient.GetType() == inputIngreient.GetType())
                {
                    outputIngredient = transformation.OutputIngregient;
                    break;
                }
            }

            return outputIngredient;
        }
    }
}
