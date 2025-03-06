using Ginox.BlackCauldron.Alchemy.Models;
using System.Collections.Generic;

namespace Ginox.BlackCauldron.Alchemy.Services
{
    public interface IMortarService
    {
        /// <summary>
        /// List of mortar transformations.
        /// </summary>
        public List<IngredientTransformation> Transformations { get; }

        /// <summary>
        /// Register transformation.
        /// </summary>
        /// <param name="ingredientTransformation">Transformation</param>
        public void RegisterTransformation(IngredientTransformation ingredientTransformation);

        /// <summary>
        /// Perform transformation.
        /// </summary>
        /// <param name="inputIngreient">Added ingredient</param>
        /// <returns>Performed ingredient</returns>
        public AIngredient Transform(AIngredient inputIngreient);
    }
}
