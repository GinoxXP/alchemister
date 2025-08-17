using Ginox.BlackCauldron.Alchemy.Models;
using System.Collections.Generic;

namespace Ginox.BlackCauldron.Alchemy.Services
{
    public interface IAlembicService
    {
        /// <summary>
        /// List of alembic transformations.
        /// </summary>
        public List<PotionTransformation> Transformations { get; }

        /// <summary>
        /// Register transformation.
        /// </summary>
        /// <param name="potionTransformation">Transformation</param>
        public void RegisterTransformation(PotionTransformation potionTransformation);

        /// <summary>
        /// Perform transformation.
        /// </summary>
        /// <param name="inputPotion">Added potion.</param>
        /// <returns>Performed potion.</returns>
        public APotion Transform(APotion inputPotion);
        
        /// <summary>
        /// Get transformation for potion.
        /// </summary>
        /// <param name="inputPotion">Potion.</param>
        /// <returns>Transformation potion.</returns>
        public PotionTransformation GetTransformation(APotion inputPotion);
    }
}
