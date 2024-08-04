using UnityEngine;

namespace Ginox.BlackCauldron.Alchemy.Model
{
    public abstract class APotion
    {
        public Material Material { get; private set; }

        public APotion(Material material)
        {
            Material = material;
        }
    }
}
