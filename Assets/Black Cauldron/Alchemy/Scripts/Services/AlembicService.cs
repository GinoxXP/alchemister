using Ginox.BlackCauldron.Alchemy.Models;
using System.Collections.Generic;

namespace Ginox.BlackCauldron.Alchemy.Services
{
    public class AlembicService : IAlembicService
    {
        public List<PotionTransformation> Transformations { get; private set; } = new();

        public void RegisterTransformation(PotionTransformation potionTransformation)
        {
            Transformations.Add(potionTransformation);
        }

        public APotion Transform(APotion inputPotion)
        {
            APotion outputPotion = null;

            foreach (var transformation in Transformations)
            {
                if (transformation.InputPotion.GetType() == inputPotion.GetType())
                {
                    outputPotion = transformation.OutputPotion;
                    break;
                }
            }

            return outputPotion;
        }
    }
}
